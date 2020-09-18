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
            tempUpDown.Value = (decimal)this.tankProbe.ProductTemperature;
            productUpDown.Value = Convert.ToDecimal(tankProbe.GetProductLevel());
            waterUpDown.Value = Convert.ToDecimal(tankProbe.waterLevel);
            productVolume.Text = Convert.ToString(tankProbe.GetProductLevel() * 10);
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            capacity.Text = Convert.ToString(tankProbe.FullVolume);
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
            waterVolume.Text = Convert.ToString(tankProbe.waterVolume);

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
            tankProbe.SetProductLevel(Convert.ToSingle(productUpDown.Value));
            productVolume.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            gsv.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
        }

        private void tempUpDown_ValueChanged(object sender, EventArgs e)
        {
            tankProbe.ProductTemperature = Convert.ToInt32(tempUpDown.Value);
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            gsv.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
        }

        private void waterUpDown_ValueChanged(object sender, EventArgs e)
        {
            tankProbe.SetWaterLevel(Convert.ToSingle(waterUpDown.Value));
            waterVolume.Text = Convert.ToString(tankProbe.waterVolume);
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            gsv.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
        }

        private void gaugeSetupButton_Click(object sender, EventArgs e)
        {
            GaugeSetup form3 = new GaugeSetup(tankProbe);
            form3.ShowDialog();
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            capacity.Text = Convert.ToString(tankProbe.FullVolume);
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
            this.Refresh();
        }
    }
}
