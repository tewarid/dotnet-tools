using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WmiQuery
{
    public partial class WmiQueryForm : Form
    {
        public WmiQueryForm()
        {
            InitializeComponent();
        }

        private void query_Click(object sender, EventArgs e)
        {
            if (string.Empty.Equals(queryClass.Text.Trim()) || string.Empty.Equals(queryProperty.Text.Trim()))
            {
                MessageBox.Show("Class and property need to be specified.", "Error");
                return;
            }
            if (!queryClass.Items.Contains(queryClass.Text))
                queryClass.Items.Add(queryClass.Text);
            if (!queryProperty.Items.Contains(queryProperty.Text))
                queryProperty.Items.Add(queryProperty.Text);

            ManagementClass mc = new System.Management.ManagementClass(queryClass.Text);
            ManagementObjectCollection moc = mc.GetInstances();
            string value = string.Empty;
            foreach (System.Management.ManagementObject mo in moc)
            {
                try
                {
                    value = mo[queryProperty.Text].ToString();
                    log.AppendText(string.Format("{0}.{1}=\"{2}\"{3}", queryClass.Text, queryProperty.Text, value, Environment.NewLine));
                }
                catch
                {
                }
            }
        }
    }
}
