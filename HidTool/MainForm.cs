using HidSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HidTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (HidDevice device in DeviceList.Local.GetHidDevices())
            {
                hidDevicesCombo.Items.Add(device.GetFriendlyName());
            }
        }
    }
}
