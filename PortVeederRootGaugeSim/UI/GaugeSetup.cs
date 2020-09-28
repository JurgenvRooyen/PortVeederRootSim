using PortVeederRootGaugeSim.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace PortVeederRootGaugeSim
{
    public partial class GaugeSetup : Form
    {
        private TankProbe tankGauge;

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
            // TODO  need to change tankHeightText to TankProbeLengthText
            tankHeightText.Text = Convert.ToString(tankGauge.TankProbeLength);
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
            catch (FormatException f)
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

        // TODO  need to change tankHeightText to TankProbeLengthText
        private void TankHeightText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tankGauge.SetTankProbeLength(Convert.ToSingle(tankHeightText.Text));
                tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MaxSafeWorkingCapacity);
            }
            catch (FormatException f)
            {
                tankGauge.SetTankProbeLength(0F);
                tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.MaxSafeWorkingCapacity);
            }

        }
    }
}
