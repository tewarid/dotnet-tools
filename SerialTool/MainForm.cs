using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using de.log.HexToBinLib;

namespace SerialTool
{
    public partial class MainForm : Form
    {
        SerialPort port;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowSerialPorts()
        {
            serialPortName.Items.Clear();
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
                length = HexToBin.Convert(input, output);
                data = output.GetBuffer();
            }
            else
            {
                data = UTF8Encoding.UTF8.GetBytes(text);
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

        private void ShowReceivedData(string data)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate {
                    ShowReceivedData(data);
                });
                return;
            }

            if (viewInHex.Checked)
            {
                foreach (char c in data)
                {
                    outputText.AppendText(string.Format("{0:X2} ", (byte)c));
                }
                outputText.AppendText("\r\n\r\n");
            }
            else
            {
                StringBuilder output = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    switch (data[i])
                    {
                        case '\r':
                            output.Append("\r\n");
                            break;

                        case '\n':
                            if (i > 0 && data[i - 1] != '\r') output.Append("\r\n");
                            break;

                        default:
                            // remove special char
                            if (data[i] < ' ' || data[i] > '~')
                                output.Append('.');
                            else
                                output.Append(data[i]);
                            break;
                    }
                }
                outputText.AppendText(output.ToString());
            }
        }

        private void CreateSerialPort()
        {
            port = new SerialPort(serialPortName.Text);
            port.Encoding = UTF8Encoding.UTF8;
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
                port.DataReceived += port_DataReceived;
            }
            catch
            {
                MessageBox.Show("Invalid port name or unknown error.");
                port = null;
                openButton.Enabled = true;
                return;
            }

            serialPortName.Enabled = false;
            baudRate.Enabled = false;
            openButton.Enabled = false;
            sendButton.Enabled = true;
            closeButton.Enabled = true;
            updateButton.Enabled = false;
        }

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = port.ReadExisting();
            ShowReceivedData(data);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputText.Clear();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (port != null)
            {
                try
                {
                    port.Close();
                    port = null;
                }
                catch
                {
                    //
                }
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openButton.Enabled = false;

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
            closeButton.Enabled = port!= null ? port.IsOpen : false;
        }

        private void CloseSerialPort()
        {
            if (port.IsOpen)
            {
                try
                {
                    port.Close();
                }
                catch
                {
                    port = null;
                }
            }
            port = null;

            closeButton.Enabled = false;
            sendButton.Enabled = false;
            openButton.Enabled = true;
            updateButton.Enabled = true;
            serialPortName.Enabled = true;
            baudRate.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseSerialPort();
        }
    }
}