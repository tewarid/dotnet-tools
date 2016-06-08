using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Common
{
    public partial class InterfaceSelectorComboBox : ComboBox
    {
        List<string> addresses = new List<string>();

        public event Action<string> InterfaceDeleted;

        public InterfaceSelectorComboBox()
        {
            InitializeComponent();

            DataSource = addresses;
            RefreshNetworkInterfaces();

            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
        }

        private void RefreshNetworkInterfaces()
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)RefreshNetworkInterfaces);
                return;
            }

            // Get all IP v4 addresses
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

            bool refresh = false;

            // Add
            foreach (string address in newList)
            {
                if (!addresses.Contains(address))
                {
                    // Added
                    addresses.Add(address);
                    refresh = true;
                }
            }

            // Delete
            for (int i = 0; i < addresses.Count; i++)
            {
                if (!newList.Contains(addresses[i]))
                {
                    // Removed
                    if (SelectedIndex == i)
                    {
                        InterfaceDeleted.Invoke(addresses[i]);
                        if (SelectedIndex != i)
                        {
                            addresses.RemoveAt(i);
                        }
                    }
                    else
                    {
                        addresses.RemoveAt(i);
                    }

                    refresh = true;
                }
            }

            if (refresh)
                RefreshItems();
        }

        private void NetworkChange_NetworkAddressChanged(object sender, System.EventArgs e)
        {
            RefreshNetworkInterfaces();
        }
    }
}
