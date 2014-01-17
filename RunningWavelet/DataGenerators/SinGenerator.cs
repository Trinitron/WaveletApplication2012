using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RunningWavelet.DataGenerators
{
    class SinGenerator:IGenerable
    {
        public double SignalAmplitude { get; set; }
        public int NoiseAmplitude { get; set; }
        public int SignalFrequency { get; set; }

        public double GetValue()
        {
            var time = DateTime.Now;
            var rand = new Random();
            double dt = time.Second - 1 + (double)time.Millisecond/1000;
            return SignalAmplitude*Math.Sin(dt*SignalFrequency/6) + rand.Next(NoiseAmplitude*(-1),NoiseAmplitude);
        }
    }
}
