﻿namespace PortVeederRootGaugeSim
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.gaugeButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addProbeButton = new System.Windows.Forms.Button();
            this.deleteProbeButton = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
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
            this.mainMenu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(1160, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(93, 22);
            this.toolStripMenuItem5.Text = "Exit";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem2.Text = "Options";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem3.Text = "Help";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.toolStripMenuItem4.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem4.Text = "About";
            // 
            // gaugeButton
            // 
            this.gaugeButton.Location = new System.Drawing.Point(10, 543);
            this.gaugeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gaugeButton.Name = "gaugeButton";
            this.gaugeButton.Size = new System.Drawing.Size(125, 22);
            this.gaugeButton.TabIndex = 2;
            this.gaugeButton.Text = "Gauge Setup";
            this.gaugeButton.UseVisualStyleBackColor = true;
            this.gaugeButton.Click += new System.EventHandler(this.gaugeButton_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 23);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1160, 515);
            this.flowLayoutPanel.TabIndex = 3;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // addProbeButton
            // 
            this.addProbeButton.Location = new System.Drawing.Point(141, 543);
            this.addProbeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addProbeButton.Name = "addProbeButton";
            this.addProbeButton.Size = new System.Drawing.Size(125, 22);
            this.addProbeButton.TabIndex = 4;
            this.addProbeButton.Text = "Add Probe";
            this.addProbeButton.UseVisualStyleBackColor = true;
            this.addProbeButton.Click += new System.EventHandler(this.addProbeButton_Click);
            // 
            // deleteProbeButton
            // 
            this.deleteProbeButton.Location = new System.Drawing.Point(271, 543);
            this.deleteProbeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteProbeButton.Name = "deleteProbeButton";
            this.deleteProbeButton.Size = new System.Drawing.Size(125, 22);
            this.deleteProbeButton.TabIndex = 5;
            this.deleteProbeButton.Text = "Delete Probe";
            this.deleteProbeButton.UseVisualStyleBackColor = true;
            this.deleteProbeButton.Click += new System.EventHandler(this.deleteProbeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 628);
            this.Controls.Add(this.deleteProbeButton);
            this.Controls.Add(this.addProbeButton);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.gaugeButton);
            this.Controls.Add(this.mainMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Veeder-Root TLS Simulator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.Button gaugeButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button addProbeButton;
        private System.Windows.Forms.Button deleteProbeButton;
    }
}


