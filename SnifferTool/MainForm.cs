using Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SnifferTool
{
    [MainForm(Name = "Network Sniffer Tool")]
    public partial class MainForm : Form
    {
        private const int MTU = 65535;
        private Socket socket;
        private readonly List<object> protocolTypes = new List<object>
        {
            new { Value = ProtocolType.Icmp, Description = "ICMP" },
            new { Value = ProtocolType.IP, Description = "IP" },
            new { Value = ProtocolType.Udp, Description = "UDP" }
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            protocolType.ValueMember = "Value";
            protocolType.DisplayMember = "Description";
            protocolType.DataSource = protocolTypes;
            protocolType.SelectedValue = ProtocolType.IP;
            interfaceSelector.InterfaceDeleted += InterfaceSelector_InterfaceDeleted;
        }

        private void InterfaceSelector_InterfaceDeleted()
        {
            interfaceSelector.DeleteSelected();
            if (socket != null)
            {
                CloseRawSocket();
                MessageBox.Show(this, "Socket closed.", this.Text);
            }
        }

        private void Bind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(interfaceSelector.TextValue))
            {
                MessageBox.Show("Please select an interface.", this.Text);
                interfaceSelector.Focus();
                return;
            }

            try
            {
                CreateRawSocket(new IPEndPoint(IPAddress.Parse(interfaceSelector.TextValue), 0));
                close.Enabled = true;
                bind.Enabled = false;
                interfaceSelector.Enabled = false;
                protocolType.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private void CreateRawSocket(IPEndPoint endPoint)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, 
                (ProtocolType)protocolType.SelectedValue);
            socket.Bind(endPoint);
            PlatformID p = Environment.OSVersion.Platform;
            if (p == PlatformID.Win32NT && !endPoint.Address.Equals(IPAddress.Any))
            {
                socket.SetSocketOption(SocketOptionLevel.IP, 
                    SocketOptionName.HeaderIncluded, true);

                socket.IOControl(IOControlCode.ReceiveAll, 
                    new byte[] { 1, 0, 0, 0 }, 
                    new byte[] { 0, 0, 0, 0 });
            }
            BeginReceiveFrom();
        }

        private void BeginReceiveFrom()
        {
            byte[] data = new byte[MTU];
            EndPoint remoteEndPoint = new IPEndPoint(0, 0);
            try
            {
                socket.BeginReceiveFrom(data, 0, data.Length, SocketFlags.None,
                    ref remoteEndPoint,
                    delegate (IAsyncResult ar)
                    {
                        ReceiveCallback(ar, remoteEndPoint, data);
                    }, null);
            }
            catch
            {
                // nothing to show/tell the user
            }
        }

        private void ReceiveCallback(IAsyncResult ar, EndPoint remoteEndPoint, byte[] data)
        {
            int length;
            try
            {
                length = socket.EndReceiveFrom(ar, ref remoteEndPoint);
            }
            catch
            {
                return;
            }
            ShowMessage(data, length, remoteEndPoint);
            BeginReceiveFrom();
        }

        private void ShowMessage(byte[] data, int length, EndPoint remoteEndPoint)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    ShowMessage(data, length, remoteEndPoint);
                });
                return;
            }
            string dateTime = string.Format("{0:yyyyMMddTHH:mm:ssZ}", DateTime.UtcNow);
            output.AppendText(string.Format("Received {0} bytes from {1} on {2}:{3}",
                length, remoteEndPoint.ToString(), dateTime, 
                Environment.NewLine));
            output.AppendBinary(data, length);
            output.AppendText(Environment.NewLine);
            output.AppendText(Environment.NewLine);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            CloseRawSocket();
        }

        private void CloseRawSocket()
        {
            if (socket == null)
            {
                return;
            }

            if (InvokeRequired)
            {
                Invoke((Action)delegate
                {
                    CloseRawSocket();
                });
                return;
            }
            socket.Close();
            socket = null;
            bind.Enabled = true;
            close.Enabled = false;
            interfaceSelector.Enabled = true;
            protocolType.Enabled = true;
        }
    }
}
