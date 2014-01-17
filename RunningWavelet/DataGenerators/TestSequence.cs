using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunningWavelet.DataGenerators
{
    internal class TestSequence : IGenerable
    {
        private static int i;
        private readonly double[] sequence = new double[] { 4, 1, 12, 62, 5, 11, 9, 1, 3, 10, 5, 12, 2, 12, 32, 12, 4, 41, 13, 3, 4, 8, 12, 3, 5, 11, 1, 4, 7, 9 };


        public double GetValue()
        {
            var ret = sequence[i];
            i = i < sequence.Length-1 ? i+1 : i;
            return ret;
        }

        public double SignalAmplitude { get; set; }
        public int NoiseAmplitude { get; set; }
        public int SignalFrequency { get; set; }
    }
}
