using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace UdpTool
{
    public partial class MainForm : Form
    {
        UdpClient udpClient;
        delegate void ShowReceivedDataDelegate(IPEndPoint endPoint, byte[] data);

        public MainForm()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (udpClient == null)
            {
                CreateUdpClient();
                if (udpClient == null) return;
            }

            IPEndPoint endPoint;
            try
            {
                endPoint = new IPEndPoint(IPAddress.Parse(destinationIPAddress.Text),
                    int.Parse(destinationPort.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                return;
            }

            sendButton.Enabled = false;

            int tickcount = 0;

            byte[] data = input.Bytes;
            if (data.Length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
            }
            else
            {
                try
                {
                    tickcount = Environment.TickCount;
                    udpClient.Send(data, data.Length, endPoint);
                    tickcount = Environment.TickCount - tickcount;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            status.Text = String.Format("Sent {0} bytes in {1} milliseconds",
                data.Length, tickcount);

            sendButton.Enabled = true;
        }

        private void ShowReceivedData(IPEndPoint endPoint, byte[] data)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    ShowReceivedData(endPoint, data);
                });
                return;
            }

            destinationIPAddress.Text = endPoint.Address.ToString();
            destinationPort.Text = endPoint.Port.ToString();

            outputText.AppendText(string.Format("{0} sent {1} bytes(s):\r\n", endPoint.ToString(), data.Length));
            status.Text = string.Format("Received {0} byte(s) from {1}", data.Length, endPoint.ToString());
            outputText.Append(data, data.Length);
            outputText.AppendText(Environment.NewLine);
            outputText.AppendText(Environment.NewLine);
        }

        private void CreateUdpClient() 
        {
            IPAddress address = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 0);

            if(!string.Empty.Equals(sourceIPAddress.Text))
            {
                try
                {
                    address = IPAddress.Parse(sourceIPAddress.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                    return;
                }
            }

            if (!string.Empty.Equals(sourcePort.Text))
            {
                localEndPoint = new IPEndPoint(address, int.Parse(sourcePort.Text));
            }
            else
            {
                localEndPoint = new IPEndPoint(address, 0);
                sourcePort.Text = "";
            }

            try
            {
                udpClient = new UdpClient();
                if (reuseAddress.Checked)
                {
                    // See also, udpClient.ExclusiveAddressUse 
                    // which allows just the port number to be reused
                    udpClient.Client.SetSocketOption(SocketOptionLevel.Socket,
                        SocketOptionName.ReuseAddress, true);
                }
                else
                {
                    udpClient.Client.SetSocketOption(SocketOptionLevel.Socket,
                        SocketOptionName.ReuseAddress, false);
                }
                udpClient.Client.Bind(localEndPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                udpClient = null;
                return;
            }

            udpClient.BeginReceive(ReceiveCallback, null);

            sourceIPAddress.Enabled = false;
            IPEndPoint endPoint = (IPEndPoint)udpClient.Client.LocalEndPoint;
            sourceIPAddress.Text = endPoint.Address.ToString();
            sourcePort.Enabled = false;
            sourcePort.Text = endPoint.Port.ToString();
            bind.Enabled = false;
            reuseAddress.Enabled = false;
            multicastGroupBox.Enabled = true;
            close.Enabled = true;
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            try
            {
                if (udpClient == null) return;
                byte[] data = udpClient.EndReceive(ar, ref endPoint);
                udpClient.BeginReceive(ReceiveCallback, null);
                ShowReceivedData(endPoint, data);
            }
            catch (ObjectDisposedException) { }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (udpClient != null)
            {
                udpClient.Close();
            }
        }

        private void bind_Click(object sender, EventArgs e)
        {
            if (udpClient == null)
            {
                CreateUdpClient();
            }
        }

        private void join_Click(object sender, EventArgs e)
        {
            IPAddress groupIPAddress;
            try
            {
                groupIPAddress = IPAddress.Parse(multicastGroupAddress.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            try
            {
                udpClient.JoinMulticastGroup(groupIPAddress);
                MessageBox.Show("Membership to multicast group has been added.");
            }
            catch(SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            udpClient.Close();
            udpClient = null;
            sourceIPAddress.Enabled = true;
            sourcePort.Enabled = true;
            bind.Enabled = true;
            reuseAddress.Enabled = true;
            multicastGroupBox.Enabled = false;
            close.Enabled = false;
        }
    }
}
