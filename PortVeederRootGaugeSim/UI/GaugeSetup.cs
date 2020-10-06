using PortVeederRootGaugeSim.Models;
using System;
using System.Windows.Forms;

namespace PortVeederRootGaugeSim
{
    public partial class GaugeSetup : Form
    {
        private readonly TankProbe tankGauge;
        private float workingTankDiameter;
        private float workingTankLength;
        private float workingSafeCapacity;
        private float workingFullVolume;

        public GaugeSetup(TankProbe tankProbe)
        {
            tankGauge = tankProbe;
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
            workingSafeCapacity = tankGauge.MaxSafeWorkingCapacityModifier;
            workingTankDiameter = tankGauge.MyTank.TankDiameter;
            workingTankLength = tankGauge.MyTank.TankLength;
            workingFullVolume = Helper.GetFullVolume(workingTankDiameter, workingTankLength);
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToSingle(overfillLimitText.Value) > workingFullVolume)
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
                tankGauge.MaxSafeWorkingCapacityModifier = workingSafeCapacity;
                tankGauge.MyTank.MaxSafeWorkingCapacity = Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume);
                tankGauge.MyTank.OverFillLimitLevel = Convert.ToSingle(overfillLimitText.Value);
                tankGauge.MyTank.HighProductAlarmLevel = Convert.ToSingle(highLimitText.Value);
                tankGauge.MyTank.DeliveryNeededWarningLevel = Convert.ToSingle(deliveryWarningText.Value);
                tankGauge.MyTank.LowProductAlarmLevel = Convert.ToSingle(lowLimitText.Value);
                tankGauge.MyTank.HighWaterAlarmLevel = Convert.ToSingle(waterAlarmText.Value);
                tankGauge.MyTank.HighWaterWarningLevel = Convert.ToSingle(waterWarningText.Value);
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TankDiameterText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                workingTankDiameter = Convert.ToSingle(tankDiameterText.Value);
                workingFullVolume = Helper.GetFullVolume(workingTankDiameter, workingTankLength);
                tankVolumeText.Text = Convert.ToString(Helper.GetFullVolume(workingTankDiameter, workingTankLength));
                safeWorkingCapacityText.Text = Convert.ToString(Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume));
            }
            catch (FormatException)
            {
                workingTankDiameter = 0F;
                workingFullVolume = Helper.GetFullVolume(workingTankDiameter, workingTankLength);
                tankVolumeText.Text = Convert.ToString(Helper.GetFullVolume(workingTankDiameter, workingTankLength));
                safeWorkingCapacityText.Text = Convert.ToString(Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume));
            }

        }

        private void Capacity90_CheckedChanged(object sender, EventArgs e)
        {
            workingSafeCapacity = 0.9F;
            safeWorkingCapacityText.Text = Convert.ToString(Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume));
        }

        private void Capacity95_CheckedChanged(object sender, EventArgs e)
        {
            workingSafeCapacity = 0.95F;
            safeWorkingCapacityText.Text = Convert.ToString(Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume));
        }

        private void TankLengthText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                workingTankLength = Convert.ToSingle(tankLengthText.Value);
                workingFullVolume = Helper.GetFullVolume(workingTankDiameter, workingTankLength);
                tankVolumeText.Text = Convert.ToString(Helper.GetFullVolume(workingTankDiameter, workingTankLength));
                safeWorkingCapacityText.Text = Convert.ToString(Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume));
            }
            catch (FormatException)
            {
                workingTankLength = 0F;
                workingFullVolume = Helper.GetFullVolume(workingTankDiameter, workingTankLength);
                tankVolumeText.Text = Convert.ToString(Helper.GetFullVolume(workingTankDiameter, workingTankLength));
                safeWorkingCapacityText.Text = Convert.ToString(Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume));
            }
        }
    }
}
