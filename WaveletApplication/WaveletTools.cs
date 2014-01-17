/*
powered by TrinitroN
icq: 251-939-070
Copyright 20.06.2011 < ELTECH.ru >
Last Updated: 10.01.2014
*********************************
.........../\_____/\............
...../\.../.|[]|[]|.\.../\......
....|{}|\/.^../^\..^.\/|{}|.....
....|..|..__/..O..\__..|..|.....
....|[]|......___......|[]|.....
....|......./#####\.......|.....
.....\o....|#######|....o/......
......|....|#######|....|.......
......|....@@@@@@@@@....|.......
.....^......^......^......^.....
....|L|....|E|....|T|....|I|....
*********************************
*/
using System;

namespace WaveletApplication
{
    public static class WaveletTools
    {
        public static WaveletSettings WaveletSettings { get; set; }

        //public static void UpdateWaveletSettings(string SelectedWaveletName)
        //{
        //    WaveletSettings.CurrentWatelet = SelectedWaveletName;
        //    //WaveletSettings = new WaveletLoader();
        //}
        public struct WaveletCoef
        {
            public double[] ca { get; set; }
            public double[] cd { get; set; }
            public int[] l { get; set; }

            public WaveletCoef(double[] ca, double[] cd, int[] l)
                : this()
            {
                this.ca = ca;
                this.cd = cd;
                this.l = l;
            }
        }

        /// <summary>
        /// Одноуровневое вейвлет разложение
        /// </summary>
        /// <param name="a">сигнал</param>
        /// <returns></returns>
        public static WaveletCoef DWT(double[] a)
        {
            return new WaveletCoef(
                DownSample(Conv(a, WaveletSettings.H0)),
                DownSample(Conv(a, WaveletSettings.H1)),
                new int[] { a.Length });

        }
        /// <summary>
        /// Многоуровневое вейвлет разложение
        /// </summary>
        /// <param name="coefficients">сигнал записанный в виде коэффициента CA</param>
        /// <param name="decomposeLevel">глубина разложения</param>
        /// <returns></returns>
        public static WaveletCoef WaveDec(WaveletCoef coefficients, int decomposeLevel)
        {
            WaveletCoef coefficients2 = new WaveletCoef();

            //Length Coefficients
            if (coefficients.l != null)
            {
                coefficients2.l = new int[coefficients.l.Length + 1];
                coefficients.l.CopyTo(coefficients2.l, 0);
                coefficients2.l[coefficients.l.Length] = coefficients.ca.Length;
            }
            else
            {
                coefficients2.l = new int[] { coefficients.ca.Length };
            }

            //Approximation coefficients
            coefficients2.ca = DownSample(Conv(coefficients.ca, WaveletSettings.H0));

            //Detalization coefficients
            if (coefficients.cd != null)
            {
                //создаем расширенный масив для дет. коеф. нового уровня декомпозиции.
                coefficients2.cd = new double[coefficients.cd.Length + coefficients2.ca.Length];
                //дублируем существующие дет. коеф. в расширенный массив.
                coefficients.cd.CopyTo(coefficients2.cd, 0);
                //копируем реультат посделней свертки в конец расширеного массива дет. коеф.
                DownSample(Conv(coefficients.ca, WaveletSettings.H1)).CopyTo(coefficients2.cd, coefficients.cd.Length);
            }

            else
            {
                coefficients2.cd = DownSample(Conv(coefficients.ca, WaveletSettings.H1));

            }


            //Recursive part
            if (decomposeLevel == 1)
                return coefficients2;
            else return WaveDec(coefficients2
                , decomposeLevel - 1);

        }

        /// <summary>
        /// Многоуровневое вейвлет восстановление
        /// </summary>
        /// <param name="coefficients"></param>
        /// <returns>Восстановлены сигнал записанный в виде CA коэффициентов</returns>
        public static WaveletCoef WaveRec(WaveletCoef coefficients)
        {
            WaveletCoef coefficients2 = new WaveletCoef();

            //Length Coefficients
            if (coefficients.l.Length > 1)
            {
                coefficients2.l = new int[coefficients.l.Length - 1];
                //копируем весь массив без последнего элемента
                Array.Copy(coefficients.l, 0, coefficients2.l, 0, coefficients.l.Length - 1);
            }

            //Detalization coefficients
            //из списска коэффициентов необходимо выцепить коэф. последнего уровня
            double[] LastCds = new double[coefficients.ca.Length];
            //выбираем дет. коэффициенты последнего уровня 
            Array.Copy(coefficients.cd, (coefficients.cd.Length - coefficients.ca.Length), LastCds, 0, coefficients.ca.Length);
            //выбираем дет. коэффициенты всех оставшихся уровней, кроме последнего
            coefficients2.cd = new double[coefficients.cd.Length - coefficients.ca.Length];
            Array.Copy(coefficients.cd, 0, coefficients2.cd, 0, coefficients.cd.Length - coefficients.ca.Length);

            //Approximation coefficients
            coefficients2.ca = TrimToLength(
                                    VectorAddition(
                                        Conv(UpSample(coefficients.ca), WaveletSettings.F0),
                                        Conv(UpSample(LastCds), WaveletSettings.F1)
                                                  ),
                                        coefficients.l[coefficients.l.Length - 1]
                                           );

            //Recursive part
            if (coefficients2.l == null)
                return coefficients2;
            else return WaveRec(coefficients2);
        }

        //TODO:  Вектороное сложение в С# имеется?
        public static double[] VectorAddition(double[] a, double[] b)
        {
            double[] result = new double[a.Length];
            if (a.Length != b.Length) throw new Exception("Вектора должны быть одинакового размера!");
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = a[i] + b[i];
            }
            return result;

        }

        /// <summary>
        /// Обрезание восстановленого сигнала до исходной длинны 
        /// </summary>
        /// <param name="a">удлиненная копия восстановленного сигнала</param>
        /// <param name="l">истинная длина исходного сигнала</param>
        /// <returns>обрезанная копия восстановленного сигнала истинной длинны</returns>
        public static double[] TrimToLength(double[] a, int l)
        {
            int aLength = a.Length;
            int am = (aLength % 2);
            int bm = (l % 2);
            double[] result = new double[l];
            //TODO: заместо этого цикла можно применить Where(i => i > [нижняя граница]  && i < [верхняя граница] ???
            //if (am == 0 && bm == 0) 
            //{
            for (int i = (aLength - l) / 2; i < (aLength + l) / 2; i++)
            {
                result[i - ((aLength - l) / 2)] = a[i];
            }
            //}
            return result;
        }
        public static double[] iDWT(WaveletCoef coefficients)
        {
            return TrimToLength(
                VectorAddition(
                Conv(UpSample(coefficients.ca), WaveletSettings.F0),
                Conv(UpSample(coefficients.cd), WaveletSettings.F1)),
                coefficients.l[0]);
        }
        /// <summary>
        /// Свертка 2х сигналов (см. учебкик обработки сигналов)
        /// </summary>
        /// <param name="a">первый сигнал</param>
        /// <param name="b">второй сигнал</param>
        /// <returns>результат свертки</returns>
        public static double[] Conv(double[] a, double[] b)
        {
            int aLength = a.Length;
            int bLength = b.Length;
            double[] result = new double[aLength + bLength - 1];
            for (int j = 0; j < bLength; j++)
            {
                for (int i = 0; i < aLength; i++)
                {
                    result[(i) + (bLength - j - 1)] += a[i] * b[bLength - 1 - j];
                }
            }
            return result;
        }
        /// <summary>
        /// Процедура прореживания сигнала в 2 раза 
        /// (четные индексы остаются)
        /// </summary>
        /// <param name="a">исходный сигнал</param>
        /// <returns>прореженная копия</returns>
        public static double[] DownSample(double[] a)
        {
            int aLength = a.Length;
            double[] result = new double[(int)Math.Floor((decimal)aLength / 2)];
            for (int i = 1; i < aLength; i += 2)
            {
                result[(i - 1) / 2] = a[i];
            }
            return result;
        }
        /// <summary>
        /// Процедура увеличения отсчетов сигнала в 2 раза +1
        /// (Заполнение нулями нечетных индексов)
        /// </summary>
        /// <param name="a">исходный сигнал</param>
        /// <returns>удлиненная копия</returns>
        public static double[] UpSample(double[] a)
        {
            int aLength = a.Length;
            double[] result = new double[aLength * 2 + 1];
            result[0] = 0;
            for (int i = 0; i < aLength; i++)
            {
                result[i * 2 + 1] = a[i];
                result[i * 2 + 2] = 0;
            }
            return result;
        }

        /// <summary>
        /// Процедура увеличения отсчетов сигнала в 2 раза для БВП
        /// (Заполнение нулями четных индексов)
        /// </summary>
        /// <param name="a">исходный сигнал</param>
        /// <returns>удлиненная копия</returns>
        public static double[] UpSampleEven(double[] a)
        {
            int aLength = a.Length;
            double[] result = new double[aLength * 2];
            for (int i = 0; i < aLength; i++)
            {
                result[i * 2] = 0;
                result[i * 2 + 1] = a[i];
            }
            return result;
        }
        /// <summary>
        /// Процедура увеличения отсчетов сигнала в 2 раза для БВП
        /// (Заполнение нулями нечетных индексов)
        /// </summary>
        /// <param name="a">исходный сигнал</param>
        /// <returns>удлиненная копия</returns>
        public static double[] UpSampleOdd(double[] a)
        {
            int aLength = a.Length;
            double[] result = new double[aLength * 2];
            for (int i = 0; i < aLength; i++)
            {
                result[i * 2] = a[i];
                result[i * 2 + 1] = 0;
            }
            return result;
        }
        /// <summary>
        /// Функция пороговой обработки
        /// </summary>
        /// <param name="DH">Детализирующие коэф., подлежащие обработки</param>
        /// <param name="prg">Высота порога или пороговое значение</param>
        /// <param name="mode">Тип порога (0-без попрога 1-мягкий 2-твердый)</param>
        /// <returns></returns>
        public static double[] WThresh(double[] cd, double prg, int mode)
        {

            if (mode == 1 || mode == 2)
            {
                for (int j = 0; j < cd.Length; j++)
                {
                    //Console.WriteLine(j);
                    if (Math.Abs(cd[j]) >= prg && mode == 2)
                    {
                        cd[j] = cd[j];
                    }
                    else if (Math.Abs(cd[j]) >= prg && mode == 1)
                    {
                        cd[j] = Math.Sign(cd[j]) * (Math.Abs(cd[j]) - prg);

                    }
                    else
                    {
                        cd[j] = 0;
                    }
                }
            }
            return cd;
        }
        /// <summary>
        /// Укороченый вариант свертки для бегущего ДВП
        /// </summary>
        /// <param name="a">сигнал А</param>
        /// <param name="b">сигнал Б</param>
        /// <returns>значение свертки</returns>
        public static double ShortConv(double[] a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception("Вектора должны быть одинакового размера!");
            double result = new double();

            for (int i = 0; i < a.Length;i++)
            {
                result += a[i]*b[a.Length-1-i];

            }
            return result;
        }
        /// <summary>
        /// Определение максимального уровня декомпозиции для БВП
        /// </summary>
        /// <param name="signalLength">длина сигнала</param>
        /// <param name="waveletLength">длина вейвлета</param>
        /// <returns>макс. уровень</returns>
        public static int? MaxRunningDecompositionLevel(int signalLength, int waveletLength)
        {
            var dl = (int) (Math.Floor((Double) ((signalLength - waveletLength)/2)))+1;
            return (dl<0)?(int?) null:dl;
        }

        /// <summary>
        /// Определяет необходимую длинну сегмента данных ДВПРВ
        /// </summary>
        /// <param name="wLength">длинна вейвлета</param>
        /// <param name="wLevel">глубина декомпозиции</param>
        /// <returns>размер сегмента</returns>
        public static int GetWaveletPhase(int wLength, int wLevel)
        {
            wLength = wLength - 2;
            for (int i = 1; i < wLevel; i++)
            {
                wLength = wLength * 2;
            }
            return wLength;
        }

        /// <summary>
        /// Расчет количесва отсетов, на которое требуется задержать сигнал ДВПРВ, чтобы получть первый
        /// достоверный коэффициент желаймого уровня декомпозиции
        /// </summary>
        /// <param name="wLength">длина вейвлета</param>
        /// <param name="wLevel">глубина декомпозиции</param>
        /// <returns>кол. отсчетов задержки</returns>
        public static int GetPhaseDelay(int wLength, int wLevel)
        {
            if (wLevel < 1) throw new Exception("Уровень разложения строго больше нуля!");
            int swLength = wLength;
            for (int i = 1; i < wLevel; i++)
            {
                wLength = wLength*2 + swLength - 2;
            }
            
            return wLength;

        }
    }
}
