using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace PortVeederRootGaugeSim
{
    public class TankProbe
    {
        // Tank attributes
        public int TankProbeId { get; set; }
        public string TankProbeShape { get; set; }
        public double TankProbeHeight { get; set; }
        public double TankProbeDiameter { get; set; }

        public double productLevel = 0; public double GetProductLevel()
        {
            return productLevel;
        }
        public Boolean SetProductLevel(double value)
        {
            if (value + GetWaterLevel() > TankProbeHeight)
            {
                return false;
            }
            productLevel = value;
            productVolume = (LevelToVolume(value));
            return true;

        }

        private double productVolume = 0; public double GetProductVolume()
        {
            return productVolume;
        }
        public Boolean SetProductVolume(double value)
        {
            if (value + waterVolume > FullVolume)
            {
                return false;
            }
            productVolume = value;
            productLevel = (VolumeToLevel(value));
            return true;
        }

        public double waterLevel = 0; public double GetWaterLevel()
        {
            return waterLevel;
        }
        public Boolean SetWaterLevel(double value)
        {
            if (value + productLevel > TankProbeHeight)
            {
                return false;
            }
            waterLevel = value;
            waterVolume = LevelToVolume(value);
            return true;
        }

        public double waterVolume = 0; public double GetwaterVolume()
        {
            return waterVolume;
        }
        public Boolean SetwaterVolume(double value)
        {
            if (value + productVolume > FullVolume)
            {
                return false;
            }
            waterLevel = value;
            waterVolume = value * 10;
            return true;
        }

        public int ProductTemerature { get; set; }
        public int TankDropCount { get; set; }

        public const double thermalExpansionCoefficient = 0.0018;

        // Alarm attributes
        public double FullVolume { get; set; }

        public double MaxSafeWorkingCapacity { get; set; }
        public double OverFillLimit { get; set; }
        public double HighProductAlarmLevel { get; set; }
        public double DeliveryNeededWarningLevel { get; set; }
        public double LowProductAlarmLevel { get; set; }
        public double HighWaterAlarmLevel { get; set; }
        public double HighWaterWarningLevel { get; set; }


        // tank dropping attributes
        public Boolean TankDelivering { get; set; }
        public Boolean TankLeaking { get; set; }
        public Thread DeliveringThread { get; set; }



        public TankProbe(int tankId, double tankLength, double tankDiameter, double productValue, double waterValue, int productTemerature, string unit, string tankShapeString = "cylinder")
        {
            this.TankProbeId = tankId;
            this.TankProbeHeight = tankLength;
            this.TankProbeDiameter = tankDiameter;
            this.TankProbeShape = tankShapeString;
            if (unit == "level")
            {
                SetProductLevel(productValue);
                SetWaterLevel(waterValue);
            }
            else if (unit == "volume")
            {
                SetProductVolume(productValue);
                SetwaterVolume(waterValue);
            }

            this.ProductTemerature = productTemerature;


            this.TankDelivering = false;
            this.TankLeaking = false;
            DeliveringThread = new Thread(new ThreadStart(DeliveryThread));


            FullVolume = LevelToVolume(tankLength);


            MaxSafeWorkingCapacity = 0.95 * TankProbeHeight;
            OverFillLimit = 0.90 * TankProbeHeight;
            HighProductAlarmLevel = 0.80 * TankProbeHeight;
            DeliveryNeededWarningLevel = 0.30 * TankProbeHeight;
            LowProductAlarmLevel = 0.20 * TankProbeHeight;
            HighWaterAlarmLevel = 0.10 * TankProbeHeight;
            HighWaterWarningLevel = 0.05 * TankProbeHeight;

        }


        public TankProbe(int tankId, double TankVolume, double productValue, double waterValue, int productTemerature)
        {
            this.TankProbeId = tankId;
            this.FullVolume = TankVolume;
            this.ProductTemerature = productTemerature;
            this.TankDelivering = false;
            this.TankLeaking = false;
            this.TankProbeHeight = TankVolume / 10;
            this.waterLevel = waterValue;
            this.productLevel = productValue;
            this.productVolume = productValue * 10;
            this.waterVolume = waterValue * 10;

            DeliveringThread = new Thread(new ThreadStart(DeliveryThread));

            MaxSafeWorkingCapacity = 0.90 * TankProbeHeight;
            OverFillLimit = 0.90 * TankProbeHeight;
            HighProductAlarmLevel = 0.80 * TankProbeHeight;
            DeliveryNeededWarningLevel = 0.30 * TankProbeHeight;
            LowProductAlarmLevel = 0.20 * TankProbeHeight;
            HighWaterAlarmLevel = 0.10 * TankProbeHeight;
            HighWaterWarningLevel = 0.05 * TankProbeHeight;

        }

        public Boolean TankDrop(TankDrop tp)
        {
            Boolean Dropped = SetProductVolume(this.productVolume + tp.Volume);
            if (Dropped)
            {
                this.TankDropCount += 1;
            }
            return Dropped;

        }

        public Boolean DeliveryPerInterval()
        {
            // could change 
            double IncreasdVolume = 50;
            return SetProductVolume(this.productVolume + IncreasdVolume);
        }

        public void DeliveryThread()
        {
            while (this.TankDelivering & DeliveryPerInterval())
            {
                Thread.Sleep(100);
            }
            this.TankDelivering = false;
            this.TankDropCount += 1;
        }

        public void DeliverySwich()
        {

            if (this.TankDelivering)
            {
                this.TankDelivering = false;
            }
            else
            {
                this.TankDelivering = true;
                this.DeliveringThread = new Thread(new ThreadStart(DeliveryThread));
                this.DeliveringThread.Start();
            }
        }


        public double GetGOV()
        {
            return (productLevel * 10) + (waterLevel * 10);
        }

        public double GetGSV()
        {
            double tempDelta = ProductTemerature - 15;
            double calc = productLevel * (1 - thermalExpansionCoefficient * tempDelta);
            return Math.Round(10 * calc, 2);
        }
        public double GetGrossObservedVolume()
        {
            return LevelToVolume(GetProductLevel()) + LevelToVolume(GetWaterLevel());
        }

        public double GetGrossStandardVolume()
        {
            double tempDelta = ProductTemerature - 15;
            return LevelToVolume(GetProductLevel()) * (1 - thermalExpansionCoefficient * tempDelta);
        }

        public double GetUllage2()
        {
            return 10 * (MaxSafeWorkingCapacity - productLevel - waterLevel);
        }
        public double GetUllage()
        {
            return LevelToVolume(MaxSafeWorkingCapacity - GetProductLevel() - GetWaterLevel());
        }

        public Boolean[] GetTankStatus()
        {
            //TODO
            //Need To Add Invalid Fuel Height Alarm !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Boolean[] temp = { this.TankDelivering, this.TankLeaking };

            return temp;
        }

        private double VolumeToLevel(double v)
        {
            double l = v / (Math.PI * Math.Pow(TankProbeDiameter / 2, 2));
            return l;
        }

        private double LevelToVolume(double l)
        {
            double v = l * (Math.PI * Math.Pow(TankProbeDiameter / 2, 2));
            return v;
        }

        public void Connect(TankProbe t)
        {
            //TODO-Optional
        }

        public void Leaking()
        {
            //TODO-Optional
        }

        public override string ToString()
        {
            String returnString = "";
            returnString += "TankProbeId = " + TankProbeId.ToString() + "                                               ";
            returnString += "productLevel = " + productLevel.ToString() + "               ";
            returnString += "productVolume = " + productVolume.ToString() + "             ";
            returnString += "waterLevel = " + waterLevel.ToString() + "                                                   ";
            returnString += "waterVolume = " + waterVolume.ToString() + "                 ";
            returnString += "ProductTemerature = " + ProductTemerature.ToString() + "                           ";
            returnString += "TankDropCount = " + TankDropCount.ToString() + "                           ";


            return returnString;
        }

        public string getProductVolumeString()
        {
            return Convert.ToString(productVolume);
        }

    }
}
