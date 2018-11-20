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

                if (endOfLineMac.Checked)
                {
                    text = inputText.Text.Replace(Environment.NewLine,
                        EndOfLineConstants.MACOS);
                }
                else if (endOfLineDos.Checked)
                {
                    text = inputText.Text.Replace(Environment.NewLine,
                        EndOfLineConstants.DOS);
                }
                else
                {
                    text = inputText.Text.Replace(Environment.NewLine,
                        EndOfLineConstants.UNIX);
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

        private void InputInHex_CheckedChanged(object sender, EventArgs e)
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
