using PortVeederRootGaugeSim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {

        RootSim rootSim = new RootSim(new List<Tank>());
        public Form1()
        {
            InitializeComponent();

            List<TankDrop> tankDrop1 = new List<TankDrop>();
            Tank t = new Tank(1, 100, 5, 30, 5, 15, tankDrop1);
            rootSim.addTank(t);
            textBox1.Text = t.ToString();
        }

        private void AddDropButton_Click(object sender, EventArgs e)
        {
            try
            {
                TankDrop temp = new TankDrop(int.Parse(TankDropVolumeTextArea.Text), DateTime.Now.ToString(), int.Parse(TankDropDurationTextArea.Text));
                Boolean addable = rootSim.TankList[0].AddTankDropAndFeedBack(temp);
                if (!addable)
                {
                    MessageBox.Show("Could Not Drop Tank! Will Exceeds Max Safe Working Capacity!", "Alert");
                    TankDropVolumeTextArea.Clear();
                    TankDropDurationTextArea.Clear();
                }
                else
                {
                    textBox1.Text = rootSim.TankList[0].ToString();
                    TankDropVolumeTextArea.Clear();
                    TankDropDurationTextArea.Clear();
                    MessageBox.Show("Tank Added!", "Alert");
                }



            }
            catch
            {
                MessageBox.Show("wrong input!", "Alert");
            }
        }

        private void StartDropButton_Click(object sender, EventArgs e)
        {
            if (StartDropTimer.Enabled == true)
            {
                StartDropTimer.Enabled = false;
                StartDropButton.Text = "Start Drop";
            }
            else
            {
                StartDropTimer.Enabled = true;
                StartDropButton.Text = "Stop Drop";
            }
        }

        private void StartDropTimer_Tick(object sender, EventArgs e)
        {
            Boolean Droppable = rootSim.TankList[0].TankDroppingPerSecond();
            if (!Droppable) 
            { 
                StartDropButton.Text = "Start Drop";
                StartDropTimer.Enabled = false;
            }
            textBox1.Text = rootSim.TankList[0].ToString();
        }







        private void StartLeakButton_Click(object sender, EventArgs e)
        {
            if (StartLeakTimer.Enabled == true)
            {
                StartLeakTimer.Enabled = false;
                StartLeakButton.Text = "Start Leak";
            }
            else
            {
                StartLeakTimer.Enabled = true;
                StartLeakButton.Text = "Stop Leak";
            }
        }

        private void StartLeakTimer_Tick(object sender, EventArgs e)
        {

            Boolean Leaking = rootSim.TankList[0].TankLeakingPerSecond();
            if (!Leaking)
            {
                StartLeakButton.Text = "Start Leak";
                StartLeakTimer.Enabled = false;
            }
            textBox1.Text = rootSim.TankList[0].ToString();
        }
    }
}
