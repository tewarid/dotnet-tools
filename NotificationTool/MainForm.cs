using Common;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace NotificationTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetStartup();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && runInBackground.Checked)
            {
                e.Cancel = true;
                ShowInTaskbar = false;
                Visible = false;
                notifyIcon.ShowBalloonTip(0, this.Text, backgroundTip.Text, ToolTipIcon.Info);
            }
            else
            {
                notifyIcon.Visible = false;
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                rk.SetValue(this.Text, Application.ExecutablePath);
            }
            else
            {
                rk.DeleteValue(this.Text, false);
            }
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            OpenToolStripMenuItem_Click(sender, e);
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            OpenToolStripMenuItem_Click(sender, e);
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            TaskBar.Dock(this);
        }
    }
}
