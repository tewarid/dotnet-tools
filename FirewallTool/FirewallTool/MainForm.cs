using Connection;
using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirewallTool
{
    public partial class MainForm : Form
    {
        private FirewallHelper firewall;
        public MainForm()
        {
            InitializeComponent();
            firewall = new FirewallHelper();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                txtAppPath.Text = openFileDialog1.FileName;
                
            }
        }

        private void btnGrantAppAuth_Click(object sender, EventArgs e)
        {
            firewall.GrantAuthorization(txtAppPath.Text);
        }

        private void btnRemoveAppAuth_Click(object sender, EventArgs e)
        {
            firewall.RemoveAuthorization(txtAppPath.Text);
        }

        private void btnGrantPortAuth_Click(object sender, EventArgs e)
        {
            NET_FW_IP_PROTOCOL_ ipProtocol;
            if (rbTCP.Checked)
            {
                ipProtocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            }
            else
            {
                ipProtocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
            }

            firewall.GrantPortAuthorization(txtAppPath.Text, txtPort.Text, ipProtocol);
        }

        private void btnRemovePortAuth_Click(object sender, EventArgs e)
        {
            NET_FW_IP_PROTOCOL_ ipProtocol;
            if (rbTCP.Checked)
            {
                ipProtocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            }
            else
            {
                ipProtocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
            }

            firewall.RemovePortAuthorization(txtAppPath.Text, txtPort.Text, ipProtocol);
        }
    }
}
