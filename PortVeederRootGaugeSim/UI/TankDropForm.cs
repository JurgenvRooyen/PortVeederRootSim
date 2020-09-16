using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PortVeederRootGaugeSim
{
    public partial class TankDropForm : Form
    {
        public TankDropForm()
        {
            InitializeComponent();
            startDate.Format = DateTimePickerFormat.Custom;
            startDate.CustomFormat = "dd/MM/yyyy hh:mm";
            volumeLitres.Value = 5000;
            durationMinutes.Value = 20;
        }
        private void OkayButton_Click(object sender, EventArgs e)
        {
            //TODO: update tank drop information
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}