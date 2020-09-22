namespace PortVeederRootGaugeSim
{
    partial class GaugeSetup
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
            this.introText = new System.Windows.Forms.Label();
            this.safeWorkingCapacityBox = new System.Windows.Forms.GroupBox();
            this.capacity95 = new System.Windows.Forms.RadioButton();
            this.capacity90 = new System.Windows.Forms.RadioButton();
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tankCapacityLabel = new System.Windows.Forms.Label();
            this.overfillLimitText = new System.Windows.Forms.TextBox();
            this.highLimitText = new System.Windows.Forms.TextBox();
            this.deliveryWarningText = new System.Windows.Forms.TextBox();
            this.lowLimitText = new System.Windows.Forms.TextBox();
            this.waterWarningText = new System.Windows.Forms.TextBox();
            this.waterAlarmText = new System.Windows.Forms.TextBox();
            this.safeWorkingCapacityLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.overfillLimitLabel = new System.Windows.Forms.Label();
            this.highLimitLabel = new System.Windows.Forms.Label();
            this.deliveryWarningLabel = new System.Windows.Forms.Label();
            this.lowLimitLabel = new System.Windows.Forms.Label();
            this.waterAlarmLabel = new System.Windows.Forms.Label();
            this.waterWarningLabel = new System.Windows.Forms.Label();
            this.tankDiameterText = new System.Windows.Forms.TextBox();
            this.tankHeightText = new System.Windows.Forms.TextBox();
            this.tankDiameterLabel = new System.Windows.Forms.Label();
            this.tankLengthLabel = new System.Windows.Forms.Label();
            this.tankVolumeText = new System.Windows.Forms.Label();
            this.safeWorkingCapacityText = new System.Windows.Forms.Label();
            this.safeWorkingCapacityBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // introText
            // 
            this.introText.AutoSize = true;
            this.introText.Location = new System.Drawing.Point(11, 10);
            this.introText.Name = "introText";
            this.introText.Size = new System.Drawing.Size(339, 15);
            this.introText.TabIndex = 0;
            this.introText.Text = "The following configurations apply to all tanks being simulated";
            // 
            // safeWorkingCapacityBox
            // 
            this.safeWorkingCapacityBox.Controls.Add(this.capacity95);
            this.safeWorkingCapacityBox.Controls.Add(this.capacity90);
            this.safeWorkingCapacityBox.Location = new System.Drawing.Point(11, 34);
            this.safeWorkingCapacityBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.safeWorkingCapacityBox.Name = "safeWorkingCapacityBox";
            this.safeWorkingCapacityBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.safeWorkingCapacityBox.Size = new System.Drawing.Size(332, 80);
            this.safeWorkingCapacityBox.TabIndex = 1;
            this.safeWorkingCapacityBox.TabStop = false;
            this.safeWorkingCapacityBox.Text = "Level to use for Safe Working Capacity (Ullage)";
            // 
            // capacity95
            // 
            this.capacity95.AutoSize = true;
            this.capacity95.Location = new System.Drawing.Point(22, 49);
            this.capacity95.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.capacity95.Name = "capacity95";
            this.capacity95.Size = new System.Drawing.Size(110, 19);
            this.capacity95.TabIndex = 1;
            this.capacity95.TabStop = true;
            this.capacity95.Text = "95% of Capacity";
            this.capacity95.UseVisualStyleBackColor = true;
            this.capacity95.CheckedChanged += new System.EventHandler(this.Capacity95_CheckedChanged);
            // 
            // capacity90
            // 
            this.capacity90.AutoSize = true;
            this.capacity90.Location = new System.Drawing.Point(22, 20);
            this.capacity90.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.capacity90.Name = "capacity90";
            this.capacity90.Size = new System.Drawing.Size(110, 19);
            this.capacity90.TabIndex = 0;
            this.capacity90.TabStop = true;
            this.capacity90.Text = "90% of Capacity";
            this.capacity90.UseVisualStyleBackColor = true;
            this.capacity90.CheckedChanged += new System.EventHandler(this.Capacity90_CheckedChanged);
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(372, 375);
            this.okayButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(85, 29);
            this.okayButton.TabIndex = 2;
            this.okayButton.Text = "OK";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(463, 375);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 29);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // tankCapacityLabel
            // 
            this.tankCapacityLabel.AutoSize = true;
            this.tankCapacityLabel.Location = new System.Drawing.Point(100, 120);
            this.tankCapacityLabel.Name = "tankCapacityLabel";
            this.tankCapacityLabel.Size = new System.Drawing.Size(74, 15);
            this.tankCapacityLabel.TabIndex = 4;
            this.tankCapacityLabel.Text = "Tank Volume";
            // 
            // overfillLimitText
            // 
            this.overfillLimitText.Location = new System.Drawing.Point(187, 159);
            this.overfillLimitText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.overfillLimitText.Name = "overfillLimitText";
            this.overfillLimitText.Size = new System.Drawing.Size(156, 23);
            this.overfillLimitText.TabIndex = 5;
            // 
            // highLimitText
            // 
            this.highLimitText.Location = new System.Drawing.Point(187, 184);
            this.highLimitText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.highLimitText.Name = "highLimitText";
            this.highLimitText.Size = new System.Drawing.Size(156, 23);
            this.highLimitText.TabIndex = 5;
            // 
            // deliveryWarningText
            // 
            this.deliveryWarningText.Location = new System.Drawing.Point(187, 208);
            this.deliveryWarningText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deliveryWarningText.Name = "deliveryWarningText";
            this.deliveryWarningText.Size = new System.Drawing.Size(156, 23);
            this.deliveryWarningText.TabIndex = 5;
            // 
            // lowLimitText
            // 
            this.lowLimitText.Location = new System.Drawing.Point(187, 233);
            this.lowLimitText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lowLimitText.Name = "lowLimitText";
            this.lowLimitText.Size = new System.Drawing.Size(156, 23);
            this.lowLimitText.TabIndex = 5;
            // 
            // waterWarningText
            // 
            this.waterWarningText.Location = new System.Drawing.Point(187, 315);
            this.waterWarningText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.waterWarningText.Name = "waterWarningText";
            this.waterWarningText.Size = new System.Drawing.Size(156, 23);
            this.waterWarningText.TabIndex = 5;
            // 
            // waterAlarmText
            // 
            this.waterAlarmText.Location = new System.Drawing.Point(187, 288);
            this.waterAlarmText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.waterAlarmText.Name = "waterAlarmText";
            this.waterAlarmText.Size = new System.Drawing.Size(156, 23);
            this.waterAlarmText.TabIndex = 5;
            // 
            // safeWorkingCapacityLabel
            // 
            this.safeWorkingCapacityLabel.AutoSize = true;
            this.safeWorkingCapacityLabel.Location = new System.Drawing.Point(60, 142);
            this.safeWorkingCapacityLabel.Name = "safeWorkingCapacityLabel";
            this.safeWorkingCapacityLabel.Size = new System.Drawing.Size(126, 15);
            this.safeWorkingCapacityLabel.TabIndex = 6;
            this.safeWorkingCapacityLabel.Text = "Safe Working Capacity";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(5, 256);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(306, 30);
            this.noteLabel.TabIndex = 7;
            this.noteLabel.Text = "NOTE: Fuel draw off level is usually between the low limit\r\nand high water alarm " +
    "levels\r\n";
            // 
            // overfillLimitLabel
            // 
            this.overfillLimitLabel.AutoSize = true;
            this.overfillLimitLabel.Location = new System.Drawing.Point(100, 161);
            this.overfillLimitLabel.Name = "overfillLimitLabel";
            this.overfillLimitLabel.Size = new System.Drawing.Size(75, 15);
            this.overfillLimitLabel.TabIndex = 8;
            this.overfillLimitLabel.Text = "Overfill Limit";
            // 
            // highLimitLabel
            // 
            this.highLimitLabel.AutoSize = true;
            this.highLimitLabel.Location = new System.Drawing.Point(114, 186);
            this.highLimitLabel.Name = "highLimitLabel";
            this.highLimitLabel.Size = new System.Drawing.Size(63, 15);
            this.highLimitLabel.TabIndex = 9;
            this.highLimitLabel.Text = "High Limit";
            // 
            // deliveryWarningLabel
            // 
            this.deliveryWarningLabel.AutoSize = true;
            this.deliveryWarningLabel.Location = new System.Drawing.Point(19, 211);
            this.deliveryWarningLabel.Name = "deliveryWarningLabel";
            this.deliveryWarningLabel.Size = new System.Drawing.Size(147, 15);
            this.deliveryWarningLabel.TabIndex = 10;
            this.deliveryWarningLabel.Text = "Delivery Required Warning";
            // 
            // lowLimitLabel
            // 
            this.lowLimitLabel.AutoSize = true;
            this.lowLimitLabel.Location = new System.Drawing.Point(110, 236);
            this.lowLimitLabel.Name = "lowLimitLabel";
            this.lowLimitLabel.Size = new System.Drawing.Size(59, 15);
            this.lowLimitLabel.TabIndex = 11;
            this.lowLimitLabel.Text = "Low Limit";
            // 
            // waterAlarmLabel
            // 
            this.waterAlarmLabel.AutoSize = true;
            this.waterAlarmLabel.Location = new System.Drawing.Point(38, 290);
            this.waterAlarmLabel.Name = "waterAlarmLabel";
            this.waterAlarmLabel.Size = new System.Drawing.Size(132, 15);
            this.waterAlarmLabel.TabIndex = 12;
            this.waterAlarmLabel.Text = "High Water Alarm Limit";
            // 
            // waterWarningLabel
            // 
            this.waterWarningLabel.AutoSize = true;
            this.waterWarningLabel.Location = new System.Drawing.Point(24, 317);
            this.waterWarningLabel.Name = "waterWarningLabel";
            this.waterWarningLabel.Size = new System.Drawing.Size(145, 15);
            this.waterWarningLabel.TabIndex = 12;
            this.waterWarningLabel.Text = "High Water Warning Limit";
            // 
            // tankDiameterText
            // 
            this.tankDiameterText.Location = new System.Drawing.Point(187, 354);
            this.tankDiameterText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tankDiameterText.Name = "tankDiameterText";
            this.tankDiameterText.Size = new System.Drawing.Size(156, 23);
            this.tankDiameterText.TabIndex = 5;
            this.tankDiameterText.TextChanged += new System.EventHandler(this.TankDiameterText_TextChanged);
            // 
            // tankHeightText
            // 
            this.tankHeightText.Location = new System.Drawing.Point(187, 381);
            this.tankHeightText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tankHeightText.Name = "tankHeightText";
            this.tankHeightText.Size = new System.Drawing.Size(156, 23);
            this.tankHeightText.TabIndex = 5;
            this.tankHeightText.TextChanged += new System.EventHandler(this.TankHeightText_TextChanged);
            // 
            // tankDiameterLabel
            // 
            this.tankDiameterLabel.AutoSize = true;
            this.tankDiameterLabel.Location = new System.Drawing.Point(84, 357);
            this.tankDiameterLabel.Name = "tankDiameterLabel";
            this.tankDiameterLabel.Size = new System.Drawing.Size(82, 15);
            this.tankDiameterLabel.TabIndex = 12;
            this.tankDiameterLabel.Text = "Tank Diameter";
            // 
            // tankLengthLabel
            // 
            this.tankLengthLabel.AutoSize = true;
            this.tankLengthLabel.Location = new System.Drawing.Point(96, 384);
            this.tankLengthLabel.Name = "tankLengthLabel";
            this.tankLengthLabel.Size = new System.Drawing.Size(71, 15);
            this.tankLengthLabel.TabIndex = 12;
            this.tankLengthLabel.Text = "Tank Length";
            // 
            // tankVolumeText
            // 
            this.tankVolumeText.AutoSize = true;
            this.tankVolumeText.Location = new System.Drawing.Point(187, 120);
            this.tankVolumeText.Name = "tankVolumeText";
            this.tankVolumeText.Size = new System.Drawing.Size(39, 15);
            this.tankVolumeText.TabIndex = 13;
            this.tankVolumeText.Text = "*VOL*";
            // 
            // safeWorkingCapacityText
            // 
            this.safeWorkingCapacityText.AutoSize = true;
            this.safeWorkingCapacityText.Location = new System.Drawing.Point(193, 139);
            this.safeWorkingCapacityText.Name = "safeWorkingCapacityText";
            this.safeWorkingCapacityText.Size = new System.Drawing.Size(42, 15);
            this.safeWorkingCapacityText.TabIndex = 14;
            this.safeWorkingCapacityText.Text = "*SWC*";
            // 
            // GaugeSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 414);
            this.Controls.Add(this.safeWorkingCapacityText);
            this.Controls.Add(this.tankVolumeText);
            this.Controls.Add(this.tankLengthLabel);
            this.Controls.Add(this.tankDiameterLabel);
            this.Controls.Add(this.tankHeightText);
            this.Controls.Add(this.tankDiameterText);
            this.Controls.Add(this.waterWarningLabel);
            this.Controls.Add(this.waterAlarmLabel);
            this.Controls.Add(this.lowLimitLabel);
            this.Controls.Add(this.deliveryWarningLabel);
            this.Controls.Add(this.highLimitLabel);
            this.Controls.Add(this.overfillLimitLabel);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.safeWorkingCapacityLabel);
            this.Controls.Add(this.waterAlarmText);
            this.Controls.Add(this.waterWarningText);
            this.Controls.Add(this.lowLimitText);
            this.Controls.Add(this.deliveryWarningText);
            this.Controls.Add(this.highLimitText);
            this.Controls.Add(this.overfillLimitText);
            this.Controls.Add(this.tankCapacityLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.safeWorkingCapacityBox);
            this.Controls.Add(this.introText);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GaugeSetup";
            this.Text = "Gauge Setup & Alarm Levels";
            this.safeWorkingCapacityBox.ResumeLayout(false);
            this.safeWorkingCapacityBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label introText;
        private System.Windows.Forms.GroupBox safeWorkingCapacityBox;
        private System.Windows.Forms.RadioButton capacity95;
        private System.Windows.Forms.RadioButton capacity90;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label tankCapacityLabel;
        private System.Windows.Forms.TextBox overfillLimitText;
        private System.Windows.Forms.TextBox highLimitText;
        private System.Windows.Forms.TextBox deliveryWarningText;
        private System.Windows.Forms.TextBox lowLimitText;
        private System.Windows.Forms.TextBox waterWarningText;
        private System.Windows.Forms.TextBox waterAlarmText;
        private System.Windows.Forms.Label safeWorkingCapacityLabel;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Label overfillLimitLabel;
        private System.Windows.Forms.Label highLimitLabel;
        private System.Windows.Forms.Label deliveryWarningLabel;
        private System.Windows.Forms.Label lowLimitLabel;
        private System.Windows.Forms.Label waterAlarmLabel;
        private System.Windows.Forms.Label waterWarningLabel;
        private System.Windows.Forms.TextBox tankDiameterText;
        private System.Windows.Forms.TextBox tankHeightText;
        private System.Windows.Forms.Label tankDiameterLabel;
        private System.Windows.Forms.Label tankLengthLabel;
        private System.Windows.Forms.Label tankVolumeText;
        private System.Windows.Forms.Label safeWorkingCapacityText;
    }
}