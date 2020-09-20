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

            if (tankGauge.safeWorkingCapacityModifier == 0.95)
            {
                capacity95.Checked = true;
            }
            else
            {
                capacity90.Checked = true;
            }
            
            tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
            overfillLimitText.Text = Convert.ToString(tankGauge.OverFillLimit);
            highLimitText.Text = Convert.ToString(tankGauge.HighProductAlarmLevel);
            deliveryWarningText.Text = Convert.ToString(tankGauge.DeliveryNeededWarningLevel);
            lowLimitText.Text = Convert.ToString(tankGauge.LowProductAlarmLevel);
            waterAlarmText.Text = Convert.ToString(tankGauge.HighWaterAlarmLevel);
            waterWarningText.Text = Convert.ToString(tankGauge.HighWaterWarningLevel);
            tankHeightText.Text = Convert.ToString(tankGauge.TankProbeHeight);
            tankDiameterText.Text = Convert.ToString(tankGauge.TankProbeDiameter);
            safeWorkingCapacityText.Text = Convert.ToString(tankGauge.getSafeWorkingCapacityVolume());
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            tankGauge.OverFillLimit = Convert.ToSingle(overfillLimitText.Text);
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

        private void tankDiameterText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tankGauge.SetTankProbeDiameter(Convert.ToSingle(tankDiameterText.Text));
                tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.getSafeWorkingCapacityVolume());
            }
            catch (FormatException f)
            {
                tankGauge.SetTankProbeDiameter(0F);
                tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.getSafeWorkingCapacityVolume());
            }

        }

        private void capacity90_CheckedChanged(object sender, EventArgs e)
        {
            tankGauge.setSafeWorkingCapacityModifier(0.90F);
            safeWorkingCapacityText.Text = Convert.ToString(tankGauge.getSafeWorkingCapacityVolume());
        }

        private void capacity95_CheckedChanged(object sender, EventArgs e)
        {
            tankGauge.setSafeWorkingCapacityModifier(0.95F);
            safeWorkingCapacityText.Text = Convert.ToString(tankGauge.getSafeWorkingCapacityVolume());
        }

        private void tankHeightText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tankGauge.SetTankProbeHeight(Convert.ToSingle(tankHeightText.Text));
                tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.getSafeWorkingCapacityVolume());
            }
            catch (FormatException f)
            {
                tankGauge.SetTankProbeHeight(0F);
                tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
                safeWorkingCapacityText.Text = Convert.ToString(tankGauge.getSafeWorkingCapacityVolume());
            }

        }
    }
}
