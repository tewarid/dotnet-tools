using System;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class ReceiveTextBox : UserControl
    {
        public ReceiveTextBox()
        {
            InitializeComponent();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputText.Clear();
        }

        private void ReceiveTextBox_Resize(object sender, EventArgs e)
        {
            panel.Width = this.Width - flowLayoutPanel.Margin.Vertical;
            outputText.Width = this.Width - flowLayoutPanel.Margin.Vertical;
            outputText.Height = this.Height - label.Height - panel.Height
                - 2 * flowLayoutPanel.Margin.Vertical;
        }

        public void Append(byte [] data, int length)
        {
            if (viewInHex.Checked)
            {
                StringBuilder sb = new StringBuilder(length);
                for (int i = 0; i < length; i++)
                {
                    sb.Append(string.Format("{0:X2} ", data[i]));
                }
                outputText.AppendText(sb.ToString());
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

        public void AppendText(string text)
        {
            outputText.AppendText(text);
        }

        public void AppendText(string text, bool inHexadecimalMode)
        {
            if (inHexadecimalMode && viewInHex.Checked)
                AppendText(text);
            else if (!inHexadecimalMode && !viewInHex.Checked)
                AppendText(text);
        }

        private void outputText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 1) // Control+A
            {
                outputText.SelectAll();
                e.Handled = true;
            }
        }
    }
}
