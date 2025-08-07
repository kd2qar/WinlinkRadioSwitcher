using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinlinkRadioSwitcher
{
  public partial class SettingsForm : Form
  {
    public SettingsForm()
    {
      InitializeComponent();
    }
    Dictionary<string, Dictionary<string, string>> _radioSettings;
    public SettingsForm(Dictionary<string,Dictionary<string, string>> settings)
    {
      InitializeComponent();
      ComboBoxTNC.Items.Clear();
      _radioSettings = settings;
      foreach (var set in _radioSettings)
      {
      var i=  this.ComboBoxTNC.Items.Add(set.Key);
      }
      ComboBoxTNC.SelectedIndexChanged += (s, e) =>
      {
        if (ComboBoxTNC.SelectedIndex >= 0)
        {
          var selectedKey = ComboBoxTNC.SelectedItem.ToString();
          if (_radioSettings.ContainsKey(selectedKey))
          {
            radioSettingsControl1.RadioSettingsList = _radioSettings[selectedKey];
          }
        }
      };
      ComboBoxTNC.SelectedIndex = 0;
      var key1 = _radioSettings.Keys.FirstOrDefault();
      ComboBoxTNC.SelectedItem = key1;
      radioSettingsControl1.RadioSettingsList = _radioSettings[key1];
    }
    private void SettingsForm_Load(object sender, EventArgs e)
    {
      // Load settings or initialize components if needed
      //settingsSaver1.LoadSettings();
    }
  }
}
