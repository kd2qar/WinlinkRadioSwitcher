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
  }
}
