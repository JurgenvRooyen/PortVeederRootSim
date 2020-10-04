using PortVeederRootGaugeSim.UI;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace PortVeederRootGaugeSim
{

    public partial class MainForm : Form
    {
        private int numberOfTanks = 0;
        private readonly RootSim TankGauges;
        private static readonly Timer refreshTimer = new Timer();

        public MainForm(RootSim r)
        {
            TankGauges = r;
            InitializeComponent();
            try
            {
                TankGauges.LoadFile("ProbePersistence");
                foreach (TankProbe tank in TankGauges.TankProbeList)
                {
                    flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, TankGauges.TankProbeList[numberOfTanks]));
                    numberOfTanks++;
                }
                numberOfTanks--;
                if (flowLayoutPanel.Controls.Count < 2)
                {
                    deleteProbeButton.Enabled = false;
                    ConnectProbeButton.Enabled = false;
                }
                else
                {
                    deleteProbeButton.Enabled = true;
                    ConnectProbeButton.Enabled = true;
                }
            }
            catch
            {
                TankGauges.AddTankProbe(new TankProbe(numberOfTanks, '1', new Tank(1000,2000), 0, 0, 15));
                flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, TankGauges.TankProbeList[numberOfTanks]));
                deleteProbeButton.Enabled = false;
                ConnectProbeButton.Enabled = false;
                string title = "Error Loading File";
                string message = "Probe Persistence file not found or invalid";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            refreshTimer.Tick += TimerEventProcessor;
            refreshTimer.Interval = 500;
            refreshTimer.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flowLayoutPanel.Controls.Count > 1)
            {
                TankGauges.TankProbeList[0].Disconnect(TankGauges.TankProbeList[1]);
            }
            foreach (TankUserControl probeControl in flowLayoutPanel.Controls)
            {
                TankProbe tankProbe = probeControl.GetTankProbe();
                tankProbe.TankDelivering = false;
                tankProbe.TankLeaking = false;
            }
            TankGauges.SaveFile("ProbePersistence");
        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            foreach (TankUserControl probeControl in flowLayoutPanel.Controls) {
                probeControl.UpdateLabels();
            }
        }

        private void AddProbeButton_Click(object sender, EventArgs e)
        {
            deleteProbeButton.Enabled = true;
            ConnectProbeButton.Enabled = true;
            numberOfTanks++;
            
            TankGauges.AddTankProbe(new TankProbe(numberOfTanks, '1',new Tank(1000,2000), 0, 0, 15));
            flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, TankGauges.TankProbeList[numberOfTanks]));       
        }

        private void DeleteProbeButton_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel.Controls.Count > 1)
            {
                flowLayoutPanel.Controls.RemoveAt(flowLayoutPanel.Controls.Count - 1);
                TankGauges.RemoveTankProbe(numberOfTanks);
                numberOfTanks--;
                if (flowLayoutPanel.Controls.Count.Equals(1))
                {
                    deleteProbeButton.Enabled = false;
                    ConnectProbeButton.Enabled = false;
                }
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            string message = "About information";
            string title = "About Veeder-Root TLS Simulator by ITL";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EchoTestMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PortVeederRootMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ConnectProbeButton_Click(object sender, EventArgs e)
        {
            if (TankGauges.TankProbeList[0].MyTank.Connecting)
            {
                TankGauges.TankProbeList[0].Disconnect(TankGauges.TankProbeList[1]);
                ConnectProbeButton.Text = "Connect Probe 1 + 2";
                ConnectProbeButton.BackColor = Control.DefaultBackColor;
                ConnectProbeButton.UseVisualStyleBackColor = true;
            }
            else
            {
                TankGauges.TankProbeList[0].Connect(TankGauges.TankProbeList[1]);
                ConnectProbeButton.Text = "Disconnect Probe 1 + 2";
                ConnectProbeButton.BackColor = Color.Green;
            }
        }
    }
}