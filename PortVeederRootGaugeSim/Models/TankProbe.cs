using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace PortVeederRootGaugeSim
{
    class TankProbe
    {
        // Tank attributes
        public int TankProbeId { get; set; }
        public char ProductCode { get; set; }
        public string TankProbeShape { get; set; }
        public float TankProbeHight { get; set; }
        public float TankProbeDiameter { get; set; }

        public float productLevel = 0 ;     
        public float GetProductLevel()
        {
            return productLevel;
        }     
        public Boolean SetProductLevel(float value)
        {
            if (value + GetWaterLevel()> TankProbeHight | value < 0)
            {
                return false;
            }
            productLevel = value;
            productVolume = (LevelToVolume(value));
            return true;
            
        }

        private float productVolume = 0;   
        public float GetProductVolume()
        {
            return productVolume;
        }    
        public Boolean SetProductVolume(float value)
        {
            if (value + waterVolume > FullVolume | value < 0)
            {
                return false;
            }
            productVolume = value;
            productLevel = (VolumeToLevel(value));
            return true;
        }

        public float waterLevel = 0;       
        public float GetWaterLevel()
        {
            return waterLevel;
        }       
        public Boolean SetWaterLevel(float value)
        {
            if (value + productLevel > TankProbeHight | value < 0)
            {
                return false;
            }
            waterLevel = value;
            waterVolume = LevelToVolume(value);
            return true;
        }

        public float waterVolume = 0;      
        public float GetwaterVolume()
        {
            return waterVolume;
        }      
        public Boolean SetwaterVolume(float value)
        {
            if (value + productVolume > FullVolume | value < 0)
            {
                return false;
            }
            waterVolume = value;
            waterLevel = VolumeToLevel(value);
            return true;
        }

        public float ProductTemerature { get; set; }
        public float TankDropCount { get; set; }

        public const float thermalExpansionCoefficient = 0.0018F; 

        // Alarm attributes
        public float FullVolume { get; }

        public float MaxSafeWorkingCapacity { get; set; }
        public float OverFillLimit { get; set; }
        public float HighProductAlarmLevel { get; set; }
        public float DeliveryNeededWarningLevel { get; set; }
        public float LowProductAlarmLevel { get; set; }
        public float HighWaterAlarmLevel { get; set; }
        public float HighWaterWarningLevel { get; set; }


        // tank dropping attributes
        public Boolean TankDelivering { get; set; }
        public Boolean TankLeaking { get; set; }
        public Thread ProductChanging{ get; set; }



        public TankProbe(int tankId, char productCode, float tankLength, float tankDiameter, float productValue, float waterValue, float productTemerature,string unit,string tankShapeString="cylinder")
        {
            this.TankProbeId = tankId;
            this.ProductCode = productCode;
            this.TankProbeHight = tankLength;
            this.TankProbeDiameter = tankDiameter;
            this.TankProbeShape = tankShapeString;
            if (unit == "level")
            {
                SetProductLevel(productValue);
                SetWaterLevel(waterValue);
            }else if (unit == "volume")
            {
                SetProductVolume(productValue);
                SetwaterVolume(waterValue);
            }
            
            this.ProductTemerature = productTemerature;


            this.TankDelivering = false;
            this.TankLeaking = false;


            FullVolume = LevelToVolume(tankLength);

    
            MaxSafeWorkingCapacity      = 0.95F * TankProbeHight;
            OverFillLimit               = 0.90F * TankProbeHight;
            HighProductAlarmLevel       = 0.80F * TankProbeHight;
            DeliveryNeededWarningLevel  = 0.30F * TankProbeHight;
            LowProductAlarmLevel        = 0.20F * TankProbeHight;
            HighWaterAlarmLevel         = 0.10F * TankProbeHight;
            HighWaterWarningLevel       = 0.05F * TankProbeHight;

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



        public Boolean  ProducChangePerInterval(float value) 
        {
            // could change 
            float IncreasdVolume = value;
            return SetProductVolume(this.productVolume + IncreasdVolume);
        }

        public void ProductChangeThread(float value)
        {
            if (TankDelivering)
            {
                while (TankDelivering & ProducChangePerInterval(value))
                {
                    Thread.Sleep(100);
                }
                TankDelivering = false;
                this.TankDropCount += 1;
                return;
            }
            if (TankLeaking)
            {
                while (TankLeaking & ProducChangePerInterval(value))
                {
                    Thread.Sleep(100);
                }
                TankLeaking = false;
                return;
            }
        }

  

        public void DeliverySwich(float value)
        {

            if (TankDelivering)
            {
                TankDelivering = false;
            }
            else 
            {
                
                TankDelivering = true;
                this.ProductChanging = new Thread(() => ProductChangeThread(value)); 
                this.ProductChanging.Start(); 
            }
        }

        public void LeakingSwich(float value)
        {

            if (this.TankLeaking)
            {
                this.TankLeaking = false;
            }
            else
            {

                this.TankLeaking = true;
                this.ProductChanging = new Thread(() => ProductChangeThread(-value));
                this.ProductChanging.Start();
            }
        }



        public float GetGrossObservedVolume() 
        {
            return LevelToVolume(GetProductLevel()) + LevelToVolume(GetWaterLevel());
        }

        public float GetGrossStandardVolume()
        {
            float tempDelta = ProductTemerature - 15;
            return LevelToVolume(GetProductLevel()) * (1 - thermalExpansionCoefficient * tempDelta);
        }

        public float GetUllage() 
        {
            return LevelToVolume(MaxSafeWorkingCapacity - GetProductLevel() - GetWaterLevel());
        }

        public Boolean[] GetTankStatus(){
            //TODO
            //Need To Add Invalid Fuel Height Alarm !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Boolean[] temp = { this.TankDelivering, this.TankLeaking };

            return temp;
        }


       





        private float VolumeToLevel(float v) 
        {
           float l = (float)(v / (Math.PI * Math.Pow(TankProbeDiameter / 2, 2)));
           return l;
        }

        private float LevelToVolume(float l)
        {
            float v = (float)(l * (Math.PI * Math.Pow(TankProbeDiameter / 2, 2)));
            return v;
        }

        




     


        public void Connect(TankProbe t)
        {
            //TODO-Optional
        }

   


        public override string ToString()
        {
            String returnString = "";
            returnString += "TankProbeId = " + TankProbeId.ToString() + "                                               ";
            returnString += "productLevel = " + productLevel.ToString() + "                                  ";
            returnString += "productVolume = " + productVolume.ToString() + "                               ";
            returnString += "waterLevel = " + waterLevel.ToString() + "                                                 ";
            returnString += "waterVolume = " + waterVolume.ToString() + "                        ";
            returnString += "ProductTemerature = " + ProductTemerature.ToString() + "                           ";
            returnString += "TankDropCount = " + TankDropCount.ToString() + "                           ";


            return returnString;
        }
    }
}
