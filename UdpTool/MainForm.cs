using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UdpTool
{
    public partial class MainForm : Form
    {
        private UdpClient udpClient;

        public MainForm()
        {
            InitializeComponent();
            sourceIPAddress.InterfaceDeleted += SourceIPAddress_InterfaceDeleted;
        }

        private void SourceIPAddress_InterfaceDeleted()
        {
            // selected interface has ceased to exist
            if (udpClient != null)
            {
                CloseUdpClient();
            }
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            if (udpClient == null)
            {
                CreateUdpClient();
                if (udpClient == null)
                {
                    return;
                }
                await SendAsync().ConfigureAwait(true);
                await ReceiveAsync().ConfigureAwait(true);
            }
            else
            {
                await SendAsync().ConfigureAwait(true);
            }
        }

        private async Task SendAsync()
        {
            IPEndPoint endPoint;
            try
            {
                endPoint = new IPEndPoint(
                    IPAddress.Parse(destinationIPAddress.Text),
                    int.Parse(destinationPort.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                return;
            }

            sendButton.Enabled = false;

            byte[] data = input.SelectedBinaryValue;
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

            status.Text = $"Sent {data.Length} bytes in {tickcount} milliseconds";

            sendButton.Enabled = true;
        }

        private void ShowReceivedData(IPEndPoint endPoint, byte[] data)
        {
            destinationIPAddress.Text = endPoint.Address.ToString();
            destinationPort.Text = endPoint.Port.ToString();

            outputText.AppendText($"{endPoint} sent {data.Length} bytes(s) on {DateTime.Now}:{Environment.NewLine}");
            outputText.AppendBinary(data, data.Length);
            outputText.AppendText(Environment.NewLine);
            outputText.AppendText(Environment.NewLine);
        }

        private void CreateUdpClient() 
        {
            IPAddress address = IPAddress.Any;
			IPAddress destination;
            if (!string.IsNullOrWhiteSpace(destinationIPAddress.Text) &&
                IPAddress.TryParse(destinationIPAddress.Text, out destination) &&
                destination.AddressFamily == AddressFamily.InterNetworkV6)
            {
                address = IPAddress.IPv6Any;
            }
            IPEndPoint localEndPoint = new IPEndPoint(address, 0);

            if(!string.Empty.Equals(sourceIPAddress.TextValue))
            {
                try
                {
                    address = IPAddress.Parse(sourceIPAddress.TextValue);
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
                udpClient = new UdpClient(address.AddressFamily);
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
            sourceIPAddress.TextValue = endPoint.Address.ToString();
            sourcePort.Text = endPoint.Port.ToString();
            EnableDisable(false);
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
            {
                return;
            }

            UdpReceiveResult r;
            while(true)
            {
                try
                {
                    r = await udpClient.ReceiveAsync().ConfigureAwait(true);
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
            Properties.Settings.Default.Save();
            if (udpClient != null)
            {
                udpClient.Close();
            }
        }

        private async void Bind_Click(object sender, EventArgs e)
        {
            if (udpClient == null)
            {
                CreateUdpClient();
                if (udpClient == null)
                {
                    return;
                }
                await ReceiveAsync().ConfigureAwait(true);
            }
        }

        private void Join_Click(object sender, EventArgs e)
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

        private void Close_Click(object sender, EventArgs e)
        {
            CloseUdpClient();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            outputText.ScrollToEnd();
            input.ScrollToEnd();
        }
    }
}
