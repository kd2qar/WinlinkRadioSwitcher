using IniFileTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinlinkRadioSwitcher.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Schema;

namespace WinlinkRadioSwitcher
{
  public partial class SettingsSaver : UserControl
  {
    public SettingsSaver()
    {
      InitializeComponent();
      listViewSavedRadios.Columns.Add("Name", 200, HorizontalAlignment.Left);
      listViewSavedRadios.Columns.Add("Radio", 200, HorizontalAlignment.Left);

      listViewSavedRadios.View = View.List;
      listViewSavedRadios.BindingContext = new BindingContext();
      listViewSavedRadios.View = View.Details;
      listViewSavedRadios.View = View.Details;
      listViewSavedRadios.HeaderStyle = ColumnHeaderStyle.Nonclickable;

      listViewSavedRadios.Scrollable = true;
      listViewSavedRadios.MultiSelect = false;

      // Initialize any additional components or settings if needed
      //#if DEBUG
      //      textBoxWinlinkIniFile.Text = "c:\\TEMP\\RMS Express.ini"; // Default path for debugging
      //      textBoxSavedRadiosFile.Text = "c:\\TEMP\\SavedRadios.ini"; // Default path for debugging
      //#endif
      if (!DesignMode)
      {
        if (System.IO.File.Exists(textBoxWinlinkIniFile.Text))
        {
          ReadRMSFile();
        }
        if (System.IO.File.Exists(textBoxSavedRadiosFile.Text))
        {
          ReadSavedFile();
        }
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<SavedRadio> Radios
    {
      get
      {
        var radios = new List<SavedRadio>();
        foreach (ListViewItem item in listViewSavedRadios.Items)
        {
          if (item.Tag is SavedRadio radio)
          {
            radios.Add(radio);
          }
        }
        return radios;
      }
      set
      {
        listViewSavedRadios.Items.Clear();
        if (value is null) return;
        foreach (var radio in value)
        {
          var item = new ListViewItem(radio.Name) { Tag = radio };
          var sitem = new ListViewItem.ListViewSubItem(item, radio.ArdopTag);
          item.SubItems.Add(sitem);
          listViewSavedRadios.Items.Add(item);
        }
      }
    }
    private IniFile GetWinlinkIni()
    {
      var filePath = textBoxWinlinkIniFile.Text;
      if (System.IO.File.Exists(filePath))
      {
        return new IniFile(filePath);
      }
      return null;
    }
    private IniFile GetSavedRadioIni()
    {
      var filePath = textBoxSavedRadiosFile.Text;
      if (System.IO.File.Exists(filePath))
      {
        return new IniFile(filePath);
      }
      else
      {
        // Create a new file if it does not exist
        var ini = new IniFile(filePath);
        ini.WriteSection("Radios", string.Empty);
        return ini;
      }
    }

    private void ButtonReadRMSIni_Click(object sender, EventArgs e)
    {
      ReadRMSFile();
      ReadSavedFile();
    }
    public void ReadSavedFile(string filePath = null)
    {

      if (!string.IsNullOrEmpty(filePath))
      {
        textBoxSavedRadiosFile.Text = filePath;
      }
      listViewSavedRadios.Clear();
      listViewSavedRadios.Columns.Add("Name", 200, HorizontalAlignment.Left);
      listViewSavedRadios.Columns.Add("Radio", 200, HorizontalAlignment.Left);
      var filePathToRead = textBoxSavedRadiosFile.Text;
      if (System.IO.File.Exists(filePathToRead))
      {
        var ini = new IniFile(filePathToRead);

        if (ini.SectionExists("Radios"))
        {
          var section = ini.ReadSectionAsDictionary("Radios");
          foreach (var radio in section)
          {
            var model = "";
            var ardopTag = "Ardop_" + radio.Key;
            var varaTag = "Vara_" + radio.Key;
            var varaFMTag = "VaraFM_" + radio.Key;
            var ardopSection = ini.ReadSectionAsDictionary(ardopTag);
            var VaraSection = ini.ReadSectionAsDictionary(varaTag);
            var VaraFMSection = ini.ReadSectionAsDictionary(varaFMTag);
            var somesection = VaraSection ?? ardopSection ?? VaraFMSection;
            if (somesection != null)
            {

              //var radioSettings = ini.ReadSectionAsDictionary(radio.Key);
              var radioSettings = somesection;
              model = radioSettings.GetValueOrDefault("Model", "None");
            }
            var item = new ListViewItem(radio.Value) { Tag = new SavedRadio { Guid = radio.Key, Name = radio.Value } };
            listViewSavedRadios.ContextMenu = new ContextMenu
            {
              MenuItems = {
                new MenuItem("Rename", (s, ev) => {
                  listViewSavedRadios.LabelEdit = true;
                  var vi = listViewSavedRadios.SelectedItems.Count > 0 ? listViewSavedRadios.SelectedItems[0] : null;
                  if (vi == null) return;
                  vi.BeginEdit();
                }),
                new MenuItem("Copy to RMS", (s, ev) => ButtonCopyToRMS_Click(s, ev)),
                new MenuItem("View Settings", (s, ev) => ButtonView_Click(s,ev)),
                new MenuItem("Remove", (s, ev) => ButtonRemove_Click(s, ev)),
                new MenuItem("Add New Radio", (s, ev) => ButtonAdd_Click(s, ev))
              }

            }
              ;
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, model, Color.Red, Color.PowderBlue, null));
            listViewSavedRadios.Items.Add(item);
          }
          listViewSavedRadios.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        else
        {
          MessageBox.Show("Section 'Radios' does not exist in the file.", "Error");
        }
      }
      else
      {
        MessageBox.Show("File does not exist: " + filePathToRead, "Error");
      }

    }
    public string ss() => textBoxSavedRadiosFile.Text;
    //      "This is a test string to demonstrate the code completion functionality. It is not meant to be functional code, but rather a placeholder for testing purposes.";

    public void ReadRMSFile(string rmsFile = null)
    {
      if (!string.IsNullOrEmpty(rmsFile))
      {
        textBoxWinlinkIniFile.Text = rmsFile;
      }

      richTextBox1.Clear();
      var filePath = textBoxWinlinkIniFile.Text;
      if (System.IO.File.Exists(filePath))
      {
        var ini = new IniFile(filePath);

        Action<string> sectionSummary = (sectionName) =>
        {
          if (ini.SectionExists(sectionName))
          {
            richTextBox1.Text += sectionName + " Settings" + Environment.NewLine;
            var values = ini.ReadSectionAsDictionary(sectionName);
            Action<string> forKey = (key) =>
            {
              if (values.ContainsKey(key))
              {
                richTextBox1.Text += key + ": " + values[key] + Environment.NewLine;
              }
            };
            forKey("Model");
            forKey("Control Port");
            forKey("Control Baud");
            forKey("PTT Port");
            forKey("PTT Baud");
            richTextBox1.Text += Environment.NewLine;
          }
        };
        sectionSummary("Ardop");
        sectionSummary("Vara");
        sectionSummary("Vara FM");
      }
    }

    private void ButtonAdd_Click(object sender, EventArgs e)
    {
      listViewSavedRadios.LabelEdit = true;

      // Add a new item to the ListView, with an empty label
      // (you can set any default properties that you want to here)
      var item = listViewSavedRadios.Items.Add(string.Empty);
      item.Tag = new SavedRadio();
      listViewSavedRadios.AfterLabelEdit += ListViewSavedRadios_AfterLabelEdit;

      // Place the newly-added item into edit mode immediately
      item.BeginEdit();
    }

    private void ListViewSavedRadios_AfterLabelEdit(object sender, LabelEditEventArgs e)
    {
      if (e.Label == null || e.Label.Trim() == string.Empty)
      {
        // If the label is empty, cancel the edit
        e.CancelEdit = true;
        return;
      }
      // If the label is valid, update the item's text
      if (e.Item >= 0 && e.Item < listViewSavedRadios.Items.Count)
      {
        var item = listViewSavedRadios.Items[e.Item];
        item.Text = e.Label;
        // Optionally, you can also update the tag or other properties of the item
        if (item.Tag is SavedRadio radio)
        {
          radio.Name = e.Label; // Assuming SavedRadio has a Name property
          var sav = GetSavedRadioIni();
          sav?.WriteValue("Radios", radio.Guid, radio.Name);
        }
      }
    }

    private void ButtonCopyFromRMS_Click(object sender, EventArgs e)
    {
      var ini = GetWinlinkIni();
      var sav = GetSavedRadioIni();
      if (ini == null || sav == null)
      {
        MessageBox.Show("INI files not found. Please check the paths.");
        return;
      }
      if (listViewSavedRadios.SelectedItems.Count == 0)
      {
        MessageBox.Show("Please select a radio from the list.");
        return;
      }
      var selectedItem = listViewSavedRadios.SelectedItems[0];
      var saveTo = selectedItem.Tag as SavedRadio;
      sav.WriteValue("Radios", saveTo.Guid, saveTo.Name);

      var ardopTag = saveTo.ArdopTag;
      var varaTag = saveTo.VaraTag;
      var varaFMTag = saveTo.VaraFMTag;

      if (ini.SectionExists("Ardop"))
      {
        var ardopSection = ini.ReadSectionAsString("Ardop");
        if (!String.IsNullOrEmpty(ardopSection))
        {
          sav.WriteSection(ardopTag, ardopSection);
        }
      }
      if (ini.SectionExists("Vara"))
      {
        var varaSection = ini.ReadSectionAsString("Vara");
        if (!String.IsNullOrEmpty(varaSection))
        {
          sav.WriteSection(varaTag, varaSection);
        }
      }
      if (ini.SectionExists("Vara FM"))
      {
        var varaFMSection = ini.ReadSectionAsString("Vara FM");
        if (!String.IsNullOrEmpty(varaFMSection))
        {
          sav.WriteSection(varaFMTag, varaFMSection);
        }
      }
    }

    private void ButtonCopyToRMS_Click(object sender, EventArgs e)
    {
      var ini = GetWinlinkIni();
      var sav = GetSavedRadioIni();
      if (ini == null || sav == null)
      {
        MessageBox.Show("INI files not found. Please check the paths.");
        return;
      }
      if (listViewSavedRadios.SelectedItems.Count == 0)
      {
        MessageBox.Show("Please select a radio configuration from the list.");
        return;
      }
      var selectedItem = listViewSavedRadios.SelectedItems[0];
      if (!(selectedItem.Tag is SavedRadio saveTo))
      {
        MessageBox.Show("Selected item is not a valid SavedRadio.");
        return;
      }

      // Backup the current RMS INI File
      var date = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
      var backupFilePath = textBoxWinlinkIniFile.Text + "." + date + ".bak";
      if (System.IO.File.Exists(textBoxWinlinkIniFile.Text))
      {
        System.IO.File.Copy(textBoxWinlinkIniFile.Text, backupFilePath, true);
      }

      if (sav.SectionExists(saveTo.ArdopTag))
      {
        var section = sav.ReadSectionAsString(saveTo.ArdopTag);
        if (!String.IsNullOrEmpty(section))
        {
          ini.WriteSection("Ardop", section);
        }
      }
      if (sav.SectionExists(saveTo.VaraTag))
      {
        var section = sav.ReadSectionAsString(saveTo.VaraTag);
        if (!String.IsNullOrEmpty(section))
        {
          ini.WriteSection("Vara", section);
        }
      }
      if (sav.SectionExists(saveTo.VaraFMTag))
      {
        var section = sav.ReadSectionAsString(saveTo.VaraFMTag);
        if (!String.IsNullOrEmpty(section))
        {
          ini.WriteSection("Vara FM", section);
        }
      }
      ReadRMSFile();
      ReadSavedFile();
    }

    private void ButtonRemove_Click(object sender, EventArgs e)
    {
      var sav = GetSavedRadioIni();
      if (sav == null)
      {
        MessageBox.Show("INI files not found. Please check the paths.");
        return;
      }
      if (listViewSavedRadios.SelectedItems.Count == 0)
      {
        MessageBox.Show("Please select a radio from the list.");
        return;
      }
      var selectedItem = listViewSavedRadios.SelectedItems[0];
      var saveTo = selectedItem.Tag as SavedRadio;
      sav.WriteValue("Radios", saveTo.Guid, saveTo.Name);
      sav.DeleteSection(saveTo.ArdopTag);
      sav.DeleteSection(saveTo.VaraTag);
      sav.DeleteSection(saveTo.VaraFMTag);
      sav.DeleteKey("Radios", saveTo.Guid);
      listViewSavedRadios.Items.Remove(selectedItem);
    }

    private void ButtonView_Click(object sender, EventArgs e)
    {
      var sav = GetSavedRadioIni();
      if (sav == null)
      {
        MessageBox.Show("INI files not found. Please check the paths.");
        return;
      }
      if (listViewSavedRadios.SelectedItems.Count == 0)
      {
        MessageBox.Show("Please select a radio from the list.");
        return;
      }
      var selectedItem = listViewSavedRadios.SelectedItems[0];
      var saveTo = selectedItem.Tag as SavedRadio;
      var d = new Dictionary<string, Dictionary<string, string>>();
      if (sav.SectionExists(saveTo.ArdopTag))
      {
        d.Add("Ardop", sav.ReadSectionAsDictionary(saveTo.ArdopTag));
      }
      if (sav.SectionExists(saveTo.VaraTag))
      {
        d.Add("Vara", sav.ReadSectionAsDictionary(saveTo.VaraTag));
      }
      if (sav.SectionExists(saveTo.VaraFMTag))
      {
        d.Add("Vara FM", sav.ReadSectionAsDictionary(saveTo.VaraFMTag));
      }
      if (d.Count == 0)
      {
        MessageBox.Show("No settings found for the selected radio: " + saveTo.Name);
        return;
      }
      var settings = new SettingsForm(d);
      settings.ShowDialog(this);
    }

    private void TextBoxSavedRadiosFile_TextChanged(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(textBoxSavedRadiosFile.Text))
      {
        Settings.Default.SavedRadiosFile = textBoxSavedRadiosFile.Text;
        if (File.Exists(textBoxSavedRadiosFile.Text))
        {
          Settings.Default.Save();
          ReadSavedFile(textBoxSavedRadiosFile.Text);
        }
      }
    }

    private void TextBoxWinlinkIniFile_TextChanged(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(textBoxWinlinkIniFile.Text))
      {
        Settings.Default.RMSIniFile = textBoxWinlinkIniFile.Text;
        if (File.Exists(textBoxWinlinkIniFile.Text))
        {
          var dir = Path.GetDirectoryName(textBoxWinlinkIniFile.Text);
          dir = Path.GetFullPath(dir); // Normalize the path
          if (Directory.Exists(dir))
          {
            // update the path to the save file to match the RMS file (if the path exists)
            var fil = Path.GetFileName(textBoxSavedRadiosFile.Text);
            var ful = Path.Combine(dir, fil);
            textBoxSavedRadiosFile.Text = ful;
          }
          Settings.Default.Save();
          ReadRMSFile(textBoxWinlinkIniFile.Text);
        }
      }
    }
  }
}
