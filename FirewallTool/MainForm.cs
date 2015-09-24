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
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                txtAppPath.Text = openFileDialog1.FileName;
                btnGrantAppAuth.Enabled = true;
                btnRemoveAppAuth.Enabled = true;
                txtPort.Enabled = true;
            }
            else if (txtAppPath.Text.Trim().Length == 0)
            {
                btnGrantAppAuth.Enabled = false;
                btnRemoveAppAuth.Enabled = false;
                txtPort.Enabled = false;
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

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            if (txtPort.Text.Trim().Length == 0)
            {
                btnGrantPortAuth.Enabled = false;
                btnRemovePortAuth.Enabled = false;

            }
            else
            {
                btnGrantPortAuth.Enabled = true;
                btnRemovePortAuth.Enabled = true;
                
            }
        }

        private void txtAppPath_TextChanged(object sender, EventArgs e)
        {
            if (txtAppPath.Text.Trim().Length == 0)
            {
                btnGrantAppAuth.Enabled = false;
                btnRemoveAppAuth.Enabled = false;
                txtPort.Enabled = false;
            }
            else
            {
                btnGrantAppAuth.Enabled = true;
                btnRemoveAppAuth.Enabled = true;
                txtPort.Enabled = true;
            }
        }
    }
}
