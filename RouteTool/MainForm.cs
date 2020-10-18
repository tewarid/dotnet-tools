using Common;
using Native;
using System;
using System.Data;
using System.Linq;
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
            Route[] list = Route.List();

            var data = from item in list
                        select new
                        {
                            Route = item,
                            item.DestinationAddress,
                            item.DestinationMask,
                            item.NextHop,
                            item.RouteMetric,
                            item.Persistent,
                            item.InterfaceIndex
                        };
            BindingSource bindingSource = new BindingSource
            {
                DataSource = data
            };
            routes.AutoGenerateColumns = true;
            routes.Columns.Clear();
            routes.DataSource = bindingSource;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshRoutes();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (routes.SelectedRows.Count == 0)
            {
                return;
            }
            Route route = (Route)((dynamic)routes.SelectedRows[0].DataBoundItem).Route;
            Route.Delete(route);
            RefreshRoutes();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddRouteForm form = new AddRouteForm();
            DialogResult result = form.ShowDialog(this);
            if (result != DialogResult.Cancel)
            {
                RefreshRoutes();
            }
            Route.Add(new Route
            {
                DestinationAddress = form.DestinationAddress,
                InterfaceIndex = form.InterfaceIndex,
                NextHop = form.NextHop,
                DestinationMask = form.DestinationMask,
                RouteMetric = form.RouteMetric
            });
            RefreshRoutes();
        }
    }
}
