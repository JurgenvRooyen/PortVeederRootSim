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
    
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1.Controls.Add(new TankUserControl());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gaugeButton_Click(object sender, EventArgs e)
        {
            GaugeSetup form3 = new GaugeSetup();
            form3.ShowDialog();
        }

        private void addProbeButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Add(new TankUserControl());
        }

        private void deleteProbeButton_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.Count - 1);
            }
        }
    }
}