using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PortVeederRootGaugeSim.UI
{
    public partial class TankUserControl : UserControl
    {
        public int TankID { get; set; }
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
            TankID = id;
            this.tankProbe = tankProbe;
            tankProbe.TankDelivering = false;
            tankProbe.TankLeaking = false;
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            tempUpDown.Value = Convert.ToDecimal(tankProbe.ProductTemperature);
            productUpDown.Value = Convert.ToDecimal(tankProbe.GetProductLevel());
            waterUpDown.Value = Convert.ToDecimal(tankProbe.GetWaterLevel());
            productVolume.Text = Convert.ToString(tankProbe.GetProductVolume());
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            gsv.Text = gsv.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
            capacity.Text = Convert.ToString(tankProbe.FullVolume);
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
            TankGroupBox.Text = "Probe " + Convert.ToString(id + 1);
            tankDropNumber.Text = Convert.ToString(tankProbe.TankDroppedList.Count) + " drops";
            waterVolume.Text = Convert.ToString(tankProbe.waterVolume);
            ProbeLength.Text = Convert.ToString(tankProbe.TankProbeHeight);
            ProbeDiameter.Text = Convert.ToString(tankProbe.TankProbeDiameter);
        }

        public void SetNewTempUpDown()
        {
            tempUpDown.Value = Convert.ToDecimal(tankProbe.ProductTemperature);
        }

        public void SetNewProductUpDown()
        {
            productUpDown.Value = Convert.ToDecimal(this.tankProbe.ProductLevel);
        }

        public void SetNewProductVolume()
        {
            productVolume.Text = Convert.ToString(this.tankProbe.GetProductVolume());
        }

        public void SetNewWaterUpDown()
        {
            waterUpDown.Value = Convert.ToDecimal(tankProbe.GetWaterLevel());
        }

        public void SetNewWaterVolume()
        {
            waterVolume.Text = Convert.ToString(tankProbe.waterVolume);
        }

        public void SetNewGOV()
        {
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
        }

        public void SetNewGSV()
        {
            gsv.Text = gsv.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
        }

        public void SetNewCapacity()
        {
            capacity.Text = Convert.ToString(tankProbe.FullVolume);
        }

        public void SetNewUllage()
        {
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
        }

        private void StartDeliveryButton_Click(object sender, EventArgs e)
        {
            if (this.tankProbe.TankDelivering)
            {
                this.tankProbe.TankDelivering = false;
                startDeliveryButton.Text = "Start Delivery";
            }
            else
            {
                TankDropForm tankDrop = new TankDropForm();
                DialogResult result = tankDrop.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.tankProbe.TankDelivering = true;
                    startDeliveryButton.Text = "Stop Delivery";
                }
            }
        }

        private void StartLeakButton_Click(object sender, EventArgs e)
        {
            if (this.tankProbe.TankLeaking)
            {
                this.tankProbe.LeakingSwitch();
                startLeakButton.Text = "Start Leak";
            }
            else
            {
                this.tankProbe.LeakingSwitch();
                startLeakButton.Text = "Stop Leak";
            }
        }

        private void ProductUpDown_ValueChanged(object sender, EventArgs e)
        {
            tankProbe.SetProductLevel(Convert.ToSingle(productUpDown.Value));
            productVolume.Text = Convert.ToString(tankProbe.GetProductVolume());
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            gsv.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
        }

        private void TempUpDown_ValueChanged(object sender, EventArgs e)
        {
            tankProbe.ProductTemperature = Convert.ToInt32(tempUpDown.Value);
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            gsv.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
        }

        private void WaterUpDown_ValueChanged(object sender, EventArgs e)
        {
            tankProbe.SetWaterLevel(Convert.ToSingle(waterUpDown.Value));
            waterVolume.Text = Convert.ToString(tankProbe.waterVolume);
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            gsv.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
        }
    }
}
