﻿using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public float TankProbeHeight { get; set; }
        public float TankProbeDiameter { get; set; }

        public float productLevel = 0 ;     
        public float GetProductLevel()
        {
            return productLevel;
        }     

        public Boolean SetProductLevel(float value)
        {

            if (value + GetWaterLevel() > TankProbeHeight | value < 0)
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
            if (value + productLevel > TankProbeHeight | value < 0)
            {
                return false;
            }
            waterLevel = value;
            waterVolume = LevelToVolume(value);
            return true;
        }

        public float waterVolume = 0;      
        public float GetWaterVolume()
        {
            return waterVolume;
        }
      
        public Boolean SetWaterVolume(float value)
        {
            if (value + productVolume > FullVolume | value < 0)
            {
                return false;
            }
            waterVolume = value;
            waterLevel = VolumeToLevel(value);
            return true;
        }

        public float ProductTemperature { get; set; }
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
        public List<TankDrop> TankDroppedList { get; set; }


        public Boolean TankDelivering { get; set; }
        public float TankDeliveringPerInterval { get; set; }
        public Boolean TankLeaking { get; set; }
        public float TankLeakingPerInterval { get; set; }
        public Thread ProductChanging{ get; set; }



        public TankProbe(int tankId, char productCode, float tankLength, float tankDiameter, float productValue, float waterValue, float productTemerature,string unit,string tankShapeString="cylinder")
        {
            this.TankProbeId = tankId;
            this.ProductCode = productCode;
            this.TankProbeHeight = tankLength;
            this.TankProbeDiameter = tankDiameter;
            this.TankProbeShape = tankShapeString;
            FullVolume = LevelToVolume(tankLength);
            if (unit == "level")
            {
                SetProductLevel(productValue);
                SetWaterLevel(waterValue);
            }else if (unit == "volume")
            {
                SetProductVolume(productValue);
                SetWaterVolume(waterValue);
            }
            
            this.ProductTemperature = productTemerature;


            this.TankDelivering = false;
            this.TankLeaking = false;

            FullVolume = LevelToVolume(tankLength);

    
            MaxSafeWorkingCapacity      = 0.95F * TankProbeHeight;
            OverFillLimit               = 0.90F * TankProbeHeight;
            HighProductAlarmLevel       = 0.80F * TankProbeHeight;
            DeliveryNeededWarningLevel  = 0.30F * TankProbeHeight;
            LowProductAlarmLevel        = 0.20F * TankProbeHeight;
            HighWaterAlarmLevel         = 0.10F * TankProbeHeight;
            HighWaterWarningLevel       = 0.05F * TankProbeHeight;

            TankDeliveringPerInterval = 50;
            TankLeakingPerInterval = 50;

            TankDroppedList = new List<TankDrop>();
        }


        public Boolean DropTank(float volume, TimeSpan startTime, TimeSpan duration)
        {
            TankDrop td = new TankDrop( volume,
                                        startTime,
                                        this.GetProductVolume(),
                                        this.GetProductLevel(),
                                        this.GetGrossStandardVolume(),
                                        this.GetWaterVolume(),
                                        this.ProductTemperature);
            if (SetProductVolume(this.productVolume + volume))
            {
                td.EndingTime = startTime + duration;
                td.EndingVolume = this.GetProductVolume();
                td.EndingVLevel = this.GetProductLevel();
                td.EndingTemperatureCompensatedVolume = this.GetGrossStandardVolume();
                td.EndingWaterVolume = this.GetWaterVolume();
                td.EndingTemperature = this.ProductTemperature;
                this.TankDroppedList.Add(td);
                return true;
            }
            return false;
        }


        public Boolean  ProductChangePerInterval(float value) 
        {
            // could change 
            return SetProductVolume(this.productVolume + value);
        }

        public void ProductChangeThread(TimeSpan startTime)
        {
            if (TankDelivering)
            {
                TankDrop td =  new TankDrop(0,
                                            startTime,
                                            this.GetProductVolume(),
                                            this.GetProductLevel(),
                                            this.GetGrossStandardVolume(),
                                            this.GetWaterVolume(),
                                            this.ProductTemperature);
                float droppedVolume = 0f;
                TimeSpan startDeliveringtime = DateTime.Now.TimeOfDay;
                while (TankDelivering & ProductChangePerInterval(TankDeliveringPerInterval))
                {
                    droppedVolume += TankDeliveringPerInterval;
                    Thread.Sleep(100);
                }
                td.Volume = droppedVolume;
                TimeSpan endDeliveringtime = DateTime.Now.TimeOfDay;
                td.EndingTime = startTime + startDeliveringtime - endDeliveringtime;
                td.EndingVolume = this.GetProductVolume();
                td.EndingVLevel = this.GetProductLevel();
                td.EndingTemperatureCompensatedVolume = this.GetGrossStandardVolume();
                td.EndingWaterVolume = this.GetWaterVolume();
                td.EndingTemperature = this.ProductTemperature;
                this.TankDroppedList.Add(td);
                return;
            }


            if (TankLeaking)
            {
                while (TankLeaking & ProductChangePerInterval(-TankLeakingPerInterval))
                {
                    Thread.Sleep(100);
                }

                return;
            }
        }

  


        public void DeliverySwich(TimeSpan startTime)

        {

            if (TankDelivering)
            {
                TankDelivering = false;
            }
            else 
            { 
                TankDelivering = true;
                this.ProductChanging = new Thread(() => ProductChangeThread(startTime)); 
                this.ProductChanging.Start(); 
            }
        }

        public void LeakingSwitch()
        {

            if (this.TankLeaking)
            {
                this.TankLeaking = false;
            }
            else
            {
                this.TankLeaking = true;
                this.ProductChanging = new Thread(() => ProductChangeThread(new TimeSpan()));
                this.ProductChanging.Start();
            }
        }

        public float GetGrossObservedVolume() 
        {
            return LevelToVolume(GetProductLevel()) + LevelToVolume(GetWaterLevel());
        }

        public float GetGrossStandardVolume()
        {

            float tempDelta = ProductTemperature - 15;
            return LevelToVolume(GetProductLevel()) * (1 - thermalExpansionCoefficient * tempDelta);
        }

        public float GetUllage() 
        {
            return LevelToVolume(FullVolume - GetProductLevel() - GetWaterLevel());
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
            returnString += "ProductTemerature = " + ProductTemperature.ToString() + "                           ";
            returnString += "TankDropCount = " + TankDropCount.ToString() + "                           ";


            return returnString;
        }
    }
}
