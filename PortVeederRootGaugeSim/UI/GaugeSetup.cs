using PortVeederRootGaugeSim.Models;
using System;
using System.Windows.Forms;

namespace PortVeederRootGaugeSim
{
    public partial class GaugeSetup : Form
    {
        private readonly TankProbe tankProbe;
        private float workingTankDiameter;
        private float workingTankLength;
        private float workingSafeCapacity;
        private float workingFullVolume;

        public GaugeSetup(TankProbe tank)
        {
            tankProbe = tank;
            InitializeComponent();

            if (tankProbe.MaxSafeWorkingCapacityModifier == 0.95f)
            {
                capacity95.Checked = true;
            }
            else
            {
                capacity90.Checked = true;
            }

            tankVolume.Text = Convert.ToString(Math.Round(tankProbe.MyTank.FullVolume));
            overfillLimit.Value = Convert.ToDecimal(tankProbe.MyTank.OverFillLimitLevel);
            highLimit.Value = Convert.ToDecimal(tankProbe.MyTank.HighProductAlarmLevel);
            deliveryWarning.Value = Convert.ToDecimal(tankProbe.MyTank.DeliveryNeededWarningLevel);
            lowLimit.Value = Convert.ToDecimal(tankProbe.MyTank.LowProductAlarmLevel);
            waterAlarm.Value = Convert.ToDecimal(tankProbe.MyTank.HighWaterAlarmLevel);
            waterWarning.Value = Convert.ToDecimal(tankProbe.MyTank.HighWaterWarningLevel);
            tankLength.Value = Convert.ToDecimal(tankProbe.MyTank.TankLength);
            tankDiameter.Value = Convert.ToDecimal(tankProbe.MyTank.TankDiameter);
            safeWorkingCapacity.Text = Convert.ToString(Math.Round(tankProbe.MyTank.MaxSafeWorkingCapacity));
            workingSafeCapacity = tankProbe.MaxSafeWorkingCapacityModifier;
            workingTankDiameter = tankProbe.MyTank.TankDiameter;
            workingTankLength = tankProbe.MyTank.TankLength;
            workingFullVolume = Helper.GetFullVolume(workingTankDiameter, workingTankLength);
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToSingle(overfillLimit.Value) > workingFullVolume)
            {
                string message = "Overfill Level is greater than Tank Capacity";
                string title = "ERROR: Invalid Configuration";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (highLimit.Value > overfillLimit.Value)
            {
                string message = "High Product Level is greater than Overfill Level";
                string title = "ERROR: Invalid Configuration";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (deliveryWarning.Value > highLimit.Value)
            {
                string message = "Delivery Required Level is greater than High Product Level";
                string title = "ERROR: Invalid Configuration";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (lowLimit.Value > deliveryWarning.Value)
            {
                string message = "Low Product Level is greater than Delivery Required Level";
                string title = "ERROR: Invalid Configuration";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (waterAlarm.Value > lowLimit.Value)
            {
                string message = "High Water Alarm Level is greater than Low Product Level";
                string title = "ERROR: Invalid Configuration";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (waterWarning.Value > waterAlarm.Value)
            {
                string message = "High Water Warning Level is greater than High Water Alarm Level";
                string title = "ERROR: Invalid Configuration";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tankProbe.SetTankDiameter(Convert.ToSingle(tankDiameter.Value));
                tankProbe.SetTankLength(Convert.ToSingle(tankLength.Value));
                tankProbe.MaxSafeWorkingCapacityModifier = workingSafeCapacity;
                tankProbe.MyTank.MaxSafeWorkingCapacity = Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume);
                tankProbe.MyTank.OverFillLimitLevel = Convert.ToSingle(overfillLimit.Value);
                tankProbe.MyTank.HighProductAlarmLevel = Convert.ToSingle(highLimit.Value);
                tankProbe.MyTank.DeliveryNeededWarningLevel = Convert.ToSingle(deliveryWarning.Value);
                tankProbe.MyTank.LowProductAlarmLevel = Convert.ToSingle(lowLimit.Value);
                tankProbe.MyTank.HighWaterAlarmLevel = Convert.ToSingle(waterAlarm.Value);
                tankProbe.MyTank.HighWaterWarningLevel = Convert.ToSingle(waterWarning.Value);
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TankDiameter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                workingTankDiameter = Convert.ToSingle(tankDiameter.Value);
                workingFullVolume = Helper.GetFullVolume(workingTankDiameter, workingTankLength);
                tankVolume.Text = Convert.ToString(Math.Round(Helper.GetFullVolume(workingTankDiameter, workingTankLength)));
                safeWorkingCapacity.Text = Convert.ToString(Math.Round(Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume)));
            }
            catch (FormatException)
            {
                workingTankDiameter = 0F;
                workingFullVolume = Helper.GetFullVolume(workingTankDiameter, workingTankLength);
                tankVolume.Text = Convert.ToString(Math.Round(Helper.GetFullVolume(workingTankDiameter, workingTankLength)));
                safeWorkingCapacity.Text = Convert.ToString(Math.Round(Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume)));
            }

        }

        private void Capacity90_CheckedChanged(object sender, EventArgs e)
        {
            workingSafeCapacity = 0.9F;
            safeWorkingCapacity.Text = Convert.ToString(Math.Round(Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume)));
        }

        private void Capacity95_CheckedChanged(object sender, EventArgs e)
        {
            workingSafeCapacity = 0.95F;
            safeWorkingCapacity.Text = Convert.ToString(Math.Round(Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume)));
        }

        private void TankLength_TextChanged(object sender, EventArgs e)
        {
            try
            {
                workingTankLength = Convert.ToSingle(tankLength.Value);
                workingFullVolume = Helper.GetFullVolume(workingTankDiameter, workingTankLength);
                tankVolume.Text = Convert.ToString(Math.Round(Helper.GetFullVolume(workingTankDiameter, workingTankLength)));
                safeWorkingCapacity.Text = Convert.ToString(Math.Round(Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume)));
            }
            catch (FormatException)
            {
                workingTankLength = 0F;
                workingFullVolume = Helper.GetFullVolume(workingTankDiameter, workingTankLength);
                tankVolume.Text = Convert.ToString(Math.Round(Helper.GetFullVolume(workingTankDiameter, workingTankLength)));
                safeWorkingCapacity.Text = Convert.ToString(Math.Round(Helper.GetWorkingSafeCapacity(workingSafeCapacity, workingFullVolume)));
            }
        }
    }
}
