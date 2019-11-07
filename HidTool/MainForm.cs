using HidSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HidTool
{
    public partial class MainForm : Form
    {
        List<HidDevice> hidDevices = new List<HidDevice>();
        HidStream stream;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DeviceList.Local.Changed += DeviceListChanged;
            RefreshDevices();
        }

        private void DeviceListChanged(object sender, DeviceListChangedEventArgs e)
        {
            RefreshDevices();
        }

        private void RefreshDevices()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    RefreshDevices();
                }));
                return;
            }
            hidDevicesCombo.Items.Clear();
            hidDevices.Clear();
            foreach (HidDevice device in DeviceList.Local.GetHidDevices())
            {
                hidDevicesCombo.Items.Add($"{device.GetFriendlyName()} [{device.GetSerialNumber()}] [VID 0x{device.VendorID:X}] [PID 0x{device.ProductID:X}]");
                hidDevices.Add(device);
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshDevices();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (hidDevicesCombo.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select a HID device in the list.");
                return;
            }
            if (!hidDevices[hidDevicesCombo.SelectedIndex].TryOpen(out stream))
            {
                MessageBox.Show(this, "Could not open HID stream. Device may be in use.");
            }
        }
    }
}
