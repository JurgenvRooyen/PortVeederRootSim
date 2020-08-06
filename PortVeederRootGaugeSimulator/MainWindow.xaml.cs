using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PortVeederRootGaugeSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RootSim rootSim = new RootSim(new List<Tank>());
        public MainWindow()
        {
            InitializeComponent();

            List<TankDrop> tankDrop1 = new List<TankDrop>();
            Tank t = new Tank(1, 100, 5, 30, 5, 15, tankDrop1);
            rootSim.addTank(t);

            tankIdTag.Content = "TankId : " + t.TankId;
            tankLengthTag.Content = "TankLength : " + t.TankLength;
            tankDiameterTag.Content = "TankDiameter : " + t.TankDiameter;
            productLevelTag.Content = "ProductLevel : " + t.ProductLevel;
            productTemeratureTag.Content = "ProductTemerature : " + t.ProductTemerature;
            waterLevelTag.Content = "WaterLevel : " + t.WaterLevel;

        }

        private void MakeTankDrop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TankDrop temp = new TankDrop(int.Parse(volume.Text), DateTime.Now.ToString(), int.Parse(duration.Text));
                bool addable = rootSim.TankList[0].AddTankDrop(temp);
                if (addable)
                {
                    MessageBox.Show("TankDrop added", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    Drops.Content = rootSim.TankList[0].TankDrops.Count + " Tank Drops";
                    volume.Clear();
                    duration.Clear();
                }
                else
                {
                    MessageBox.Show("Tank drop too big", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }



            }
            catch
            {
                MessageBox.Show("wrong input", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void StartDrop_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}