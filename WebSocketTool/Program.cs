using System;
using System.Net;
using System.Net.Security;
using System.Windows.Forms;

namespace WebSocketTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Ignore X.509 certificate errors
            ServicePointManager.ServerCertificateValidationCallback
                += new RemoteCertificateValidationCallback(delegate
                {
                    return true;
                });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
