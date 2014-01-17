using System;
using System.Collections.Generic;

namespace WaveletApplication
{
    [Serializable()]
    public class WaveletSettings
    {
        /// <summary>
        /// Имя вейвлета
        /// </summary>
        public string WaveletName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string WaveletDescription { get; set; }

        //коэфициенты
        public double[] H0 { get; set; }
        public double[] H1 { get; set; }
        public double[] F0 { get; set; }
        public double[] F1 { get; set; }


    }
}