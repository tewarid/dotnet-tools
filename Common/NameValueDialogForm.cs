using System;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Common
{
    public partial class NameValueDialog : Form
    {
        NameValueCollection collection;

        public NameValueCollection NameValues
        {
            get
            {
                return collection;
            }
        }

        public NameValueDialog()
        {
            InitializeComponent();
            collection = new NameValueCollection();
        }

        public NameValueDialog(string title, 
            NameValueCollection initialValues) : this()
        {
            this.Text = title;
            headers.Add(initialValues);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            headers.RemoveSelected();
        }

        private void Done_Click(object sender, EventArgs e)
        {
            collection = headers.Get();
            this.Hide();
        }
    }
}
