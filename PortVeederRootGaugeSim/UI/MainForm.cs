using PortVeederRootGaugeSim.IO.PortVeederRoot;
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
        private readonly DebugPortVeederRoot debugOptions;
        private static readonly Timer refreshTimer = new Timer();

        public MainForm(RootSim root, DebugPortVeederRoot debug)
        {
            TankGauges = root;
            debugOptions = debug;
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
            
            foreach(var menuItem in debugOptions.MenuOutput())
            { 
                OptionsMenuItem.DropDownItems.Add(menuItem, null, OptionMenuItem_Click);
            }
        } 

        private void MainForm_Load(object sender, EventArgs e)
        {
            refreshTimer.Tick += TimerEventProcessor;
            refreshTimer.Interval = 500;
            refreshTimer.Enabled = true;
            CheckIncludeHeights(debugOptions.IncludeHeights);
            CheckInvalidTankDropNumber(debugOptions.InvalidTankDropNumber);
            CheckSupportBIR(debugOptions.SupportBIR);
            CheckVersionRespond(debugOptions.VersionRespond);
            CheckTankDropRespond(debugOptions.TankDropRespond);
            CheckDateTimeRespond(debugOptions.DateTimeRespond);
            CheckRespondToAllProbes(debugOptions.RespondToAllProbes);
            CheckEventAckNakRespond(debugOptions.EventAckNakRespond);
            CheckInvalidDataTerminationFlag(debugOptions.InvalidDataTerminationFlag);
            CheckDeliveryTankZeroBased(debugOptions.DeliveryTankZeroBased);
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

        private void OptionMenuItem_Click(object sender, EventArgs e)
        {
            const string includeHeights = "Include Heights";
            const string invalidDropNumber = "Invalid Drop Number";
            const string supportBIR = "Support BIR";
            const string versionRespond = "Version Respond";
            const string tankDropRespond = "Tank Drop Respond";
            const string dateTimeRespond = "Date Time Respond";
            const string respondToAllProbes = "Respond to All Probes";
            const string eventAckNakRespond = "Event AckNak Respond";
            const string invalidDataTermination = "Invalid Data Termination Flag";
            const string zeroBasedTankDelivery = "Zero Based Tank Delivery";
            var menuItem = (ToolStripMenuItem)sender;
            var menuText = menuItem.Text;

            switch(menuText)
            {
                case includeHeights:
                    debugOptions.ToggleIncludeHeights();
                    CheckIncludeHeights(debugOptions.IncludeHeights);
                    break;

                case invalidDropNumber:
                    debugOptions.ToggleInvalidDropNumber();
                    CheckInvalidTankDropNumber(debugOptions.InvalidTankDropNumber);
                    break;

                case supportBIR:
                    debugOptions.ToggleSupportBIR();
                    CheckSupportBIR(debugOptions.SupportBIR);
                    break;

                case versionRespond:
                    debugOptions.ToggleVersionRespond();
                    CheckVersionRespond(debugOptions.VersionRespond);
                    break;

                case tankDropRespond:
                    debugOptions.ToggleTankDropRespond();
                    CheckTankDropRespond(debugOptions.TankDropRespond);
                    break;

                case dateTimeRespond:
                    debugOptions.ToggleDateTimeRespond();
                    CheckDateTimeRespond(debugOptions.DateTimeRespond);
                    break;

                case respondToAllProbes:
                    debugOptions.ToggleRespondToAllProbes();
                    CheckRespondToAllProbes(debugOptions.RespondToAllProbes);
                    break;

                case eventAckNakRespond:
                    debugOptions.ToggleEventAckNakRespond();
                    CheckEventAckNakRespond(debugOptions.EventAckNakRespond);
                    break;

                case invalidDataTermination:
                    debugOptions.ToggleInvalidDataTerminationFlag();
                    CheckInvalidDataTerminationFlag(debugOptions.InvalidDataTerminationFlag);
                    break;

                case zeroBasedTankDelivery:
                    debugOptions.ToggleDeliveryTankZeroBased();
                    CheckDeliveryTankZeroBased(debugOptions.DeliveryTankZeroBased);
                    break;
            }
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

        private void CheckIncludeHeights(bool includeHeights)
        {
            if (includeHeights)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[0]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[0]).Checked = false;
            }
        }

        private void CheckInvalidTankDropNumber(bool invalidDropNumber)
        {
            if (invalidDropNumber)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[1]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[1]).Checked = false;
            }
        }

        private void CheckSupportBIR(bool supportBIR)
        {
            if (supportBIR)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[2]).Checked = true;
                OptionsMenuItem.DropDownItems[7].Enabled = true;
                OptionsMenuItem.DropDownItems[9].Enabled = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[2]).Checked = false;
                OptionsMenuItem.DropDownItems[7].Enabled = false;
                OptionsMenuItem.DropDownItems[9].Enabled = false;
            }
        }

        private void CheckVersionRespond(bool versionRespond)
        {
            if (versionRespond)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[3]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[3]).Checked = false;
            }
        }

        private void CheckTankDropRespond(bool dropRespond)
        {
            if (dropRespond)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[4]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[4]).Checked = false;
            }
        }
        
        private void CheckDateTimeRespond(bool dateRespond)
        {
            if (dateRespond)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[5]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[5]).Checked = false;
            }
        }

        private void CheckRespondToAllProbes(bool probeRespond)
        {
            if (probeRespond)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[6]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[6]).Checked = false;
            }
        }

        private void CheckEventAckNakRespond(bool eventRespond)
        {
            if (eventRespond)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[7]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[7]).Checked = false;
            }
        }

        private void CheckInvalidDataTerminationFlag(bool invalidFlag)
        {
            if (invalidFlag)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[8]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[8]).Checked = false;
            }
        }

        private void CheckDeliveryTankZeroBased(bool deliveryZero)
        {
            if (deliveryZero)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[9]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[9]).Checked = false;
            }
        }
    }
}
