using Common;
using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
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
        UrlEncode,
        [Description("SHA1 Hash")]
        Sha1Hash,
    }

    [MainForm(Name = "Encoding Tool")]
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
            byte[] to;
            switch ((Conversions)convertTo.SelectedValue)
            {
                case Conversions.Base64Decode:
                    try
                    {
                        to = System.Convert.FromBase64String(input.TextValue);
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(this, ex.Message, this.Text);
                        return;
                    }
                    break;
                case Conversions.Base64Encode:
                    to = Encoding.UTF8.GetBytes(System.Convert
                        .ToBase64String(input.BinaryValue));
                    break;
                case Conversions.XmlDecode:
                    to = Encoding.UTF8.GetBytes(HttpUtility.HtmlDecode(input.TextValue));
                    break;
                case Conversions.XmlEncode:
                    to = Encoding.UTF8.GetBytes(HttpUtility.HtmlEncode(input.TextValue));
                    break;
                case Conversions.UrlDecode:
                    to = Encoding.UTF8.GetBytes(Uri.UnescapeDataString(input.TextValue));
                    break;
                case Conversions.UrlEncode:
                    to = Encoding.UTF8.GetBytes(Uri.EscapeDataString(input.TextValue));
                    break;
                case Conversions.Sha1Hash:
                    to = SHA1CryptoServiceProvider.Create().ComputeHash(input.BinaryValue);
                    break;
                default:
                    return;
            }
            output.AppendBinary(to, to.Length);
        }
    }
}
