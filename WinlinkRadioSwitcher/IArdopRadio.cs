using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinlinkRadioSwitcher
{
  internal interface IArdopRadio
  {
    string PTT_Baud { get; set; }
    string Control_Baud { get; set; }
    string Antenna_Selection { get; set; }
    bool Control_DTR { get; set; }
    bool Control_RTS { get; set; }
    string Control_Port { get; set; }
    bool Use_TTL { get; set; }
    bool FM { get; set; }
    bool USB { get; set; }
    bool USBDigital { get; set; }
    string Icom_Address { get; set; }
    string Model { get; set; }
    string PTT_Port { get; set; }
    bool PTT_DTR { get; set; }
    bool PTT_RTS { get; set; }
    bool Tuner { get; set; }
    bool Codan_login { get; set; }
    string Codan_password { get; set; }
    bool Internal_soundcard { get; set; }
    bool Enable_ALE { get; set; }
  }
}
