using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotificationTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenToolStripMenuItem_Click(sender, e);
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
    }
}
