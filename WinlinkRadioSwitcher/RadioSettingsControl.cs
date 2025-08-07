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
  public partial class RadioSettingsControl : UserControl
  {
    public RadioSettingsControl()
    {
      InitializeComponent();
    }

    readonly radioSettingsBindingSource radioSettingsBindingSource = new radioSettingsBindingSource();
    internal RadioSettings RadioSettings
    {
      get { return radioSettingsBindingSource.Current as RadioSettings; }
      set { radioSettingsBindingSource.DataSource = value; }
    }

    public Dictionary<string, string> RadioSettingsList
    {
      get { return _radioSettings; }
      internal set
      {
        TextBoxRadioModel.Text = value.ContainsKey("Model") ? value["Model"] : string.Empty;
        
        _radioSettings = value;
          var radioSetting = new RadioSettings(_radioSettings);
        radioSettingsBindingSource.DataSource = radioSetting;
        radioSettingsBindingSource.ResetBindings(false);
        // Optionally, you can update the UI elements here if needed
        // For example, if you have text boxes or labels bound to the properties of RadioSettings
        TextBoxPTT_Baud.Text = radioSetting.PTT_Baud;
        TextBoxControlBaud.Text = radioSetting.Control_Baud;
        TextBoxAntennaSelection.Text = radioSetting.Antenna_Selection;
        CheckBoxControlDTR.Checked = radioSetting.Control_DTR;
        CheckBoxControlRTS.Checked = radioSetting.Control_RTS;
        TextBoxControlPort.Text = radioSetting.Control_Port;
        CheckBoxControlTTL.Checked = radioSetting.Use_TTL;
        RadioButtonFM.Checked = radioSetting.FM;
        RadioButtonUSB.Checked = radioSetting.USB;
        RadioButtonUSBD.Checked = radioSetting.USBDigital;
        TextBoxIcomAddress.Text = radioSetting.Icom_Address;
        TextBoxRadioModel.Text = radioSetting.Model;
        TextBoxPTT_Port.Text = radioSetting.PTT_Port;
        CheckBoxPTT_DTR.Checked = radioSetting.PTT_DTR;
        CheckBoxPTT_RTS.Checked = radioSetting.PTT_RTS;
        CheckBoxInternalTuner.Checked = radioSetting.Tuner;
        CheckBoxCodanLogin.Checked = radioSetting.Codan_login;
        //TextboxCodanPassword = radioSetting.Codan_password;
        CheckBoxInternalSoundcard.Checked = radioSetting.Internal_soundcard;
        ComboBoxFilterWidth.Text = radioSetting.Codan_filter_width;
        //TextBoxPTT_Baud.Enabled = !radioSetting.Use_TTL;
        //TextBoxControlBaud.Enabled = !radioSetting.Use_TTL;
        //TextBoxControlPort.Enabled = !radioSetting.Use_TTL;
        //TextBoxPTT_Port.Enabled = !radioSetting.Use_TTL;
        //TextBoxAntennaSelection.Enabled = !radioSetting.Use_TTL;
        //TextBoxIcomAddress.Enabled = !radioSetting.Use_TTL;
        //TextBoxRadioModel.Enabled = !radioSetting.Use_TTL;
        //RadioButtonFM.Enabled = !radioSetting.Use_TTL;
        //RadioButtonUSB.Enabled = !radioSetting.Use_TTL;
        //RadioButtonUSBD.Enabled = !radioSetting.Use_TTL;
        //CheckBoxPTT_DTR.Enabled = !radioSetting.Use_TTL;
        //CheckBoxPTT_RTS.Enabled = !radioSetting.Use_TTL;
        //CheckBoxControlDTR.Enabled = !radioSetting.Use_TTL;
        //CheckBoxControlRTS.Enabled = !radioSetting.Use_TTL;
        //CheckBoxInternalTuner.Enabled = !radioSetting.Use_TTL;
      }
    }
    Dictionary<string, string> _radioSettings;

    private void RadioSettingsControl_Load(object sender, EventArgs e)
    {
      // Initialize any additional components or settings if needed
    }

  }
}
