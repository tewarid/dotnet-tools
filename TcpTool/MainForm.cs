using System;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Globalization;
using System.IO;

namespace TcpTool
{
    public partial class MainForm : Form
    {
        TcpClient tcpClient;
        delegate void ShowReceivedDataDelegate(byte[] data, int length);
        TcpListener listener;
        byte[] buffer = new byte[100];

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
            if (listener != null && tcpClient == null)
            {
                MessageBox.Show("Listening for incoming TCP connection. Try again after a client has connected.");
                return;
            }


            if (tcpClient == null || !tcpClient.Connected)
            {
                CreateTcpClient();
                if (tcpClient == null || !tcpClient.Connected) return;
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
                tcpClient.GetStream().Write(data, 0, length);
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
            TcpClient tcpClient = (TcpClient)obj;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                try
                {
                    byte[] data = new byte[100];
                    int length = tcpClient.GetStream().Read(data, 0, 100);
                    ShowReceivedData(data, length);
                }
                catch
                {
                    break;
                }
            }
        }

        private void ShowReceivedData(byte [] data, int length)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate {
                    ShowReceivedData(data, length);
                });
                return;
            }

            if (viewInHex.Checked)
            {
                for (int i = 0; i < length; i++)
                {
                    outputText.AppendText(string.Format("{0:X2} ", data[i]));
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    // remove special chars
                    if (data[i] < (byte)' ' || data[i] > (byte)'~') data[i] = (byte)'.';
                }

                outputText.AppendText(ASCIIEncoding.UTF8.GetString(data, 0, length));
            }
    }

        private void CreateTcpClient() {
            if (tcpClient != null && tcpClient.Connected) return;

            try
            {
                IPEndPoint localEndPoint;
                if (!string.Empty.Equals(sourceIPAddress.Text)
                    && !string.Empty.Equals(sourcePort.Text))
                {
                    localEndPoint = new IPEndPoint(IPAddress.Parse(sourceIPAddress.Text),
                        int.Parse(sourcePort.Text));
                }
                else
                {
                    localEndPoint = new IPEndPoint(IPAddress.Any, 0);
                }
                if (tcpClient == null)
                {
                    tcpClient = new TcpClient(localEndPoint);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, this.Text);
                return;
            }

            try
            {
                if (string.Empty.Equals(destinationIPAddress.Text)
                    || string.Empty.Equals(destinationPort.Text))
                {
                    MessageBox.Show(this, "Please specify the destination IP address and/or port.", this.Text);
                    return;
                }

                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(destinationIPAddress.Text),
                    int.Parse(destinationPort.Text));
                tcpClient.Connect(remoteEndPoint);
                tcpClient.GetStream().BeginRead(buffer, 0, buffer.Length, ReadCallback, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, this.Text);
                return;
            }

            sourceIPAddress.Enabled = false;
            IPEndPoint endPoint = (IPEndPoint)tcpClient.Client.LocalEndPoint;
            sourceIPAddress.Text = endPoint.Address.ToString();
            sourcePort.Enabled = false;
            sourcePort.Text = endPoint.Port.ToString();
            destinationIPAddress.Enabled = false;
            destinationPort.Enabled = false;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputText.Clear();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }

        private void listen_Click(object sender, EventArgs e)
        {
            CreateTcpListener();
        }

        private void CreateTcpListener()
        {
            if (listener != null) return;

            try
            {
                IPEndPoint localEndPoint;
                int port = 0;
                if(!string.Empty.Equals(sourcePort.Text))
                {
                    port = int.Parse(sourcePort.Text);
                }
                if (!string.Empty.Equals(sourceIPAddress.Text))
                {
                    localEndPoint = new IPEndPoint(IPAddress.Parse(sourceIPAddress.Text),
                        port);
                }
                else
                {
                    localEndPoint = new IPEndPoint(IPAddress.Any, port);
                }
                if (listener == null)
                {
                    listener = new TcpListener(localEndPoint);
                }
                listener.Start();
                listener.BeginAcceptTcpClient(BeginAcceptCallback, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, this.Text);
                return;
            }

            IPEndPoint ipEndPoint = (IPEndPoint)listener.LocalEndpoint;
            sourceIPAddress.Text = ipEndPoint.Address.ToString();
            sourcePort.Text = ipEndPoint.Port.ToString();

            listen.Enabled = false;
            sourceIPAddress.Enabled = false;
            sourcePort.Enabled = false;
            destinationIPAddress.Enabled = false;
            destinationPort.Enabled = false;
        }

        private void BeginAcceptCallback(IAsyncResult ar)
        {
            if (InvokeRequired) 
            {
                Invoke((MethodInvoker)delegate {
                    BeginAcceptCallback(ar);
                });
                return;
            }

            tcpClient = listener.EndAcceptTcpClient(ar);

            tcpClient.GetStream().BeginRead(buffer, 0, buffer.Length, ReadCallback, null);

            IPEndPoint ipEndPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
            destinationIPAddress.Text = ipEndPoint.Address.ToString();
            destinationPort.Text = ipEndPoint.Port.ToString();
        }

        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                int length = tcpClient.GetStream().EndRead(ar);
                ShowReceivedData(buffer, length);
                tcpClient.GetStream().BeginRead(buffer, 0, buffer.Length, ReadCallback, null);
            }
            catch (ObjectDisposedException)
            { }
        }
    }
}
