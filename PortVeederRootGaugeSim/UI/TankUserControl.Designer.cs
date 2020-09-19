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
            this.TankGroupBox = new System.Windows.Forms.GroupBox();
            this.GaugeSetupButton = new System.Windows.Forms.Button();
            this.ProbeDiameter = new System.Windows.Forms.Label();
            this.ProbeDiameterLabel = new System.Windows.Forms.Label();
            this.ProbeLength = new System.Windows.Forms.Label();
            this.ProbeLengthLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.TankGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TankGroupBox
            // 
            this.TankGroupBox.Controls.Add(this.GaugeSetupButton);
            this.TankGroupBox.Controls.Add(this.ProbeDiameter);
            this.TankGroupBox.Controls.Add(this.ProbeDiameterLabel);
            this.TankGroupBox.Controls.Add(this.ProbeLength);
            this.TankGroupBox.Controls.Add(this.ProbeLengthLabel);
            this.TankGroupBox.Controls.Add(this.comboBox1);
            this.TankGroupBox.Controls.Add(this.gsv);
            this.TankGroupBox.Controls.Add(this.ullage);
            this.TankGroupBox.Controls.Add(this.ullageLabel);
            this.TankGroupBox.Controls.Add(this.capacity);
            this.TankGroupBox.Controls.Add(this.capacityLabel);
            this.TankGroupBox.Controls.Add(this.startLeakButton);
            this.TankGroupBox.Controls.Add(this.startDeliveryButton);
            this.TankGroupBox.Controls.Add(this.tankDropNumber);
            this.TankGroupBox.Controls.Add(this.gsvLabel);
            this.TankGroupBox.Controls.Add(this.gov);
            this.TankGroupBox.Controls.Add(this.govLabel);
            this.TankGroupBox.Controls.Add(this.waterVolume);
            this.TankGroupBox.Controls.Add(this.waterVolLabel);
            this.TankGroupBox.Controls.Add(this.waterUpDown);
            this.TankGroupBox.Controls.Add(this.waterLabel);
            this.TankGroupBox.Controls.Add(this.productVolume);
            this.TankGroupBox.Controls.Add(this.productVolLabel);
            this.TankGroupBox.Controls.Add(this.productUpDown);
            this.TankGroupBox.Controls.Add(this.productLabel);
            this.TankGroupBox.Controls.Add(this.tempUpDown);
            this.TankGroupBox.Controls.Add(this.tempLabel);
            this.TankGroupBox.Location = new System.Drawing.Point(2, 0);
            this.TankGroupBox.Name = "TankGroupBox";
            this.TankGroupBox.Size = new System.Drawing.Size(123, 679);
            this.TankGroupBox.TabIndex = 2;
            this.TankGroupBox.TabStop = false;
            this.TankGroupBox.Text = "Probe #";
            // 
            // GaugeSetupButton
            // 
            this.GaugeSetupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GaugeSetupButton.Location = new System.Drawing.Point(8, 644);
            this.GaugeSetupButton.Name = "GaugeSetupButton";
            this.GaugeSetupButton.Size = new System.Drawing.Size(107, 29);
            this.GaugeSetupButton.TabIndex = 17;
            this.GaugeSetupButton.Text = "Gauge Setup";
            this.GaugeSetupButton.UseVisualStyleBackColor = true;
            this.GaugeSetupButton.Click += new System.EventHandler(this.GaugeSetupButton_Click);
            // 
            // ProbeDiameter
            // 
            this.ProbeDiameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProbeDiameter.Location = new System.Drawing.Point(8, 517);
            this.ProbeDiameter.Name = "ProbeDiameter";
            this.ProbeDiameter.Size = new System.Drawing.Size(107, 20);
            this.ProbeDiameter.TabIndex = 23;
            this.ProbeDiameter.Text = "*Diameter*";
            this.ProbeDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProbeDiameterLabel
            // 
            this.ProbeDiameterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProbeDiameterLabel.AutoSize = true;
            this.ProbeDiameterLabel.Location = new System.Drawing.Point(4, 497);
            this.ProbeDiameterLabel.Name = "ProbeDiameterLabel";
            this.ProbeDiameterLabel.Size = new System.Drawing.Size(114, 20);
            this.ProbeDiameterLabel.TabIndex = 23;
            this.ProbeDiameterLabel.Text = "Probe Diameter";
            this.ProbeDiameterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProbeLength
            // 
            this.ProbeLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProbeLength.Location = new System.Drawing.Point(8, 477);
            this.ProbeLength.Name = "ProbeLength";
            this.ProbeLength.Size = new System.Drawing.Size(107, 20);
            this.ProbeLength.TabIndex = 23;
            this.ProbeLength.Text = "*Length*";
            this.ProbeLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProbeLengthLabel
            // 
            this.ProbeLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProbeLengthLabel.AutoSize = true;
            this.ProbeLengthLabel.Location = new System.Drawing.Point(13, 457);
            this.ProbeLengthLabel.Name = "ProbeLengthLabel";
            this.ProbeLengthLabel.Size = new System.Drawing.Size(97, 20);
            this.ProbeLengthLabel.TabIndex = 23;
            this.ProbeLengthLabel.Text = "Probe Length";
            this.ProbeLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Probe Ok",
            "Setup Err",
            "Probe Out"});
            this.comboBox1.Location = new System.Drawing.Point(8, 540);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 28);
            this.comboBox1.TabIndex = 22;
            // 
            // gsv
            // 
            this.gsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gsv.Location = new System.Drawing.Point(8, 191);
            this.gsv.Name = "gsv";
            this.gsv.Size = new System.Drawing.Size(106, 20);
            this.gsv.TabIndex = 2;
            this.gsv.Text = "*GSV*";
            this.gsv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ullage
            // 
            this.ullage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ullage.Location = new System.Drawing.Point(8, 404);
            this.ullage.Name = "ullage";
            this.ullage.Size = new System.Drawing.Size(106, 20);
            this.ullage.TabIndex = 21;
            this.ullage.Text = "*Ullage*";
            this.ullage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ullageLabel
            // 
            this.ullageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ullageLabel.AutoSize = true;
            this.ullageLabel.Location = new System.Drawing.Point(35, 384);
            this.ullageLabel.Name = "ullageLabel";
            this.ullageLabel.Size = new System.Drawing.Size(52, 20);
            this.ullageLabel.TabIndex = 20;
            this.ullageLabel.Text = "Ullage";
            this.ullageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // capacity
            // 
            this.capacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.capacity.Location = new System.Drawing.Point(8, 364);
            this.capacity.Name = "capacity";
            this.capacity.Size = new System.Drawing.Size(106, 20);
            this.capacity.TabIndex = 19;
            this.capacity.Text = "*Capacity*";
            this.capacity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // capacityLabel
            // 
            this.capacityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Location = new System.Drawing.Point(28, 344);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(66, 20);
            this.capacityLabel.TabIndex = 18;
            this.capacityLabel.Text = "Capacity";
            this.capacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startLeakButton
            // 
            this.startLeakButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startLeakButton.Location = new System.Drawing.Point(8, 609);
            this.startLeakButton.Name = "startLeakButton";
            this.startLeakButton.Size = new System.Drawing.Size(107, 29);
            this.startLeakButton.TabIndex = 17;
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
            this.startDeliveryButton.TabIndex = 16;
            this.startDeliveryButton.Text = "Start Delivery";
            this.startDeliveryButton.UseVisualStyleBackColor = true;
            this.startDeliveryButton.Click += new System.EventHandler(this.StartDeliveryButton_Click);
            // 
            // tankDropNumber
            // 
            this.tankDropNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tankDropNumber.Location = new System.Drawing.Point(8, 424);
            this.tankDropNumber.Name = "tankDropNumber";
            this.tankDropNumber.Size = new System.Drawing.Size(107, 20);
            this.tankDropNumber.TabIndex = 15;
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
            this.gsvLabel.TabIndex = 13;
            this.gsvLabel.Text = "GSV";
            this.gsvLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gov
            // 
            this.gov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gov.Location = new System.Drawing.Point(8, 149);
            this.gov.Name = "gov";
            this.gov.Size = new System.Drawing.Size(106, 20);
            this.gov.TabIndex = 12;
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
            this.govLabel.TabIndex = 11;
            this.govLabel.Text = "GOV";
            this.govLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waterVolume
            // 
            this.waterVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.waterVolume.Location = new System.Drawing.Point(8, 271);
            this.waterVolume.Name = "waterVolume";
            this.waterVolume.Size = new System.Drawing.Size(106, 20);
            this.waterVolume.TabIndex = 9;
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
            this.waterVolLabel.TabIndex = 8;
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
            this.waterUpDown.TabIndex = 7;
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
            this.waterLabel.TabIndex = 6;
            this.waterLabel.Text = "Water Level";
            this.waterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productVolume
            // 
            this.productVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.productVolume.Location = new System.Drawing.Point(8, 231);
            this.productVolume.Name = "productVolume";
            this.productVolume.Size = new System.Drawing.Size(107, 20);
            this.productVolume.TabIndex = 5;
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
            this.productVolLabel.TabIndex = 4;
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
            this.productUpDown.TabIndex = 3;
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
            this.productLabel.TabIndex = 2;
            this.productLabel.Text = "Product Level";
            this.productLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tempUpDown
            // 
            this.tempUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tempUpDown.Location = new System.Drawing.Point(8, 314);
            this.tempUpDown.Name = "tempUpDown";
            this.tempUpDown.Size = new System.Drawing.Size(107, 27);
            this.tempUpDown.TabIndex = 1;
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
            this.tempLabel.TabIndex = 0;
            this.tempLabel.Text = "Temperature";
            this.tempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TankUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TankGroupBox);
            this.Name = "TankUserControl";
            this.Size = new System.Drawing.Size(127, 683);
            this.TankGroupBox.ResumeLayout(false);
            this.TankGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox TankGroupBox;
        private System.Windows.Forms.ComboBox comboBox1;
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
        private System.Windows.Forms.Label ProbeLength;
        private System.Windows.Forms.Label ProbeDiameter;
        private System.Windows.Forms.Label ProbeDiameterLabel;
        private System.Windows.Forms.Button GaugeSetupButton;
    }
}
