using PortVeederRootGaugeSim;
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
            comboBox1.SelectedIndex = 0;
            tempUpDown.Value = 15;
            productUpDown.Value = 800;
            waterUpDown.Value = 20;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tankDropButton_Click(object sender, EventArgs e)
        {
            TankDropForm form2 = new TankDropForm();
            form2.ShowDialog();
        }

        private void startDeliveryButton_Click(object sender, EventArgs e)
        {

        }

        private void startLeakButton_Click(object sender, EventArgs e)
        {

        }

        private void gaugeButton_Click(object sender, EventArgs e)
        {
            GaugeSetup form3 = new GaugeSetup();
            form3.ShowDialog();
        }

        private void productUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}