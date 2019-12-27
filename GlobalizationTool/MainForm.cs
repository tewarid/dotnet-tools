using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;


namespace GlobalizationTool
{
    public partial class MainForm : Form
    {
        List<CultureInfo> cultures = new List<CultureInfo>();

        public MainForm()
        {
            InitializeComponent();
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                string specName = "(none)";
                try { specName = CultureInfo.CreateSpecificCulture(ci.Name).Name; }

                catch { }
                cultures.Add(ci);
            }
            var data = cultures
                .Select(item => new
                {
                    item.EnglishName,
                    item.Name,
                    SpecificName = CultureInfo.CreateSpecificCulture(item.Name).Name,
                    item.LCID,
                    item.DateTimeFormat.ShortDatePattern,
                    item.NumberFormat.NumberDecimalSeparator,
                    item.TwoLetterISOLanguageName,
                    item.ThreeLetterISOLanguageName
                })
                .OrderBy(item => item.EnglishName);
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            culturesGrid.DataSource = bs;
        }
    }
}
