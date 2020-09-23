namespace PortVeederRootGaugeSim
{
    partial class MainForm
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProtocolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EchoTestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PortVeederRootMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addProbeButton = new System.Windows.Forms.Button();
            this.deleteProbeButton = new System.Windows.Forms.Button();
            this.ConnectProbeButton = new System.Windows.Forms.Button();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.OptionsMenuItem,
            this.ProtocolMenuItem,
            this.HelpMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.MainMenu.Size = new System.Drawing.Size(1331, 30);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "mainMenu";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(46, 24);
            this.FileMenuItem.Text = "File";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(116, 26);
            this.ExitMenuItem.Text = "Exit";
            // 
            // OptionsMenuItem
            // 
            this.OptionsMenuItem.Name = "OptionsMenuItem";
            this.OptionsMenuItem.Size = new System.Drawing.Size(75, 24);
            this.OptionsMenuItem.Text = "Options";
            // 
            // ProtocolMenuItem
            // 
            this.ProtocolMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EchoTestMenuItem,
            this.PortVeederRootMenuItem});
            this.ProtocolMenuItem.Name = "ProtocolMenuItem";
            this.ProtocolMenuItem.Size = new System.Drawing.Size(79, 24);
            this.ProtocolMenuItem.Text = "Protocol";
            // 
            // EchoTestMenuItem
            // 
            this.EchoTestMenuItem.Name = "EchoTestMenuItem";
            this.EchoTestMenuItem.Size = new System.Drawing.Size(206, 26);
            this.EchoTestMenuItem.Text = "Echo Test";
            // 
            // PortVeederRootMenuItem
            // 
            this.PortVeederRootMenuItem.Name = "PortVeederRootMenuItem";
            this.PortVeederRootMenuItem.Size = new System.Drawing.Size(206, 26);
            this.PortVeederRootMenuItem.Text = "Port Veeder-Root";
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuItem});
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(55, 24);
            this.HelpMenuItem.Text = "Help";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.AboutMenuItem.Size = new System.Drawing.Size(157, 26);
            this.AboutMenuItem.Text = "About";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 31);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1331, 708);
            this.flowLayoutPanel.TabIndex = 3;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // addProbeButton
            // 
            this.addProbeButton.Location = new System.Drawing.Point(208, 745);
            this.addProbeButton.Name = "addProbeButton";
            this.addProbeButton.Size = new System.Drawing.Size(143, 29);
            this.addProbeButton.TabIndex = 4;
            this.addProbeButton.Text = "Add Probe";
            this.addProbeButton.UseVisualStyleBackColor = true;
            this.addProbeButton.Click += new System.EventHandler(this.AddProbeButton_Click);
            // 
            // deleteProbeButton
            // 
            this.deleteProbeButton.Location = new System.Drawing.Point(357, 745);
            this.deleteProbeButton.Name = "deleteProbeButton";
            this.deleteProbeButton.Size = new System.Drawing.Size(143, 29);
            this.deleteProbeButton.TabIndex = 5;
            this.deleteProbeButton.Text = "Delete Probe";
            this.deleteProbeButton.UseVisualStyleBackColor = true;
            this.deleteProbeButton.Click += new System.EventHandler(this.DeleteProbeButton_Click);
            // 
            // ConnectProbeButton
            // 
            this.ConnectProbeButton.Location = new System.Drawing.Point(12, 745);
            this.ConnectProbeButton.Name = "ConnectProbeButton";
            this.ConnectProbeButton.Size = new System.Drawing.Size(190, 29);
            this.ConnectProbeButton.TabIndex = 5;
            this.ConnectProbeButton.Text = "Connect Probe 1 + 2";
            this.ConnectProbeButton.UseVisualStyleBackColor = true;
            this.ConnectProbeButton.Click += new System.EventHandler(this.ConnectProbeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 797);
            this.Controls.Add(this.ConnectProbeButton);
            this.Controls.Add(this.deleteProbeButton);
            this.Controls.Add(this.addProbeButton);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.MainMenu);
            this.Name = "MainForm";
            this.Text = "Veeder-Root TLS Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button addProbeButton;
        private System.Windows.Forms.Button deleteProbeButton;
        private System.Windows.Forms.Button ConnectProbeButton;
        private System.Windows.Forms.ToolStripMenuItem ProtocolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EchoTestMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PortVeederRootMenuItem;
    }
}



