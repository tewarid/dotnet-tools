using System.Windows.Forms;

namespace RouteTool
{
    public partial class AddRouteForm : Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.destinationPrefix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.interfaces = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.routeMetric = new System.Windows.Forms.NumericUpDown();
            this.add = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.persistent = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nextHopIPAddress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.routeMetric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Destination Prefix";
            // 
            // destinationPrefix
            // 
            this.destinationPrefix.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationPrefix.Location = new System.Drawing.Point(16, 30);
            this.destinationPrefix.Name = "destinationPrefix";
            this.destinationPrefix.Size = new System.Drawing.Size(170, 22);
            this.destinationPrefix.TabIndex = 1;
            this.destinationPrefix.Text = "0.0.0.0/8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Interface";
            // 
            // interfaces
            // 
            this.interfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interfaces.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfaces.FormattingEnabled = true;
            this.interfaces.Location = new System.Drawing.Point(16, 71);
            this.interfaces.Name = "interfaces";
            this.interfaces.Size = new System.Drawing.Size(351, 24);
            this.interfaces.TabIndex = 3;
            this.interfaces.SelectedIndexChanged += new System.EventHandler(this.Interfaces_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Route Metric";
            // 
            // routeMetric
            // 
            this.routeMetric.Location = new System.Drawing.Point(16, 156);
            this.routeMetric.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.routeMetric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.routeMetric.Name = "routeMetric";
            this.routeMetric.Size = new System.Drawing.Size(120, 20);
            this.routeMetric.TabIndex = 5;
            this.routeMetric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // add
            // 
            this.add.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.add.Location = new System.Drawing.Point(210, 192);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 7;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(292, 192);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 8;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // persistent
            // 
            this.persistent.AutoSize = true;
            this.persistent.Location = new System.Drawing.Point(16, 182);
            this.persistent.Name = "persistent";
            this.persistent.Size = new System.Drawing.Size(72, 17);
            this.persistent.TabIndex = 6;
            this.persistent.Text = "Persistent";
            this.persistent.UseVisualStyleBackColor = true;
            this.persistent.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Next Hop";
            // 
            // nextHopIPAddress
            // 
            this.nextHopIPAddress.Location = new System.Drawing.Point(16, 115);
            this.nextHopIPAddress.Name = "nextHopIPAddress";
            this.nextHopIPAddress.Size = new System.Drawing.Size(120, 20);
            this.nextHopIPAddress.TabIndex = 4;
            // 
            // AddRoute
            // 
            this.AcceptButton = this.add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(379, 244);
            this.Controls.Add(this.nextHopIPAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.persistent);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.add);
            this.Controls.Add(this.routeMetric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.interfaces);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.destinationPrefix);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Route";
            this.Load += new System.EventHandler(this.AddRoute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.routeMetric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox destinationPrefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox interfaces;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown routeMetric;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.CheckBox persistent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nextHopIPAddress;
    }
}