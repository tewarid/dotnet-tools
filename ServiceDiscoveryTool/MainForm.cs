using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Enumeration;

namespace ServiceBrowserTool
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// The protocol ID that identifies DNS-SD.
        /// </summary>
        private const string PROTOCOL_GUID = "{4526e8c1-8aac-4153-9b16-55e86ada0e54}";

        /// <summary>
        /// The host name property.
        /// </summary>
        private const string HOSTNAME_PROPERTY = "System.Devices.Dnssd.HostName";

        /// <summary>
        /// The service name property.
        /// </summary>
        private const string SERVICENAME_PROPERTY = "System.Devices.Dnssd.ServiceName";

        /// <summary>
        /// The instance name property.
        /// </summary>
        private const string INSTANCENAME_PROPERTY = "System.Devices.Dnssd.InstanceName";

        /// <summary>
        /// The IP address property.
        /// </summary>
        private const string IPADDRESS_PROPERTY = "System.Devices.IpAddress";

        /// <summary>
        /// The port number property.
        /// </summary>
        private const string PORTNUMBER_PROPERTY = "System.Devices.Dnssd.PortNumber";

        /// <summary>
        /// All of the properties that will be returned when a DNS-SD instance has been found. 
        /// </summary>
        private readonly string[] _propertyKeys = new string[] {
            HOSTNAME_PROPERTY,
            SERVICENAME_PROPERTY,
            INSTANCENAME_PROPERTY,
            IPADDRESS_PROPERTY,
            PORTNUMBER_PROPERTY
        };

        /// <summary>
        /// The device watcher that will be watching for DNS-SD connections.
        /// </summary>
        private DeviceWatcher _watcher;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
        {
            BeginInvoke((Action)(() => {
                output.AppendText($"Device Added{Environment.NewLine}");
                output.AppendText($"\tKind: {args.Kind}{Environment.NewLine}");
                output.AppendText($"\tId: {args.Id}{Environment.NewLine}");
                output.AppendText($"\tName: {args.Name}{Environment.NewLine}");
                output.AppendText($"\tIP Address: {(args.Properties[IPADDRESS_PROPERTY] as string[])[0]}{Environment.NewLine}");
                output.AppendText($"\tPort: {args.Properties[PORTNUMBER_PROPERTY]}{Environment.NewLine}");
                output.AppendText($"{Environment.NewLine}");
            }));
            await Task.CompletedTask.ConfigureAwait(false);
        }

        private async void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            BeginInvoke((Action)(() => {
                output.AppendText($"Device Updated{Environment.NewLine}");
                output.AppendText($"\tKind: {args.Kind}{Environment.NewLine}");
                output.AppendText($"\tId: {args.Id}{Environment.NewLine}");
                output.AppendText($"\tIP Address: {(args.Properties[IPADDRESS_PROPERTY] as string[])[0]}{Environment.NewLine}");
                output.AppendText($"\tPort: {args.Properties[PORTNUMBER_PROPERTY]}{Environment.NewLine}");
                output.AppendText($"{Environment.NewLine}");
            }));
            await Task.CompletedTask.ConfigureAwait(false);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Event handler")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        private void StartWatcher_Click(object sender, EventArgs e)
        {
            string _aqsQueryString = $"System.Devices.AepService.ProtocolId:={PROTOCOL_GUID}"
                + $" AND System.Devices.Dnssd.Domain:=\"{domainText.Text}\""
                + $" AND System.Devices.Dnssd.ServiceName:=\"{serviceType.Text}.{networkProtocol.Text}\"";

            _watcher = DeviceInformation.CreateWatcher(_aqsQueryString, _propertyKeys, DeviceInformationKind.AssociationEndpointService);
            _watcher.Added += DeviceWatcher_Added;
            _watcher.Updated += DeviceWatcher_Updated;
            _watcher.Start();
            EnableDisable(false);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Event handler")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        private void StopWatcher_Click(object sender, EventArgs e)
        {
            _watcher.Stop();
            _watcher = null;
            EnableDisable(true);
        }

        private void EnableDisable(bool enable)
        {
            startWatcher.Enabled = enable;
            domainText.Enabled = enable;
            serviceType.Enabled = enable;
            networkProtocol.Enabled = enable;
            stopWatcher.Enabled = !enable;
        }
    }
}
