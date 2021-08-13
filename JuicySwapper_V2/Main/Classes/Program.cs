using System;
using System.Windows.Forms;
using JuicySwapper_V2.Properties;

namespace JuicySwapper_V2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Settings.Default.DebugAPI = null;
            foreach (var arg in args)
            {
                if (arg.Contains("-Debugpath="))
                {
                    var debugpath = arg.Replace("-Debugpath=", "");

                    MessageBox.Show(debugpath);
                    Settings.Default.DebugAPI = "C:\\Users\\User\\Desktop\\Juicy\\github\\Website\\api\\v1";
                    Settings.Default.Save();
                    
                }
            }
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}
