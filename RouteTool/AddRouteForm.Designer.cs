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
            this.destinationAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.interfaces = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.routeMetric = new System.Windows.Forms.NumericUpDown();
            this.add = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nextHopIPAddress = new System.Windows.Forms.TextBox();
            this.destinationMask = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.routeMetric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Destination Address";
            // 
            // destinationAddress
            // 
            this.destinationAddress.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationAddress.Location = new System.Drawing.Point(16, 30);
            this.destinationAddress.Name = "destinationAddress";
            this.destinationAddress.Size = new System.Drawing.Size(170, 22);
            this.destinationAddress.TabIndex = 1;
            this.destinationAddress.Text = "0.0.0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 96);
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
            this.interfaces.Location = new System.Drawing.Point(16, 112);
            this.interfaces.Name = "interfaces";
            this.interfaces.Size = new System.Drawing.Size(434, 24);
            this.interfaces.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Route Metric";
            // 
            // routeMetric
            // 
            this.routeMetric.Location = new System.Drawing.Point(16, 197);
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
            100,
            0,
            0,
            0});
            // 
            // add
            // 
            this.add.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.add.Location = new System.Drawing.Point(293, 226);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 7;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(375, 226);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 8;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Next Hop";
            // 
            // nextHopIPAddress
            // 
            this.nextHopIPAddress.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.nextHopIPAddress.Location = new System.Drawing.Point(16, 156);
            this.nextHopIPAddress.Name = "nextHopIPAddress";
            this.nextHopIPAddress.Size = new System.Drawing.Size(120, 22);
            this.nextHopIPAddress.TabIndex = 4;
            this.nextHopIPAddress.Text = "0.0.0.0";
            // 
            // destinationMask
            // 
            this.destinationMask.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationMask.Location = new System.Drawing.Point(16, 71);
            this.destinationMask.Name = "destinationMask";
            this.destinationMask.Size = new System.Drawing.Size(170, 22);
            this.destinationMask.TabIndex = 2;
            this.destinationMask.Text = "255.255.255.255";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Destination Mask";
            // 
            // AddRouteForm
            // 
            this.AcceptButton = this.add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(464, 261);
            this.Controls.Add(this.destinationMask);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nextHopIPAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.add);
            this.Controls.Add(this.routeMetric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.interfaces);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.destinationAddress);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRouteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Route";
            this.Load += new System.EventHandler(this.AddRoute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.routeMetric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox destinationAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox interfaces;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown routeMetric;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nextHopIPAddress;
        private TextBox destinationMask;
        private Label label5;
    }
}