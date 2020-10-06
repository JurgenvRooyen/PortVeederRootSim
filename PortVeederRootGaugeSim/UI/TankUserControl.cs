using System;
using System.Windows.Forms;

namespace PortVeederRootGaugeSim.UI
{
    public partial class TankUserControl : UserControl
    {
        public int TankID { get; set; }
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
            TankID = id;
            tankProbe = probe;
            InitializeComponent();
            TankProbeStatus.SelectedIndex = 0;
            tempUpDown.Value = Convert.ToDecimal(tankProbe.ProductTemperature);
            productUpDown.Value = Convert.ToDecimal(tankProbe.ProductLevel);
            waterUpDown.Value = Convert.ToDecimal(tankProbe.WaterLevel);
            productVolume.Text = Convert.ToString(tankProbe.ProductVolume);
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            gsv.Text = gsv.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
            capacity.Text = Convert.ToString(tankProbe.MyTank.FullVolume);
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
            TankGroupBox.Text = "Probe " + Convert.ToString(id + 1);
            tankDropNumber.Text = Convert.ToString(tankProbe.TankDropCount) + " drops";
            waterVolume.Text = Convert.ToString(tankProbe.WaterVolume);
            ProbeLength.Text = Convert.ToString(tankProbe.MyTank.TankLength);
            ProbeDiameter.Text = Convert.ToString(tankProbe.MyTank.TankDiameter);
        }

        public void UpdateLabels()
        {
            tempUpDown.Value = Convert.ToDecimal(tankProbe.ProductTemperature);
            productUpDown.Value = Convert.ToDecimal(tankProbe.ProductLevel);
            productVolume.Text = Convert.ToString(tankProbe.ProductVolume);
            waterUpDown.Value = Convert.ToDecimal(tankProbe.WaterLevel);
            waterVolume.Text = Convert.ToString(tankProbe.WaterVolume);
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            gsv.Text = gsv.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
            capacity.Text = Convert.ToString(tankProbe.MyTank.FullVolume);
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
            tankDropNumber.Text = Convert.ToString(tankProbe.TankDropCount) + " drops";
            ProbeLength.Text = Convert.ToString(tankProbe.MyTank.TankLength);
            ProbeDiameter.Text = Convert.ToString(tankProbe.MyTank.TankDiameter);
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
                    tankProbe.DeliverySwitch(dropVolume, dropStartDate, TimeSpan.FromMinutes(dropDuration));
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
            productVolume.Text = Convert.ToString(tankProbe.ProductVolume);
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
            waterVolume.Text = Convert.ToString(tankProbe.WaterVolume);
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            gsv.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
        }

        private void GaugeSetupButton_Click(object sender, EventArgs e)
        {
            GaugeSetup gaugeSetupForm = new GaugeSetup(tankProbe);
            gaugeSetupForm.ShowDialog();
            gov.Text = Convert.ToString(tankProbe.GetGrossObservedVolume());
            gsv.Text = Convert.ToString(tankProbe.GetGrossStandardVolume());
            capacity.Text = Convert.ToString(tankProbe.MyTank.FullVolume);
            ullage.Text = Convert.ToString(tankProbe.GetUllage());
            Refresh();
        }

        private void TankProbeStatusChanged(object sender, EventArgs e)
        {
            if (TankProbeStatus.SelectedIndex == 0)
            {
                tankProbe.TankprobeStatus = "OK";
            }
            else if (TankProbeStatus.SelectedIndex == 1)
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
