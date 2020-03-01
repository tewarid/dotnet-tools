namespace NotificationTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quit = new System.Windows.Forms.ToolStripMenuItem();
            this.runInBackground = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundTip = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.periodicNotification = new System.Windows.Forms.CheckBox();
            this.period = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.periodicTip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.runAtStartup = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.period)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Notification Tool";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.quit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // quit
            // 
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(103, 22);
            this.quit.Text = "Quit";
            this.quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // runInBackground
            // 
            this.runInBackground.AutoSize = true;
            this.runInBackground.Checked = true;
            this.runInBackground.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runInBackground.Location = new System.Drawing.Point(12, 12);
            this.runInBackground.Name = "runInBackground";
            this.runInBackground.Size = new System.Drawing.Size(180, 17);
            this.runInBackground.TabIndex = 0;
            this.runInBackground.Text = "Run in background when closed";
            this.runInBackground.UseVisualStyleBackColor = true;
            this.runInBackground.CheckedChanged += new System.EventHandler(this.RunInBackground_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tip when minimizing to background";
            // 
            // backgroundTip
            // 
            this.backgroundTip.Location = new System.Drawing.Point(15, 48);
            this.backgroundTip.Name = "backgroundTip";
            this.backgroundTip.Size = new System.Drawing.Size(557, 20);
            this.backgroundTip.TabIndex = 2;
            this.backgroundTip.Text = "Notification Tool is now running in the background and can be accessed using the " +
    "tray icon.";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 600000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // periodicNotification
            // 
            this.periodicNotification.AutoSize = true;
            this.periodicNotification.Checked = true;
            this.periodicNotification.CheckState = System.Windows.Forms.CheckState.Checked;
            this.periodicNotification.Location = new System.Drawing.Point(15, 75);
            this.periodicNotification.Name = "periodicNotification";
            this.periodicNotification.Size = new System.Drawing.Size(152, 17);
            this.periodicNotification.TabIndex = 3;
            this.periodicNotification.Text = "Show periodic notifications";
            this.periodicNotification.UseVisualStyleBackColor = true;
            this.periodicNotification.CheckedChanged += new System.EventHandler(this.PeriodicNotification_CheckedChanged);
            // 
            // period
            // 
            this.period.Location = new System.Drawing.Point(52, 98);
            this.period.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.period.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.period.Name = "period";
            this.period.Size = new System.Drawing.Size(86, 20);
            this.period.TabIndex = 4;
            this.period.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.period.ValueChanged += new System.EventHandler(this.Period_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Every";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "seconds";
            // 
            // periodicTip
            // 
            this.periodicTip.Location = new System.Drawing.Point(15, 137);
            this.periodicTip.Name = "periodicTip";
            this.periodicTip.Size = new System.Drawing.Size(557, 20);
            this.periodicTip.TabIndex = 8;
            this.periodicTip.Text = "Remember to blink your eyes!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tip for periodic notification";
            // 
            // runAtStartup
            // 
            this.runAtStartup.AutoSize = true;
            this.runAtStartup.Checked = true;
            this.runAtStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runAtStartup.Location = new System.Drawing.Point(12, 164);
            this.runAtStartup.Name = "runAtStartup";
            this.runAtStartup.Size = new System.Drawing.Size(93, 17);
            this.runAtStartup.TabIndex = 9;
            this.runAtStartup.Text = "Run at startup";
            this.runAtStartup.UseVisualStyleBackColor = true;
            this.runAtStartup.CheckedChanged += new System.EventHandler(this.RunAtStartup_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 198);
            this.Controls.Add(this.runAtStartup);
            this.Controls.Add(this.periodicTip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.period);
            this.Controls.Add(this.periodicNotification);
            this.Controls.Add(this.backgroundTip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runInBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Notification Tool";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.period)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox runInBackground;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox backgroundTip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem quit;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox periodicNotification;
        private System.Windows.Forms.NumericUpDown period;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox periodicTip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox runAtStartup;
    }
}

