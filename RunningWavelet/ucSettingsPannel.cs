using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RunningWavelet
{
    public partial class ucSettingsPannel : UserControl
    {
        public ucSettingsPannel()
        {
            InitializeComponent();
        }

        public string WaveletType
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }

        public int WaveletDepth
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }

        public int ThreadDataSpeed
        {
            get { return Convert.ToInt32(textBox4.Text); }
            set { textBox4.Text = value.ToString(); }
        }

        private IList<string> wavletetListComboBox;
        public IList<string> WavletetListComboBox
        {
            get { return wavletetListComboBox; //new List<string>() { "Добеши 6" };
            }
            set { wavletetListComboBox = value; }
        }


    }
}
