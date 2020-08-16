namespace PortVeederRootGaugeSim
{
    partial class Form1
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tank1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.gsv = new System.Windows.Forms.Label();
            this.ullage = new System.Windows.Forms.Label();
            this.ullageLabel = new System.Windows.Forms.Label();
            this.capacity = new System.Windows.Forms.Label();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.startLeakButton = new System.Windows.Forms.Button();
            this.startDeliveryButton = new System.Windows.Forms.Button();
            this.tankDropNumber = new System.Windows.Forms.Label();
            this.tankDropButton = new System.Windows.Forms.Button();
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
            this.gaugeButton = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.tank1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1174, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 24);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(116, 26);
            this.toolStripMenuItem5.Text = "Exit";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(75, 24);
            this.toolStripMenuItem2.Text = "Options";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(55, 24);
            this.toolStripMenuItem3.Text = "Help";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.toolStripMenuItem4.Size = new System.Drawing.Size(157, 26);
            this.toolStripMenuItem4.Text = "About";
            // 
            // tank1
            // 
            this.tank1.Controls.Add(this.comboBox1);
            this.tank1.Controls.Add(this.gsv);
            this.tank1.Controls.Add(this.ullage);
            this.tank1.Controls.Add(this.ullageLabel);
            this.tank1.Controls.Add(this.capacity);
            this.tank1.Controls.Add(this.capacityLabel);
            this.tank1.Controls.Add(this.startLeakButton);
            this.tank1.Controls.Add(this.startDeliveryButton);
            this.tank1.Controls.Add(this.tankDropNumber);
            this.tank1.Controls.Add(this.tankDropButton);
            this.tank1.Controls.Add(this.gsvLabel);
            this.tank1.Controls.Add(this.gov);
            this.tank1.Controls.Add(this.govLabel);
            this.tank1.Controls.Add(this.waterVolume);
            this.tank1.Controls.Add(this.waterVolLabel);
            this.tank1.Controls.Add(this.waterUpDown);
            this.tank1.Controls.Add(this.waterLabel);
            this.tank1.Controls.Add(this.productVolume);
            this.tank1.Controls.Add(this.productVolLabel);
            this.tank1.Controls.Add(this.productUpDown);
            this.tank1.Controls.Add(this.productLabel);
            this.tank1.Controls.Add(this.tempUpDown);
            this.tank1.Controls.Add(this.tempLabel);
            this.tank1.Location = new System.Drawing.Point(12, 28);
            this.tank1.Name = "tank1";
            this.tank1.Size = new System.Drawing.Size(143, 647);
            this.tank1.TabIndex = 1;
            this.tank1.TabStop = false;
            this.tank1.Text = "Tank 1 ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Probe Ok",
            "Setup Err",
            "Probe Out"});
            this.comboBox1.Location = new System.Drawing.Point(13, 611);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(106, 28);
            this.comboBox1.TabIndex = 22;
            // 
            // gsv
            // 
            this.gsv.AutoSize = true;
            this.gsv.Location = new System.Drawing.Point(37, 359);
            this.gsv.Name = "gsv";
            this.gsv.Size = new System.Drawing.Size(48, 20);
            this.gsv.TabIndex = 2;
            this.gsv.Text = "*GSV*";
            // 
            // ullage
            // 
            this.ullage.AutoSize = true;
            this.ullage.Location = new System.Drawing.Point(33, 573);
            this.ullage.Name = "ullage";
            this.ullage.Size = new System.Drawing.Size(64, 20);
            this.ullage.TabIndex = 21;
            this.ullage.Text = "*Ullage*";
            // 
            // ullageLabel
            // 
            this.ullageLabel.AutoSize = true;
            this.ullageLabel.Location = new System.Drawing.Point(37, 553);
            this.ullageLabel.Name = "ullageLabel";
            this.ullageLabel.Size = new System.Drawing.Size(52, 20);
            this.ullageLabel.TabIndex = 20;
            this.ullageLabel.Text = "Ullage";
            // 
            // capacity
            // 
            this.capacity.AutoSize = true;
            this.capacity.Location = new System.Drawing.Point(27, 533);
            this.capacity.Name = "capacity";
            this.capacity.Size = new System.Drawing.Size(78, 20);
            this.capacity.TabIndex = 19;
            this.capacity.Text = "*Capacity*";
            // 
            // capacityLabel
            // 
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Location = new System.Drawing.Point(33, 513);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(66, 20);
            this.capacityLabel.TabIndex = 18;
            this.capacityLabel.Text = "Capacity";
            // 
            // startLeakButton
            // 
            this.startLeakButton.Location = new System.Drawing.Point(13, 481);
            this.startLeakButton.Name = "startLeakButton";
            this.startLeakButton.Size = new System.Drawing.Size(107, 29);
            this.startLeakButton.TabIndex = 17;
            this.startLeakButton.Text = "Start Leak";
            this.startLeakButton.UseVisualStyleBackColor = true;
            this.startLeakButton.Click += new System.EventHandler(this.startLeakButton_Click);
            // 
            // startDeliveryButton
            // 
            this.startDeliveryButton.Location = new System.Drawing.Point(13, 446);
            this.startDeliveryButton.Name = "startDeliveryButton";
            this.startDeliveryButton.Size = new System.Drawing.Size(107, 29);
            this.startDeliveryButton.TabIndex = 16;
            this.startDeliveryButton.Text = "Start Delivery";
            this.startDeliveryButton.UseVisualStyleBackColor = true;
            this.startDeliveryButton.Click += new System.EventHandler(this.startDeliveryButton_Click);
            // 
            // tankDropNumber
            // 
            this.tankDropNumber.AutoSize = true;
            this.tankDropNumber.Location = new System.Drawing.Point(33, 423);
            this.tankDropNumber.Name = "tankDropNumber";
            this.tankDropNumber.Size = new System.Drawing.Size(60, 20);
            this.tankDropNumber.TabIndex = 15;
            this.tankDropNumber.Text = "# drops";
            // 
            // tankDropButton
            // 
            this.tankDropButton.Location = new System.Drawing.Point(13, 391);
            this.tankDropButton.Name = "tankDropButton";
            this.tankDropButton.Size = new System.Drawing.Size(107, 29);
            this.tankDropButton.TabIndex = 14;
            this.tankDropButton.Text = "Tank Drop";
            this.tankDropButton.UseVisualStyleBackColor = true;
            this.tankDropButton.Click += new System.EventHandler(this.tankDropButton_Click);
            // 
            // gsvLabel
            // 
            this.gsvLabel.AutoSize = true;
            this.gsvLabel.Location = new System.Drawing.Point(41, 339);
            this.gsvLabel.Name = "gsvLabel";
            this.gsvLabel.Size = new System.Drawing.Size(36, 20);
            this.gsvLabel.TabIndex = 13;
            this.gsvLabel.Text = "GSV";
            // 
            // gov
            // 
            this.gov.AutoSize = true;
            this.gov.Location = new System.Drawing.Point(34, 319);
            this.gov.Name = "gov";
            this.gov.Size = new System.Drawing.Size(51, 20);
            this.gov.TabIndex = 12;
            this.gov.Text = "*GOV*";
            // 
            // govLabel
            // 
            this.govLabel.AutoSize = true;
            this.govLabel.Location = new System.Drawing.Point(41, 299);
            this.govLabel.Name = "govLabel";
            this.govLabel.Size = new System.Drawing.Size(39, 20);
            this.govLabel.TabIndex = 11;
            this.govLabel.Text = "GOV";
            // 
            // waterVolume
            // 
            this.waterVolume.AutoSize = true;
            this.waterVolume.Location = new System.Drawing.Point(41, 260);
            this.waterVolume.Name = "waterVolume";
            this.waterVolume.Size = new System.Drawing.Size(42, 20);
            this.waterVolume.TabIndex = 9;
            this.waterVolume.Text = "*Vol*";
            // 
            // waterVolLabel
            // 
            this.waterVolLabel.AutoSize = true;
            this.waterVolLabel.Location = new System.Drawing.Point(20, 240);
            this.waterVolLabel.Name = "waterVolLabel";
            this.waterVolLabel.Size = new System.Drawing.Size(73, 20);
            this.waterVolLabel.TabIndex = 8;
            this.waterVolLabel.Text = "Water Vol";
            // 
            // waterUpDown
            // 
            this.waterUpDown.Location = new System.Drawing.Point(34, 206);
            this.waterUpDown.Name = "waterUpDown";
            this.waterUpDown.Size = new System.Drawing.Size(85, 27);
            this.waterUpDown.TabIndex = 7;
            this.waterUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.waterUpDown.Maximum = 10000;
            // 
            // waterLabel
            // 
            this.waterLabel.AutoSize = true;
            this.waterLabel.Location = new System.Drawing.Point(7, 182);
            this.waterLabel.Name = "waterLabel";
            this.waterLabel.Size = new System.Drawing.Size(86, 20);
            this.waterLabel.TabIndex = 6;
            this.waterLabel.Text = "Water Level";
            // 
            // productVolume
            // 
            this.productVolume.AutoSize = true;
            this.productVolume.Location = new System.Drawing.Point(41, 156);
            this.productVolume.Name = "productVolume";
            this.productVolume.Size = new System.Drawing.Size(42, 20);
            this.productVolume.TabIndex = 5;
            this.productVolume.Text = "*Vol*";
            // 
            // productVolLabel
            // 
            this.productVolLabel.AutoSize = true;
            this.productVolLabel.Location = new System.Drawing.Point(20, 136);
            this.productVolLabel.Name = "productVolLabel";
            this.productVolLabel.Size = new System.Drawing.Size(85, 20);
            this.productVolLabel.TabIndex = 4;
            this.productVolLabel.Text = "Product Vol";
            // 
            // productUpDown
            // 
            this.productUpDown.Location = new System.Drawing.Point(7, 106);
            this.productUpDown.Name = "productUpDown";
            this.productUpDown.Size = new System.Drawing.Size(112, 27);
            this.productUpDown.TabIndex = 3;
            this.productUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.productUpDown.Maximum = 100000;
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Location = new System.Drawing.Point(7, 83);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(98, 20);
            this.productLabel.TabIndex = 2;
            this.productLabel.Text = "Product Level";
            // 
            // tempUpDown
            // 
            this.tempUpDown.Location = new System.Drawing.Point(47, 50);
            this.tempUpDown.Name = "tempUpDown";
            this.tempUpDown.Size = new System.Drawing.Size(72, 27);
            this.tempUpDown.TabIndex = 1;
            this.tempUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tempLabel
            // 
            this.tempLabel.AutoSize = true;
            this.tempLabel.Location = new System.Drawing.Point(7, 27);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(93, 20);
            this.tempLabel.TabIndex = 0;
            this.tempLabel.Text = "Temperature";
            // 
            // gaugeButton
            // 
            this.gaugeButton.Location = new System.Drawing.Point(12, 697);
            this.gaugeButton.Name = "gaugeButton";
            this.gaugeButton.Size = new System.Drawing.Size(143, 29);
            this.gaugeButton.TabIndex = 2;
            this.gaugeButton.Text = "Gauge Setup";
            this.gaugeButton.UseVisualStyleBackColor = true;
            this.gaugeButton.Click += new System.EventHandler(this.gaugeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 738);
            this.Controls.Add(this.gaugeButton);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.tank1);
            this.Name = "Form1";
            this.Text = "Veeder-Root TLS Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.tank1.ResumeLayout(false);
            this.tank1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempUpDown)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.GroupBox tank1;
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
        private System.Windows.Forms.Label gsvLabel;
        private System.Windows.Forms.Label gov;
        private System.Windows.Forms.Label govLabel;
        private System.Windows.Forms.Label gsv;
        private System.Windows.Forms.Button tankDropButton;
        private System.Windows.Forms.Button startDeliveryButton;
        private System.Windows.Forms.Label tankDropNumber;
        private System.Windows.Forms.Label ullage;
        private System.Windows.Forms.Label ullageLabel;
        private System.Windows.Forms.Label capacity;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.Button startLeakButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.Button gaugeButton;
    }
}



