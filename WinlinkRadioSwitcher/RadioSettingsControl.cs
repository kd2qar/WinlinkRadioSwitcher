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
    private void RadioSettingsControl_Load(object sender, EventArgs e)
    {
      // Initialize any additional components or settings if needed
    }

  }
}
