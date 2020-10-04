using PortVeederRootGaugeSim.Models;
using System;
using System.Windows.Forms;

namespace PortVeederRootGaugeSim
{
    public partial class GaugeSetup : Form
    {
        private readonly TankProbe tankGauge;

        public GaugeSetup(TankProbe tp)
        {
            tankGauge = tp;
            InitializeComponent();

            if (tankGauge.MaxSafeWorkingCapacityModifier == 0.95f)
            {
                capacity95.Checked = true;
            }
            else
            {
                capacity90.Checked = true;
            }

            tankVolumeText.Text = Convert.ToString(tankGauge.MyTank.FullVolume);
            overfillLimitText.Value = Convert.ToDecimal(tankGauge.MyTank.OverFillLimitLevel);
            highLimitText.Value = Convert.ToDecimal(tankGauge.MyTank.HighProductAlarmLevel);
            deliveryWarningText.Value = Convert.ToDecimal(tankGauge.MyTank.DeliveryNeededWarningLevel);
            lowLimitText.Value = Convert.ToDecimal(tankGauge.MyTank.LowProductAlarmLevel);
            waterAlarmText.Value = Convert.ToDecimal(tankGauge.MyTank.HighWaterAlarmLevel);
            waterWarningText.Value = Convert.ToDecimal(tankGauge.MyTank.HighWaterWarningLevel);
            tankLengthText.Value = Convert.ToDecimal(tankGauge.MyTank.TankLength);
            tankDiameterText.Value = Convert.ToDecimal(tankGauge.MyTank.TankDiameter);
            safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MyTank.MaxSafeWorkingCapacity);
            Helper.SetSafeWorkingCapacity(tankGauge.MaxSafeWorkingCapacityModifier);
            Helper.SetTankDiameter(tankGauge.MyTank.TankDiameter);
            Helper.SetTankLength(tankGauge.MyTank.TankLength);
            Helper.GetFullVolume();
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToSingle(overfillLimitText.Value) > Helper.GetFullVolume())
            {
                string message = "Overfill Level is greater than Tank Capacity";
                string title = "ERROR: Invalid Configuration";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (highLimitText.Value > overfillLimitText.Value)
            {
                string message = "High Product Level is greater than Overfill Level";
                string title = "ERROR: Invalid Configuration";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (deliveryWarningText.Value > highLimitText.Value)
            {
                string message = "Delivery Required Level is greater than High Product Level";
                string title = "ERROR: Invalid Configuration";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (lowLimitText.Value > deliveryWarningText.Value)
            {
                string message = "Low Product Level is greater than Delivery Required Level";
                string title = "ERROR: Invalid Configuration";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (waterAlarmText.Value > lowLimitText.Value)
            {
                string message = "High Water Alarm Level is greater than Low Product Level";
                string title = "ERROR: Invalid Configuration";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (waterWarningText.Value > waterAlarmText.Value)
            {
                string message = "High Water Warning Level is greater than High Water Alarm Level";
                string title = "ERROR: Invalid Configuration";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tankGauge.SetTankDiameter(Convert.ToSingle(tankDiameterText.Value));
                tankGauge.SetTankLength(Convert.ToSingle(tankLengthText.Value));
                tankGauge.MaxSafeWorkingCapacityModifier = Helper.GetWorkingCapacityModifier();
                tankGauge.MyTank.MaxSafeWorkingCapacity = Helper.GetWorkingSafeCapacity();
                tankGauge.MyTank.OverFillLimitLevel = Convert.ToSingle(overfillLimitText.Value);
                tankGauge.MyTank.HighProductAlarmLevel = Convert.ToSingle(highLimitText.Value);
                tankGauge.MyTank.DeliveryNeededWarningLevel = Convert.ToSingle(deliveryWarningText.Value);
                tankGauge.MyTank.LowProductAlarmLevel = Convert.ToSingle(lowLimitText.Value);
                tankGauge.MyTank.HighWaterAlarmLevel = Convert.ToSingle(waterAlarmText.Value);
                tankGauge.MyTank.HighWaterWarningLevel = Convert.ToSingle(waterWarningText.Value);
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TankDiameterText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.SetTankDiameter(Convert.ToSingle(tankDiameterText.Value));
                tankVolumeText.Text = Convert.ToString(Helper.GetFullVolume());
                safeWorkingCapacityText.Text = Convert.ToString(Helper.GetWorkingSafeCapacity());
            }
            catch (FormatException)
            {
                Helper.SetTankDiameter(0F);
                tankVolumeText.Text = Convert.ToString(Helper.GetFullVolume());
                safeWorkingCapacityText.Text = Convert.ToString(Helper.GetWorkingSafeCapacity());
            }

        }

        private void Capacity90_CheckedChanged(object sender, EventArgs e)
        {
            Helper.SetSafeWorkingCapacity(0.9F);
            safeWorkingCapacityText.Text = Convert.ToString(Helper.GetWorkingSafeCapacity());
        }

        private void Capacity95_CheckedChanged(object sender, EventArgs e)
        {
            Helper.SetSafeWorkingCapacity(0.95F);
            safeWorkingCapacityText.Text = Convert.ToString(Helper.GetWorkingSafeCapacity());
        }

        private void TankLengthText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.SetTankLength(Convert.ToSingle(tankLengthText.Value));
                tankVolumeText.Text = Convert.ToString(Helper.GetFullVolume());
                safeWorkingCapacityText.Text = Convert.ToString(Helper.GetWorkingSafeCapacity());
            }
            catch (FormatException)
            {
                Helper.SetTankLength(0F);
                tankVolumeText.Text = Convert.ToString(Helper.GetFullVolume());
                safeWorkingCapacityText.Text = Convert.ToString(Helper.GetWorkingSafeCapacity());
            }
        }
    }
}
