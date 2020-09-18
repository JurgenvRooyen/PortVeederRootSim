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

            if (tankGauge.MaxSafeWorkingCapacity == 90)
            {
                capacity90.Checked = true;
            }
            else
            {
                capacity95.Checked = true;
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
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            tankGauge.OverFillLimit = Convert.ToSingle(overfillLimitText.Text);
            tankGauge.HighProductAlarmLevel = Convert.ToSingle(highLimitText.Text);
            tankGauge.DeliveryNeededWarningLevel = Convert.ToSingle(deliveryWarningText.Text);
            tankGauge.LowProductAlarmLevel = Convert.ToSingle(lowLimitText.Text);
            tankGauge.HighWaterAlarmLevel = Convert.ToSingle(waterAlarmText.Text);
            tankGauge.HighWaterWarningLevel = Convert.ToSingle(waterWarningText.Text);
            tankGauge.TankProbeDiameter = Convert.ToSingle(tankDiameterText.Text);
            tankGauge.SetTankProbeHeight(Convert.ToSingle(tankHeightText.Text));

            if (capacity90.Checked)
            {
                tankGauge.MaxSafeWorkingCapacity = 90;
            } else
            {
                tankGauge.MaxSafeWorkingCapacity = 95;
            }

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tankDiameterText_TextChanged(object sender, EventArgs e)
        {
            tankGauge.SetTankProbeDiameter(Convert.ToSingle(tankDiameterText.Text));
            tankVolumeText.Text = Convert.ToString(tankGauge.FullVolume);
        }
    }
}
