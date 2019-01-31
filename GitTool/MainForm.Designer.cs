using System.Windows.Forms;

namespace GitTool
{
    public partial class MainForm : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.clone = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clipboard = new System.Windows.Forms.Button();
            this.gitFolders = new System.Windows.Forms.ListBox();
            this.browse = new System.Windows.Forms.Button();
            this.scan = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cheats = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.run = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.TextBox();
            this.rootFolder = new System.Windows.Forms.TextBox();
            this.command = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.clone);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.clipboard);
            this.splitContainer1.Panel1.Controls.Add(this.gitFolders);
            this.splitContainer1.Panel1.Controls.Add(this.browse);
            this.splitContainer1.Panel1.Controls.Add(this.scan);
            this.splitContainer1.Panel1.Controls.Add(this.rootFolder);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(805, 450);
            this.splitContainer1.SplitterDistance = 353;
            this.splitContainer1.TabIndex = 14;
            // 
            // clone
            // 
            this.clone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clone.Location = new System.Drawing.Point(192, 52);
            this.clone.Name = "clone";
            this.clone.Size = new System.Drawing.Size(75, 23);
            this.clone.TabIndex = 13;
            this.clone.Text = "Clone...";
            this.clone.UseVisualStyleBackColor = true;
            this.clone.Click += new System.EventHandler(this.clone_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Select Git repositories";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Specify root folder";
            // 
            // clipboard
            // 
            this.clipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clipboard.Location = new System.Drawing.Point(222, 422);
            this.clipboard.Name = "clipboard";
            this.clipboard.Size = new System.Drawing.Size(125, 23);
            this.clipboard.TabIndex = 15;
            this.clipboard.Text = "Copy to Clipboard";
            this.clipboard.UseVisualStyleBackColor = true;
            this.clipboard.Click += new System.EventHandler(this.clipboard_Click);
            // 
            // gitFolders
            // 
            this.gitFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gitFolders.DataBindings.Add(new System.Windows.Forms.Binding("Tag", global::GitTool.Properties.Settings.Default, "selectedGitFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gitFolders.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gitFolders.FormattingEnabled = true;
            this.gitFolders.IntegralHeight = false;
            this.gitFolders.Location = new System.Drawing.Point(6, 93);
            this.gitFolders.Name = "gitFolders";
            this.gitFolders.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.gitFolders.Size = new System.Drawing.Size(341, 323);
            this.gitFolders.Sorted = true;
            this.gitFolders.TabIndex = 14;
            this.gitFolders.Tag = global::GitTool.Properties.Settings.Default.selectedGitFolder;
            this.gitFolders.SelectedIndexChanged += new System.EventHandler(this.gitFolders_SelectedIndexChanged);
            // 
            // browse
            // 
            this.browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browse.Location = new System.Drawing.Point(192, 23);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 11;
            this.browse.Text = "Browse...";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // scan
            // 
            this.scan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scan.Location = new System.Drawing.Point(272, 23);
            this.scan.Name = "scan";
            this.scan.Size = new System.Drawing.Size(75, 23);
            this.scan.TabIndex = 12;
            this.scan.Text = "Scan...";
            this.scan.UseVisualStyleBackColor = true;
            this.scan.Click += new System.EventHandler(this.scan_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cheats);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.run);
            this.splitContainer2.Panel1.Controls.Add(this.command);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.clear);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.log);
            this.splitContainer2.Size = new System.Drawing.Size(448, 450);
            this.splitContainer2.SplitterDistance = 110;
            this.splitContainer2.TabIndex = 20;
            // 
            // cheats
            // 
            this.cheats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cheats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cheats.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheats.FormattingEnabled = true;
            this.cheats.Location = new System.Drawing.Point(3, 85);
            this.cheats.Name = "cheats";
            this.cheats.Size = new System.Drawing.Size(359, 21);
            this.cheats.Sorted = true;
            this.cheats.TabIndex = 22;
            this.cheats.SelectedIndexChanged += new System.EventHandler(this.cheats_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Run command(s) on selected repositories";
            // 
            // run
            // 
            this.run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.run.Location = new System.Drawing.Point(368, 84);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(75, 23);
            this.run.TabIndex = 19;
            this.run.Text = "Run...";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // clear
            // 
            this.clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clear.Location = new System.Drawing.Point(368, 310);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 22;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Output";
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GitTool.Properties.Settings.Default, "output", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.log.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log.Location = new System.Drawing.Point(6, 19);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(437, 286);
            this.log.TabIndex = 20;
            this.log.Text = global::GitTool.Properties.Settings.Default.output;
            // 
            // rootFolder
            // 
            this.rootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rootFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GitTool.Properties.Settings.Default, "rootFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rootFolder.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootFolder.Location = new System.Drawing.Point(7, 24);
            this.rootFolder.Multiline = true;
            this.rootFolder.Name = "rootFolder";
            this.rootFolder.Size = new System.Drawing.Size(178, 50);
            this.rootFolder.TabIndex = 10;
            this.rootFolder.Text = global::GitTool.Properties.Settings.Default.rootFolder;
            this.rootFolder.TextChanged += new System.EventHandler(this.rootFolder_TextChanged);
            // 
            // command
            // 
            this.command.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.command.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GitTool.Properties.Settings.Default, "commands", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.command.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.command.Location = new System.Drawing.Point(3, 21);
            this.command.Multiline = true;
            this.command.Name = "command";
            this.command.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.command.Size = new System.Drawing.Size(440, 58);
            this.command.TabIndex = 18;
            this.command.Text = global::GitTool.Properties.Settings.Default.commands;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 450);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Git Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private SplitContainer splitContainer1;
        private Button clone;
        private Label label2;
        private Label label1;
        private Button clipboard;
        private ListBox gitFolders;
        private Button browse;
        private Button scan;
        private TextBox rootFolder;
        private SplitContainer splitContainer2;
        private Label label3;
        private Button run;
        private TextBox command;
        private Button clear;
        private Label label4;
        private TextBox log;
        private ComboBox cheats;
    }
}

