namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TankDropVolumeTextArea = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TankDropDurationTextArea = new System.Windows.Forms.TextBox();
            this.AddDropButton = new System.Windows.Forms.Button();
            this.StartDropButton = new System.Windows.Forms.Button();
            this.StartDropTimer = new System.Windows.Forms.Timer(this.components);
            this.StartLeakButton = new System.Windows.Forms.Button();
            this.StartLeakTimer = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(-1, -1);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(493, 637);
            this.textBox1.TabIndex = 0;
            // 
            // TankDropVolumeTextArea
            // 
            this.TankDropVolumeTextArea.Location = new System.Drawing.Point(584, 30);
            this.TankDropVolumeTextArea.Margin = new System.Windows.Forms.Padding(4);
            this.TankDropVolumeTextArea.Name = "TankDropVolumeTextArea";
            this.TankDropVolumeTextArea.Size = new System.Drawing.Size(42, 23);
            this.TankDropVolumeTextArea.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(499, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Volume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Duration";
            // 
            // TankDropDurationTextArea
            // 
            this.TankDropDurationTextArea.Location = new System.Drawing.Point(584, 74);
            this.TankDropDurationTextArea.Margin = new System.Windows.Forms.Padding(4);
            this.TankDropDurationTextArea.Name = "TankDropDurationTextArea";
            this.TankDropDurationTextArea.Size = new System.Drawing.Size(42, 23);
            this.TankDropDurationTextArea.TabIndex = 4;
            // 
            // AddDropButton
            // 
            this.AddDropButton.Location = new System.Drawing.Point(502, 150);
            this.AddDropButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddDropButton.Name = "AddDropButton";
            this.AddDropButton.Size = new System.Drawing.Size(126, 33);
            this.AddDropButton.TabIndex = 5;
            this.AddDropButton.Text = "Add Tank Drop";
            this.AddDropButton.UseVisualStyleBackColor = true;
            this.AddDropButton.Click += new System.EventHandler(this.AddDropButton_Click);
            // 
            // StartDropButton
            // 
            this.StartDropButton.Location = new System.Drawing.Point(502, 193);
            this.StartDropButton.Margin = new System.Windows.Forms.Padding(4);
            this.StartDropButton.Name = "StartDropButton";
            this.StartDropButton.Size = new System.Drawing.Size(126, 33);
            this.StartDropButton.TabIndex = 6;
            this.StartDropButton.Text = "Start Drop";
            this.StartDropButton.UseVisualStyleBackColor = true;
            this.StartDropButton.Click += new System.EventHandler(this.StartDropButton_Click);
            // 
            // StartDropTimer
            // 
            this.StartDropTimer.Interval = 10;
            this.StartDropTimer.Tick += new System.EventHandler(this.StartDropTimer_Tick);
            // 
            // StartLeakButton
            // 
            this.StartLeakButton.Location = new System.Drawing.Point(499, 234);
            this.StartLeakButton.Margin = new System.Windows.Forms.Padding(4);
            this.StartLeakButton.Name = "StartLeakButton";
            this.StartLeakButton.Size = new System.Drawing.Size(126, 33);
            this.StartLeakButton.TabIndex = 7;
            this.StartLeakButton.Text = "Start Leak";
            this.StartLeakButton.UseVisualStyleBackColor = true;
            this.StartLeakButton.Click += new System.EventHandler(this.StartLeakButton_Click);
            // 
            // StartLeakTimer
            // 
            this.StartLeakTimer.Interval = 10;
            this.StartLeakTimer.Tick += new System.EventHandler(this.StartLeakTimer_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = false;
            this.backgroundWorker1.WorkerSupportsCancellation = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 638);
            this.Controls.Add(this.StartLeakButton);
            this.Controls.Add(this.StartDropButton);
            this.Controls.Add(this.AddDropButton);
            this.Controls.Add(this.TankDropDurationTextArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TankDropVolumeTextArea);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox TankDropVolumeTextArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TankDropDurationTextArea;
        private System.Windows.Forms.Button AddDropButton;
        private System.Windows.Forms.Button StartDropButton;
        private System.Windows.Forms.Timer StartDropTimer;
        private System.Windows.Forms.Button StartLeakButton;
        private System.Windows.Forms.Timer StartLeakTimer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

