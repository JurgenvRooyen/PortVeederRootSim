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

        public MainForm(RootSim r)
        {
            TankGauges = r;
            InitializeComponent();
            TankGauges.AddTankProbe(new TankProbe(numberOfTanks, 500, 50, numberOfTanks, 1, 17));
            flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, TankGauges.GetProbe(numberOfTanks)));
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void gaugeButton_Click(object sender, EventArgs e)
        {
            GaugeSetup form3 = new GaugeSetup(TankGauges, flowLayoutPanel);
            form3.ShowDialog();
            
        }

        private void addProbeButton_Click(object sender, EventArgs e)
        {
            numberOfTanks++;
            TankGauges.AddTankProbe(new TankProbe(numberOfTanks, 500, 50, numberOfTanks, 800, numberOfTanks));
            flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, TankGauges.GetProbe(numberOfTanks)));
        }

        private void deleteProbeButton_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel.Controls.Count > 1)
            {
                System.Diagnostics.Debug.WriteLine(flowLayoutPanel.Controls.Count);
                flowLayoutPanel.Controls.RemoveAt(flowLayoutPanel.Controls.Count - 1);
                TankGauges.RemoveTankProbe(numberOfTanks);
                numberOfTanks--;
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
    }
}