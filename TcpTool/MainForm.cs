using HexToBinLib;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

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

            sendButton.Enabled = false;

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
                length = HexToBin.Convert(input, output);
                data = output.GetBuffer();
            }
            else
            {
                data = UTF8Encoding.UTF8.GetBytes(text);
                length = data.Length;
            }

            int tickcount = 0;
            if (length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
            }
            else
            {
                tickcount = Environment.TickCount;
                tcpClient.GetStream().Write(data, 0, length);
                tickcount = Environment.TickCount - tickcount;
            }

            status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds", length, tickcount);
            sendButton.Enabled = true;
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
                    if (data[i] == '\r' && data[i == length - 1 ? i : i + 1] == '\n')
                    {
                        i++; // maintain DOS end of line
                        continue;
                    }
                    else if (data[i] < (byte)' ' || data[i] > (byte)'~')
                    { 
                        data[i] = (byte)'.';
                    }
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
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
