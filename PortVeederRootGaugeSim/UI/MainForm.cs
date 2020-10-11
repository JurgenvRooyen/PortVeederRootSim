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
        private readonly RootSim rootSim;
        private readonly DebugPortVeederRoot debugOptions;
        private static readonly Timer refreshTimer = new Timer();

        public MainForm(RootSim root, DebugPortVeederRoot debug)
        {
            rootSim = root;
            debugOptions = debug;
            InitializeComponent();
            try
            {
                rootSim.LoadFile("ProbePersistence");
                foreach (TankProbe tank in rootSim.TankProbeList)
                {
                    flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, rootSim.TankProbeList[numberOfTanks]));
                    numberOfTanks++;
                }
                numberOfTanks--; // removes 1 as an extra 1 is added in the loop
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
                rootSim.AddTankProbe(new TankProbe(numberOfTanks, '1', new Tank(1000,2000), 0, 0, 15));
                flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, rootSim.TankProbeList[numberOfTanks]));
                deleteProbeButton.Enabled = false;
                ConnectProbeButton.Enabled = false;
                string title = "Error Loading File";
                string message = "Probe Persistence file not found or invalid";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            foreach(var menuItem in debugOptions.MenuOutput())
            {
                ToolStripMenuItem toolMenuItem = new ToolStripMenuItem(menuItem.Key, null, OptionMenuItem_Click);
                toolMenuItem.Checked = menuItem.Value;
                OptionsMenuItem.DropDownItems.Add(toolMenuItem);
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
            // disconnect all potentially operating buttons when form is closed
            // if buttons are not disconnected - issues when clicking buttons on re-opening
            if (flowLayoutPanel.Controls.Count > 1)
            {
                rootSim.TankProbeList[0].Disconnect(rootSim.TankProbeList[1]);
            }
            foreach (TankUserControl probeControl in flowLayoutPanel.Controls)
            {
                TankProbe tankProbe = probeControl.GetTankProbe();
                tankProbe.TankDelivering = false;
                tankProbe.TankLeaking = false;
            }
            rootSim.SaveFile("ProbePersistence");
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
            rootSim.AddTankProbe(new TankProbe(numberOfTanks, '1',new Tank(1000,2000), 0, 0, 15));
            flowLayoutPanel.Controls.Add(new TankUserControl(numberOfTanks, rootSim.TankProbeList[numberOfTanks]));       
        }

        private void DeleteProbeButton_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel.Controls.Count > 1)
            {
                flowLayoutPanel.Controls.RemoveAt(flowLayoutPanel.Controls.Count - 1);
                rootSim.RemoveTankProbe(numberOfTanks);
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
            var menuItem = (ToolStripMenuItem)sender;
            var menuText = menuItem.Text;

            switch(menuText)
            {
#if ITLDEBUG
                case "Include Heights":
                    debugOptions.ToggleIncludeHeights();
                    CheckIncludeHeights(debugOptions.IncludeHeights);
                    break;

                case "Support BIR":
                    debugOptions.ToggleSupportBIR();
                    CheckSupportBIR(debugOptions.SupportBIR);
                    break;

                case "Version Respond":
                    debugOptions.ToggleVersionRespond();
                    CheckVersionRespond(debugOptions.VersionRespond);
                    break;

                case "Tank Drop Respond":
                    debugOptions.ToggleTankDropRespond();
                    CheckTankDropRespond(debugOptions.TankDropRespond);
                    break;

                case "Date Time Respond":
                    debugOptions.ToggleDateTimeRespond();
                    CheckDateTimeRespond(debugOptions.DateTimeRespond);
                    break;

                case "Respond to All Probes":
                    debugOptions.ToggleRespondToAllProbes();
                    CheckRespondToAllProbes(debugOptions.RespondToAllProbes);
                    break;

                case "Event AckNak Respond":
                    debugOptions.ToggleEventAckNakRespond();
                    CheckEventAckNakRespond(debugOptions.EventAckNakRespond);
                    break;

                case "Zero Based Tank Delivery":
                    debugOptions.ToggleDeliveryTankZeroBased();
                    CheckDeliveryTankZeroBased(debugOptions.DeliveryTankZeroBased);
                    break;

                case "Update Volume Using BIR":
                    debugOptions.ToggleUpdatevolumeUsingBIR();
                    CheckUpdateVolumeUsingBIR(debugOptions.UpdateVolumeUsingBIR);
                    break;

                case "Randomize Levels":
                    debugOptions.ToggleRandomizeLevels();
                    CheckRandomizeLevels(debugOptions.RandomizeLevels);
                    break;

                case "Force Rnd Msg":
                    debugOptions.ToggleForceRndMsg();
                    CheckForceRndMsg(debugOptions.ForceRndMsg);
                    break;

                case "Invalid Drop Number":
                    debugOptions.ToggleInvalidDropNumber();
                    CheckInvalidTankDropNumber((ToolStripMenuItem) sender, debugOptions.InvalidTankDropNumber);
                    break;

                case "Invalid Data Termination Flag":
                    debugOptions.ToggleInvalidDataTerminationFlag();
                    CheckInvalidDataTerminationFlag((ToolStripMenuItem) sender, debugOptions.InvalidDataTerminationFlag);
                    break;
#else
                case "Invalid Drop Number":
                    debugOptions.ToggleInvalidDropNumber();
                    CheckInvalidTankDropNumber((ToolStripMenuItem) sender, debugOptions.InvalidTankDropNumber);
                    break;

                case "Invalid Data Termination Flag":
                    debugOptions.ToggleInvalidDataTerminationFlag();
                    CheckInvalidDataTerminationFlag((ToolStripMenuItem) sender, debugOptions.InvalidDataTerminationFlag);
                    break;
#endif
            }
        }

        private void ConnectProbeButton_Click(object sender, EventArgs e)
        {
            if (rootSim.TankProbeList[0].MyTank.Connecting)
            {
                rootSim.TankProbeList[0].Disconnect(rootSim.TankProbeList[1]);
                ConnectProbeButton.Text = "Connect Probe 1 + 2";
                ConnectProbeButton.BackColor = Control.DefaultBackColor;
                ConnectProbeButton.UseVisualStyleBackColor = true;
            }
            else
            {
                rootSim.TankProbeList[0].Connect(rootSim.TankProbeList[1]);
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

        private void CheckInvalidTankDropNumber(ToolStripMenuItem sender, bool invalidDropNumber)
        {
            if (invalidDropNumber)
            {
                sender.Checked = true;
            }
            else
            {
                sender.Checked = false;
            }
        }

        private void CheckSupportBIR(bool supportBIR)
        {
            if (supportBIR)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[2]).Checked = true;
                OptionsMenuItem.DropDownItems[7].Enabled = true;
                OptionsMenuItem.DropDownItems[9].Enabled = true;
                OptionsMenuItem.DropDownItems[10].Enabled = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[2]).Checked = false;
                OptionsMenuItem.DropDownItems[7].Enabled = false;
                OptionsMenuItem.DropDownItems[9].Enabled = false;
                OptionsMenuItem.DropDownItems[10].Enabled = false;
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

        private void CheckInvalidDataTerminationFlag(ToolStripMenuItem sender, bool invalidFlag)
        {
            if (invalidFlag)
            {
                sender.Checked = true;
            }
            else
            {
                sender.Checked = false;
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

        private void CheckUpdateVolumeUsingBIR(bool updateVolume)
        {
            if (updateVolume)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[10]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[10]).Checked = false;
            }
        }

        private void CheckRandomizeLevels(bool randomizeLevels)
        {
            if (randomizeLevels)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[11]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[11]).Checked = false;
            }
        }

        private void CheckForceRndMsg(bool forceRndMsg)
        {
            if (forceRndMsg)
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[12]).Checked = true;
            }
            else
            {
                ((ToolStripMenuItem)OptionsMenuItem.DropDownItems[12]).Checked = false;
            }
        }
    }
}
