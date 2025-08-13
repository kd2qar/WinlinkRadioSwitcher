using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinlinkRadioSwitcher
{
  internal static class ExtensionMethods
  {
    public static string GetValueOrDefault(this Dictionary<string, string> me, string key, string defaul="")
    {
      if (me == null || !me.ContainsKey(key))
      {
        return defaul;
      }
      return me[key];
    }
  }
}
