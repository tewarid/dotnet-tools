using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace FontTool
{
    public partial class MainForm : Form
    {
        PrivateFontCollection fontCollection;

        public MainForm()
        {
            InitializeComponent();
            if (string.IsNullOrWhiteSpace(text.Text))
            {
                text.Text = "aáàâãäåbcçdefghijklmnopqrstuvwxyzAÁÀÂÃÄÅBCDEFGHIJKLMNOPQRSTUVWXYZ1¹2²3³4567890";
                display.Text = text.Text;
            }
            hint.DisplayMember = "Description";
            hint.ValueMember = "Value";
            hint.DataSource = Enum.GetValues(typeof(TextRenderingHint))
                .Cast<Enum>()
                .Select(value => new
                {
                    Description = value.ToString(),
                    Value = value
                })
                .ToList();
            font.Text = display.Font.Name;
            size.Value = (decimal)display.Font.Size;
            ShowStyle(display.Font.Style);
        }

        private void Pick_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            display.Font = fontDialog.Font;
            font.Text = display.Font.Name;
            size.Value = (decimal)display.Font.Size;
            ShowStyle(display.Font.Style);
        }

        private void Text_TextChanged(object sender, EventArgs e)
        {
            display.Text = text.Text;
        }

        private void Display_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        }

        private void Hint_SelectedIndexChanged(object sender, EventArgs e)
        {
            display.TextRenderingHint = (TextRenderingHint)hint.SelectedValue;
            display.Refresh();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(openFileDialog.FileName);
            display.Font = new Font(fontCollection.Families[0], (float)size.Value,
               GetStyle(), GraphicsUnit.Point);
            font.Text = display.Font.Name;
        }

        private void Size_ValueChanged(object sender, EventArgs e)
        {
            Font f = display.Font;
            display.Font = new Font(f.FontFamily, (float)size.Value,
               GetStyle(), f.Unit);
        }

        private void Style_CheckedChanged(object sender, EventArgs e)
        {
            Font f = display.Font;
            display.Font = new Font(f.FontFamily, (float)size.Value,
               GetStyle(), f.Unit);
        }

        private FontStyle GetStyle()
        {
            return ((bold.Checked ? FontStyle.Bold : FontStyle.Regular)
                | (italic.Checked ? FontStyle.Italic : FontStyle.Regular)
                | (underline.Checked ? FontStyle.Underline : FontStyle.Regular)
                | (strikeout.Checked ? FontStyle.Strikeout : FontStyle.Regular));
        }

        private void ShowStyle(FontStyle fontStyle)
        {
            bold.Checked = ((fontStyle & FontStyle.Bold) != FontStyle.Regular);
            italic.Checked = ((fontStyle & FontStyle.Italic) != FontStyle.Regular);
            underline.Checked = ((fontStyle & FontStyle.Underline) != FontStyle.Regular);
            strikeout.Checked = ((fontStyle & FontStyle.Strikeout) != FontStyle.Regular);
        }
    }
}
