using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunningWavelet.Extensions
{
    public static class ArrayExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] {' ', '.', '?'},
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static double[] FitValue1D(this double[] arr1D, double val)
        {

            for (int i = 1; i <= arr1D.Length - 1; ++i)
            {
                arr1D[arr1D.Length - i] = arr1D[arr1D.Length - i - 1];
            }
            arr1D[0] = val;
            return arr1D;

        }

        public static double[] GetRow(this double[,] arr2D, int rowNumber)
        {
            //TODO: подумать о возможности задания offset
            //количество байт занимаемых 1м элементом массива (8 - double)
            int abyte = 8;
            int arr2DLen = arr2D.GetUpperBound(1) + 1;
            var oResult = new double[arr2DLen];
            //var len = System.Buffer.ByteLength(LfBuffer);

            System.Buffer.BlockCopy(arr2D, (rowNumber)*abyte*(arr2DLen), oResult, 0, abyte*(arr2DLen));
            return oResult;
        }
    }
}
