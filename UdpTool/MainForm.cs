using System;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Globalization;
using System.IO;

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
                if (iface.Supports(NetworkInterfaceComponent.IPv4) && iface.OperationalStatus == OperationalStatus.Up)
                {
                    UnicastIPAddressInformationCollection addresses = iface.GetIPProperties().UnicastAddresses;
                    foreach (UnicastIPAddressInformation address in addresses)
                    {
                        if (address.Address.AddressFamily == AddressFamily.InterNetwork)
                            sourceIPAddress.Items.Add(address.Address);
                    }
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
                length = HexToBin(input, output);
                data = output.GetBuffer();
            }
            else
            {
                data = ASCIIEncoding.ASCII.GetBytes(text);
                length = data.Length;
            }

            if (length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
            }
            else
            {
                udpClient.Send(data, length, endPoint);
            }
        }

        static int HexToBin(TextReader input, Stream output)
        {
            int line = 1;
            int col = 1;
            int colStart = 0;
            int count = 0;
            StringBuilder val = new StringBuilder();
            while (true)
            {
                int ch = input.Read();
                switch (ch)
                {
                    case '\n':
                    case '\r':
                    case ' ':
                    case -1:
                        if (ch == '\n' || ch == '\r')
                        {
                            line++;
                            col = 0;
                        }
                        if (val.Length > 0)
                        {
                            count++;
                            byte result;
                            if (byte.TryParse(val.ToString(), NumberStyles.HexNumber,
                                CultureInfo.InvariantCulture, out result))
                            {
                                output.WriteByte(result);
                            }
                            else
                            {
                                Console.Error.WriteLine("Bad data at line {0} column {1}: {2}",
                                    line, colStart, val);
                                return -1;
                            }
                            val.Clear();
                            colStart = 0;
                        }
                        if (ch == '\r' && input.Peek() == '\n')
                        {
                            // just so we don't count the same line twice for dos/windows
                            input.Read();
                        }
                        break;
                    default:
                        if (colStart == 0)
                        {
                            colStart = col;
                        }
                        if (ch == '0')
                        {
                            // strip off 0x
                            int x = input.Peek();
                            if (x == 'x' || x == 'X')
                            {
                                input.Read();
                                col++;
                                break;
                                // skip
                            }
                        }
                        val.Append((char)ch);
                        break;
                }
                if (ch == -1)
                {
                    break;
                }
                col++;
            }
            return count;
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
                outputText.AppendText(string.Format("{0} said:\r\n", endPoint.ToString()));
                if (viewInHex.Checked)
                {
                    foreach (byte b in data)
                    {
                        outputText.AppendText(string.Format("{0:X2} ", b));
                    }
                    outputText.AppendText("\r\n\r\n");
                }
                else
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        // remove special chars
                        if (data[i] < (byte)' ' || data[i] > (byte)'~') data[i] = (byte)'.';
                    }

                    outputText.AppendText(ASCIIEncoding.UTF8.GetString(data, 0, data.Length));
                    outputText.AppendText("\r\n\r\n");
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
