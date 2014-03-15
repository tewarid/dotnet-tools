using HexToBinLib;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UdpTool
{
    public partial class MainForm : Form
    {
        UdpClient udpClient;
        delegate void ShowReceivedDataDelegate(IPEndPoint endPoint, byte[] data);
        Thread receiverThread;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowInterfaceAddresses()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface iface in interfaces)
            {
                UnicastIPAddressInformationCollection addresses = iface.GetIPProperties().UnicastAddresses;
                foreach (UnicastIPAddressInformation address in addresses)
                {
                    if (address.Address.AddressFamily == AddressFamily.InterNetwork)
                        sourceIPAddress.Items.Add(address.Address);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowInterfaceAddresses();
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

            string text;

            if (endOfLineMac.Checked) // MAC - CR
            {
                text = inputText.Text.Replace("\r\n", "\r");
            }
            else if (endOfLineDos.Checked) // DOS - CR/LF
            {
                text = inputText.Text;
            }
            else // Unix - LF
            {
                text = inputText.Text.Replace("\r\n", "\n");
            }

            byte[] data;
            int length;

            if (inputInHex.Checked)
            {
                MemoryStream output = new MemoryStream();
                TextReader input = new StringReader(text);
                length = HexToBin.Convert(input, output);
                data = output.GetBuffer();
            }
            else
            {
                data = ASCIIEncoding.ASCII.GetBytes(text);
                length = data.Length;
            }

            int tickcount = 0;

            if (length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
            }
            else
            {
                try
                {
                    tickcount = Environment.TickCount;
                    udpClient.Send(data, length, endPoint);
                    tickcount = Environment.TickCount - tickcount;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            status.Text = String.Format("Sent {0} bytes in {1} milliseconds", length, tickcount);
            sendButton.Enabled = true;
        }

        private void DataReceiverThread(object obj)
        {
            UdpClient udp = (UdpClient)obj;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                try
                {
                    byte[] data = udp.Receive(ref endPoint);
                    ShowReceivedData(endPoint, data);
                }
                catch (SocketException)
                {
                    break;
                }
            }
        }

        private void ShowReceivedData(IPEndPoint endPoint, byte[] data)
        {
            if (!InvokeRequired)
            {
                destinationIPAddress.Text = endPoint.Address.ToString();
                destinationPort.Text = endPoint.Port.ToString();
                status.Text = string.Format("Received {0} byte(s) from {1}", data.Length, endPoint.ToString());
                if (viewInHex.Checked)
                {
                    foreach (byte b in data)
                    {
                        outputText.AppendText(string.Format("{0:X2} ", b));
                    }
                }
                else
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        // remove special chars
                        if (data[i] == '\r' && data[i == data.Length - 1 ? i : i + 1] == '\n')
                        {
                            i++;
                            continue; // leave DOS CR LF as is
                        }
                        else if (data[i] < (byte)' ' || data[i] > (byte)'~')
                        { 
                            data[i] = (byte)'.';
                        }
                    }

                    outputText.AppendText(ASCIIEncoding.UTF8.GetString(data, 0, data.Length));
                }
            }
            else
            {
                try
                {
                    Invoke(new ShowReceivedDataDelegate(ShowReceivedData), endPoint, data);
                }
                catch (ObjectDisposedException)
                {
                }
            }
        }

        private void CreateUdpClient() {
            IPEndPoint srcEndPoint = new IPEndPoint(IPAddress.Any, 0);

            if (!string.Empty.Equals(sourceIPAddress.Text)
                && !string.Empty.Equals(sourcePort.Text))
            {
                try
                {
                    srcEndPoint = new IPEndPoint(IPAddress.Parse(sourceIPAddress.Text), int.Parse(sourcePort.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                    return;
                }
            }
            else
            {
                sourceIPAddress.Text = "";
                sourcePort.Text = "";
            }

            try
            {
                udpClient = new UdpClient(srcEndPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }

            receiverThread = new Thread(new ParameterizedThreadStart(DataReceiverThread));
            receiverThread.Start(udpClient);

            sourceIPAddress.Enabled = false;
            IPEndPoint endPoint = (IPEndPoint)udpClient.Client.LocalEndPoint;
            sourceIPAddress.Text = endPoint.Address.ToString();
            sourcePort.Enabled = false;
            sourcePort.Text = endPoint.Port.ToString();
            bind.Enabled = false;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputText.Clear();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (receiverThread != null)
            {
                // 
            }
            else
            {
                return;
            }
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
    }
}
