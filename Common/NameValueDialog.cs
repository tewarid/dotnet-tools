using System;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace WebSocketSharpTool
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
            this.collection.Add(initialValues);
            foreach(string key in this.collection)
            {
                headers.Rows.Add(key, this.collection[key]);
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (headers.SelectedRows.Count > 0 && !headers.SelectedRows[0].IsNewRow)
                headers.Rows.Remove(headers.SelectedRows[0]);
        }

        private void done_Click(object sender, EventArgs e)
        {
            collection = new NameValueCollection();
            foreach (DataGridViewRow row in headers.Rows)
            {
                string name = (string)row.Cells[0].Value;
                string value = (string)row.Cells[1].Value;
                if (!string.IsNullOrWhiteSpace(name))
                    collection.Add(name, value);
            }
            this.Hide();
        }
    }
}
