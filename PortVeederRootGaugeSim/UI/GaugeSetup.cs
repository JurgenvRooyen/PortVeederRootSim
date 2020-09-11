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
        private RootSim tankGauges;
        private FlowLayoutPanel tankGaugesControls;
        public GaugeSetup(RootSim r, FlowLayoutPanel f)
        {
            tankGauges = r;
            tankGaugesControls = f;
            InitializeComponent();
            if (tankGauges.GetProbe(0).MaxSafeWorkingCapacity == 90)
            {
                capacity90.Checked = true;
            }
            else
            {
                capacity95.Checked = true;
            }
            
            tankCapacityText.Text = Convert.ToString(tankGauges.GetProbe(0).FullVolume);
            overfillLimitText.Text = Convert.ToString(tankGauges.GetProbe(0).OverFillLimit);
            highLimitText.Text = Convert.ToString(tankGauges.GetProbe(0).HighProductAlarmLevel);
            deliveryWarningText.Text = Convert.ToString(tankGauges.GetProbe(0).DeliveryNeededWarningLevel);
            lowLimitText.Text = Convert.ToString(tankGauges.GetProbe(0).LowProductAlarmLevel);
            waterAlarmText.Text = Convert.ToString(tankGauges.GetProbe(0).HighWaterAlarmLevel);
            waterWarningText.Text = Convert.ToString(tankGauges.GetProbe(0).HighWaterWarningLevel);
            
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            foreach (TankProbe t in tankGauges.TankProbeList)
            {
                t.FullVolume = Convert.ToSingle(tankCapacityText.Text);
                t.OverFillLimit = Convert.ToSingle(overfillLimitText.Text);
                t.HighProductAlarmLevel = Convert.ToSingle(highLimitText.Text);
                t.DeliveryNeededWarningLevel = Convert.ToSingle(deliveryWarningText.Text);
                t.LowProductAlarmLevel = Convert.ToSingle(lowLimitText.Text);
                t.HighWaterAlarmLevel = Convert.ToSingle(waterAlarmText.Text);
                t.HighWaterWarningLevel = Convert.ToSingle(waterWarningText.Text);
                if (capacity90.Checked)
                {
                    t.MaxSafeWorkingCapacity = 90;
                } else
                {
                    t.MaxSafeWorkingCapacity = 95;
                }

            }

            foreach (Control control in tankGaugesControls.Controls)
            {
                //control.
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
