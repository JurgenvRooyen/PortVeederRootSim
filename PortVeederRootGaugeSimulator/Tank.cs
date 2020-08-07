using System;
using System.Collections.Generic;
using System.Text;

namespace PortVeederRootGaugeSimulator
{
    class Tank
    {
        public int TankId { get; set; }
        public double TankLength { get; set; }
        public double TankDiameter { get; set; }
        public double FullVolume { get; set; }
        public double ProductLevel { get; set; }
        public double WaterLevel { get; set; }
        public int ProductTemerature { get; set; }
        public List<TankDrop> TankDrops { get; set; }

        // Alarm, we could have some default value first. then user could edit it.
        public double OverFillLimit { get; set; }



        public Tank(int tankId, double tankLength, double tankDiameter, double productLevel, double waterLevel, int productTemerature, List<TankDrop> tankDrops)
        {
            TankId = tankId;
            TankLength = tankLength;
            TankDiameter = tankDiameter;
            ProductLevel = productLevel;
            WaterLevel = waterLevel;
            ProductTemerature = productTemerature;
            TankDrops = tankDrops;

            FullVolume = Math.PI * Math.Pow(TankDiameter / 2, 2) * tankLength;

            // Alarm attr
            OverFillLimit = 0.9 * TankLength;
           
        }

        public bool AddTankDrop(TankDrop tp)
        {
            double PotentialIncreaseLevel = tp.Volume / (Math.PI * Math.Pow(TankDiameter / 2, 2));

            // check if we could add tank or not
            if (ProductLevel + getPotentialProductLevel() + PotentialIncreaseLevel > OverFillLimit)
            {
                return false;
            }

            TankDrops.Add(tp);
            return true;
        }


        public double getPotentialProductLevel()
        {
            double PotentialVolume = 0;

            for (int i = 0; i < TankDrops.Count; i++)
            {
                PotentialVolume += TankDrops[i].Volume;
            }

            double PotentialProductLevel = PotentialVolume / (Math.PI * Math.Pow(TankDiameter / 2, 2));

            return PotentialProductLevel;
        }

    }
}
