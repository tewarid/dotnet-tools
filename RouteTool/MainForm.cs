using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Threading;

namespace RouteTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshRoutes();
        }

        private void RefreshRoutes()
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript("Get-NetRoute");

                Collection<PSObject> outputCollection = 
                    PowerShellInstance.Invoke<PSObject>(null);

                routes.AutoGenerateColumns = true;
                routes.Columns.Clear();
                var data = from dynamic item in outputCollection
                           select new
                           {
                               DestinationPrefix = item.DestinationPrefix,
                               NextHop = item.NextHop,
                               RouteMetric = item.RouteMetric,
                               //Persistent = item.Store == 0,
                               InterfaceIndex = item.InterfaceIndex,
                               InterfaceAlias = item.InterfaceAlias
                           };
                BindingSource bs = new BindingSource();
                bs.DataSource = data;
                routes.DataSource = bs;
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            RefreshRoutes();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (routes.SelectedRows.Count > 0)
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    foreach (DataGridViewRow row in routes.SelectedRows)
                    {
                        string script = "Remove-NetRoute -Confirm:$false -DestinationPrefix " + row.Cells[0].Value;
                        PowerShellInstance.AddScript(script);
                    }
                    PowerShellInstance.Invoke();
                }
                RefreshRoutes();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddRoute form = new AddRoute();
            DialogResult result = form.ShowDialog(this);
            if (result != DialogResult.Cancel)
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    foreach (DataGridViewRow row in routes.SelectedRows)
                    {
                        string persistent = string.Empty;
                        if (!form.Persistent)
                        {
                            // Do not specify PolicyStore for PersistentStore
                            persistent = "-PolicyStore ActiveStore";
                        }
                        string format = "New-NetRoute -DestinationPrefix {0} -InterfaceIndex {1} -NextHop {2} {3} -RouteMetric {4}";
                        string script = string.Format(format, form.DestinationPrefix,
                            form.InterfaceIndex, form.NextHop, persistent, form.RouteMetric);
                        PowerShellInstance.AddScript(script);
                    }
                    PowerShellInstance.Invoke();
                }
                RefreshRoutes();
            }
        }
    }
}
