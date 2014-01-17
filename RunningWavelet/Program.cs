using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RunningWavelet.WaveletController;
using WaveletApplication;

namespace RunningWavelet
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //http://www.codeproject.com/Articles/383153/The-Model-View-Controller-MVC-Pattern-with-Csharp
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            //UsersView view = new UsersView();
            Form1 view = new Form1();
            view.Visible = false;
            RunningWaveletController controller = new RunningWaveletController(view);
            view.ShowDialog();

        }
    }
}
