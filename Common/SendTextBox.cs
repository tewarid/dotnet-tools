using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HexToBinLib;

namespace Common
{
    public partial class SendTextBox : UserControl
    {
        public byte[] Bytes {
            get
            {
                byte[] buffer;

                if (Binary)
                {
                    MemoryStream output = new MemoryStream();
                    TextReader input = new StringReader(Text);
                    HexToBin.DefaultInstance.Convert(input, output);
                    buffer = output.ToArray();
                }
                else
                {
                    buffer = UTF8Encoding.UTF8.GetBytes(Text);
                }

                return buffer;
            }
        }

        public bool Binary
        {
            get
            {
                return inputInHex.Checked;
            }
        }

        public override string Text
        {
            get
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

                return text;
            }

            set
            {
                inputText.Text = value;
            }
        }

        public SendTextBox()
        {
            InitializeComponent();
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

        private void inputText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 1) // Control+A
            {
                inputText.SelectAll();
                e.Handled = true;
            }
        }
    }
}
