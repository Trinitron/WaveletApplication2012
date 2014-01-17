using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WaveletApplication.ChartTools
{
    public partial class SettingsForm : Form
    {
        public event SelectedGridItemChangedEventHandler SettingsFormChangedEvent;
        public SettingsForm(ChartDisplaySettings cs)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = cs;

        }
        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            propertyGrid1.SelectedGridItemChanged += SettingsFormChangedEvent;

        }


    }


}
