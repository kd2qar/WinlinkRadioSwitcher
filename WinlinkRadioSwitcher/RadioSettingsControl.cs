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

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class codan_filter_width
    {
      public string Label { get; set; }
      public string Value { get; set; }
      public override string ToString()
      {
        return Label; // This will be displayed in the ComboBox
      }
    }

    static public List<codan_filter_width> CodanFilterValues => _fv;
    static readonly List<codan_filter_width> _fv = (new[] { new codan_filter_width { Value = "USB", Label = "2.4 kHz" }, new codan_filter_width { Value = "USBW", Label = "2.8 kHz" }, new codan_filter_width { Value = "USBUW", Label = "3.0 kHz" } }).ToList();

    public Dictionary<string, string> RadioSettingsList
    {

      get { return _radioSettings; }
      internal set
      {

        _radioSettings = value;
        var radioSetting = new RadioSettings(_radioSettings);
        radioSettingsBindingSource.DataSource = radioSetting;
        radioSettingsBindingSource.ResetBindings(false);
        TextBoxRadioModel.Text = value.ContainsKey("Model") ? value["Model"] : string.Empty;
        // Optionally, you can update the UI elements here if needed
        // For example, if you have text boxes or labels bound to the properties of RadioSettings
        TextBoxPTT_Baud.Text = radioSetting.PTT_Baud;
        TextBoxControlBaud.Text = radioSetting.Control_Baud;
        TextBoxAntennaSelection.Text = radioSetting.Antenna_Selection;
        CheckBoxControlDTR.Checked = radioSetting.Control_DTR;
        CheckBoxControlRTS.Checked = radioSetting.Control_RTS;
        TextBoxControlPort.Text = radioSetting.Control_Port;
        CheckBoxUseTTL.Checked = radioSetting.Use_TTL;
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
        TextBoxCodanPassword.Text = radioSetting.Codan_password;
        CheckBoxALE.Checked = radioSetting.Enable_ALE;
        CheckBoxInternalSoundcard.Checked = radioSetting.Internal_soundcard;

        ComboBoxFilterWidth.Items.Clear();
        foreach (var item in CodanFilterValues)
        {
          ComboBoxFilterWidth.Items.Add(item);
        }
        if (radioSetting.Codan_filter_width != null)
        {
          var selectedItem = ComboBoxFilterWidth.Items.Cast<codan_filter_width>()
            .FirstOrDefault(i => i.Value == radioSetting.Codan_filter_width);
          if (selectedItem != null)
          {
            ComboBoxFilterWidth.SelectedItem = selectedItem;
          }
        }
        else
        {
          ComboBoxFilterWidth.SelectedIndex = -1; // No selection
        }

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

    private void CheckBoxCodanLogin_CheckedChanged(object sender, EventArgs e)
    {
      var cb = (CheckBox)sender;
      if (cb is null) return;
      TextBoxCodanPassword.Visible = cb.Checked;
      RadioSettings.Codan_login = cb.Checked;
      _radioSettings["Codan login"] = cb.Checked.ToString();
    }

    private void TextBoxRadioModel_TextChanged(object sender, EventArgs e)
    {
      if (sender is TextBox textBoxRadioModel)
      {
        // enable/disable codan fields
        if (textBoxRadioModel.Text.ToUpper() == "Codan".ToUpper())
          groupBoxCodan.Enabled = true;
        else
          groupBoxCodan.Enabled = false;
        RadioSettings.Model = textBoxRadioModel.Text;
        _radioSettings["Model"] = textBoxRadioModel.Text;

      }
    }

    private void ComboBoxFilterWidth_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (sender is ComboBox comboBoxFilterWidth)
      {
        if (comboBoxFilterWidth.SelectedItem is codan_filter_width selectedFilter)
        {
          RadioSettings.Codan_filter_width = selectedFilter.Value;
          _radioSettings["Codan filter width"] = selectedFilter.Value;
        }
        else
        {
          RadioSettings.Codan_filter_width = string.Empty; // No selection
          _radioSettings["Codan filter width"] = string.Empty; // No selection
        }
      }
    }

    private void TextBoxAntennaSelection_TextChanged(object sender, EventArgs e)
    {
      if (sender is TextBox textBoxAntennaSelection)
      {
        RadioSettings.Antenna_Selection = textBoxAntennaSelection.Text;
        _radioSettings["Antenna Selection"] = textBoxAntennaSelection.Text;
      }
    }

    private void TextBoxIcomAddress_TextChanged(object sender, EventArgs e)
    {
      if (sender is TextBox textBoxIcomAddress)
      {
        RadioSettings.Icom_Address = textBoxIcomAddress.Text;
        _radioSettings["Icom Address"] = textBoxIcomAddress.Text;
      }
    }

    private void RadioButtonUSB_CheckedChanged(object sender, EventArgs e)
    {
      if (sender is RadioButton radioButtonUSB)
      {
        RadioSettings.USB = radioButtonUSB.Checked;
        _radioSettings["USB"] = radioButtonUSB.Checked.ToString();
      }
    }

    private void RadioButtonUSBD_CheckedChanged(object sender, EventArgs e)
    {
      if (sender is RadioButton radioButtonUSBD)
      {
        RadioSettings.USBDigital = radioButtonUSBD.Checked;
        _radioSettings["USBDigital"] = radioButtonUSBD.Checked.ToString();
      }
    }

    private void RadioButtonFM_CheckedChanged(object sender, EventArgs e)
    {
      if (sender is RadioButton fm)
      {
        RadioSettings.FM = fm.Checked;
        _radioSettings["FM"] = fm.Checked.ToString();
      }
    }

    private void CheckBoxInternalTuner_CheckedChanged(object sender, EventArgs e)
    {
      if (sender is CheckBox InternalTuner)
      {
        RadioSettings.Tuner = InternalTuner.Checked;
        _radioSettings["Tuner"] = InternalTuner.Checked.ToString();
      }
    }

    private void CheckBoxInternalSoundcard_CheckedChanged(object sender, EventArgs e)
    {
      if (sender is CheckBox InternalSoundcard)
      {
        RadioSettings.Internal_soundcard = InternalSoundcard.Checked;
        _radioSettings["Internal soundcard"] = InternalSoundcard.Checked.ToString();
      }
    }
    private void TextBoxCodanPassword_TextChanged(object sender, EventArgs e)
    {
      if (sender is TextBox codanPassword)
      {
        RadioSettings.Codan_password = codanPassword.Text;
        _radioSettings["Codan password"] = codanPassword.Text;
      }
    }
    private void CheckBoxALE_CheckedChanged(object sender, EventArgs e)
    {
      if (sender is CheckBox ale)
      {
        RadioSettings.Enable_ALE = ale.Checked;
        _radioSettings["Enable ALE"] = ale.Checked.ToString();
      }
    }
    private void TextBoxControlPort_TextChanged(object sender, EventArgs e)
    {
      if (sender is TextBox controlPort)
      {
        RadioSettings.Control_Port = controlPort.Text;
        _radioSettings["Control Port"] = controlPort.Text;
      }
    }

    private void TextBoxControlBaud_TextChanged(object sender, EventArgs e)
    {
      if (sender is TextBox controlBaud)
      {
        RadioSettings.Control_Baud = controlBaud.Text;
        _radioSettings["Control Baud"] = controlBaud.Text;
      }
    }

    private void CheckBoxControlRTS_CheckedChanged(object sender, EventArgs e)
    {
      if (sender is CheckBox controlRTS)
      {
        RadioSettings.Control_RTS = controlRTS.Checked;
        _radioSettings["Control RTS"] = controlRTS.Checked.ToString();
      }
    }

    private void CheckBoxControlDTR_CheckedChanged(object sender, EventArgs e)
    {
      if (sender is CheckBox controlDTR)
      {
        RadioSettings.Control_DTR = controlDTR.Checked;
        _radioSettings["Control DTR"] = controlDTR.Checked.ToString();
      }
    }

    private void CheckBoxUseTTL_CheckedChanged(object sender, EventArgs e)
    {
      if (sender is CheckBox useTTL)
      {
        RadioSettings.Use_TTL = useTTL.Checked;
        _radioSettings["Use TTL"] = useTTL.Checked.ToString();
      }
    }
    private void TextBoxPTT_Port_TextChanged(object sender, EventArgs e)
    {
      if (sender is TextBox pttPort)
      {
        RadioSettings.PTT_Port = pttPort.Text;
        _radioSettings["PTT Port"] = pttPort.Text;
      }
    }

    private void TextBoxPTT_Baud_TextChanged(object sender, EventArgs e)
    {
      if (sender is TextBox pttBaud)
      {
        RadioSettings.PTT_Baud = pttBaud.Text;
        _radioSettings["PTT Baud"] = pttBaud.Text;
      }
    }

    private void CheckBoxPTT_RTS_CheckedChanged(object sender, EventArgs e)
    {
      if (sender is CheckBox pttRTS)
      {
        RadioSettings.PTT_RTS = pttRTS.Checked;
        _radioSettings["PTT RTS"] = pttRTS.Checked.ToString();
      }
    }

    private void CheckBoxPTT_DTR_CheckedChanged(object sender, EventArgs e)
    {
      if (sender is CheckBox pttDTR)
      {
        RadioSettings.PTT_DTR = pttDTR.Checked;
        _radioSettings["PTT DTR"] = pttDTR.Checked.ToString();
      }
    }
  }

}
