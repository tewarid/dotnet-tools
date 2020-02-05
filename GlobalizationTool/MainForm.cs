using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GlobalizationTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            culturesGrid.Columns.Clear();
            culturesGrid.Columns.Add("EnglishName", "English Name");
            culturesGrid.Columns.Add("Name", "Name");
            culturesGrid.Columns.Add("SpecificName", "Specific Name");
            culturesGrid.Columns.Add("LCID", "LCID");
            culturesGrid.Columns.Add("ShortDatePattern", "Short Date Pattern");
            culturesGrid.Columns.Add("DecimalSeparator", "Decimal Separator");
            culturesGrid.Columns.Add("TwoLetterISOLanguageName", "ISO Name");
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                string specName = "(none)";
                try { specName = CultureInfo.CreateSpecificCulture(ci.Name).Name; }

                catch { }
                //cultures.Add(ci);
                culturesGrid.Rows.Add(new object[]
                {
                    ci.EnglishName,
                    ci.Name,
                    CultureInfo.CreateSpecificCulture(ci.Name).Name,
                    ci.LCID,
                    ci. DateTimeFormat.ShortDatePattern,
                    ci.NumberFormat.NumberDecimalSeparator,
                    ci.TwoLetterISOLanguageName
                });
            }
        }

        private void Tab_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (tab.SelectedIndex == 1)
            {
                LoadUnicodeGrid();
            }
        }

        private void LoadUnicodeGrid()
        {
            if (unicodeGrid.Rows.Count != 0)
            {
                return;
            }
            unicodeGrid.Columns.Clear();
            unicodeGrid.Columns.Add("Code", "Code (hex)");
            unicodeGrid.Columns.Add("Code", "Code (dec)");
            unicodeGrid.Columns.Add("Name", "Name");
            unicodeGrid.Columns.Add("Display", "Display");
            using (var reader = new StreamReader("UnicodeData.txt"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.Delimiter = ";";
                var records = csv.GetRecords<dynamic>();
                foreach (var record in records)
                {
                    int value = int.Parse(record.Field1, NumberStyles.HexNumber);
                    unicodeGrid.Rows.Add(new object[]
                    {
                        record.Field1,
                        value,
                        record.Field2,
                        (char)value
                    });
                }
            }
        }

        private void UpperCase_Click(object sender, System.EventArgs e)
        {
            text.Text = text.Text.ToUpper();
        }

        private void LowerCase_Click(object sender, System.EventArgs e)
        {
            text.Text = text.Text.ToLower();
        }

        private void RemoveDiacritics_Click(object sender, System.EventArgs e)
        {
            text.Text = RemoveDiacritics(text.Text);
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private void Sort_Click(object sender, System.EventArgs e)
        {
            string[] words = text.Text.Split(new string[] { Environment.NewLine, " " },
                StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            text.Text = string.Join(Environment.NewLine, words);
        }
    }
}
