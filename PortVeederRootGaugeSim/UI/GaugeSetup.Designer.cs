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
            this.overfillLimit = new System.Windows.Forms.NumericUpDown();
            this.highLimit = new System.Windows.Forms.NumericUpDown();
            this.deliveryWarning = new System.Windows.Forms.NumericUpDown();
            this.lowLimit = new System.Windows.Forms.NumericUpDown();
            this.waterWarning = new System.Windows.Forms.NumericUpDown();
            this.waterAlarm = new System.Windows.Forms.NumericUpDown();
            this.safeWorkingCapacityLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.overfillLimitLabel = new System.Windows.Forms.Label();
            this.highLimitLabel = new System.Windows.Forms.Label();
            this.deliveryWarningLabel = new System.Windows.Forms.Label();
            this.lowLimitLabel = new System.Windows.Forms.Label();
            this.waterAlarmLabel = new System.Windows.Forms.Label();
            this.waterWarningLabel = new System.Windows.Forms.Label();
            this.tankDiameter = new System.Windows.Forms.NumericUpDown();
            this.tankLength = new System.Windows.Forms.NumericUpDown();
            this.tankDiameterLabel = new System.Windows.Forms.Label();
            this.tankLengthLabel = new System.Windows.Forms.Label();
            this.tankVolume = new System.Windows.Forms.Label();
            this.safeWorkingCapacity = new System.Windows.Forms.Label();
            this.safeWorkingCapacityBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overfillLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankLength)).BeginInit();
            this.SuspendLayout();
            // 
            // introText
            // 
            this.introText.AutoSize = true;
            this.introText.Location = new System.Drawing.Point(13, 13);
            this.introText.Name = "introText";
            this.introText.Size = new System.Drawing.Size(427, 20);
            this.introText.TabIndex = 20;
            this.introText.Text = "The following configurations apply to all tanks being simulated";
            // 
            // safeWorkingCapacityBox
            // 
            this.safeWorkingCapacityBox.Controls.Add(this.capacity95);
            this.safeWorkingCapacityBox.Controls.Add(this.capacity90);
            this.safeWorkingCapacityBox.Location = new System.Drawing.Point(13, 45);
            this.safeWorkingCapacityBox.Name = "safeWorkingCapacityBox";
            this.safeWorkingCapacityBox.Size = new System.Drawing.Size(379, 107);
            this.safeWorkingCapacityBox.TabIndex = 19;
            this.safeWorkingCapacityBox.TabStop = false;
            this.safeWorkingCapacityBox.Text = "Level to use for Safe Working Capacity (Ullage)";
            // 
            // capacity95
            // 
            this.capacity95.AutoSize = true;
            this.capacity95.Location = new System.Drawing.Point(25, 65);
            this.capacity95.Name = "capacity95";
            this.capacity95.Size = new System.Drawing.Size(137, 24);
            this.capacity95.TabIndex = 1;
            this.capacity95.TabStop = true;
            this.capacity95.Text = "95% of Capacity";
            this.capacity95.UseVisualStyleBackColor = true;
            this.capacity95.CheckedChanged += new System.EventHandler(this.Capacity95_CheckedChanged);
            // 
            // capacity90
            // 
            this.capacity90.AutoSize = true;
            this.capacity90.Location = new System.Drawing.Point(25, 27);
            this.capacity90.Name = "capacity90";
            this.capacity90.Size = new System.Drawing.Size(137, 24);
            this.capacity90.TabIndex = 0;
            this.capacity90.TabStop = true;
            this.capacity90.Text = "90% of Capacity";
            this.capacity90.UseVisualStyleBackColor = true;
            this.capacity90.CheckedChanged += new System.EventHandler(this.Capacity90_CheckedChanged);
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(425, 500);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(97, 39);
            this.okayButton.TabIndex = 10;
            this.okayButton.Text = "OK";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(529, 500);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(99, 39);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // tankCapacityLabel
            // 
            this.tankCapacityLabel.AutoSize = true;
            this.tankCapacityLabel.Location = new System.Drawing.Point(115, 160);
            this.tankCapacityLabel.Name = "tankCapacityLabel";
            this.tankCapacityLabel.Size = new System.Drawing.Size(92, 20);
            this.tankCapacityLabel.TabIndex = 18;
            this.tankCapacityLabel.Text = "Tank Volume";
            // 
            // overfillLimitText
            // 
            this.overfillLimit.Location = new System.Drawing.Point(214, 212);
            this.overfillLimit.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.overfillLimit.Name = "overfillLimitText";
            this.overfillLimit.Size = new System.Drawing.Size(178, 27);
            this.overfillLimit.TabIndex = 2;
            this.overfillLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // highLimitText
            // 
            this.highLimit.Location = new System.Drawing.Point(214, 245);
            this.highLimit.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.highLimit.Name = "highLimitText";
            this.highLimit.Size = new System.Drawing.Size(178, 27);
            this.highLimit.TabIndex = 3;
            this.highLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // deliveryWarningText
            // 
            this.deliveryWarning.Location = new System.Drawing.Point(214, 277);
            this.deliveryWarning.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.deliveryWarning.Name = "deliveryWarningText";
            this.deliveryWarning.Size = new System.Drawing.Size(178, 27);
            this.deliveryWarning.TabIndex = 4;
            this.deliveryWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lowLimitText
            // 
            this.lowLimit.Location = new System.Drawing.Point(214, 311);
            this.lowLimit.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.lowLimit.Name = "lowLimitText";
            this.lowLimit.Size = new System.Drawing.Size(178, 27);
            this.lowLimit.TabIndex = 5;
            this.lowLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // waterWarningText
            // 
            this.waterWarning.Location = new System.Drawing.Point(214, 420);
            this.waterWarning.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.waterWarning.Name = "waterWarningText";
            this.waterWarning.Size = new System.Drawing.Size(178, 27);
            this.waterWarning.TabIndex = 7;
            this.waterWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // waterAlarmText
            // 
            this.waterAlarm.Location = new System.Drawing.Point(214, 384);
            this.waterAlarm.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.waterAlarm.Name = "waterAlarmText";
            this.waterAlarm.Size = new System.Drawing.Size(178, 27);
            this.waterAlarm.TabIndex = 6;
            this.waterAlarm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // safeWorkingCapacityLabel
            // 
            this.safeWorkingCapacityLabel.AutoSize = true;
            this.safeWorkingCapacityLabel.Location = new System.Drawing.Point(49, 185);
            this.safeWorkingCapacityLabel.Name = "safeWorkingCapacityLabel";
            this.safeWorkingCapacityLabel.Size = new System.Drawing.Size(158, 20);
            this.safeWorkingCapacityLabel.TabIndex = 17;
            this.safeWorkingCapacityLabel.Text = "Safe Working Capacity";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(6, 341);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(386, 40);
            this.noteLabel.TabIndex = 16;
            this.noteLabel.Text = "NOTE: Fuel draw off level is usually between the low limit\r\nand high water alarm " +
    "levels\r\n";
            this.noteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // overfillLimitLabel
            // 
            this.overfillLimitLabel.AutoSize = true;
            this.overfillLimitLabel.Location = new System.Drawing.Point(114, 215);
            this.overfillLimitLabel.Name = "overfillLimitLabel";
            this.overfillLimitLabel.Size = new System.Drawing.Size(94, 20);
            this.overfillLimitLabel.TabIndex = 15;
            this.overfillLimitLabel.Text = "Overfill Limit";
            // 
            // highLimitLabel
            // 
            this.highLimitLabel.AutoSize = true;
            this.highLimitLabel.Location = new System.Drawing.Point(130, 248);
            this.highLimitLabel.Name = "highLimitLabel";
            this.highLimitLabel.Size = new System.Drawing.Size(78, 20);
            this.highLimitLabel.TabIndex = 14;
            this.highLimitLabel.Text = "High Limit";
            // 
            // deliveryWarningLabel
            // 
            this.deliveryWarningLabel.AutoSize = true;
            this.deliveryWarningLabel.Location = new System.Drawing.Point(22, 281);
            this.deliveryWarningLabel.Name = "deliveryWarningLabel";
            this.deliveryWarningLabel.Size = new System.Drawing.Size(186, 20);
            this.deliveryWarningLabel.TabIndex = 13;
            this.deliveryWarningLabel.Text = "Delivery Required Warning";
            // 
            // lowLimitLabel
            // 
            this.lowLimitLabel.AutoSize = true;
            this.lowLimitLabel.Location = new System.Drawing.Point(135, 314);
            this.lowLimitLabel.Name = "lowLimitLabel";
            this.lowLimitLabel.Size = new System.Drawing.Size(73, 20);
            this.lowLimitLabel.TabIndex = 12;
            this.lowLimitLabel.Text = "Low Limit";
            // 
            // waterAlarmLabel
            // 
            this.waterAlarmLabel.AutoSize = true;
            this.waterAlarmLabel.Location = new System.Drawing.Point(43, 387);
            this.waterAlarmLabel.Name = "waterAlarmLabel";
            this.waterAlarmLabel.Size = new System.Drawing.Size(165, 20);
            this.waterAlarmLabel.TabIndex = 11;
            this.waterAlarmLabel.Text = "High Water Alarm Limit";
            // 
            // waterWarningLabel
            // 
            this.waterWarningLabel.AutoSize = true;
            this.waterWarningLabel.Location = new System.Drawing.Point(27, 423);
            this.waterWarningLabel.Name = "waterWarningLabel";
            this.waterWarningLabel.Size = new System.Drawing.Size(180, 20);
            this.waterWarningLabel.TabIndex = 10;
            this.waterWarningLabel.Text = "High Water Warning Limit";
            // 
            // tankDiameterText
            // 
            this.tankDiameter.Location = new System.Drawing.Point(214, 472);
            this.tankDiameter.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.tankDiameter.Name = "tankDiameterText";
            this.tankDiameter.Size = new System.Drawing.Size(178, 27);
            this.tankDiameter.TabIndex = 8;
            this.tankDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tankDiameter.TextChanged += new System.EventHandler(this.TankDiameter_TextChanged);
            // 
            // tankLengthText
            // 
            this.tankLength.Location = new System.Drawing.Point(214, 508);
            this.tankLength.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.tankLength.Name = "tankLengthText";
            this.tankLength.Size = new System.Drawing.Size(178, 27);
            this.tankLength.TabIndex = 9;
            this.tankLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tankLength.TextChanged += new System.EventHandler(this.TankLength_TextChanged);
            // 
            // tankDiameterLabel
            // 
            this.tankDiameterLabel.AutoSize = true;
            this.tankDiameterLabel.Location = new System.Drawing.Point(104, 475);
            this.tankDiameterLabel.Name = "tankDiameterLabel";
            this.tankDiameterLabel.Size = new System.Drawing.Size(104, 20);
            this.tankDiameterLabel.TabIndex = 3;
            this.tankDiameterLabel.Text = "Tank Diameter";
            // 
            // tankLengthLabel
            // 
            this.tankLengthLabel.AutoSize = true;
            this.tankLengthLabel.Location = new System.Drawing.Point(120, 511);
            this.tankLengthLabel.Name = "tankLengthLabel";
            this.tankLengthLabel.Size = new System.Drawing.Size(87, 20);
            this.tankLengthLabel.TabIndex = 2;
            this.tankLengthLabel.Text = "Tank Length";
            // 
            // tankVolumeText
            // 
            this.tankVolume.Location = new System.Drawing.Point(214, 160);
            this.tankVolume.Name = "tankVolumeText";
            this.tankVolume.Size = new System.Drawing.Size(178, 27);
            this.tankVolume.TabIndex = 1;
            this.tankVolume.Text = "*VOL*";
            // 
            // safeWorkingCapacityText
            // 
            this.safeWorkingCapacity.Location = new System.Drawing.Point(214, 185);
            this.safeWorkingCapacity.Name = "safeWorkingCapacityText";
            this.safeWorkingCapacity.Size = new System.Drawing.Size(178, 27);
            this.safeWorkingCapacity.TabIndex = 0;
            this.safeWorkingCapacity.Text = "*SWC*";
            // 
            // GaugeSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 552);
            this.Controls.Add(this.safeWorkingCapacity);
            this.Controls.Add(this.tankVolume);
            this.Controls.Add(this.tankLengthLabel);
            this.Controls.Add(this.tankDiameterLabel);
            this.Controls.Add(this.tankLength);
            this.Controls.Add(this.tankDiameter);
            this.Controls.Add(this.waterWarningLabel);
            this.Controls.Add(this.waterAlarmLabel);
            this.Controls.Add(this.lowLimitLabel);
            this.Controls.Add(this.deliveryWarningLabel);
            this.Controls.Add(this.highLimitLabel);
            this.Controls.Add(this.overfillLimitLabel);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.safeWorkingCapacityLabel);
            this.Controls.Add(this.waterAlarm);
            this.Controls.Add(this.waterWarning);
            this.Controls.Add(this.lowLimit);
            this.Controls.Add(this.deliveryWarning);
            this.Controls.Add(this.highLimit);
            this.Controls.Add(this.overfillLimit);
            this.Controls.Add(this.tankCapacityLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.safeWorkingCapacityBox);
            this.Controls.Add(this.introText);
            this.Name = "GaugeSetup";
            this.Text = "Gauge Setup & Alarm Levels";
            this.safeWorkingCapacityBox.ResumeLayout(false);
            this.safeWorkingCapacityBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overfillLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankLength)).EndInit();
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
        private System.Windows.Forms.NumericUpDown overfillLimit;
        private System.Windows.Forms.NumericUpDown highLimit;
        private System.Windows.Forms.NumericUpDown deliveryWarning;
        private System.Windows.Forms.NumericUpDown lowLimit;
        private System.Windows.Forms.NumericUpDown waterWarning;
        private System.Windows.Forms.NumericUpDown waterAlarm;
        private System.Windows.Forms.Label safeWorkingCapacityLabel;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Label overfillLimitLabel;
        private System.Windows.Forms.Label highLimitLabel;
        private System.Windows.Forms.Label deliveryWarningLabel;
        private System.Windows.Forms.Label lowLimitLabel;
        private System.Windows.Forms.Label waterAlarmLabel;
        private System.Windows.Forms.Label waterWarningLabel;
        private System.Windows.Forms.NumericUpDown tankDiameter;
        private System.Windows.Forms.NumericUpDown tankLength;
        private System.Windows.Forms.Label tankDiameterLabel;
        private System.Windows.Forms.Label tankLengthLabel;
        private System.Windows.Forms.Label tankVolume;
        private System.Windows.Forms.Label safeWorkingCapacity;
    }
}