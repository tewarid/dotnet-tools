using System.Collections.Specialized;
using System.Windows.Forms;

namespace NetTools.Common
{
    public partial class NameValueGrid : UserControl
    {
        private NameValueCollection collection = new NameValueCollection();
        private DataGridView dataGrid;

        public bool ReadOnly
        {
            get
            {
                return dataGrid.ReadOnly;
            }
            set
            {
                dataGrid.ReadOnly = value;
            }
        }

        public bool AllowUserToAddRows
        {
            get
            {
                return dataGrid.AllowUserToAddRows;
            }
            set
            {
                dataGrid.AllowUserToAddRows = value;
            }
        }

        public bool AllowUserToDeleteRows
        {
            get
            {
                return dataGrid.AllowUserToDeleteRows;
            }
            set
            {
                dataGrid.AllowUserToDeleteRows = value;
            }
        }
        
        public NameValueGrid()
        {
            InitializeComponent();
            dataGrid = new DataGridView();
            dataGrid.Dock = DockStyle.Fill;
            Controls.Add(dataGrid);
            dataGrid.Columns.Clear();
            dataGrid.Columns.Add("name", "Name");
            dataGrid.Columns.Add("value", "Value");
        }

        public void Add(NameValueCollection values)
        {
            this.collection.Add(values);
            foreach (string key in this.collection)
            {
                dataGrid.Rows.Add(key, this.collection[key]);
            }
        }

        internal void RemoveSelected()
        {
            if (dataGrid.SelectedRows.Count > 0 && !dataGrid.SelectedRows[0].IsNewRow)
            {
                dataGrid.Rows.Remove(dataGrid.SelectedRows[0]);
            }
        }

        public void Clear()
        {
            this.collection.Clear();
            dataGrid.Rows.Clear();
        }

        public NameValueCollection Get()
        {
            collection = new NameValueCollection();
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                string name = (string)row.Cells[0].Value;
                string value = (string)row.Cells[1].Value;
                if (!string.IsNullOrWhiteSpace(name))
                    collection.Add(name, value);
            }
            return collection;
        }
    }
}
