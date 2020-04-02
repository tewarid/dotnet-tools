using System;
using System.Windows.Forms;

namespace Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LauncherApplicationContext context = new LauncherApplicationContext();
            Application.Run(context);
        }
    }

    class LauncherApplicationContext : ApplicationContext
    {
        public LauncherApplicationContext()
        {
            (new MainForm()).Show();
        }
    }
}
