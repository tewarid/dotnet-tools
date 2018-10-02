using Connection;
using NetFwTypeLib;
using System;
using System.Windows.Forms;

namespace FirewallTool
{
    public partial class MainForm : Form
    {
        private readonly FirewallHelper firewall;
        public MainForm()
        {
            InitializeComponent();
            firewall = new FirewallHelper();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                appPath.Text = openFileDialog.FileName;
                grantAppAuth.Enabled = !firewall.HasAuthorization(openFileDialog.FileName);
                removeAppAuth.Enabled = firewall.HasAuthorization(openFileDialog.FileName);
                port.Enabled = true;
            }
            else if (appPath.Text.Trim().Length == 0)
            {
                grantAppAuth.Enabled = false;
                removeAppAuth.Enabled = false;
                port.Enabled = false;
            }
        }

        private void GrantAppAuth_Click(object sender, EventArgs e)
        {
            firewall.GrantAuthorization(appPath.Text);
            grantAppAuth.Enabled = false;
            removeAppAuth.Enabled = true;
        }

        private void RemoveAppAuth_Click(object sender, EventArgs e)
        {
            firewall.RemoveAuthorization(appPath.Text);
            grantAppAuth.Enabled = true;
            removeAppAuth.Enabled = false;
        }

        private void GrantPortAuth_Click(object sender, EventArgs e)
        {
            NET_FW_IP_PROTOCOL_ ipProtocol;
            if (tcpOption.Checked)
            {
                ipProtocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            }
            else
            {
                ipProtocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
            }

            firewall.GrantPortAuthorization(appPath.Text, port.Text, ipProtocol);
        }

        private void RemovePortAuth_Click(object sender, EventArgs e)
        {
            NET_FW_IP_PROTOCOL_ ipProtocol;
            if (tcpOption.Checked)
            {
                ipProtocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            }
            else
            {
                ipProtocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
            }

            firewall.RemovePortAuthorization(appPath.Text, port.Text, ipProtocol);
        }

        private void Port_TextChanged(object sender, EventArgs e)
        {
            if (port.Text.Trim().Length == 0)
            {
                grantPortAuth.Enabled = false;
                removePortAuth.Enabled = false;

            }
            else
            {
                grantPortAuth.Enabled = true;
                removePortAuth.Enabled = true;                
            }
        }

        private void AppPath_TextChanged(object sender, EventArgs e)
        {
            if (appPath.Text.Trim().Length == 0)
            {
                grantAppAuth.Enabled = false;
                removeAppAuth.Enabled = false;
                port.Enabled = false;
            }
            else
            {
                grantAppAuth.Enabled = true;
                removeAppAuth.Enabled = true;
                port.Enabled = true;
            }
        }
    }
}
