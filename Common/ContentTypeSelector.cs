using System.Windows.Forms;

namespace NetTools.Common
{
    public partial class ContentTypeSelector : UserControl
    {
        private ComboBox comboBox;

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
            comboBox = new ComboBox();
            comboBox.Items.Add(MimeTypes.MimeTypeMap.GetMimeType("txt"));
            comboBox.Items.Add(MimeTypes.MimeTypeMap.GetMimeType("xml"));
            comboBox.Items.Add(MimeTypes.MimeTypeMap.GetMimeType("json"));
            comboBox.Dock = DockStyle.Fill;
            Controls.Add(comboBox);
            this.Height = comboBox.Height;
        }
    }
}
