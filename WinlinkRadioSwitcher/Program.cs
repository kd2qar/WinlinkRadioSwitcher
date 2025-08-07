using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinlinkRadioSwitcher; // Assuming you have a class for handling INI file
using IniFileTool;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WinlinkRadioSwitcher.Properties;

namespace WinlinkRadioSwitcher
{
  internal static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
#if false
      tests();
      return;
#endif
      Application.Run(new Form1());
    }

    public static void tests()
    {
      var ini1 = new IniFile("c:\\TEMP\\RMS Express.ini");
     var sect = ini1.ReadSection("Ardop");
      Debug.WriteLine("Ardop Section: {sect}"+sect);
      foreach(var item in sect)
      {
        Debug.WriteLine($"Key: {item}, Value: {item}");
      }

      var f = Resources.SavedRadios_ini;
      f = "c:\\TEMP\\SavedRadios.ini";
      var ini2 = new IniFile(f);
      ini2.WriteSection("Ardop", sect);
    }
  }
}
