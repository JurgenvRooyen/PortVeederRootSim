using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PortVeederRootGaugeSim.UI
{
    public partial class TankUserControl : UserControl
    {
        public int tankID { get; set; }
        public RootSim tankGauges { get; set; }

        public TankUserControl()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            tempUpDown.Value = 15;
            productUpDown.Value = 800;
            waterUpDown.Value = 20;
        }

        public TankUserControl(int id, RootSim r)
        {
            tankID = id;
            tankGauges = r;
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            //tempUpDown.Value = 15;
            tempUpDown.Value = tankGauges.getProbe(tankID).ProductTemerature;
            productUpDown.Value = 800;
            waterUpDown.Value = 20;
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
    }
}
