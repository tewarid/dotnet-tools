using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HexToBinLib;

namespace Common
{
    public partial class SendTextBox : UserControl
    {
        private bool changed = false;
        public int Length { get; private set; }
        public byte[] Bytes { get; private set; }

        public SendTextBox()
        {
            InitializeComponent();
        }

        private void Evaluate()
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

            byte[] buffer;
            int length;

            if (inputInHex.Checked)
            {
                MemoryStream output = new MemoryStream();
                TextReader input = new StringReader(text);
                length = HexToBin.Convert(input, output);
                buffer = output.GetBuffer();
            }
            else
            {
                buffer = UTF8Encoding.UTF8.GetBytes(text);
                length = buffer.Length;
            }

            Length = length;
            Bytes = buffer;
        }

        private void inputText_Leave(object sender, EventArgs e)
        {
            if (changed) Evaluate();
        }

        private void inputText_Enter(object sender, EventArgs e)
        {
            changed = false;
        }

        private void inputText_TextChanged(object sender, EventArgs e)
        {
            changed = true;
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
            Evaluate();
        }

        private void endOfLine_CheckedChanged(object sender, EventArgs e)
        {
            Evaluate();
        }

        private void inputText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 1) // Control+A
            {
                inputText.SelectAll();
                e.Handled = true;
            }
        }

        private void SendTextBox_Resize(object sender, EventArgs e)
        {
            int padding = 5;
            inputInHex.Top = padding;
            inputTextLabel.Top = inputInHex.Bottom + padding;
            inputText.Top = inputTextLabel.Bottom + padding;
            endOfLine.Top = this.Height - padding - endOfLine.Height;
            inputText.Height = endOfLine.Top - inputTextLabel.Bottom - 2 * padding;
            inputText.Width = this.Width - 2 * padding;
        }
    }
}
