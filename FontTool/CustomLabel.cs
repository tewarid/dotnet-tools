using System.Drawing.Text;
using System.Windows.Forms;

namespace FontTool
{
    class CustomLabel : Label
    {
        public TextRenderingHint TextRenderingHint { get; set; } = TextRenderingHint.SystemDefault;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = this.TextRenderingHint;
            base.OnPaint(e);
        }
    }
}
