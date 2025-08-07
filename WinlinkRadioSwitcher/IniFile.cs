using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace IniFileTool
{
  public class IniFile
  {
    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
    public static extern long WriteValueA(string strSection,
                                       string strKeyName,
                                       string strValue,
                                       string strFilePath);
    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringW")]
    public static extern long WriteValueW(string strSection,
                                       string strKeyName,
                                       string strValue,
                                       string strFilePath);
    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
    public static extern long ReadValueA(string strSection,
                                      string strKeyName,
                                      string strDefault,
                                      StringBuilder strReturnValue,
                                      int nSize,
                                      string strFilePath);
    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringW")]
    public static extern long ReadValueW(string strSection,
                                      string strKeyName,
                                      string strDefault,
                                      StringBuilder strReturnValue,
                                      int nSize,
                                      string strFilePath);
    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileSection")]
    public static extern long ReadSectionA(string strSection,
                                        byte[] pReturnBuffer,
                                        int nSize,
                                        string strFilePath);
    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileSectionW")]
    public static extern long ReadSectionW(string strSection,
                                        byte[] pReturnBuffer,
                                        int nSize,
                                        string strFilePath);
    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileSectionNames")]
    public static extern long ReadSectionNamesA(byte[] pReturnBuffer,
                                              int nSize,
                                              string strFilePath);
    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileSectionNamesW")]
    public static extern long ReadSectionNamesW(byte[] pReturnBuffer,
                                              int nSize,
                                              string strFilePath);
    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileSection")]
    public static extern long WriteSectionA(string strSection,
                                          string strKeyValuePairs,
                                          string strFilePath);
    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileSectionW")]
    public static extern long WriteSectionW(string strSection,
                                          string strKeyValuePairs,
                                          string strFilePath);

    private string filePath;
    private bool isUnicode;
    public IniFile(string filePath, bool isUnicode = false)
    {
      this.filePath = filePath;
      this.isUnicode = isUnicode;
    }
    public long WriteValue(string section, string key, string value)
    {
      if (isUnicode)
      {
        return WriteValueW(section, key, value, filePath);
      }
      else
      {
        return WriteValueA(section, key, value, filePath);
      }
    }
    public string ReadValue(string section, string key, string defaultValue = "")
    {
      StringBuilder sb = new StringBuilder(1024);
      if (isUnicode)
      {
        ReadValueW(section, key, defaultValue, sb, sb.Capacity, filePath);
      }
      else
      {
        ReadValueA(section, key, defaultValue, sb, sb.Capacity, filePath);
      }
      return sb.ToString();
    }
    public string[] ReadSection(string section)
    {
      byte[] buffer = new byte[1024];
      if (isUnicode)
      {
        ReadSectionW(section, buffer, buffer.Length, filePath);
      }
      else
      {
        ReadSectionA(section, buffer, buffer.Length, filePath);
      }
      return Encoding.UTF8.GetString(buffer).Split(new[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
    }
    public string[] ReadSectionNames()
    {
      byte[] buffer = new byte[1024];
      if (isUnicode)
      {
        ReadSectionNamesW(buffer, buffer.Length, filePath);
      }
      else
      {
        ReadSectionNamesA(buffer, buffer.Length, filePath);
      }
      return Encoding.UTF8.GetString(buffer).Split(new[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
    }
    public Dictionary<string, string> ReadSectionAsDictionary(string section)
    {
      var keyValues = ReadSection(section);
      var dict = new Dictionary<string, string>();
      foreach (var kv in keyValues)
      {
        var parts = kv.Split(new[] { '=' }, 2);
        if (parts.Length == 2)
        {
          dict[parts[0].Trim()] = parts[1].Trim();
        }
      }
      return dict;
    }
    public string ReadSectionAsString(string section)
    {
      StringBuilder sb = new StringBuilder();
      string[] keyValues = ReadSection(section);
      foreach (var kv in keyValues)
      {
        sb.AppendLine(kv);
      }
      return sb.ToString();
    }
    public bool DeleteKey(string section, string key)
    {
      if (isUnicode)
      {
        return WriteValueW(section, key, null, filePath) != 0;
      }
      else
      {
        return WriteValueA(section, key, null, filePath) != 0;
      }
    }
    public bool DeleteSection(string section)
    {
      if (isUnicode)
      {
        return WriteValueW(section, null, null, filePath) != 0;
      }
      else
      {
        return WriteValueA(section, null, null, filePath) != 0;
      }
    }
    public bool KeyExists(string section, string key)
    {
      string value = ReadValue(section, key);
      return !string.IsNullOrEmpty(value);
    }
    public bool SectionExists(string section)
    {
      string[] sections = ReadSectionNames();
      return Array.Exists(sections, s => s.Equals(section, StringComparison.OrdinalIgnoreCase));
    }
    public void SetFilePath(string newFilePath)
    {
      filePath = newFilePath;
    }
    public string GetFilePath()
    {
      return filePath;
    }
    public bool IsUnicode()
    {
      return isUnicode;
    }
    public void SetUnicode(bool unicode)
    {
      isUnicode = unicode;
    }
    public override string ToString()
    {
      return $"IniFile: {filePath}, Unicode: {isUnicode}";
    }
    public static bool FileExists(string filePath)
    {
      return System.IO.File.Exists(filePath);
    }
    public static void CreateFile(string filePath)
    {
      if (!FileExists(filePath))
      {
        using (var fs = System.IO.File.Create(filePath))
        {
          // Create an empty file
        }
      }
    }
    public static void DeleteFile(string filePath)
    {
      if (FileExists(filePath))
      {
        System.IO.File.Delete(filePath);
      }
    }
    public static string[] GetFilesInDirectory(string directoryPath, string searchPattern = "*.*")
    {
      if (System.IO.Directory.Exists(directoryPath))
      {
        return System.IO.Directory.GetFiles(directoryPath, searchPattern);
      }
      return Array.Empty<string>();
    }
    public static string[] GetDirectoriesInDirectory(string directoryPath)
    {
      if (System.IO.Directory.Exists(directoryPath))
      {
        return System.IO.Directory.GetDirectories(directoryPath);
      }
      return Array.Empty<string>();
    }
    public static void CreateDirectory(string directoryPath)
    {
      if (!System.IO.Directory.Exists(directoryPath))
      {
        System.IO.Directory.CreateDirectory(directoryPath);
      }
    }
    public static void DeleteDirectory(string directoryPath, bool recursive = false)
    {
      if (System.IO.Directory.Exists(directoryPath))
      {
        System.IO.Directory.Delete(directoryPath, recursive);
      }
    }
    public static void MoveFile(string sourceFilePath, string destinationFilePath)
    {
      if (FileExists(sourceFilePath))
      {
        System.IO.File.Move(sourceFilePath, destinationFilePath);
      }
    }
    public static void CopyFile(string sourceFilePath, string destinationFilePath, bool overwrite = false)
    {
      if (FileExists(sourceFilePath))
      {
        System.IO.File.Copy(sourceFilePath, destinationFilePath, overwrite);
      }
    }
    public static void MoveDirectory(string sourceDirectoryPath, string destinationDirectoryPath)
    {
      if (System.IO.Directory.Exists(sourceDirectoryPath))
      {
        System.IO.Directory.Move(sourceDirectoryPath, destinationDirectoryPath);
      }
    }
    public static void CopyDirectory(string sourceDirectoryPath, string destinationDirectoryPath, bool overwrite = false)
    {
      if (System.IO.Directory.Exists(sourceDirectoryPath))
      {
        if (!System.IO.Directory.Exists(destinationDirectoryPath))
        {
          System.IO.Directory.CreateDirectory(destinationDirectoryPath);
        }
        foreach (var file in System.IO.Directory.GetFiles(sourceDirectoryPath))
        {
          string destFile = System.IO.Path.Combine(destinationDirectoryPath, System.IO.Path.GetFileName(file));
          System.IO.File.Copy(file, destFile, overwrite);
        }
        foreach (var dir in System.IO.Directory.GetDirectories(sourceDirectoryPath))
        {
          string destDir = System.IO.Path.Combine(destinationDirectoryPath, System.IO.Path.GetFileName(dir));
          CopyDirectory(dir, destDir, overwrite);
        }
      }
    }
    public static void ClearDirectory(string directoryPath)
    {
      if (System.IO.Directory.Exists(directoryPath))
      {
        foreach (var file in System.IO.Directory.GetFiles(directoryPath))
        {
          System.IO.File.Delete(file);
        }
        foreach (var dir in System.IO.Directory.GetDirectories(directoryPath))
        {
          System.IO.Directory.Delete(dir, true);
        }
      }
    }

    public void WriteSection(string section, string key, string value)
    {
      if (isUnicode)
      {
        WriteValueW(section, key, value, filePath);
      }
      else
      {
        WriteValueA(section, key, value, filePath);
      }
    }
    public void WriteSection(string section, string keyValuePairs)
    {
      if (isUnicode)
      {
        WriteSectionW(section, keyValuePairs, filePath);
      }
      else
      {
        WriteSectionA(section, keyValuePairs, filePath);
      }
    }
    public void WriteSection(string section, string[] keyValues)
    {
      StringBuilder sb = new StringBuilder();
      foreach (var kv in keyValues)
      {
        sb.AppendLine(kv);
      }
      if (isUnicode)
      {
        WriteSectionW(section, sb.ToString(), filePath);
      }
      else
      {
        WriteSectionA(section, sb.ToString(), filePath);
      }
    }
    public void WriteSection(string section, Dictionary<string, string> keyValues)
    {
      StringBuilder sb = new StringBuilder();
      foreach (var kvp in keyValues)
      {
        sb.AppendLine($"{kvp.Key}={kvp.Value}");
      }
      if (isUnicode)
      {
        WriteSectionW(section, sb.ToString(), filePath);
      }
      else
      {
        WriteSectionA(section, sb.ToString(), filePath);
      }
    }



  }
}
