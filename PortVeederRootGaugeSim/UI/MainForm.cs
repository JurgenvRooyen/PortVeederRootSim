using PortVeederRootGaugeSim;
using PortVeederRootGaugeSim.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            TankGauges.addTankProbe(new TankProbe(numberOfTanks, 30000, numberOfTanks, 58, 17));
            flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, TankGauges.getProbe(numberOfTanks)));
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void gaugeButton_Click(object sender, EventArgs e)
        {
            GaugeSetup form3 = new GaugeSetup();
            form3.ShowDialog();
        }

        private void addProbeButton_Click(object sender, EventArgs e)
        {
            numberOfTanks++;
            TankGauges.addTankProbe(new TankProbe(numberOfTanks, 10000, numberOfTanks, 800, numberOfTanks));
            flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, TankGauges.getProbe(numberOfTanks)));
        }

        private void deleteProbeButton_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel.Controls.Count > 0)
            {
                flowLayoutPanel.Controls.RemoveAt(flowLayoutPanel.Controls.Count - 1);
                TankGauges.removeTankProbe(numberOfTanks);
                numberOfTanks--;
            }
        }
    }
}