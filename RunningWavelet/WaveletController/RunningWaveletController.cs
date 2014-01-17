using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using RunningWavelet.DataGenerators;
using RunningWavelet.Extensions;
using WaveletApplication;

namespace RunningWavelet.WaveletController
{
    public class RunningWaveletController
    {
        private TestSequence _generator;
        private SignalBuffer _buffer;
        private IRunningWaveletView _view;
        private Thread t2;
        private RunningProcessor _rwp;
        private WaveletSettings _waveletSettings;
        private double[] _signalData = new double[200];
        public List<string> wList { set; get; } 

        public RunningWaveletController(IRunningWaveletView view)
        {
            this._view = view;
            view.SetController(this);


            //Инициализация настроек для вейвлета
            WaveletSettingsInitialization();

            //создание генератора случ. значений
            _generator = new TestSequence();
            _generator.NoiseAmplitude = 2;
            _generator.SignalAmplitude = 10;
            _generator.SignalFrequency = 6;

            
            
            this._buffer = new SignalBuffer(WaveletApplication.WaveletTools.GetWaveletPhase(_waveletSettings.H0.Length,_view.DecompilationDepth),_view.DecompilationDepth);
            this._rwp = new RunningProcessor(_buffer, _waveletSettings);
        }

        private void WaveletSettingsInitialization()
        {
            var wl = new WaveletLoader();
            wl.LoadWaveletSettings();
            wList = wl.GetWaveletsNames;
            //BUG: GetWaveletsNames[0] может не существовать
            _waveletSettings = wl.GetWaveletByName(String.IsNullOrEmpty(_view.UsingWavelet)?wl.GetWaveletsNames[0]:_view.UsingWavelet);
        }

        public void UpdateWaveletSettings()
        {
            this._buffer = new SignalBuffer(WaveletApplication.WaveletTools.GetWaveletPhase(_waveletSettings.H0.Length, _view.DecompilationDepth), _view.DecompilationDepth);
            this._rwp = new RunningProcessor(_buffer,_waveletSettings);
        }

        public void ChangeChartView(int wLevel)
        {

        }

        public void StartGenerator()
        {
            _view.StatusString = "Преобразование запущено";
            //Thread #1 - GeneratorThread
            if (t2 == null)
            {
                t2 = new Thread(FillValuesThread);
                t2.Name = "GeneratorThread";
                //t2.IsBackground = true;
                t2.Priority = ThreadPriority.Lowest;

            }
            switch (t2.ThreadState)
            {
                case ThreadState.Unstarted:
                    t2.Start();
                    break;
                case ThreadState.Suspended:
                    t2.Resume();
                    break;
            }
        }
        public void StopGenerator()
        {

            if (t2 == null)
                return;
            switch (t2.ThreadState)
            {
                case ThreadState.WaitSleepJoin:
                    t2.Suspend();
                    break;
                case ThreadState.Running:
                    t2.Abort();
                    break;
            }
            _view.StatusString = "Преобразование остановлено";

        }

        public void FillValuesThread()
        {
            while (true)
            {

                double newValue = _generator.GetValue();
                _buffer.FitValue1D(_buffer.SignalSegment,newValue);
                _signalData.FitValue1D(newValue);
                _view.Chart1Data = _signalData.ToList();
                _rwp.ApplyDecFilter(_buffer,_view.DecompilationDepth);
                _rwp.ApplyRecFilter(_buffer, _view.DecompilationDepth);
                _view.Chart2Data = _buffer.GetRow(_buffer.HfBuffer,1).ToList();
                Thread.Sleep(_view.ThreadDataSpeed);
            }
        }

    }
}
