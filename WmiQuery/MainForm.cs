using Common;
using System;
using System.Management;
using System.Windows.Forms;

namespace WmiQuery
{
    [MainForm(Name = "WMI Query Tool")]
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Query_Click(object sender, EventArgs e)
        {
            if (string.Empty.Equals(queryClass.Text.Trim()) || string.Empty.Equals(queryProperty.Text.Trim()))
            {
                MessageBox.Show("Class and property need to be specified.", "Error");
                return;
            }

            ManagementClass mc = new ManagementClass(queryClass.Text);
            ManagementObjectCollection moc = mc.GetInstances();
            string value;
            foreach (ManagementObject mo in moc)
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
