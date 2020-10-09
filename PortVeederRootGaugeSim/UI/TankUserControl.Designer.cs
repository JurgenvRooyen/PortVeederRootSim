namespace PortVeederRootGaugeSim.UI
{
    partial class TankUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tankGroupBox = new System.Windows.Forms.GroupBox();
            this.GaugeSetupButton = new System.Windows.Forms.Button();
            this.probeDiameter = new System.Windows.Forms.Label();
            this.ProbeDiameterLabel = new System.Windows.Forms.Label();
            this.probeLength = new System.Windows.Forms.Label();
            this.ProbeLengthLabel = new System.Windows.Forms.Label();
            this.tankProbeStatus = new System.Windows.Forms.ComboBox();
            this.gsv = new System.Windows.Forms.Label();
            this.ullage = new System.Windows.Forms.Label();
            this.ullageLabel = new System.Windows.Forms.Label();
            this.capacity = new System.Windows.Forms.Label();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.startLeakButton = new System.Windows.Forms.Button();
            this.startDeliveryButton = new System.Windows.Forms.Button();
            this.tankDropNumber = new System.Windows.Forms.Label();
            this.gsvLabel = new System.Windows.Forms.Label();
            this.gov = new System.Windows.Forms.Label();
            this.govLabel = new System.Windows.Forms.Label();
            this.waterVolume = new System.Windows.Forms.Label();
            this.waterVolLabel = new System.Windows.Forms.Label();
            this.waterUpDown = new System.Windows.Forms.NumericUpDown();
            this.waterLabel = new System.Windows.Forms.Label();
            this.productVolume = new System.Windows.Forms.Label();
            this.productVolLabel = new System.Windows.Forms.Label();
            this.productUpDown = new System.Windows.Forms.NumericUpDown();
            this.productLabel = new System.Windows.Forms.Label();
            this.tempUpDown = new System.Windows.Forms.NumericUpDown();
            this.tempLabel = new System.Windows.Forms.Label();
            this.tankGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TankGroupBox
            // 
            this.tankGroupBox.Controls.Add(this.GaugeSetupButton);
            this.tankGroupBox.Controls.Add(this.probeDiameter);
            this.tankGroupBox.Controls.Add(this.ProbeDiameterLabel);
            this.tankGroupBox.Controls.Add(this.probeLength);
            this.tankGroupBox.Controls.Add(this.ProbeLengthLabel);
            this.tankGroupBox.Controls.Add(this.tankProbeStatus);
            this.tankGroupBox.Controls.Add(this.gsv);
            this.tankGroupBox.Controls.Add(this.ullage);
            this.tankGroupBox.Controls.Add(this.ullageLabel);
            this.tankGroupBox.Controls.Add(this.capacity);
            this.tankGroupBox.Controls.Add(this.capacityLabel);
            this.tankGroupBox.Controls.Add(this.startLeakButton);
            this.tankGroupBox.Controls.Add(this.startDeliveryButton);
            this.tankGroupBox.Controls.Add(this.tankDropNumber);
            this.tankGroupBox.Controls.Add(this.gsvLabel);
            this.tankGroupBox.Controls.Add(this.gov);
            this.tankGroupBox.Controls.Add(this.govLabel);
            this.tankGroupBox.Controls.Add(this.waterVolume);
            this.tankGroupBox.Controls.Add(this.waterVolLabel);
            this.tankGroupBox.Controls.Add(this.waterUpDown);
            this.tankGroupBox.Controls.Add(this.waterLabel);
            this.tankGroupBox.Controls.Add(this.productVolume);
            this.tankGroupBox.Controls.Add(this.productVolLabel);
            this.tankGroupBox.Controls.Add(this.productUpDown);
            this.tankGroupBox.Controls.Add(this.productLabel);
            this.tankGroupBox.Controls.Add(this.tempUpDown);
            this.tankGroupBox.Controls.Add(this.tempLabel);
            this.tankGroupBox.Location = new System.Drawing.Point(2, 0);
            this.tankGroupBox.Name = "TankGroupBox";
            this.tankGroupBox.Size = new System.Drawing.Size(123, 679);
            this.tankGroupBox.TabStop = false;
            this.tankGroupBox.Text = "Probe #";
            // 
            // GaugeSetupButton
            // 
            this.GaugeSetupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GaugeSetupButton.Location = new System.Drawing.Point(8, 644);
            this.GaugeSetupButton.Name = "GaugeSetupButton";
            this.GaugeSetupButton.Size = new System.Drawing.Size(107, 29);
            this.GaugeSetupButton.TabIndex = 7;
            this.GaugeSetupButton.Text = "Gauge Setup";
            this.GaugeSetupButton.UseVisualStyleBackColor = true;
            this.GaugeSetupButton.Click += new System.EventHandler(this.GaugeSetupButton_Click);
            // 
            // ProbeDiameter
            // 
            this.probeDiameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.probeDiameter.Location = new System.Drawing.Point(8, 517);
            this.probeDiameter.Name = "ProbeDiameter";
            this.probeDiameter.Size = new System.Drawing.Size(107, 20);
            this.probeDiameter.Text = "*Diameter*";
            this.probeDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProbeDiameterLabel
            // 
            this.ProbeDiameterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProbeDiameterLabel.AutoSize = true;
            this.ProbeDiameterLabel.Location = new System.Drawing.Point(4, 497);
            this.ProbeDiameterLabel.Name = "ProbeDiameterLabel";
            this.ProbeDiameterLabel.Size = new System.Drawing.Size(114, 20);
            this.ProbeDiameterLabel.Text = "Probe Diameter";
            this.ProbeDiameterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProbeLength
            // 
            this.probeLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.probeLength.Location = new System.Drawing.Point(8, 477);
            this.probeLength.Name = "ProbeLength";
            this.probeLength.Size = new System.Drawing.Size(107, 20);
            this.probeLength.Text = "*Length*";
            this.probeLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProbeLengthLabel
            // 
            this.ProbeLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProbeLengthLabel.AutoSize = true;
            this.ProbeLengthLabel.Location = new System.Drawing.Point(13, 457);
            this.ProbeLengthLabel.Name = "ProbeLengthLabel";
            this.ProbeLengthLabel.Size = new System.Drawing.Size(97, 20);
            this.ProbeLengthLabel.Text = "Probe Length";
            this.ProbeLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.tankProbeStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tankProbeStatus.FormattingEnabled = true;
            this.tankProbeStatus.Items.AddRange(new object[] {
            "Probe Ok",
            "Setup Err",
            "Probe Out"});
            this.tankProbeStatus.Location = new System.Drawing.Point(8, 540);
            this.tankProbeStatus.Name = "comboBox1";
            this.tankProbeStatus.Size = new System.Drawing.Size(107, 28);
            this.tankProbeStatus.TabIndex = 4;
            this.tankProbeStatus.SelectedIndexChanged += new System.EventHandler(this.TankProbeStatusChanged);
            // 
            // gsv
            // 
            this.gsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gsv.Location = new System.Drawing.Point(8, 191);
            this.gsv.Name = "gsv";
            this.gsv.Size = new System.Drawing.Size(106, 20);
            this.gsv.Text = "*GSV*";
            this.gsv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ullage
            // 
            this.ullage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ullage.Location = new System.Drawing.Point(8, 417);
            this.ullage.Name = "ullage";
            this.ullage.Size = new System.Drawing.Size(106, 20);
            this.ullage.Text = "*Ullage*";
            this.ullage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ullageLabel
            // 
            this.ullageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ullageLabel.AutoSize = true;
            this.ullageLabel.Location = new System.Drawing.Point(35, 397);
            this.ullageLabel.Name = "ullageLabel";
            this.ullageLabel.Size = new System.Drawing.Size(52, 20);
            this.ullageLabel.Text = "Ullage";
            this.ullageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // capacity
            // 
            this.capacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.capacity.Location = new System.Drawing.Point(8, 377);
            this.capacity.Name = "capacity";
            this.capacity.Size = new System.Drawing.Size(106, 20);
            this.capacity.Text = "*Capacity*";
            this.capacity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // capacityLabel
            // 
            this.capacityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Location = new System.Drawing.Point(28, 357);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(66, 20);
            this.capacityLabel.Text = "Capacity";
            this.capacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startLeakButton
            // 
            this.startLeakButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startLeakButton.Location = new System.Drawing.Point(8, 609);
            this.startLeakButton.Name = "startLeakButton";
            this.startLeakButton.Size = new System.Drawing.Size(107, 29);
            this.startLeakButton.TabIndex = 6;
            this.startLeakButton.Text = "Start Leak";
            this.startLeakButton.UseVisualStyleBackColor = true;
            this.startLeakButton.Click += new System.EventHandler(this.StartLeakButton_Click);
            // 
            // startDeliveryButton
            // 
            this.startDeliveryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startDeliveryButton.Location = new System.Drawing.Point(8, 574);
            this.startDeliveryButton.Name = "startDeliveryButton";
            this.startDeliveryButton.Size = new System.Drawing.Size(107, 29);
            this.startDeliveryButton.TabIndex = 5;
            this.startDeliveryButton.Text = "Start Delivery";
            this.startDeliveryButton.UseVisualStyleBackColor = true;
            this.startDeliveryButton.Click += new System.EventHandler(this.StartDeliveryButton_Click);
            // 
            // tankDropNumber
            // 
            this.tankDropNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tankDropNumber.Location = new System.Drawing.Point(8, 437);
            this.tankDropNumber.Name = "tankDropNumber";
            this.tankDropNumber.Size = new System.Drawing.Size(107, 20);
            this.tankDropNumber.Text = "# drops";
            this.tankDropNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gsvLabel
            // 
            this.gsvLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gsvLabel.AutoSize = true;
            this.gsvLabel.Location = new System.Drawing.Point(43, 169);
            this.gsvLabel.Name = "gsvLabel";
            this.gsvLabel.Size = new System.Drawing.Size(36, 20);
            this.gsvLabel.Text = "GSV";
            this.gsvLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gov
            // 
            this.gov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gov.Location = new System.Drawing.Point(8, 149);
            this.gov.Name = "gov";
            this.gov.Size = new System.Drawing.Size(106, 20);
            this.gov.Text = "*GOV*";
            this.gov.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // govLabel
            // 
            this.govLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.govLabel.AutoSize = true;
            this.govLabel.Location = new System.Drawing.Point(42, 129);
            this.govLabel.Name = "govLabel";
            this.govLabel.Size = new System.Drawing.Size(39, 20);
            this.govLabel.Text = "GOV";
            this.govLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waterVolume
            // 
            this.waterVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.waterVolume.Location = new System.Drawing.Point(8, 271);
            this.waterVolume.Name = "waterVolume";
            this.waterVolume.Size = new System.Drawing.Size(106, 20);
            this.waterVolume.Text = "*Vol*";
            this.waterVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waterVolLabel
            // 
            this.waterVolLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.waterVolLabel.AutoSize = true;
            this.waterVolLabel.Location = new System.Drawing.Point(25, 251);
            this.waterVolLabel.Name = "waterVolLabel";
            this.waterVolLabel.Size = new System.Drawing.Size(73, 20);
            this.waterVolLabel.Text = "Water Vol";
            this.waterVolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waterUpDown
            // 
            this.waterUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.waterUpDown.Location = new System.Drawing.Point(8, 99);
            this.waterUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.waterUpDown.Name = "waterUpDown";
            this.waterUpDown.Size = new System.Drawing.Size(106, 27);
            this.waterUpDown.TabIndex = 2;
            this.waterUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.waterUpDown.ValueChanged += new System.EventHandler(this.WaterUpDown_ValueChanged);
            // 
            // waterLabel
            // 
            this.waterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.waterLabel.AutoSize = true;
            this.waterLabel.Location = new System.Drawing.Point(18, 76);
            this.waterLabel.Name = "waterLabel";
            this.waterLabel.Size = new System.Drawing.Size(86, 20);
            this.waterLabel.Text = "Water Level";
            this.waterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productVolume
            // 
            this.productVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.productVolume.Location = new System.Drawing.Point(8, 231);
            this.productVolume.Name = "productVolume";
            this.productVolume.Size = new System.Drawing.Size(107, 20);
            this.productVolume.Text = "*Vol*";
            this.productVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productVolLabel
            // 
            this.productVolLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.productVolLabel.AutoSize = true;
            this.productVolLabel.Location = new System.Drawing.Point(19, 211);
            this.productVolLabel.Name = "productVolLabel";
            this.productVolLabel.Size = new System.Drawing.Size(85, 20);
            this.productVolLabel.Text = "Product Vol";
            this.productVolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productUpDown
            // 
            this.productUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.productUpDown.Location = new System.Drawing.Point(8, 46);
            this.productUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.productUpDown.Name = "productUpDown";
            this.productUpDown.Size = new System.Drawing.Size(107, 27);
            this.productUpDown.TabIndex = 1;
            this.productUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.productUpDown.ValueChanged += new System.EventHandler(this.ProductUpDown_ValueChanged);
            // 
            // productLabel
            // 
            this.productLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.productLabel.AutoSize = true;
            this.productLabel.Location = new System.Drawing.Point(12, 23);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(98, 20);
            this.productLabel.Text = "Product Level";
            this.productLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tempUpDown
            // 
            this.tempUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tempUpDown.Location = new System.Drawing.Point(8, 314);
            this.tempUpDown.Name = "tempUpDown";
            this.tempUpDown.Size = new System.Drawing.Size(107, 27);
            this.tempUpDown.TabIndex = 3;
            this.tempUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tempUpDown.ValueChanged += new System.EventHandler(this.TempUpDown_ValueChanged);
            // 
            // tempLabel
            // 
            this.tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tempLabel.AutoSize = true;
            this.tempLabel.Location = new System.Drawing.Point(15, 291);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(93, 20);
            this.tempLabel.Text = "Temperature";
            this.tempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TankUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tankGroupBox);
            this.Name = "TankUserControl";
            this.Size = new System.Drawing.Size(127, 683);
            this.tankGroupBox.ResumeLayout(false);
            this.tankGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox tankGroupBox;
        private System.Windows.Forms.ComboBox tankProbeStatus;
        private System.Windows.Forms.Label gsv;
        private System.Windows.Forms.Label ullage;
        private System.Windows.Forms.Label ullageLabel;
        private System.Windows.Forms.Label capacity;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.Button startLeakButton;
        private System.Windows.Forms.Button startDeliveryButton;
        private System.Windows.Forms.Label tankDropNumber;
        private System.Windows.Forms.Label gsvLabel;
        private System.Windows.Forms.Label gov;
        private System.Windows.Forms.Label govLabel;
        private System.Windows.Forms.Label waterVolume;
        private System.Windows.Forms.Label waterVolLabel;
        private System.Windows.Forms.NumericUpDown waterUpDown;
        private System.Windows.Forms.Label waterLabel;
        private System.Windows.Forms.Label productVolume;
        private System.Windows.Forms.Label productVolLabel;
        private System.Windows.Forms.NumericUpDown productUpDown;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.NumericUpDown tempUpDown;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Label ProbeLengthLabel;
        private System.Windows.Forms.Label probeLength;
        private System.Windows.Forms.Label probeDiameter;
        private System.Windows.Forms.Label ProbeDiameterLabel;
        private System.Windows.Forms.Button GaugeSetupButton;
    }
}
