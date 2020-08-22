using PortVeederRootGaugeSim;
using PortVeederRootGaugeSim.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            TankUserControl uc1 = new TankUserControl();
            flowLayoutPanel1.Controls.Add(uc1);
            TankUserControl uc2 = new TankUserControl();
            flowLayoutPanel1.Controls.Add(uc2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gaugeButton_Click(object sender, EventArgs e)
        {
            GaugeSetup form3 = new GaugeSetup();
            form3.ShowDialog();
        }
    }
}