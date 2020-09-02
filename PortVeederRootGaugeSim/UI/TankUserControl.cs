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
        public TankProbe tankProbe;

        public TankUserControl()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            tempUpDown.Value = 15;
            productUpDown.Value = 800;
            waterUpDown.Value = 20;
        }

        public TankUserControl(int id, TankProbe tankProbe)
        {
            tankID = id;
            this.tankProbe = tankProbe;
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            tempUpDown.Value = this.tankProbe.ProductTemerature;
            productUpDown.Value = Convert.ToDecimal(tankProbe.GetProductLevel());
            waterUpDown.Value = Convert.ToDecimal(tankProbe.waterLevel);
            productVolume.Text = (tankProbe.GetProductLevel() * 10).ToString();
            gov.Text = tankProbe.GetGOV().ToString();
            capacity.Text = Convert.ToString(tankProbe.FullVolume);
            ullage.Text = Convert.ToString(tankProbe.GetUllage2());
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

        private void productUpDown_ValueChanged(object sender, EventArgs e)
        {
            tankProbe.SetProductLevel(Convert.ToDouble(productUpDown.Value));
            productVolume.Text = (tankProbe.GetProductLevel() * 10).ToString();
            gov.Text = Convert.ToString(tankProbe.GetGOV());
            gsv.Text = Convert.ToString(tankProbe.GetGSV());
            ullage.Text = Convert.ToString(tankProbe.GetUllage2());
        }

        private void tempUpDown_ValueChanged(object sender, EventArgs e)
        {
            tankProbe.ProductTemerature = Convert.ToInt32(tempUpDown.Value);
            System.Diagnostics.Debug.WriteLine(tankProbe.ProductTemerature);
            gov.Text = Convert.ToString(tankProbe.GetGOV());
            gsv.Text = Convert.ToString(tankProbe.GetGSV());
            ullage.Text = Convert.ToString(tankProbe.GetUllage2());
        }

        private void waterUpDown_ValueChanged(object sender, EventArgs e)
        {
            tankProbe.SetwaterVolume(Convert.ToDouble(waterUpDown.Value));
            waterVolume.Text = Convert.ToString(tankProbe.GetwaterVolume());
            gov.Text = Convert.ToString(tankProbe.GetGOV());
            gsv.Text = Convert.ToString(tankProbe.GetGSV());
            ullage.Text = Convert.ToString(tankProbe.GetUllage2());
        }
    }
}
