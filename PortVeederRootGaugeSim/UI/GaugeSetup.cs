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
        public GaugeSetup(RootSim r, FlowLayoutPanel f)
        {
            tankGauges = r;
            InitializeComponent();
            capacity90.Checked = true;
            tankCapacityText.Text = Convert.ToString(tankGauges.getProbe(0).FullVolume);
            overfillLimitText.Text = Convert.ToString(tankGauges.getProbe(0).OverFillLimit);
            highLimitText.Text = Convert.ToString(tankGauges.getProbe(0).HighProductAlarmLevel);
            deliveryWarningText.Text = Convert.ToString(tankGauges.getProbe(0).DeliveryNeededWarningLevel);
            lowLimitText.Text = Convert.ToString(tankGauges.getProbe(0).LowProductAlarmLevel);
            waterAlarmText.Text = Convert.ToString(tankGauges.getProbe(0).HighWaterAlarmLevel);
            waterWarningText.Text = Convert.ToString(tankGauges.getProbe(0).HighWaterWarningLevel);
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
