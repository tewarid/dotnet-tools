using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Common
{
    public partial class InterfaceSelectorComboBox : ComboBox
    {
        public event Action<string> InterfaceDeleted;

        private readonly string any = IPAddress.Any.ToString();
        bool _includeIPAddressAny = false;
        public bool IncludeIPAddressAny
        {
            get
            {
                return _includeIPAddressAny;
            }
            set
            {
                _includeIPAddressAny = value;
                if (value)
                {
                    if (!Items.Contains(any))
                    {
                        Items.Add(any);
                    }
                }
            }
        }

        public InterfaceSelectorComboBox()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                RefreshNetworkInterfaces();

                NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
            }
        }

        private void RefreshNetworkInterfaces()
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)RefreshNetworkInterfaces);
                return;
            }

            // Get all IP v4 addresses
            List<string> newList = GetIPv4Addresses();

            // Add
            foreach (string address in newList)
            {
                if (!Items.Contains(address))
                {
                    // Added
                    Items.Add(address);
                }
            }

            // Delete
            for (int i = 0; i < Items.Count; i++)
            {
                if (!any.Equals(Items[i]) && !newList.Contains((String)Items[i]))
                {
                    // Removed
                    if (SelectedIndex == i)
                    {
                        InterfaceDeleted?.Invoke((String)Items[i]);
                    }
                    Items.RemoveAt(i);
                }
            }
        }

        private List<string> GetIPv4Addresses()
        {
            List<string> newList = new List<string>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface iface in interfaces)
            {
                if (!iface.Supports(NetworkInterfaceComponent.IPv4)
                    || iface.OperationalStatus != OperationalStatus.Up)
                    continue;

                IPInterfaceProperties ipProperties = iface.GetIPProperties();
                UnicastIPAddressInformationCollection addresses = ipProperties.UnicastAddresses;
                foreach (UnicastIPAddressInformation address in addresses)
                {
                    if (address.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        newList.Add(address.Address.ToString());
                    }
                }
            }
            return newList;
        }

        private void NetworkChange_NetworkAddressChanged(object sender, System.EventArgs e)
        {
            RefreshNetworkInterfaces();
        }
    }
}
