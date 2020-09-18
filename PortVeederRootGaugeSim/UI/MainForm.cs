﻿using PortVeederRootGaugeSim;
using PortVeederRootGaugeSim.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PortVeederRootGaugeSim
{
    
    public partial class MainForm : Form
    {
        public int numberOfTanks = 0;
        public RootSim TankGauges;
        public static System.Windows.Forms.Timer refreshTimer = new System.Windows.Forms.Timer();

        public MainForm(RootSim r)
        {
            TankGauges = r;
            InitializeComponent();
            TankGauges.AddTankProbe(new TankProbe(numberOfTanks, 500, 50, numberOfTanks, 1, 17));
            flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, TankGauges.GetProbe(numberOfTanks)));
            deleteProbeButton.Enabled = false;
            ConnectProbeButton.Enabled = false;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            refreshTimer.Tick += TimerEventProcessor;
            refreshTimer.Interval = 500;
            refreshTimer.Enabled = true;
        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            foreach (TankUserControl probeControl in flowLayoutPanel.Controls) {
                probeControl.UpdateLabels();
            }
        }

        private void GaugeButton_Click(object sender, EventArgs e)
        {
            GaugeSetup form3 = new GaugeSetup(TankGauges, flowLayoutPanel);
            form3.ShowDialog();
            
        }

        private void AddProbeButton_Click(object sender, EventArgs e)
        {
            deleteProbeButton.Enabled = true;
            ConnectProbeButton.Enabled = true;
            numberOfTanks++;
            TankGauges.AddTankProbe(new TankProbe(numberOfTanks, 500, 50, numberOfTanks, 800, numberOfTanks));
            flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, TankGauges.GetProbe(numberOfTanks)));
        }

        private void DeleteProbeButton_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel.Controls.Count > 1)
            {
                System.Diagnostics.Debug.WriteLine(flowLayoutPanel.Controls.Count);
                flowLayoutPanel.Controls.RemoveAt(flowLayoutPanel.Controls.Count - 1);
                TankGauges.RemoveTankProbe(numberOfTanks);
                numberOfTanks--;
                if (flowLayoutPanel.Controls.Count.Equals(1))
                {
                    deleteProbeButton.Enabled = false;
                    ConnectProbeButton.Enabled = false;
                }
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            const string exit = "Exit";
            const string about = "About";
            var menuItem = (ToolStripMenuItem)sender;
            var menuText = menuItem.Text;

            switch(menuText)
            {
                case exit:
                    Application.Exit();
                    break;

                case about:
                    string message = "About information";
                    string title = "About Veeder-Root TLS Simulator by ITL";
                    MessageBox.Show(message, title);
                    break;
            }
        }

        private void ConnectProbeButton_Click(object sender, EventArgs e)
        {
            if (ConnectProbeButton.Text.StartsWith("Connect"))
            {
                TankGauges.GetProbe(0).Connect(TankGauges.GetProbe(1));
                ConnectProbeButton.Text = "Disconnect Probe 1 + 2";
                ConnectProbeButton.BackColor = Color.Green;
            }
            else
            {
                TankGauges.GetProbe(0).Disconnect(TankGauges.GetProbe(1));
                ConnectProbeButton.Text = "Connect Probe 1 + 2";
                ConnectProbeButton.BackColor = Control.DefaultBackColor;
                ConnectProbeButton.UseVisualStyleBackColor = true;
            }
        }
    }
}