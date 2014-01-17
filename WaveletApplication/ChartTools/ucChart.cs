using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WaveletApplication.ChartTools;

namespace WaveletApplication
{
    public class ChartUpdatedEventArgs : EventArgs
    {
        public double[] ChartData { get; set; }
    }
    public partial class ucChart : UserControl
    {
        private readonly ChartDisplaySettings _chartDisplaySet;
        
        private List<double> _chartData { get; set; }
        public List<double> ChartData
        {
            get { return _chartData; }
            set
            {
                if (value != null)
                {
                    _chartData = value;
                    ChartUpdatedEventArgs args = new ChartUpdatedEventArgs();
                    args.ChartData = ChartData.ToArray();
                    //OnChartDataChanged(args); // raise event
                    this.ThreadSafeUpdate();
                }
            }
        }
        //PropertyNameChanged Pattern
        public event EventHandler<ChartUpdatedEventArgs> ChartDataChanged;
        private void OnChartDataChanged(ChartUpdatedEventArgs e)
        {
            // raise the ChartDataChanged event
            //EventHandler<ChartUpdatedEventArgs> handler = ChartData;
            if (ChartDataChanged != null)
                ChartDataChanged(this, e);
        }


        public ucChart()
        { 
            _chartDisplaySet =  new ChartDisplaySettings();
            ChartData = new List<double>(){};
            InitializeComponent();
            CreateChartControls();
        }

        public ucChart(ChartDisplaySettings cds, List<double> ch)
        {
           _chartDisplaySet = cds;
           ChartData = ch;
        }

        private void CreateChartControls()
        {
            //btnCallSet - кнопка вызова настроек конфигурации графика
            Button btnCallSet = new System.Windows.Forms.Button();
            btnCallSet.Name = "Вызов настроек графика";
            btnCallSet.Size = new System.Drawing.Size(10, 10);
            btnCallSet.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top));
            btnCallSet.Location = new System.Drawing.Point(Width - _chartDisplaySet.BorderPadding - btnCallSet.Width, _chartDisplaySet.BorderPadding);
            btnCallSet.Parent = this;
            btnCallSet.UseVisualStyleBackColor = true;
            btnCallSet.FlatStyle = FlatStyle.Flat;
            btnCallSet.BackgroundImage = WaveletApplication.Properties.Resources.down;
            btnCallSet.Click += new EventHandler(OptionsDialog);

            //

        }

        /// <summary>
        /// Обновление графика
        /// </summary>
        public void UpdateChart()
        {
            if (_chartDisplaySet.ResizeRedraw)
            {
                this.Refresh();
                //this.Update();
            }
        }


        public void ThreadSafeUpdate()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new MethodInvoker(
                    delegate() { this.Refresh(); }));
            }
            else
            {
                //use intval and boolval
            }
        }

        private void OptionsDialog(object sender, EventArgs eventArgs)
        {
            SettingsForm setForm = new SettingsForm(_chartDisplaySet);
            setForm.SettingsFormChangedEvent += (o, args) => UpdateChart();
            setForm.Closed += (o, args) => UpdateChart();
            setForm.Show();


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Форматирование доп. надписей для графика
            StringFormat RGraphInfo = new StringFormat();
            RGraphInfo.Alignment = StringAlignment.Far;
            StringFormat CGraphInfo = new StringFormat();
            CGraphInfo.Alignment = StringAlignment.Center;


            //Рисование рабочего холста
            int BorderPadding = _chartDisplaySet.BorderPadding;
            int TicksLength = _chartDisplaySet.TicksLength;
            Color ChartLineColor = _chartDisplaySet.ChartLineColor;
            float ChartLineWidth = _chartDisplaySet.ChartLineWidth;
            bool ChartSizeArea = _chartDisplaySet.ChartSizeArea;

            e.Graphics.FillRectangle(Brushes.GhostWhite, 0, 0, Width - 1, Height - 1);
            //e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
            e.Graphics.DrawRectangle(Pens.Black, BorderPadding, BorderPadding, Width - 1 - (BorderPadding * 2), Height - 1 - (BorderPadding * 2));

            if (
                ChartData != null && 
                ChartData.Count() > 1 && 
                (Width - BorderPadding * 2) > 2 && 
                (Height - BorderPadding * 2) > 2 &&
                (ChartData.Max()-ChartData.Min())!=0
                )
            {
                //точная длина буфера (на самом деле больше на единицу), помещающаяся на экран
                int ChartDataBufferLength = Width - 1 - (2 * BorderPadding);
                if (ChartDataBufferLength >= ChartData.Count())
                { ChartDataBufferLength = ChartData.Count(); }
                int ChartDataMaxOffset = ChartData.Count() - ChartDataBufferLength;
                //double[] ChartDataBuffer = new double[ChartDataBufferLength];
                //Array.Copy(ChartData, ChartDataBuffer, ChartDataBufferLength);
                double[] ChartDataBuffer = ChartData.ToArray();

                //TODO: возможно требуется находить знаяения (max,min,count) буфера, а не всей выборки
                double MaxDataValue = ChartData.Max();
                if (_chartDisplaySet.YAxisMax != 0)
                    MaxDataValue = _chartDisplaySet.YAxisMax;
                double MinDataValue = ChartData.Min();
                if (_chartDisplaySet.YAxisMin != 0)
                    MinDataValue = _chartDisplaySet.YAxisMin;


                int DataCount = ChartDataBuffer.Count();
                double WidthCoef = (Width - 1 - (2 * BorderPadding)) / (ChartDataBuffer.Length - 1);
                double HeighCoef = (Height - 1 - (2 * BorderPadding)) / (MaxDataValue - MinDataValue);



                //построение графика
                for (int i = 0; i < ChartDataBuffer.Length - 1; i++)
                {
                    e.Graphics.DrawLine(new Pen(ChartLineColor, ChartLineWidth),
                        (float)(WidthCoef * i + (BorderPadding)), (float)((Height - 1 - BorderPadding) - (HeighCoef * (ChartDataBuffer[i] - MinDataValue))),
                        (float)(WidthCoef * (i + 1) + (BorderPadding)), (float)((Height - 1 - BorderPadding) - (HeighCoef * (ChartDataBuffer[i + 1] - MinDataValue))));
                }


                //ПОСТРОЕНИЕ У оси
                int MinLabelIndentY = 15;
                //BUG: неправильно формнируются подписи к осям +/- значения
                if (1 == 1)
                {
                    //прорисовка надписей с минимально возможным MinLabelIndentY = 15;
                    double HeightCoefN = (Height - 1 - (2 * BorderPadding)) / MinLabelIndentY;
                    for (int i = 0; i < HeightCoefN + 1; i++)
                    {

                        //Построение шкалы Y
                        e.Graphics.DrawLine(Pens.Black,
                                            (float)(BorderPadding),
                                            (float)(MinLabelIndentY * i + BorderPadding),
                                            (float)(BorderPadding + TicksLength),
                                            (float)(MinLabelIndentY * i + BorderPadding)
                            );
                        //Подписи по оси Y
                        e.Graphics.DrawString(String.Format("{0:0.0}",/*value*/MaxDataValue - ((/*Math.Round*/(((/*хитрая дельта*/(MaxDataValue - Math.Sign(MinDataValue) * Math.Abs(MinDataValue))/*хитрая дельта*/) / (HeightCoefN)) * (i))) + 0))//.ToString()
                                              , new Font("Arial", 8), Brushes.Gray, new PointF(
                                                                                        (float)(BorderPadding - 14),//-4 для отступа от границы
                                                                                        (float)(MinLabelIndentY * i + BorderPadding - 4)//-4 для центровки
                                                                                        ), CGraphInfo);
                        //Подписи по оси Y (ДЛЯ ПОТОЧЕЧНОГО ВЫВОДА)
                        //e.Graphics.DrawString(
                        //    (-1 * (((MaxDataValue - MinDataValue) / (DataCount - 1) * i) + MinDataValue)).ToString("0.0")
                        //    , new Font("Arial", 8), Brushes.Black, new PointF(
                        //                                               (float)(BorderPadding - 2),/*-2 для отступа от границы*/
                        //                                               (float)
                        //                                               (((MaxDataValue - MinDataValue) / (DataCount - 1) *
                        //                                                 (i * HeighCoef)) + BorderPadding) - 6/*-6 для центровки*/
                        //                                               ), RGraphInfo
                        //    );

                    }
                }
                int MinLabelIndentX = 20;
                if (WidthCoef > MinLabelIndentY)
                {
                    for (int i = 0; i < DataCount; i++)
                    {


                        //Построение шкалы X
                        e.Graphics.DrawLine(Pens.Black,
                                            (float)(WidthCoef * i + BorderPadding),
                                            (float)(Height - 1 - BorderPadding),
                                            (float)(WidthCoef * i + BorderPadding),
                                            (float)(Height - 1 - BorderPadding - TicksLength)
                            );

                        //Подписи по оси X
                        e.Graphics.DrawString((i + 1).ToString()
                                              , new Font("Arial", 8), Brushes.Black, new PointF(
                                                                                         (float)
                                                                                         (WidthCoef * i + BorderPadding + 1),//+1 для центровки подписей
                                                                                         (float)
                                                                                         (Height - 1 - BorderPadding + 2)), //+2 для отступа от границы*/
                                                                                         CGraphInfo
                            );

                    }
                }
                else
                {
                    //прорисовка надписей с минимально возможным MinLabelIndentX = 20;
                    double WidthCoefN = (Width - 1 - (2 * BorderPadding)) / MinLabelIndentX;

                    for (int i = 0; i < WidthCoefN + 1; i++)
                    {
                        //Построение шкалы X
                        e.Graphics.DrawLine(Pens.Black,
                                            (float)(MinLabelIndentX * i + BorderPadding),
                                            (float)(Height - 1 - BorderPadding),
                                            (float)(MinLabelIndentX * i + BorderPadding),
                                            (float)(Height - 1 - BorderPadding - TicksLength)
                            );
                        //Подписи по оси X
                        e.Graphics.DrawString(((Math.Round(((DataCount - 1) / (WidthCoefN)) * (i))) + 1).ToString()
                                              , new Font("Arial", 8), Brushes.Gray, new PointF(
                                                                                         (float)
                                                                                         (MinLabelIndentX * i + BorderPadding + 1),//+1 для центровки подписей
                                                                                         (float)
                                                                                         (Height - 1 - BorderPadding + 2)//+2 для отступа от границы
                                                                                         ), CGraphInfo
                            );


                    }
                }
            }
            else
            {
                e.Graphics.DrawString("No Data!", new Font("Arial", 14), Brushes.Gray, new PointF(Width / 2, Height / 2), CGraphInfo);
            }

            //размер графической области
            if (ChartSizeArea)
                e.Graphics.DrawString((Width - 1) + "*" + (Height - 1), new Font("Arial", 8), Brushes.Gray, new PointF(Width - 1, 0), RGraphInfo);


        }

    }
}
