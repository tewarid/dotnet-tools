using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
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
            sourceIPAddress.InterfaceDeleted += SourceIPAddress_InterfaceDeleted;
        }

        private void SourceIPAddress_InterfaceDeleted(string obj)
        {
            // selected interface has ceased to exist
            if (udpClient != null)
            {
                CloseUdpClient();
            }
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            if (udpClient == null)
            {
                CreateUdpClient();
                if (udpClient == null)
                    return;
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

            byte[] data = input.Bytes;
            if (data.Length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
                return;
            }

            int tickcount = Environment.TickCount;
            try
            {
                await udpClient.SendAsync(data, data.Length, endPoint).ConfigureAwait(true);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
                sendButton.Enabled = true;
                return;
            }
            tickcount = Environment.TickCount - tickcount;

            status.Text = String.Format("Sent {0} bytes in {1} milliseconds",
                data.Length, tickcount);

            sendButton.Enabled = true;
        }

        private void ShowReceivedData(IPEndPoint endPoint, byte[] data)
        {
            destinationIPAddress.Text = endPoint.Address.ToString();
            destinationPort.Text = endPoint.Port.ToString();

            outputText.AppendText(string.Format("{0} sent {1} bytes(s):\r\n", endPoint.ToString(), data.Length));
            status.Text = string.Format("Received {0} byte(s) from {1}", data.Length, endPoint.ToString());
            outputText.Append(data, data.Length);
            outputText.AppendText(Environment.NewLine);
            outputText.AppendText(Environment.NewLine);
        }

        private async Task CreateUdpClient() 
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
            catch (SocketException ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                udpClient = null;
                return;
            }

            IPEndPoint endPoint = (IPEndPoint)udpClient.Client.LocalEndPoint;
            sourceIPAddress.Text = endPoint.Address.ToString();
            sourcePort.Text = endPoint.Port.ToString();
            EnableDisable(false);
            await ReceiveAsync().ConfigureAwait(true);
        }

        private void EnableDisable(bool enable)
        {
            sourceIPAddress.Enabled = enable;
            sourcePort.Enabled = enable;
            bind.Enabled = enable;
            reuseAddress.Enabled = enable;
            multicastGroupBox.Enabled = !enable;
            close.Enabled = !enable;
        }

        private async Task ReceiveAsync()
        {
            if (udpClient == null)
                return;

            UdpReceiveResult r;
            while(true)
            {
                try
                {
                    r = await udpClient.ReceiveAsync();
                }
                catch (ObjectDisposedException)
                {
                    EnableDisable(true);
                    break;
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.Message);
                    CloseUdpClient();
                    break;
                }
                ShowReceivedData(r.RemoteEndPoint, r.Buffer);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (udpClient != null)
            {
                udpClient.Close();
            }
        }

        private async void bind_Click(object sender, EventArgs e)
        {
            if (udpClient == null)
            {
                await CreateUdpClient().ConfigureAwait(true);
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

        private void CloseUdpClient()
        {
            if (udpClient != null)
            {
                udpClient.Close();
                udpClient = null;
            }
            EnableDisable(true);
        }

        private void close_Click(object sender, EventArgs e)
        {
            CloseUdpClient();
        }
    }
}
