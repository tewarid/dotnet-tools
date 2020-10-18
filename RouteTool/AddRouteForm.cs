using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RouteTool
{
    public partial class AddRouteForm : Form
    {
        public string DestinationAddress
        {
            get
            {
                return destinationAddress.Text;
            }
        }
        public string DestinationMask
        {
            get
            {
                return destinationMask.Text;
            }
        }

        public int InterfaceIndex
        {
            get
            {
                return (int)interfaces.SelectedValue;
            }
        }

        public string NextHop
        {
            get
            {
                return nextHopIPAddress.Text;
            }
        }

        public ushort RouteMetric
        {
            get
            {
                return (ushort)routeMetric.Value;
            }
        }

        public bool Persistent
        {
            get
            {
                return persistent.Checked;
            }
        }

        public AddRouteForm()
        {
            InitializeComponent();
        }

        private BindingSource GetNetIPConfiguration()
        {
            var interfaces = Native.Interface.List();
            var data = from item in interfaces
                        select new
                        {
                            item.InterfaceIndex,
                            item.Name,
                            item.Description,
                            DisplayText = string.Format("[{0}] {1}",
                                item.InterfaceIndex, 
                                item.Description)
                        };
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            return bs;
        }

        private void AddRoute_Load(object sender, EventArgs e)
        {
            interfaces.DataSource = GetNetIPConfiguration();
            interfaces.DisplayMember = "DisplayText";
            interfaces.ValueMember = "InterfaceIndex";
        }
    }
}
