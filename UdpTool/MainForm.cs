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
                outputText.AppendText("\r\n\r\n");
            } 
        }

        private void CreateUdpClient() 
        {
            IPAddress address = IPAddress.Any;
            IPEndPoint srcEndPoint = new IPEndPoint(IPAddress.Any, 0);

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
                srcEndPoint = new IPEndPoint(address, int.Parse(sourcePort.Text));
            }
            else
            {
                srcEndPoint = new IPEndPoint(address, 0);
                sourcePort.Text = "";
            }

            try
            {
                udpClient = new UdpClient(srcEndPoint);
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
            add.Enabled = true;
            multicastGroup.Enabled = true;
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            try
            {
                byte[] data = udpClient.EndReceive(ar, ref endPoint);
                udpClient.BeginReceive(ReceiveCallback, null);
                ShowReceivedData(endPoint, data);
            } 
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputText.Clear();
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

        private void add_Click(object sender, EventArgs e)
        {
            IPAddress groupIPAddress;
            try
            {
                groupIPAddress = IPAddress.Parse(multicastGroup.Text);
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

        private void inputInHex_CheckedChanged(object sender, EventArgs e)
        {
            if (inputInHex.Checked)
            {
                endOfLine.Enabled = false;
            }
            else
            {
                endOfLine.Enabled = true;
            }
        }
    }
}
