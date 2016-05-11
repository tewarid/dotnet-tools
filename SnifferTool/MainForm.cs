using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SnifferTool
{
    public partial class MainForm : Form
    {
        private const int MTU = 65535;
        private Socket socket;

        public MainForm()
        {
            InitializeComponent();
        }

        private void bind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(interfaceSelector.Text))
            {
                MessageBox.Show("Please select an interface.", this.Text);
                interfaceSelector.Focus();
                return;
            }

            try
            {
                CreateRawSocket(new IPEndPoint(IPAddress.Parse(interfaceSelector.Text), 0));
                close.Enabled = true;
                bind.Enabled = false;
                interfaceSelector.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private void CreateRawSocket(IPEndPoint endPoint)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
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
            socket.BeginReceiveFrom(data, 0, data.Length, SocketFlags.None,
                ref remoteEndPoint,
                delegate(IAsyncResult ar) 
                {
                    ReceiveCallback(ar, remoteEndPoint, data);
                }, null);
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
            ShowMessage(data, length);
            BeginReceiveFrom();
        }

        private void ShowMessage(byte[] data, int length)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate ()
                {
                    ShowMessage(data, length);
                });
                return;
            }
            output.Append(data, length);
            output.AppendText(Environment.NewLine);
            output.AppendText(Environment.NewLine);
        }

        private void close_Click(object sender, EventArgs e)
        {
            socket.Close();
            bind.Enabled = true;
            close.Enabled = false;
            interfaceSelector.Enabled = true;
        }
    }
}
