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
            
            tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
            overfillLimitText.Text = Convert.ToString(tankGauge.OverFillLimitLevel);
            highLimitText.Text = Convert.ToString(tankGauge.HighProductAlarmLevel);
            deliveryWarningText.Text = Convert.ToString(tankGauge.DeliveryNeededWarningLevel);
            lowLimitText.Text = Convert.ToString(tankGauge.LowProductAlarmLevel);
            waterAlarmText.Text = Convert.ToString(tankGauge.HighWaterAlarmLevel);
            waterWarningText.Text = Convert.ToString(tankGauge.HighWaterWarningLevel);
            tankLengthText.Text = Convert.ToString(tankGauge.TankProbeLength);
            tankDiameterText.Text = Convert.ToString(tankGauge.TankProbeDiameter);
            safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MaxSafeWorkingCapacity);
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            tankGauge.OverFillLimitLevel = Convert.ToSingle(overfillLimitText.Text);
            tankGauge.HighProductAlarmLevel = Convert.ToSingle(highLimitText.Text);
            tankGauge.DeliveryNeededWarningLevel = Convert.ToSingle(deliveryWarningText.Text);
            tankGauge.LowProductAlarmLevel = Convert.ToSingle(lowLimitText.Text);
            tankGauge.HighWaterAlarmLevel = Convert.ToSingle(waterAlarmText.Text);
            tankGauge.HighWaterWarningLevel = Convert.ToSingle(waterWarningText.Text);
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
                tankGauge.SetTankProbeDiameter(Convert.ToSingle(tankDiameterText.Text));
                tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MaxSafeWorkingCapacity);
            }
            catch (FormatException)
            {
                tankGauge.SetTankProbeDiameter(0F);
                tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MaxSafeWorkingCapacity);
            }

        }

        private void Capacity90_CheckedChanged(object sender, EventArgs e)
        {  
            tankGauge.MaxSafeWorkingCapacity = 0.9f * tankGauge.FullVolume;
            safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MaxSafeWorkingCapacity);
        }

        private void Capacity95_CheckedChanged(object sender, EventArgs e)
        {
            tankGauge.MaxSafeWorkingCapacity = 0.95f * tankGauge.FullVolume;
            safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MaxSafeWorkingCapacity);
        }

        private void TankLengthText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tankGauge.SetTankProbeLength(Convert.ToSingle(tankLengthText.Text));
                tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MaxSafeWorkingCapacity);
            }
            catch (FormatException)
            {
                tankGauge.SetTankProbeLength(0F);
                tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MaxSafeWorkingCapacity);
            }
        }
    }
}
