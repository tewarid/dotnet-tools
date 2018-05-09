using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Common
{
    public partial class InterfaceSelectorComboBox : UserControl
    {
        private ComboBox comboBox;
        private readonly string any = IPAddress.Any.ToString();

        public event Action<string> InterfaceDeleted;

        private bool includeIPAddressAny = false;
        public bool IncludeIPAddressAny
        {
            get
            {
                return includeIPAddressAny;
            }
            set
            {
                includeIPAddressAny = value;
                if (value)
                {
                    if (!comboBox.Items.Contains(any))
                    {
                        comboBox.Items.Add(any);
                    }
                }
            }
        }

        public InterfaceSelectorComboBox()
        {
            InitializeComponent();
            comboBox = new ComboBox();
            comboBox.Dock = DockStyle.Fill;
            Controls.Add(comboBox);
            this.Height = comboBox.Height;
            RefreshNetworkInterfaces();
            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
        }

        public void DeleteSelected()
        {
            comboBox.SelectedIndex =
                comboBox.SelectedIndex > 0 ? comboBox.SelectedIndex - 1 : -1;
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
                if (!comboBox.Items.Contains(address))
                {
                    // Added
                    comboBox.Items.Add(address);
                }
            }

            // Delete
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (!any.Equals(comboBox.Items[i]) && !newList.Contains((String)comboBox.Items[i]))
                {
                    // Removed
                    if (comboBox.SelectedIndex == i)
                    {
                        InterfaceDeleted?.Invoke((String)comboBox.Items[i]);
                    }
                    comboBox.Items.RemoveAt(i);
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
