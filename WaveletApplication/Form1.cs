using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WaveletApplication.ChartTools;

namespace WaveletApplication
{
    public partial class Form1 : Form
    {
        //исходный сигнал загруженный из файла
        private List<double> dDataSignal = new List<double> { };
        //сигнал подвергшийся вейвлет трансформации
        private WaveletTools.WaveletCoef coefficients = new WaveletTools.WaveletCoef();
        private WaveletLoader waveletLoader;

        public Form1()
        {
            InitializeComponent();
            waveletLoader = new WaveletLoader();
            waveletLoader.LoadWaveletSettings();
            comboBox2.DataSource = waveletLoader.GetWaveletsNames;
            comboBox2.SelectedValueChanged += new EventHandler(comboBox2_SelectedValueChanged);

        }

        void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {

            WaveletTools.WaveletSettings = waveletLoader.GetWaveletByName((string) comboBox2.SelectedItem);
        }

        /// <summary>
        /// Кнопка открытия файла сигнала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.


            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                textBox1.Text = openFileDialog1.FileName;
                try
                {

                    using (StreamReader sr = new StreamReader(File.OpenRead(@file)))
                    {
                        String line = sr.ReadToEnd();
                        dDataSignal = line.Split(';').ToList().ConvertAll<double>(s => Convert.ToDouble(s));


                        scrollBarSync1.DataSource = dDataSignal.ToArray();
                        //scrollBarSync2.DataSource = dDataSignal.ToArray();
                        tbCount1.Text = dDataSignal.Count.ToString();
                        tbMean1.Text = StatisticTools.MeanValue(dDataSignal).ToString();
                        tbVar1.Text = StatisticTools.VarianceValue(dDataSignal).ToString();


                        ucChart1.ChartData = dDataSignal;
                        ucChart1.UpdateChart();
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }
        
        /// <summary>
        /// Произвести вейвлет разложение на 1 уровень
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            double[] signal = dDataSignal.ToArray();
            if (signal.Length > 1)
            {
                coefficients = WaveletTools.WaveDec(new WaveletTools.WaveletCoef(signal, null, null), (int)numericUpDown1.Value);
                ucChart2.ChartData = coefficients.cd.ToList();
                ucChart2.UpdateChart();


            }

        }

        /// <summary>
        /// Произвести вейвлет восстановление на 1 уровень
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

            //double[] signal; //= dDataSignalCopy.ToArray();
            if (coefficients.cd.Length > 1)
            {
                if (radioButton1.Checked)
                {

                    //double[] DH, double prg, int mode
                    coefficients.cd = WaveletTools.WThresh(coefficients.cd, Convert.ToDouble(textBox3.Text), 2);
                }
                else if (radioButton2.Checked)
                {
                    coefficients.cd = WaveletTools.WThresh(coefficients.cd, Convert.ToDouble(textBox3.Text), 1);
                }


                //для одноуровнего разложения
                //signal = WaveletTools.iDWT(coefficients);

                //для многоуровего
                coefficients = WaveletTools.WaveRec(coefficients);

                scrollBarSync2.DataSource = coefficients.ca;
                tbCount2.Text = coefficients.ca.Length.ToString();
                tbMean2.Text = StatisticTools.MeanValue(coefficients.ca.ToList()).ToString();
                tbVar2.Text = StatisticTools.VarianceValue(coefficients.ca.ToList()).ToString();


                ucChart2.ChartData = coefficients.ca.ToList();
                ucChart2.UpdateChart();
            }
        }

        /// <summary>
        /// 2 Синхронизированых ListBox'а
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scrollBarSync1_OnVerticalScroll(object sender, ScrollEventArgs e)
        {

            scrollBarSync2.TopIndex = scrollBarSync1.TopIndex;

        }

        private void scrollBarSync2_OnVerticalScroll(object sender, ScrollEventArgs e)
        {
            scrollBarSync1.TopIndex = scrollBarSync2.TopIndex;

        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Программа обрабатывает текстовые файлы, содержащие значения типа double, записанные в виде:\n\r -30,47;23,704;3,4179;-14,752");
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string About = string.Format(CultureInfo.InvariantCulture, @"Версия программы: {0}.{1}.{2} (r{3})", v.Major, v.Minor, v.Build, v.Revision);
            MessageBox.Show(
                About,
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        }

        /// <summary>
        /// Кнопка переключения между графиками Ca / Cd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (coefficients.l != null)
            {
                //TODO: Жопа
                //if (coefficients.cd[0] == ucChart2.ChartData[0])
                //    ucChart2.ChartData = coefficients.ca;
                //else
                {
                    //TODO: Целесообразно выводить только последний уровень дет. коэффициентов
                    ucChart2.ChartData = coefficients.cd.ToList();
                }
                ucChart2.UpdateChart();
            }

        }

        private void SaveResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //создаем файл для сохранения результатов
            using (TextWriter tw = new StreamWriter("coefficients.csv"))
            {
                //tw.WriteLine("%%Wavelet Results:%%");
                if (coefficients.ca != null)
                {
                    tw.WriteLine("%%Approximation coefficients%%");
                    tw.WriteLine(string.Join(";", coefficients.ca.Select(x => x.ToString()).ToArray()));
                }
                if (coefficients.cd != null)
                {
                    tw.WriteLine("%%Detalization coefficients%%");
                    tw.WriteLine(string.Join(";", coefficients.cd.Select(x => x.ToString()).ToArray()));
                }
                if (coefficients.l != null)
                {
                    tw.WriteLine("%%Length coefficients%%");
                    tw.WriteLine(string.Join(";", coefficients.l.Select(x => x.ToString()).ToArray()));
                }
                tw.Close();

            }
            MessageBox.Show("Результаты выгружены в туже папку, откуда взят исходный сигнал.");

        }



    }
}
