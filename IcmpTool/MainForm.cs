using System;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Globalization;
using System.IO;

namespace IcmpTool
{
    public partial class MainForm : Form
    {
        IcmpSocket icmpSocket;
        delegate void ShowReceivedDataDelegate(IPEndPoint endPoint, byte[] data, int length);

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
            IPEndPoint endPoint;

            try
            {
                endPoint = new IPEndPoint(IPAddress.Parse(destinationIPAddress.Text),
                    0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                return;
            }

            byte[] data;
            int length;

            MemoryStream output = new MemoryStream();
            TextReader input = new StringReader(inputText.Text);
            length = HexToBin(input, output);
            data = output.GetBuffer();

            if (length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
            }
            else
            {
                icmpSocket.Send(data, length, endPoint);
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

        private void ShowReceivedData(IPEndPoint endPoint, byte[] data, int length)
        {
            if (!InvokeRequired)
            {
                outputText.AppendText(string.Format("{0} said:\r\n", endPoint.ToString()));
                for (int i = 0; i < length; i++)
                {
                    outputText.AppendText(string.Format("{0:X2} ", data[i]));
                }
                outputText.AppendText("\r\n\r\n");
            }
            else
            {
                try
                {
                    Invoke(new ShowReceivedDataDelegate(ShowReceivedData), endPoint, data, length);
                }
                catch (ObjectDisposedException)
                {
                }
            }
        }

        private void CreateIcmpSocket() {
            IPEndPoint srcEndPoint = new IPEndPoint(IPAddress.Any, 0);

            if (!string.Empty.Equals(sourceIPAddress.Text))
            {
                try
                {
                    srcEndPoint = new IPEndPoint(IPAddress.Parse(sourceIPAddress.Text), 0);
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
            }

            try
            {
                icmpSocket = new IcmpSocket(srcEndPoint);
                icmpSocket.MessageReceived += icmpSocket_MessageReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }

            sourceIPAddress.Enabled = false;
            IPEndPoint endPoint = icmpSocket.LocalEndPoint;
            sourceIPAddress.Text = endPoint.Address.ToString();
            bind.Enabled = false;
        }

        void icmpSocket_MessageReceived(IPEndPoint from, byte[] message, int length)
        {
            ShowReceivedData(from, message, length);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputText.Clear();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (icmpSocket != null)
            {
                icmpSocket.Close();
            }
        }

        private void bind_Click(object sender, EventArgs e)
        {
            if (icmpSocket == null)
            {
                CreateIcmpSocket();
                sendButton.Enabled = true;
            }
        }

        private void requestType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void requestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (requestType.SelectedIndex)
            {
                case 0:
                    inputText.Text = "08 00 4d 3d 00 01 00 1e 61 62 63 64 65 66 67 68 69 6a 6b 6c 6d 6e 6f 70 71 72 73 74 75 76 77 61 62 63 64 65 66 67 68 69";
                    break;

                default:
                    break;
            }
        }
    }
}
