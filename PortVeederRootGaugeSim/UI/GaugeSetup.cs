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
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
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
                tankGauge.SetTankDiameter(Convert.ToSingle(tankDiameterText.Text));
                tankVolumeText.Text = Convert.ToString(tankGauge.MyTank.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MyTank.MaxSafeWorkingCapacity);
            }
            catch (FormatException)
            {
                tankGauge.SetTankDiameter(0F);
                tankVolumeText.Text = Convert.ToString(tankGauge.MyTank.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MyTank.MaxSafeWorkingCapacity);
            }

        }

        private void Capacity90_CheckedChanged(object sender, EventArgs e)
        {  
            tankGauge.MyTank.MaxSafeWorkingCapacity = 0.9f * tankGauge.MyTank.FullVolume;
            safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MyTank.MaxSafeWorkingCapacity);
        }

        private void Capacity95_CheckedChanged(object sender, EventArgs e)
        {
            tankGauge.MyTank.MaxSafeWorkingCapacity = 0.95f * tankGauge.MyTank.FullVolume;
            safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MyTank.MaxSafeWorkingCapacity);
        }

        private void TankLengthText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tankGauge.SetTankLength(Convert.ToSingle(tankLengthText.Text));
                tankVolumeText.Text = Convert.ToString(tankGauge.MyTank.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MyTank.MaxSafeWorkingCapacity);
            }
            catch (FormatException)
            {
                tankGauge.SetTankLength(0F);
                tankVolumeText.Text = Convert.ToString(tankGauge.MyTank.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MyTank.MaxSafeWorkingCapacity);
            }
        }
    }
}
