using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Management.Automation;
using System.Windows.Forms;

namespace RouteTool
{
    public partial class AddRoute : Form
    {
        public string DestinationPrefix
        {
            get
            {
                return destinationPrefix.Text;
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
                return interfaces.Text;
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

        public AddRoute()
        {
            InitializeComponent();
        }

        private BindingSource GetNetIPConfiguration()
        {
            BindingSource bs;
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript("Get-NetIPConfiguration");

                Collection<PSObject> outputCollection =
                    PowerShellInstance.Invoke<PSObject>(null);

                var data = from dynamic item in outputCollection
                           where item.IPv4DefaultGateway != null
                           select new
                           {
                               InterfaceIndex = item.InterfaceIndex,
                               InterfaceAlias = item.InterfaceAlias,
                               IPv4DefaultGateway = item.IPv4DefaultGateway[0].CimInstanceProperties["NextHop"].Value
                           };
                bs = new BindingSource();
                bs.DataSource = data;
            }
            return bs;
        }

        private void AddRoute_Load(object sender, EventArgs e)
        {
            interfaces.DataSource = GetNetIPConfiguration();
            interfaces.DisplayMember = "IPv4DefaultGateway";
            interfaces.ValueMember = "InterfaceIndex";
        }

        private void add_Click(object sender, EventArgs e)
        {

        }
    }
}
