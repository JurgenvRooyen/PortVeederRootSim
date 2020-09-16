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
            this.capacity90 = new System.Windows.Forms.RadioButton();
            this.capacity95 = new System.Windows.Forms.RadioButton();
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tankCapacityLabel = new System.Windows.Forms.Label();
            this.tankCapacityText = new System.Windows.Forms.TextBox();
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
            this.safeWorkingCapacityBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // introText
            // 
            this.introText.AutoSize = true;
            this.introText.Location = new System.Drawing.Point(13, 13);
            this.introText.Name = "introText";
            this.introText.Size = new System.Drawing.Size(427, 20);
            this.introText.TabIndex = 0;
            this.introText.Text = "The following configurations apply to all tanks being simulated";
            // 
            // safeWorkingCapacityBox
            // 
            this.safeWorkingCapacityBox.Controls.Add(this.capacity95);
            this.safeWorkingCapacityBox.Controls.Add(this.capacity90);
            this.safeWorkingCapacityBox.Location = new System.Drawing.Point(13, 46);
            this.safeWorkingCapacityBox.Name = "safeWorkingCapacityBox";
            this.safeWorkingCapacityBox.Size = new System.Drawing.Size(379, 107);
            this.safeWorkingCapacityBox.TabIndex = 1;
            this.safeWorkingCapacityBox.TabStop = false;
            this.safeWorkingCapacityBox.Text = "Level to use for Safe Working Capacity (Ullage)";
            // 
            // capacity90
            // 
            this.capacity90.AutoSize = true;
            this.capacity90.Location = new System.Drawing.Point(25, 26);
            this.capacity90.Name = "capacity90";
            this.capacity90.Size = new System.Drawing.Size(137, 24);
            this.capacity90.TabIndex = 0;
            this.capacity90.TabStop = true;
            this.capacity90.Text = "90% of Capacity";
            this.capacity90.UseVisualStyleBackColor = true;
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
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(412, 399);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(97, 39);
            this.okayButton.TabIndex = 2;
            this.okayButton.Text = "OK";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(524, 399);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(99, 39);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // tankCapacityLabel
            // 
            this.tankCapacityLabel.AutoSize = true;
            this.tankCapacityLabel.Location = new System.Drawing.Point(109, 162);
            this.tankCapacityLabel.Name = "tankCapacityLabel";
            this.tankCapacityLabel.Size = new System.Drawing.Size(99, 20);
            this.tankCapacityLabel.TabIndex = 4;
            this.tankCapacityLabel.Text = "Tank Capacity";
            // 
            // tankCapacityText
            // 
            this.tankCapacityText.Location = new System.Drawing.Point(214, 159);
            this.tankCapacityText.Name = "tankCapacityText";
            this.tankCapacityText.Size = new System.Drawing.Size(178, 27);
            this.tankCapacityText.TabIndex = 5;
            // 
            // overfillLimitText
            // 
            this.overfillLimitText.Location = new System.Drawing.Point(214, 212);
            this.overfillLimitText.Name = "overfillLimitText";
            this.overfillLimitText.Size = new System.Drawing.Size(178, 27);
            this.overfillLimitText.TabIndex = 5;
            // 
            // highLimitText
            // 
            this.highLimitText.Location = new System.Drawing.Point(214, 245);
            this.highLimitText.Name = "highLimitText";
            this.highLimitText.Size = new System.Drawing.Size(178, 27);
            this.highLimitText.TabIndex = 5;
            // 
            // deliveryWarningText
            // 
            this.deliveryWarningText.Location = new System.Drawing.Point(214, 278);
            this.deliveryWarningText.Name = "deliveryWarningText";
            this.deliveryWarningText.Size = new System.Drawing.Size(178, 27);
            this.deliveryWarningText.TabIndex = 5;
            // 
            // lowLimitText
            // 
            this.lowLimitText.Location = new System.Drawing.Point(214, 311);
            this.lowLimitText.Name = "lowLimitText";
            this.lowLimitText.Size = new System.Drawing.Size(178, 27);
            this.lowLimitText.TabIndex = 5;
            // 
            // waterWarningText
            // 
            this.waterWarningText.Location = new System.Drawing.Point(214, 420);
            this.waterWarningText.Name = "waterWarningText";
            this.waterWarningText.Size = new System.Drawing.Size(178, 27);
            this.waterWarningText.TabIndex = 5;
            // 
            // waterAlarmText
            // 
            this.waterAlarmText.Location = new System.Drawing.Point(214, 384);
            this.waterAlarmText.Name = "waterAlarmText";
            this.waterAlarmText.Size = new System.Drawing.Size(178, 27);
            this.waterAlarmText.TabIndex = 5;
            // 
            // safeWorkingCapacityLabel
            // 
            this.safeWorkingCapacityLabel.AutoSize = true;
            this.safeWorkingCapacityLabel.Location = new System.Drawing.Point(119, 189);
            this.safeWorkingCapacityLabel.Name = "safeWorkingCapacityLabel";
            this.safeWorkingCapacityLabel.Size = new System.Drawing.Size(212, 20);
            this.safeWorkingCapacityLabel.TabIndex = 6;
            this.safeWorkingCapacityLabel.Text = "Safe working capacity is 18000";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(6, 341);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(386, 40);
            this.noteLabel.TabIndex = 7;
            this.noteLabel.Text = "NOTE: Fuel draw off level is usually between the low limit\r\nand high water alarm " +
    "levels\r\n";
            // 
            // overfillLimitLabel
            // 
            this.overfillLimitLabel.AutoSize = true;
            this.overfillLimitLabel.Location = new System.Drawing.Point(114, 215);
            this.overfillLimitLabel.Name = "overfillLimitLabel";
            this.overfillLimitLabel.Size = new System.Drawing.Size(94, 20);
            this.overfillLimitLabel.TabIndex = 8;
            this.overfillLimitLabel.Text = "Overfill Limit";
            // 
            // highLimitLabel
            // 
            this.highLimitLabel.AutoSize = true;
            this.highLimitLabel.Location = new System.Drawing.Point(130, 248);
            this.highLimitLabel.Name = "highLimitLabel";
            this.highLimitLabel.Size = new System.Drawing.Size(78, 20);
            this.highLimitLabel.TabIndex = 9;
            this.highLimitLabel.Text = "High Limit";
            // 
            // deliveryWarningLabel
            // 
            this.deliveryWarningLabel.AutoSize = true;
            this.deliveryWarningLabel.Location = new System.Drawing.Point(22, 281);
            this.deliveryWarningLabel.Name = "deliveryWarningLabel";
            this.deliveryWarningLabel.Size = new System.Drawing.Size(186, 20);
            this.deliveryWarningLabel.TabIndex = 10;
            this.deliveryWarningLabel.Text = "Delivery Required Warning";
            // 
            // lowLimitLabel
            // 
            this.lowLimitLabel.AutoSize = true;
            this.lowLimitLabel.Location = new System.Drawing.Point(135, 314);
            this.lowLimitLabel.Name = "lowLimitLabel";
            this.lowLimitLabel.Size = new System.Drawing.Size(73, 20);
            this.lowLimitLabel.TabIndex = 11;
            this.lowLimitLabel.Text = "Low Limit";
            // 
            // waterAlarmLabel
            // 
            this.waterAlarmLabel.AutoSize = true;
            this.waterAlarmLabel.Location = new System.Drawing.Point(43, 387);
            this.waterAlarmLabel.Name = "waterAlarmLabel";
            this.waterAlarmLabel.Size = new System.Drawing.Size(165, 20);
            this.waterAlarmLabel.TabIndex = 12;
            this.waterAlarmLabel.Text = "High Water Alarm Limit";
            // 
            // waterWarningLabel
            // 
            this.waterWarningLabel.AutoSize = true;
            this.waterWarningLabel.Location = new System.Drawing.Point(28, 423);
            this.waterWarningLabel.Name = "waterWarningLabel";
            this.waterWarningLabel.Size = new System.Drawing.Size(180, 20);
            this.waterWarningLabel.TabIndex = 12;
            this.waterWarningLabel.Text = "High Water Warning Limit";
            // 
            // GaugeSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 460);
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
            this.Controls.Add(this.tankCapacityText);
            this.Controls.Add(this.tankCapacityLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.safeWorkingCapacityBox);
            this.Controls.Add(this.introText);
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
        private System.Windows.Forms.TextBox tankCapacityText;
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
    }
}