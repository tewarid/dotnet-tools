using HidSharp;
using HidSharp.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HidTool
{
    public partial class MainForm : Form
    {
        List<HidDevice> hidDevices = new List<HidDevice>();
        HidDevice device;

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
            device = hidDevices[hidDevicesCombo.SelectedIndex];
            Task.Run(() =>
            {
                Read(device);
            });
        }

        private void Read(HidDevice device)
        {
            if (device == null)
            {
                return;
            }
            ReportDescriptor reportDescriptor;
            try
            {
                reportDescriptor = device.GetReportDescriptor();
            }
            catch (Exception ex)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    outputText.AppendText($"Read failed: {ex.Message}{Environment.NewLine}");
                }));
                return;
            }
            HidStream hidStream;
            if (!device.TryOpen(out hidStream))
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    outputText.AppendText($"Could not open stream.{Environment.NewLine}");
                }));
                return;
            }
            var inputReportBuffer = new byte[device.GetMaxInputReportLength()];
            var inputReceiver = reportDescriptor.CreateHidDeviceInputReceiver();
            inputReceiver.Start(hidStream);
            while (true)
            {
                if (!inputReceiver.WaitHandle.WaitOne(1000))
                {
                    continue; // timeout
                }
                if (!inputReceiver.IsRunning)
                {
                    break;
                } // Disconnected?
                Report report;
                while (inputReceiver.TryRead(inputReportBuffer, 0, out report))
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        ShowReceivedData(inputReportBuffer);
                    }));
                }
            }
            hidStream.Dispose();
            BeginInvoke(new MethodInvoker(() =>
            {
                outputText.AppendText($"Disconnected.{Environment.NewLine}");
            }));
        }
        private void ShowReceivedData(byte[] data)
        {
            outputText.AppendText($"{data.Length} bytes(s) received on {DateTime.Now}:{Environment.NewLine}");
            outputText.AppendBinary(data, data.Length);
            outputText.AppendText(Environment.NewLine);
            outputText.AppendText(Environment.NewLine);
        }

        private async void Send_Click(object sender, EventArgs e)
        {
            if (device == null)
            {
                return;
            }

            send.Enabled = false;

            byte[] data = input.BinaryValue;
            if (data.Length <= 0)
            {
                send.Enabled = true;
                MessageBox.Show(this, "Nothing to send.", this.Text);
                return;
            }

            HidStream hidStream;
            if (!device.TryOpen(out hidStream))
            {
                return;
            }

            int tickcount = Environment.TickCount;
            try
            {
                await hidStream.WriteAsync(data, 0, data.Length).ConfigureAwait(true);
            }
            catch (IOException ex)
            {
                send.Enabled = true;
                MessageBox.Show(this, ex.Message, this.Text);
                return;
            }
            finally
            {
                hidStream.Dispose();
            }
            tickcount = Environment.TickCount - tickcount;

            status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds",
                data.Length, tickcount);
            send.Enabled = true;
        }

        private void hidDevicesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            HidDevice device = hidDevices[hidDevicesCombo.SelectedIndex];
            outputText.AppendText(string.Format("Selected {0}, Serial Number {1}, Vendor ID 0x{2:X}, Product ID 0x{3:X}{4}",
                device.GetFriendlyName(), device.GetSerialNumber(), device.VendorID, device.ProductID, Environment.NewLine));
            ReportDescriptor reportDescriptor;
            try
            {
                reportDescriptor = device.GetReportDescriptor();
            }
            catch (Exception ex)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    outputText.AppendText($"Could not get report descriptor: {ex.Message}{Environment.NewLine}");
                }));
                return;
            }
            foreach (var deviceItem in reportDescriptor.DeviceItems)
            {
                foreach (var usage in deviceItem.Usages.GetAllValues())
                {
                    outputText.AppendText($"Usage: {usage:X4} {(Usage)usage}{Environment.NewLine}");
                }
                foreach (var report in deviceItem.Reports)
                {
                    outputText.AppendText(string.Format("{0}: ReportID={1}, Length={2}, Items={3}{4}",
                                        report.ReportType, report.ReportID, report.Length,
                                        report.DataItems.Count, Environment.NewLine));
                    foreach (var dataItem in report.DataItems)
                    {
                        outputText.AppendText(string.Format("  {0} Elements x {1} Bits, Units: {2}, Expected Usage Type: {3}, Flags: {4}, Usages: {5}{6}",
                            dataItem.ElementCount, dataItem.ElementBits, dataItem.Unit.System, dataItem.ExpectedUsageType, dataItem.Flags,
                            string.Join(", ", dataItem.Usages.GetAllValues().Select(usage => usage.ToString("X4") + " " + ((Usage)usage).ToString())),
                            Environment.NewLine));
                    }
                }
            }
            outputText.AppendText(Environment.NewLine);
        }
    }
}
