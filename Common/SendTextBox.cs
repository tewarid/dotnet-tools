using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HexToBinLib;
using System.Linq;
using System.ComponentModel;

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
                string text = inputText.Text;

                if (changeEndOfLine.Checked)
                {
                    switch ((EndOfLine)endOfLine.SelectedValue)
                    {
                        case EndOfLine.MacOS:
                            text = text.Replace(Environment.NewLine,
                                EndOfLineConstants.MACOS);
                            break;
                        case EndOfLine.Dos:
                            text = text.Replace(Environment.NewLine,
                                EndOfLineConstants.DOS);
                            break;
                        default:
                            text = text.Replace(Environment.NewLine,
                                EndOfLineConstants.UNIX);
                            break;
                    }
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
            endOfLine.DisplayMember = "Description";
            endOfLine.ValueMember = "Value";
            endOfLine.DataSource = Enum.GetValues(typeof(EndOfLine))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            endOfLine.SelectedValue = EndOfLine.Dos;
        }

        private void InputInHex_CheckedChanged(object sender, EventArgs e)
        {
            changeEndOfLine.Enabled = !inputInHex.Checked;
            endOfLine.Enabled = !inputInHex.Checked && changeEndOfLine.Checked;
        }

        private void ChangeEndOfLine_CheckedChanged(object sender, EventArgs e)
        {
            endOfLine.Enabled = changeEndOfLine.Checked;
        }
    }
}
