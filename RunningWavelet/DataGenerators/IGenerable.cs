using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunningWavelet.DataGenerators
{
    interface IGenerable
    {
        double GetValue();
        double SignalAmplitude { get; set; }
        int NoiseAmplitude { get; set; }
        int SignalFrequency { get; set; }
    }
}
