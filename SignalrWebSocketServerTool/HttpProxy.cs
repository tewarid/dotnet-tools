using System;
using System.Windows.Forms;

namespace WebSocketSharpTool
{
    public partial class HttpProxy : Form
    {
        public DialogResult Result { get; private set; }
        public Uri Proxy { get; set; }

        public HttpProxy(string proxy)
        {
            InitializeComponent();
            Result = DialogResult.None;
            url.Text = proxy == null ? "http://127.0.0.1:8888" : proxy;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Cancel;
            Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            try
            {
                Proxy = new Uri(url.Text);
            }
            catch { }
            Result = DialogResult.OK;
            Close();
        }
    }
}
