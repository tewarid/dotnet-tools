using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using HexToBinLib;

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

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (icmpSocket == null)
                return;

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
            length = HexToBin.DefaultInstance.Convert(input, output);
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

        private void ShowReceivedData(IPEndPoint endPoint, byte[] data, int length)
        {
            if (!InvokeRequired)
            {
                outputText.AppendText(string.Format("{0} sent {1} bytes(s):\r\n", endPoint.ToString(), length));
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
                return;
            }

            sourceIPAddress.Enabled = false;
            IPEndPoint endPoint = icmpSocket.LocalEndPoint;
            sourceIPAddress.Text = endPoint.Address.ToString();
            bind.Enabled = false;
            close.Enabled = true;
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
            CreateIcmpSocket();
            sendButton.Enabled = true;
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
        
        private void close_Click(object sender, EventArgs e)
        {
            CloseIcmpSocket();
        }

        private void CloseIcmpSocket()
        {
            if (icmpSocket == null)
                return;

            if (InvokeRequired)
            {
                Invoke((Action)delegate
                {
                    CloseIcmpSocket();
                });
                return;
            }
            icmpSocket.Close();
            icmpSocket = null;
            bind.Enabled = true;
            sendButton.Enabled = false;
            close.Enabled = false;
            sourceIPAddress.Enabled = true;
        }
    }
}
