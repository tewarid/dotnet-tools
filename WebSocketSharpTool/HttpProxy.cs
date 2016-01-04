using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebSocketSharpTool
{
    public partial class HttpProxy : Form
    {
        public DialogResult Result { get; private set; }
        public Uri Proxy { get; set; }

        public HttpProxy()
        {
            InitializeComponent();
            Result = DialogResult.None;
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
