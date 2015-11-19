using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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
                += new System.Net.Security.RemoteCertificateValidationCallback
                (delegate (object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
                {
                    return true;
                });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
