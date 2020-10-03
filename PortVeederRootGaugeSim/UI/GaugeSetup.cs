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
            overfillLimitText.Text = Convert.ToString(tankGauge.MyTank.OverFillLimitLevel);
            highLimitText.Text = Convert.ToString(tankGauge.MyTank.HighProductAlarmLevel);
            deliveryWarningText.Text = Convert.ToString(tankGauge.MyTank.DeliveryNeededWarningLevel);
            lowLimitText.Text = Convert.ToString(tankGauge.MyTank.LowProductAlarmLevel);
            waterAlarmText.Text = Convert.ToString(tankGauge.MyTank.HighWaterAlarmLevel);
            waterWarningText.Text = Convert.ToString(tankGauge.MyTank.HighWaterWarningLevel);
            tankLengthText.Text = Convert.ToString(tankGauge.MyTank.TankLength);
            tankDiameterText.Text = Convert.ToString(tankGauge.MyTank.TankDiameter);
            safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MyTank.MaxSafeWorkingCapacity);
            Helper.SetSafeWorkingCapacity(tankGauge.MaxSafeWorkingCapacityModifier);
            Helper.SetTankDiameter(tankGauge.MyTank.TankDiameter);
            Helper.SetTankLength(tankGauge.MyTank.TankLength);
            Helper.GetFullVolume();
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            tankGauge.SetTankDiameter(Convert.ToSingle(tankDiameterText.Text));
            tankGauge.SetTankLength(Convert.ToSingle(tankLengthText.Text));
            tankGauge.MaxSafeWorkingCapacityModifier = Helper.GetWorkingCapacityModifier();
            tankGauge.MyTank.MaxSafeWorkingCapacity = Helper.GetWorkingSafeCapacity();
            tankGauge.MyTank.OverFillLimitLevel = Convert.ToSingle(overfillLimitText.Text);
            tankGauge.MyTank.HighProductAlarmLevel = Convert.ToSingle(highLimitText.Text);
            tankGauge.MyTank.DeliveryNeededWarningLevel = Convert.ToSingle(deliveryWarningText.Text);
            tankGauge.MyTank.LowProductAlarmLevel = Convert.ToSingle(lowLimitText.Text);
            tankGauge.MyTank.HighWaterAlarmLevel = Convert.ToSingle(waterAlarmText.Text);
            tankGauge.MyTank.HighWaterWarningLevel = Convert.ToSingle(waterWarningText.Text);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TankDiameterText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.SetTankDiameter(Convert.ToSingle(tankDiameterText.Text));
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
                Helper.SetTankLength(Convert.ToSingle(tankLengthText.Text));
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
