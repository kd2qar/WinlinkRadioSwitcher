using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinlinkRadioSwitcher
{
  [Serializable]
  public class SavedRadio
  {
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public string Ardop { get; set; }=string.Empty; // ARDOP settings
    public string Vara { get; set; } = string.Empty; // VARA settings
    public string VaraFM { get; set; } = string.Empty; // VARA FM settings

    public string VaraTag{get{return "Vara_"+Guid; } }
    public string VaraFMTag { get { return "VaraFM_" + Guid; } }
    public string ArdopTag { get { return "Ardop_" + Guid; } } 
  }
  [Serializable]
  public class SavedRadioList
  {
    public List<SavedRadio> Radios { get; set; } = new List<SavedRadio>();
  }
}
