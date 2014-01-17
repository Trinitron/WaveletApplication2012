using System.Collections.Generic;
using RunningWavelet.WaveletController;

namespace RunningWavelet
{
    public interface IRunningWaveletView
    {
        //добавлять только свойства и методы касающиеся представления
        void SetController(RunningWaveletController controller);

        List<double> Chart1Data { get; set; }
        List<double> Chart2Data { get; set; }

        string UsingWavelet { get; set; }
        string SignalBufferLength { get; set; }
        int DecompilationDepth { get; set; }
        string StatusString { get; set; }
        int ThreadDataSpeed { get; set; }

    }
}
