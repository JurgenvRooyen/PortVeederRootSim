namespace PortVeederRootGaugeSim
{
    partial class TankDropForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.startLabel = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.volumeLitres = new System.Windows.Forms.NumericUpDown();
            this.durationLabel = new System.Windows.Forms.Label();
            this.durationMinutes = new System.Windows.Forms.NumericUpDown();
            this.litresLabel = new System.Windows.Forms.Label();
            this.minutesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.volumeLitres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(37, 164);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(94, 29);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(160, 164);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(13, 23);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(74, 20);
            this.startLabel.TabIndex = 2;
            this.startLabel.Text = "Started at";
            // 
            // startDate
            // 
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(93, 23);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(221, 27);
            this.startDate.TabIndex = 3;
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(13, 71);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(59, 20);
            this.volumeLabel.TabIndex = 4;
            this.volumeLabel.Text = "Volume";
            // 
            // volumeLitres
            // 
            this.volumeLitres.Location = new System.Drawing.Point(93, 69);
            this.volumeLitres.Name = "volumeLitres";
            this.volumeLitres.Size = new System.Drawing.Size(94, 27);
            this.volumeLitres.TabIndex = 5;
            this.volumeLitres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.volumeLitres.Maximum = 100000;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(13, 117);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(67, 20);
            this.durationLabel.TabIndex = 6;
            this.durationLabel.Text = "Duration";
            // 
            // durationMinutes
            // 
            this.durationMinutes.Location = new System.Drawing.Point(93, 115);
            this.durationMinutes.Name = "durationMinutes";
            this.durationMinutes.Size = new System.Drawing.Size(94, 27);
            this.durationMinutes.TabIndex = 7;
            this.durationMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.durationMinutes.Maximum = 10000;
            // 
            // litresLabel
            // 
            this.litresLabel.AutoSize = true;
            this.litresLabel.Location = new System.Drawing.Point(193, 71);
            this.litresLabel.Name = "litresLabel";
            this.litresLabel.Size = new System.Drawing.Size(41, 20);
            this.litresLabel.TabIndex = 8;
            this.litresLabel.Text = "litres";
            // 
            // minutesLabel
            // 
            this.minutesLabel.AutoSize = true;
            this.minutesLabel.Location = new System.Drawing.Point(193, 117);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(61, 20);
            this.minutesLabel.TabIndex = 9;
            this.minutesLabel.Text = "minutes";
            // 
            // TankDropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 230);
            this.Controls.Add(this.minutesLabel);
            this.Controls.Add(this.litresLabel);
            this.Controls.Add(this.durationMinutes);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.volumeLitres);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "TankDropForm";
            this.Text = "Tank Drop";
            ((System.ComponentModel.ISupportInitialize)(this.volumeLitres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.NumericUpDown volumeLitres;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.NumericUpDown durationMinutes;
        private System.Windows.Forms.Label litresLabel;
        private System.Windows.Forms.Label minutesLabel;
    }
}