using System.Windows.Forms;

namespace NetTools.Common
{
    public partial class ContentTypeSelector : UserControl
    {
        private readonly ComboBox comboBox;

        public override string Text
        {
            get
            {
                return comboBox.Text;
            }
        }

        public ContentTypeSelector()
        {
            InitializeComponent();
            comboBox = new ComboBox()
            {
                Dock = DockStyle.Fill
            };
            comboBox.Items.Add(MimeTypes.MimeTypeMap.GetMimeType("txt"));
            comboBox.Items.Add(MimeTypes.MimeTypeMap.GetMimeType("xml"));
            comboBox.Items.Add(MimeTypes.MimeTypeMap.GetMimeType("json"));
            Controls.Add(comboBox);
            Height = comboBox.Height;
        }
    }
}
