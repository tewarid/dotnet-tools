using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HexToBinLib;
using System.Linq;
using System.ComponentModel;

namespace Common
{
    public partial class InputTextBox : UserControl
    {
        public byte[] BinaryValue
        {
            get
            {
                return GetBinaryValue(TextValue);
            }
        }

        public byte[] SelectedBinaryValue
        {
            get
            {
                return GetBinaryValue(SelectedTextValue);
            }
        }

        public bool BinaryChecked
        {
            get
            {
                return inputInHex.Checked;
            }
            set
            {
                inputInHex.Checked = value;
            }
        }

        public string SelectedTextValue
        {
            get
            {
                if (string.IsNullOrEmpty(inputText.SelectedText))
                {
                    return ApplyEndOfLine(inputText.Text);
                }
                else
                {
                    return ApplyEndOfLine(inputText.SelectedText);
                }
            }
            set
            {
                SetText(value);
            }
        }

        public string TextValue
        {
            get
            {
                return ApplyEndOfLine(inputText.Text);
            }
            set
            {
                SetText(value);
            }
        }

        public bool ChangeEndOfLine
        {
            get
            {
                return changeEndOfLine.Checked;
            }
            set
            {
                changeEndOfLine.Checked = value;
            }
        }

        public EndOfLine EndOfLine
        {
            get
            {
                return (EndOfLine)endOfLine.SelectedIndex;
            }
            set
            {
                endOfLine.SelectedIndex = (int)value;
            }
        }

        public InputTextBox()
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

        private string ApplyEndOfLine(string text)
        {
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

        private void SetText(string value)
        {
            if (changeEndOfLine.Checked)
            {
                switch ((EndOfLine)endOfLine.SelectedValue)
                {
                    case EndOfLine.MacOS:
                        inputText.Text = value.Replace(EndOfLineConstants.MACOS,
                            Environment.NewLine);
                        break;
                    case EndOfLine.Dos:
                        inputText.Text = value.Replace(EndOfLineConstants.DOS,
                            Environment.NewLine);
                        break;
                    default:
                        inputText.Text = value.Replace(EndOfLineConstants.UNIX,
                            Environment.NewLine);
                        break;
                }
            }
            else
            {
                inputText.Text = value;
            }
        }

        private byte[] GetBinaryValue(string value)
        {
            byte[] buffer;

            if (BinaryChecked)
            {
                MemoryStream output = new MemoryStream();
                TextReader input = new StringReader(value);
                HexToBin.DefaultInstance.Convert(input, output);
                buffer = output.ToArray();
            }
            else
            {
                buffer = UTF8Encoding.UTF8.GetBytes(value);
            }

            return buffer;
        }
    }
}
