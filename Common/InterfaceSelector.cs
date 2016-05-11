using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Common
{
    public partial class InterfaceSelectorComboBox : ComboBox
    {
        public InterfaceSelectorComboBox()
        {
            InitializeComponent();

            Initalize();

            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
        }

        private void Initalize()
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)Initalize);
                return;
            }
            Items.Clear();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface iface in interfaces)
            {
                UnicastIPAddressInformationCollection addresses = iface.GetIPProperties().UnicastAddresses;
                foreach (UnicastIPAddressInformation address in addresses)
                {
                    if (address.Address.AddressFamily == AddressFamily.InterNetwork)
                        Items.Add(address.Address.ToString());
                }
            }
        }

        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            Initalize();
        }

        private void NetworkChange_NetworkAddressChanged(object sender, System.EventArgs e)
        {
            Initalize();
        }
    }
}
