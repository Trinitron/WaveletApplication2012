using System;
using System.Collections.Generic;
using System.Linq;
using RunningWavelet.Extensions;
using WaveletApplication;

namespace RunningWavelet
{
    class RunningProcessor
    {
        private SignalBuffer _buffer;
        private readonly WaveletSettings _wSettings;
        private readonly int _wPhase;
        private static int _wiPhase;


        public RunningProcessor(SignalBuffer buffer, WaveletSettings waveletSettings)
        {
            _buffer = buffer;
            _wSettings = waveletSettings;
            int wLength = waveletSettings.H0.Length;
            _wPhase = WaveletTools.GetWaveletPhase(wLength, buffer.CoefficientsDepth);

            //Начальная задержка фазы для заполнения буфера стартовыми данными для 
            //старта безошибочного преобразования
            int _wDelay = WaveletTools.GetPhaseDelay(wLength, buffer.CoefficientsDepth);
            int _wPower = (int)Math.Pow(2, buffer.CoefficientsDepth);
            _wiPhase = (_wDelay % _wPower) == 0 ? 1 : (_wPower - (_wDelay % _wPower) + 1);
        }

        /// <summary>
        /// Фильтр многоуровневой декомпозиции для буфера с учетом фазы декомпозиции
        /// </summary>
        /// <param name="wDataBuffer">буфер данных вейвлета</param>
        public void ApplyDecFilter(SignalBuffer wDataBuffer, int wLevel)
        {

            var val0 = new double();
            var val1 = new double();
            //int lSignal = wDataBuffer.SBuffer.Length;
            int lWavelet = _wSettings.H0.Length;
            int insertLevel = 0; //в нулевой ряд массива записываються коэф. разложения 1го уровня

            if (_wiPhase >= 0)
            {

                for (int i = _wiPhase; i >= 2 && _wiPhase % 2 == 0 && insertLevel <= wLevel; i = i / 2, insertLevel++)
                {
                    //разложение первого уровня производиться над сигналом,
                    //хранящимся в отдельной переменной, а не в 2х массиве коэф.
                    if (insertLevel == 0 /*&& _wiPhase==2*/)
                    {
                        val0 = WaveletTools.ShortConv(wDataBuffer.SignalSegment.ToList().GetRange(0, lWavelet).ToArray(),
                                                      _wSettings.H0);
                        wDataBuffer.FitValue2D(wDataBuffer.LfBuffer, val0, insertLevel);
                        val1 = WaveletTools.ShortConv(wDataBuffer.SignalSegment.ToList().GetRange(0, lWavelet).ToArray(),
                                                      _wSettings.H1);
                        wDataBuffer.FitValue2D(wDataBuffer.HfBuffer, val1, insertLevel);

                    }
                    else
                    {
                        val0 =
                            WaveletTools.ShortConv(
                                wDataBuffer.GetRow(wDataBuffer.LfBuffer, insertLevel - 1)
                                           .ToList()
                                           .GetRange(0, lWavelet)
                                           .ToArray(), _wSettings.H0);
                        wDataBuffer.FitValue2D(wDataBuffer.LfBuffer, val0, insertLevel);
                        val1 =
                            WaveletTools.ShortConv(
                                wDataBuffer.GetRow(wDataBuffer.LfBuffer, insertLevel - 1)
                                           .ToList()
                                           .GetRange(0, lWavelet)
                                           .ToArray(), _wSettings.H1);
                        wDataBuffer.FitValue2D(wDataBuffer.HfBuffer, val1, insertLevel);
                    }

                }
                //_wiPhase = (_wiPhase >= _wPhase) ? 1 : ++_wiPhase;
            }

            ////Цикл для рекурсивного расчета детализирующих коэф.
            ////только для фазы кратной двум (нечетные коэффициенты всегда откидываються)
            //for (int i = _wiPhase; i >= 2 && _wiPhase % 2 == 0 && insertLevel<=wLevel; i = i / 2, insertLevel++)
            //{
            //    wDataBuffer.FitValueLf(WaveletTools.ShortConv(wDataBuffer.GetRow(insertLevel-1).ToList().GetRange(0,lWavelet).ToArray(),
            //        waveletSettings.CurrentWavelet.H1), insertLevel);
            //}
            ////Расчет только апп. коэфф. только последнего уровня
            //if(_wiPhase%Math.Pow(2,wLevel)==0)
            //{
            //    wDataBuffer.FitValueHf(WaveletTools.ShortConv(wDataBuffer.GetRow(wLevel - 1).ToList().GetRange(0, lWavelet).ToArray(),
            //        waveletSettings.CurrentWavelet.H0));
            //}


            //}
            _wiPhase = (_wiPhase >= _wPhase) ? 1 : ++_wiPhase;
        }
        public void ApplyRecFilter(SignalBuffer wDataBuffer, int wLevel)
        {

            //int lSignal = wDataBuffer.SBuffer.Length;
            int lWavelet = _wSettings.H0.Length;
            int insertLevel = 0;
            double[] arr = new double[60];



            //т.к. мы храним апп. коеф. только последнего уровня,
            // то и восстанавливаем с частотой появления этих коеф.
            if (_wiPhase % Math.Pow(2, wLevel) == 0)
            {
                //for (int i = _wiPhase; i >= 2; i /= 2) //?????


                for (int i = wLevel-1; i > 0; i--)
                {



                    //var apr = 
                    //для добеши 4 отсчета - восстановлены 4 и 3 индексы соответствено

                    var el1 =

                        WaveletTools.ShortConv(
                             WaveletTools.UpSampleEven(
                                wDataBuffer.LfBuffer.GetRow(i).ToList().GetRange(0, lWavelet / 2).ToArray()),
                             _wSettings.F0)
                        +
                        WaveletTools.ShortConv(
                             WaveletTools.UpSampleEven(
                                wDataBuffer.HfBuffer.GetRow(i).ToList().GetRange(0, lWavelet / 2).ToArray()),
                             _wSettings.F1);

                    var el2 =

                        WaveletTools.ShortConv(
                             WaveletTools.UpSampleOdd(
                                wDataBuffer.LfBuffer.GetRow(i).ToList().GetRange(0, lWavelet / 2).ToArray()),
                             _wSettings.F0)
                        +
                        WaveletTools.ShortConv(
                             WaveletTools.UpSampleOdd(
                                wDataBuffer.HfBuffer.GetRow(i).ToList().GetRange(0, lWavelet / 2).ToArray()),
                             _wSettings.F1);

                    if (insertLevel > 1)
                    {
                        _buffer.RecoveredSegment.FitValue1D(el2);
                        _buffer.RecoveredSegment.FitValue1D(el1);

                    }


                    //заменяем коэффициенты более высокого уровня восстановлеными коэф. более низкого уровня
                    //wDataBuffer.InsertValue(el1, wLevel - 1, lWavelet - 2);
                    //wDataBuffer.InsertValue(el2, wLevel - 1, lWavelet - 1);

                }
            }

        }
    }
}
