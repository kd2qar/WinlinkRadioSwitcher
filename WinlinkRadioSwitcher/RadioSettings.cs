using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace WinlinkRadioSwitcher
{
  internal class RadioSettings :IVaraRadio
  {
    public RadioSettings(Dictionary<string, string> settings)
    {
      foreach (var item in settings)
      {
        switch (item.Key)
        {
          case "PTT Baud":
            PTT_Baud = item.Value;
            break;
          case "Control Baud":
            Control_Baud = item.Value;
            break;
          case "Antenna Selection":
            Antenna_Selection = item.Value;
            break;
          case "Control DTR":
            Control_DTR = bool.Parse(item.Value);
            break;
          case "Control RTS":
            Control_RTS = bool.Parse(item.Value);
            break;
          case "Control Port":
            Control_Port = item.Value;
            break;
          case "Use TTL":
            Use_TTL = bool.Parse(item.Value);
            break;
          case "FM":
            FM = bool.Parse(item.Value);
            break;
          case "USB":
            USB = bool.Parse(item.Value);
            break;
          case "USBDigital":
            USBDigital = bool.Parse(item.Value);
            break;
          case "Icom Address":
            Icom_Address = item.Value;
            break;
          case "Model":
            Model = item.Value;
            break;
          case "PTT Port":
            PTT_Port = item.Value;
            break;
          case "PTT DTR":
            PTT_DTR = bool.Parse(item.Value);
            break;
          case "PTT RTS":
            PTT_RTS = bool.Parse(item.Value);
            break;
          case "Tuner":
            Tuner = bool.Parse(item.Value);
            break;
          case "Codan Login":
          case "Codan login":
            Codan_login = bool.Parse(item.Value);
            break;
          case "Codan Password":
          case "Codan password":
            Codan_password = item.Value;
            break;
          case "Codan filter width":
            Codan_filter_width = item.Value;
            break;
          case "Internal Soundcard":
          case "Internal soundcard":
            Internal_soundcard = bool.Parse(item.Value);
            break;
          case "Enable ALE":
            Enable_ALE = bool.Parse(item.Value);
            break;
          case "Last Session":
            break;
          default:
            // Handle other settings as needed
            break;
        }
      }
    }
    public string Name{get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PTT_Baud { get; set; } = "9600"; // Baud rate for PTT control, default is 9600
    /// <summary>
    /// Control Baud Rate
    /// </summary>
    public string Control_Baud { get; set; } = "9600";
    /// <summary>
    /// Antenna
    /// </summary>
    public string Antenna_Selection { get; set; } = "Default"; // Could be "Auto", "Antenna1", "Antenna2", etc.
    /// <summary>
    /// Control Data Terminal Ready
    /// </summary>
    public bool Control_DTR { get; set; } = false;
    public bool Control_RTS { get; set; } = false;
    public string Control_Port { get; set; } = "None";
    public bool Use_TTL { get; set; }
    public bool FM { get; set; }
    public bool USB { get; set; }
    public bool USBDigital { get; set; }
    public string Icom_Address { get; set; }
    public string Model { get; set; } = string.Empty; // Specific model of the radio, if applicable
    public string PTT_Port { get; set; } = "None";
    public bool PTT_DTR { get; set; } = false;
    public bool PTT_RTS { get; set; } = false;
    public bool Tuner { get; set; } = false;
    public bool Codan_login { get; set; }
    public string Codan_password { get; set; }
    /// <summary>
    /// User Internal Soundcard
    /// </summary>
    public bool Internal_soundcard { get; set; } = false;
    public bool Enable_ALE { get; set; }
    public string Codan_filter_width { get; set; }= "USB"; // Default filter width for Codan radios, can be "USB", "LSB", etc.
  }
}
