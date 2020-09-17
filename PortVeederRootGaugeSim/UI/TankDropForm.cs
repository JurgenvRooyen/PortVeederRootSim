﻿using System;
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DateTime GetStartDate()
        {
            return startDate.Value;
        }

        public Decimal GetVolume()
        {
            return volumeLitres.Value;
        }

        public Decimal GetDuration()
        {
            return durationMinutes.Value;
        }
    }
}