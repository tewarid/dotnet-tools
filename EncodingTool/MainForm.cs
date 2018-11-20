using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace EncodingTool
{
    enum Conversions : byte
    {
        [Description("Base64 Decode")]
        Base64Decode,
        [Description("Base64 Encode")]
        Base64Encode,
        [Description("HTML or XML Decode")]
        XmlDecode,
        [Description("HTML or XML Encode")]
        XmlEncode,
        [Description("URL Decode")]
        UrlDecode,
        [Description("URL Encode")]
        UrlEncode
    }

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            convertTo.DisplayMember = "Description";
            convertTo.ValueMember = "Value";
            convertTo.DataSource = Enum.GetValues(typeof(Conversions))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
        }

        private void Convert(object sender, EventArgs e)
        {
            output.Clear();
            string from;
            if (input.Binary)
            {
                from = Encoding.UTF8.GetString(input.Bytes);
            }
            else
            {
                from = input.Text;
            }
            byte[] to;
            switch ((Conversions)convertTo.SelectedValue)
            {
                case Conversions.Base64Decode:
                    try
                    {
                        to = System.Convert.FromBase64String(from);
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(this, ex.Message, this.Text);
                        return;
                    }
                    break;
                case Conversions.Base64Encode:
                    to = Encoding.UTF8.GetBytes(System.Convert
                        .ToBase64String(Encoding.UTF8.GetBytes(from)));
                    break;
                case Conversions.XmlDecode:
                    to = Encoding.UTF8.GetBytes(HttpUtility.HtmlDecode(from));
                    break;
                case Conversions.XmlEncode:
                    to = Encoding.UTF8.GetBytes(HttpUtility.HtmlEncode(from));
                    break;
                case Conversions.UrlDecode:
                    to = Encoding.UTF8.GetBytes(Uri.UnescapeDataString(from));
                    break;
                case Conversions.UrlEncode:
                    to = Encoding.UTF8.GetBytes(Uri.EscapeDataString(from));
                    break;
                default:
                    return;
            }
            output.Append(to, to.Length);
        }
    }
}
