using Common;
using DesktopBridge;
using Microsoft.Win32;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace NotificationTool
{
    [MainForm(Name="Notification Tool")]
    public partial class MainForm : Form
    {
        private bool quitCalled = false;

        public MainForm()
        {
            InitializeComponent();
            this.Deactivate += MainForm_Deactivate;
            CheckStartUp();
        }

        private void CheckStartUp()
        {
            Helpers helpers = new Helpers();
            if (helpers.IsRunningAsUwp())
            {
                runAtStartup.Checked = false;
                runAtStartup.Enabled = false;
            }
            else
            {
                SetStartup();
            }
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!quitCalled && e.CloseReason == CloseReason.UserClosing && runInBackground.Checked)
            {
                e.Cancel = true;
                notifyIcon.ShowBalloonTip(0, this.Text, backgroundTip.Text, ToolTipIcon.Info);
                Hide();
            }
            else
            {
                notifyIcon.Visible = false;
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            quitCalled = true;
            Close();
        }

        private void RunInBackground_CheckedChanged(object sender, EventArgs e)
        {
            backgroundTip.Enabled = runInBackground.Checked;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Visible = true;
            ShowInTaskbar = true;
            Activate();
        }

        private void PeriodicNotification_CheckedChanged(object sender, EventArgs e)
        {
            timer.Enabled = periodicNotification.Checked;
        }

        private void Period_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = (int) period.Value * 1000;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(0, this.Text, periodicTip.Text, ToolTipIcon.Warning);
        }

        private void RunAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            SetStartup();
        }

        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (runAtStartup.Checked)
            {
                rk.SetValue(this.Text, Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                rk.DeleteValue(this.Text, false);
            }
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs && ((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                OpenToolStripMenuItem_Click(sender, e);
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            TaskBar.Dock(this);
        }
    }
}
