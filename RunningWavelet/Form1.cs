using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using RunningWavelet.DataGenerators;
using RunningWavelet.WaveletController;
using WaveletApplication;

namespace RunningWavelet
{

    public partial class Form1 : Form, IRunningWaveletView
    {
        private RunningWaveletController _controller;
       
        public Form1()
        {
                   
            InitializeComponent();
            this.Closed += new EventHandler(delegate(object sender, EventArgs e) { _controller.StopGenerator(); });
            this.toolStripSplitButton1.DropDownItems.AddRange(GetWaveletDecompositionNumber);
            
        }

        private IList<string> wBox; 
        public List<string> WBox
        {
            get { return _controller != null ? _controller.wList : new List<string>() { "NO" }; }
            set { wBox = value; }
        }

        //start button
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _controller.StartGenerator();

        }
        //pause button
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _controller.StopGenerator();

        }


        public ToolStripItem[] GetWaveletDecompositionNumber 
        {
            get
            { //return ToolStripMenuItem

                var a = new System.Windows.Forms.ToolStripItem[DecompilationDepth];


                for (var i = 0; i < DecompilationDepth; i++)
                {
                    a[i] = new ToolStripMenuItem()
                        {
                            Name = "Level_" + i,
                            Text = "Уровень " + (i+1)
                            

                        };
                    a[i].Click += new EventHandler((sender, e) => _controller.ChangeChartView(i));
                }
                return a;
            }
        }


        public List<double> Chart2Data
        {
            get { return ucChart2.ChartData; }
            set { ucChart2.ChartData = value; }
        }

        public string UsingWavelet
        {
            get { return this.ucSettingsPannel1.WaveletType; }
            set { this.ucSettingsPannel1.WaveletType = value; }
            //set { throw new NotImplementedException(); }
        }

        public string SignalBufferLength
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int DecompilationDepth
        {
            get { return Convert.ToInt32(this.ucSettingsPannel1.WaveletDepth); }
            set { this.ucSettingsPannel1.WaveletDepth = value; }
        }

        public string StatusString
        {
            get { return this.toolStripStatusLabel1.Text; }
            set { this.toolStripStatusLabel1.Text = value; }
        }
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int ThreadDataSpeed
        {
            get { return ucSettingsPannel1.ThreadDataSpeed; }
            set { ucSettingsPannel1.ThreadDataSpeed = value; }
        }

        public void SetController(RunningWaveletController controller)
        {
            _controller = controller;
            //WBox = _controller.wList;
        }

        public List<double> Chart1Data
        {
            get { return ucChart1.ChartData; }
            set { ucChart1.ChartData = value; }
        }
        //НЕЗАДЕЙСТВОВАНО
        //private void toolStripButton3_Click(object sender, EventArgs e)
        //{
        //    _controller.SomeActions();

        //}

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            _controller.StartGenerator();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            _controller.StopGenerator();
        }

        private void tbWLevel_Enter(object sender, EventArgs e)
        {
            _controller.UpdateWaveletSettings();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //ucSettingsPannel1.Visible = ucSettingsPannel1.Visible != true;
            try
            {
                ucSettingsPannel1.Visible = true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ucSettingsPannel1_Load(object sender, EventArgs e)
        {

        }

        private void asdToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
