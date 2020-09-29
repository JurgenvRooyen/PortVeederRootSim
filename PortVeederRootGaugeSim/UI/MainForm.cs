using PortVeederRootGaugeSim;
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
            try
            {
                TankGauges.LoadFile("ProbePersistence");
                foreach (TankProbe tank in TankGauges.TankProbeList)
                {
                    flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, TankGauges.GetProbe(numberOfTanks)));
                    numberOfTanks++;
                }
                numberOfTanks--;
                if (flowLayoutPanel.Controls.Count < 2)
                {
                    deleteProbeButton.Enabled = false;
                    ConnectProbeButton.Enabled = false;
                }
                else
                {
                    deleteProbeButton.Enabled = true;
                    ConnectProbeButton.Enabled = true;
                }
            }
            catch
            {
                TankGauges.AddTankProbe(new TankProbe(numberOfTanks, '1', 198, 122, 0, 0, 15, "level"));
                flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, TankGauges.GetProbe(numberOfTanks)));
                deleteProbeButton.Enabled = false;
                ConnectProbeButton.Enabled = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            refreshTimer.Tick += TimerEventProcessor;
            refreshTimer.Interval = 500;
            refreshTimer.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TankGauges.SaveFile("ProbePersistence");
        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            foreach (TankUserControl probeControl in flowLayoutPanel.Controls) {
                probeControl.UpdateLabels();
            }
        }

        private void AddProbeButton_Click(object sender, EventArgs e)
        {
            deleteProbeButton.Enabled = true;
            ConnectProbeButton.Enabled = true;
            numberOfTanks++;
            TankGauges.AddTankProbe(new TankProbe(numberOfTanks, '1', 198, 122, 0, 0, 15, "level"));
            flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, TankGauges.GetProbe(numberOfTanks)));       
        }

        private void DeleteProbeButton_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel.Controls.Count > 1)
            {
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