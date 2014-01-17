using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveletApplication;

namespace RunningWavelet
{
    class SignalBuffer
    {

        //Буфер хранения матрицы НЧ коэффициентов разложения
        public double[,] LfBuffer;
        //Буфер хранения матрицы ВЧ коэффициентов разложения
        public double[,] HfBuffer;

        //Размер буфера для хранения коэффициентов (горизонталь)
        public readonly int CoefficientsLength;
        //Размер буфера для хранения кол.уровней коэффициентов (вертикаль)
        public readonly int CoefficientsDepth;

        //Сегмент сигнала и восстановленой копии
        public double[] SignalSegment;
        public double[] RecoveredSegment;
        
        /// <summary>
        /// Получение желаймого ряда из двумерного [2D] массива
        /// </summary>
        /// <param name="arr2D">Двумерный массив из которого нужно вытащить ряд</param>
        /// <param name="rowNumber">Номер запрашиваемого ряда</param>
        /// <returns>Массив  значений [1D]</returns>
        public double[] GetRow(double[,] arr2D, int rowNumber)
        {
            //TODO: подумать о возможности задания offset
            //количество байт занимаемых 1м элементом массива (8 - double)
            int abyte = 8;
            int arr2DLen = arr2D.GetUpperBound(1)+1;
            var oResult = new double[arr2DLen];
            //var len = System.Buffer.ByteLength(LfBuffer);

            System.Buffer.BlockCopy(arr2D, (rowNumber) * abyte * (arr2DLen), oResult, 0, abyte * (arr2DLen));
            return oResult;
        }

        public SignalBuffer(int bufferLength, int decompositionLevel)
        {
            //расчет размера буфера коэффициентов
            CoefficientsDepth = decompositionLevel;
            CoefficientsLength = bufferLength;
            //_lfBufferLength = bufferLength;
            LfBuffer = new double[decompositionLevel,bufferLength];
            //LfBuffer = new double[2,2];
            HfBuffer = new double[decompositionLevel,bufferLength];
            //_signalLengthSegment = bufferLength;
            SignalSegment = new double[bufferLength];
            RecoveredSegment = new double[bufferLength];
            
        }

        public void FitValue2D(double[,] arr2D, double val, int level)
        {
            //double[,] LFBuffer = new double[BufferLength, level]; 
            //сдвигаем элементы текущего уровня вправо
            for (int i = 1; i <= arr2D.GetUpperBound(1); ++i)
            {
                arr2D[level,arr2D.GetUpperBound(1) - i + 1] = arr2D[level,arr2D.GetUpperBound(1) - i];
            }
            //на первое место встает свежее значения
            arr2D[level,0] = val;
            
        }
        public void FitValue1D(double[] arr1D, double val)
        {
            for (int i = 1; i <= arr1D.Length - 1; ++i)
            {
                arr1D[arr1D.Length - i] = arr1D[arr1D.Length - i - 1];
            }
            arr1D[0] = val;

        }

        public void InsertValue(double value, int decompositionLevel, int position)
        {
            LfBuffer[decompositionLevel, position] = value;
        }
    }
}
