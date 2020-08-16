using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PortVeederRootGaugeSim
{
    public partial class GaugeSetup : Form
    {
        public GaugeSetup()
        {
            InitializeComponent();
            capacity90.Checked = true;
            tankCapacityText.Text = "20000";
            overfillLimitText.Text = "17500";
            highLimitText.Text = "17000";
            deliveryWarningText.Text = "4000";
            lowLimitText.Text = "2000";
            waterAlarmText.Text = "1500";
            waterWarningText.Text = "1000";
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            //TODO: update tank information
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
