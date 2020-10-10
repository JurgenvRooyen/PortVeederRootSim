using System;
using System.Windows.Forms;

namespace PortVeederRootGaugeSim.UI
{
    public partial class TankUserControl : UserControl
    {
        private readonly TankProbe tankProbe;

        public TankProbe GetTankProbe()
        {
            return tankProbe;
        }

        public TankUserControl()
        {
            InitializeComponent();
        }

        public TankUserControl(int id, TankProbe probe)
        {
            tankProbe = probe;
            InitializeComponent();
            tankProbeStatus.SelectedIndex = 0;
            tempUpDown.Value = Convert.ToDecimal(tankProbe.ProductTemperature);
            productUpDown.Value = Convert.ToDecimal(tankProbe.ProductLevel);
            waterUpDown.Value = Convert.ToDecimal(tankProbe.WaterLevel);
            productVolume.Text = Convert.ToString(Math.Round(tankProbe.ProductVolume));
            gov.Text = Convert.ToString(Math.Round(tankProbe.GetGrossObservedVolume()));
            gsv.Text = gsv.Text = Convert.ToString(Math.Round(tankProbe.GetGrossStandardVolume()));
            capacity.Text = Convert.ToString(Math.Round(tankProbe.MyTank.FullVolume));
            ullage.Text = Convert.ToString(Math.Round(tankProbe.GetUllage()));
            tankGroupBox.Text = "Probe " + Convert.ToString(id + 1);
            tankDropNumber.Text = Convert.ToString(tankProbe.TankDropCount) + " drops";
            waterVolume.Text = Convert.ToString(Math.Round(tankProbe.WaterVolume));
            probeLength.Text = Convert.ToString(tankProbe.MyTank.TankLength);
            probeDiameter.Text = Convert.ToString(tankProbe.MyTank.TankDiameter);
        }

        public void UpdateLabels()
        {
            tempUpDown.Value = Convert.ToDecimal(tankProbe.ProductTemperature);
            productUpDown.Value = Convert.ToDecimal(tankProbe.ProductLevel);
            productVolume.Text = Convert.ToString(Math.Round(tankProbe.ProductVolume));
            waterUpDown.Value = Convert.ToDecimal(tankProbe.WaterLevel);
            waterVolume.Text = Convert.ToString(Math.Round(tankProbe.WaterVolume));
            gov.Text = Convert.ToString(Math.Round(tankProbe.GetGrossObservedVolume()));
            gsv.Text = Convert.ToString(Math.Round(tankProbe.GetGrossStandardVolume()));
            capacity.Text = Convert.ToString(Math.Round(tankProbe.MyTank.FullVolume));
            ullage.Text = Convert.ToString(Math.Round(tankProbe.GetUllage()));
            tankDropNumber.Text = Convert.ToString(tankProbe.TankDropCount) + " drops";
            probeLength.Text = Convert.ToString(tankProbe.MyTank.TankLength);
            probeDiameter.Text = Convert.ToString(tankProbe.MyTank.TankDiameter);
            if (tankProbe.TankDelivering)
            {
                startLeakButton.Enabled = false;
                startDeliveryButton.Text = "Delivering...";
            }
            if (!tankProbe.TankDelivering)
            {
                startLeakButton.Enabled = true;
                startDeliveryButton.Text = "Start Delivery";
            }
            if (tankProbe.TankLeaking)
            {
                startDeliveryButton.Enabled = false;
                startLeakButton.Text = "Stop Leak";
            }
            if (!tankProbe.TankLeaking)
            {
                startDeliveryButton.Enabled = true;
                startLeakButton.Text = "Start Leak";
            }
        }

        private void StartDeliveryButton_Click(object sender, EventArgs e)
        {
            if (tankProbe.TankDelivering)
            {
                tankProbe.TankDelivering = false;
            }
            else
            {
                TankDropForm tankDropForm = new TankDropForm();
                DialogResult result = tankDropForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    DateTime dropStartDate = tankDropForm.GetStartDate();
                    float dropVolume = Convert.ToSingle(tankDropForm.GetVolume());
                    Double dropDuration = Convert.ToDouble(tankDropForm.GetDuration());
                    float vol = tankProbe.ProductVolume;
                    float fullVol = tankProbe.MyTank.FullVolume;
                    if (vol + dropVolume > fullVol)
                    {
                        string message = "Volume provided for delivery is too large";
                        string title = "Tank Delivery Error";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        tankProbe.StartDelivery(dropVolume, dropStartDate, TimeSpan.FromMinutes(dropDuration));
                    }
                }
            }
        }

        private void StartLeakButton_Click(object sender, EventArgs e)
        {
            tankProbe.LeakingSwitch();
        }

        private void ProductUpDown_ValueChanged(object sender, EventArgs e)
        {
            tankProbe.SetProductLevel(Convert.ToSingle(productUpDown.Value));
        }

        private void TempUpDown_ValueChanged(object sender, EventArgs e)
        {
            tankProbe.ProductTemperature = Convert.ToInt32(tempUpDown.Value);
        }

        private void WaterUpDown_ValueChanged(object sender, EventArgs e)
        {
            tankProbe.SetWaterLevel(Convert.ToSingle(waterUpDown.Value));
        }

        private void GaugeSetupButton_Click(object sender, EventArgs e)
        {
            GaugeSetup gaugeSetupForm = new GaugeSetup(tankProbe);
            gaugeSetupForm.ShowDialog();
        }

        private void TankProbeStatusChanged(object sender, EventArgs e)
        {
            if (tankProbeStatus.SelectedIndex == 0)
            {
                tankProbe.TankprobeStatus = "OK";
            }
            else if (tankProbeStatus.SelectedIndex == 1)
            {
                tankProbe.TankprobeStatus = "ERR";
            }
            else
            {
                tankProbe.TankprobeStatus = "OUT";
            }
        }
    }
}
