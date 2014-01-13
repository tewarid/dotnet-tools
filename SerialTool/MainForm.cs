using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.IO;
using System.IO.Ports;

namespace SerialTool
{
    public partial class MainForm : Form
    {
        SerialPort port;
        delegate void ShowReceivedDataDelegate(byte[] data);
        Thread receiverThread;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowSerialPorts()
        {
            foreach (string portName in SerialPort.GetPortNames())
            {
                serialPortName.Items.Add(portName);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowSerialPorts();
        }


        private void sendButton_Click(object sender, EventArgs e)
        {
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
                try
                { 
                    port.Write(data, 0, length);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void DataReceiverThread()
        {
            while (port.IsOpen)
            {
                // receive
                int bytesToRead = port.BytesToRead;
                if (bytesToRead > 0)
                {
                    byte[] data = new byte[bytesToRead];
                    port.Read(data, 0, bytesToRead);
                    ShowReceivedData(data);
                }
                Thread.Sleep(10);
            }
        }

        private void ShowReceivedData(byte[] data)
        {
            if (!InvokeRequired)
            {
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
                    Invoke(new ShowReceivedDataDelegate(ShowReceivedData), data);
                }
                catch (ObjectDisposedException)
                {
                }
            }
        }

        private void CreateSerialPort()
        {
            port = new SerialPort(serialPortName.Text);
            if (!baudRate.Text.Equals(string.Empty))
            {
                port.BaudRate = int.Parse(baudRate.Text);
            }
            else
            {
                baudRate.Text = port.BaudRate.ToString();
            }

            try
            {
                port.Open();
            }
            catch
            {
                MessageBox.Show("Invalid port name or unknown error.");
                port = null;
                return;
            }

            receiverThread = new Thread(DataReceiverThread);
            receiverThread.Start();

            serialPortName.Enabled = false;
            baudRate.Enabled = false;
            openButton.Enabled = false;
            sendButton.Enabled = true;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputText.Clear();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (receiverThread != null)
            {
                receiverThread.Abort();
            }
            else
            {
                return;
            }
            if (port != null)
            {
                try
                {
                    port.Close();
                }
                catch
                {
                    //
                }
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (string.Empty.Equals(serialPortName.Text))
            {
                MessageBox.Show("Need a port name to Open.");
                return;
            }

            if (port == null)
            {
                CreateSerialPort();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ShowSerialPorts();
            btnClose.Enabled = port.IsOpen;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnClose.Enabled = false;
            if (port.IsOpen)
                port.Close();
        }
    }
}