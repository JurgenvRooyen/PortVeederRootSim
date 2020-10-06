using System;
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
            volumeLitres.Value = 500;
            durationMinutes.Value = 20;
        }
        private void OkayButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
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
