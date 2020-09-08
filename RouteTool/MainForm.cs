using Common;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Management.Automation;
using System.Windows.Forms;

namespace RouteTool
{
    [MainForm(Name = "Network Route Tool")]
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
            using (PowerShell powerShellInstance = PowerShell.Create())
            {
                powerShellInstance.AddScript("Get-NetRoute");

                Collection<PSObject> outputCollection = 
                    powerShellInstance.Invoke<PSObject>(null);

                var data = from dynamic item in outputCollection
                           select new
                           {
                               item.DestinationPrefix,
                               item.NextHop,
                               item.RouteMetric,
                               Persistent = item.Store == 0,
                               item.InterfaceIndex,
                               item.InterfaceAlias
                           };
                BindingSource bindingSource = new BindingSource
                {
                    DataSource = data
                };
                routes.AutoGenerateColumns = true;
                routes.Columns.Clear();
                routes.DataSource = bindingSource;
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshRoutes();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (routes.SelectedRows.Count > 0)
            {
                using (PowerShell powerShellInstance = PowerShell.Create())
                {
                    foreach (DataGridViewRow row in routes.SelectedRows)
                    {
                        string script = string.Format("Remove-NetRoute -Confirm:$false -DestinationPrefix {0} -InterfaceIndex {1}", 
                            ((dynamic)row.DataBoundItem).DestinationPrefix, ((dynamic)row.DataBoundItem).InterfaceIndex);
                        powerShellInstance.AddScript(script);
                    }
                    powerShellInstance.Invoke();
                }
                RefreshRoutes();
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddRouteForm form = new AddRouteForm();
            DialogResult result = form.ShowDialog(this);
            if (result != DialogResult.Cancel)
            {
                using (PowerShell powerShellInstance = PowerShell.Create())
                {
                    string nextHop = string.Empty;
                    if (!string.IsNullOrEmpty(form.NextHop))
                    {
                        nextHop = "-NextHop " + form.NextHop;
                    }
                    string persistent = string.Empty;
                    if (!form.Persistent)
                    {
                        // Do not specify PolicyStore for PersistentStore
                        persistent = "-PolicyStore ActiveStore";
                    }
                    string format = "New-NetRoute -DestinationPrefix {0} -InterfaceIndex {1} {2} {3} -RouteMetric {4}";
                    string script = string.Format(format, form.DestinationPrefix,
                        form.InterfaceIndex, nextHop, persistent, form.RouteMetric);
                    powerShellInstance.AddScript(script);
                    powerShellInstance.Invoke();
                }
                RefreshRoutes();
            }
        }
    }
}
