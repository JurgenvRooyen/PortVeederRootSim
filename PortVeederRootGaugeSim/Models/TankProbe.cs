using System;
using System.Collections.Generic;
using System.Threading;

namespace PortVeederRootGaugeSim
{
    [Serializable]
    public class TankProbe
    {
        // Tank attributes
        public int TankProbeId { get; set; }
        public char ProductCode { get; set; }

        public string TankprobeStatus { get; set; }
        public string TankProbeShape { get; set; }
        public float TankProbeLength { get; private set; }
        
        public float TankProbeDiameter { get; private set; }

            // critical section starts
        private readonly object ProductLevelLock = new object();
        public float ProductLevel { get; private set; }

        private readonly object ProductVolumeLock = new object();
        public float ProductVolume { get; private set; }
            // critical section ends

        public float WaterLevel { get; set; }
        public float WaterVolume { get; set; }
        public float ProductTemperature { get; set; }
        public float TankDropCount { get; set; }
        public const float thermalExpansionCoefficient = 0.0018F;

        


        // Alarm attributes
        public float FullVolume { get; set; }
        public float MaxSafeWorkingCapacity { get; set; }
        public float MaxSafeWorkingCapacityModifier { get; set; }
        public float OverFillLimitLevel { get; set; }
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


        // connection status
        public Boolean Connecting { get; set; }
        public int ConnectedTo { get; set; } // store other tank's ID



        // Getters and Setters

        public void SetTankProbeLength(float value)
        {
            TankProbeLength = value;
            FullVolume = Models.Helper.LevelToVolume_Horizontal(TankProbeDiameter, TankProbeLength, TankProbeDiameter);
        }

        public void SetTankProbeDiameter(float value)
        {
            TankProbeDiameter = value;
            FullVolume = Models.Helper.LevelToVolume_Horizontal(TankProbeDiameter, TankProbeLength, TankProbeDiameter);
        }


        public Boolean SetByProductLevel(float value)
        {

            if (value + WaterLevel > TankProbeDiameter | value < 0)
            {
                return false;
            }
            lock (ProductLevelLock)
            {
                ProductLevel = value;
            }
            lock (ProductVolumeLock)
            {
                ProductVolume = Models.Helper.LevelToVolume_Horizontal(value, TankProbeLength, TankProbeDiameter);
            }

            return true;
        }

        public Boolean SetProductVolume(float value)
        {

            if (value + WaterVolume > FullVolume | value < 0)
            {
                return false;
            }

            lock (ProductVolumeLock)
            {
                ProductVolume = value;
            }

            lock (ProductLevelLock)
            {
                ProductLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0, value, 0, TankProbeLength, TankProbeDiameter);
            }

            return true;
        }



        public Boolean SetWaterLevel(float value)
        {
            if (value + ProductLevel > TankProbeDiameter | value < 0)
            {
                return false;
            }
            WaterLevel = value;
            WaterVolume = Models.Helper.LevelToVolume_Horizontal(value, TankProbeLength, TankProbeDiameter);
            return true;
        }

        public Boolean SetWaterVolume(float value)
        {
            if (value + ProductVolume > FullVolume | value < 0)
            {
                return false;
            }
            WaterLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0, value, 0, TankProbeLength, TankProbeDiameter);
            WaterVolume = value;
            return true;
        }

        public void SetMaxSafeWorkingCapacityByLevel(float level)
        {
            MaxSafeWorkingCapacity = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0, level, 0, TankProbeLength, TankProbeDiameter);
        }


        public TankProbe(int tankId, char productCode, float tankLength, float tankDiameter,  float productValue, float waterValue, float productTemperature, string unit, string tankShapeString = "cylinder")
        {
            TankProbeId = tankId;
            ProductCode = productCode;
            TankprobeStatus = "OK";
            TankProbeLength = tankLength;
            TankProbeDiameter = tankDiameter;
            TankProbeShape = tankShapeString;
            FullVolume = Models.Helper.LevelToVolume_Horizontal(tankDiameter,tankLength, TankProbeDiameter);

            if (unit == "level")
            {
                SetWaterLevel(waterValue);
                SetByProductLevel(productValue);  
            }
            else if (unit == "volume")
            {
                SetWaterVolume(waterValue);
                SetProductVolume(productValue); 
            }
            ProductTemperature = productTemperature;


            TankDelivering = false;
            TankLeaking = false;

            MaxSafeWorkingCapacityModifier = 0.95f;
            MaxSafeWorkingCapacity = MaxSafeWorkingCapacityModifier * FullVolume;

            OverFillLimitLevel = 0.90F * TankProbeDiameter;
            HighProductAlarmLevel = 0.80F * TankProbeDiameter;
            DeliveryNeededWarningLevel = 0.30F * TankProbeDiameter;
            LowProductAlarmLevel = 0.20F * TankProbeDiameter;
            HighWaterAlarmLevel = 0.10F * TankProbeDiameter;
            HighWaterWarningLevel = 0.05F * TankProbeDiameter;

            TankDeliveringPerInterval = 50;
            TankLeakingPerInterval = 50;

            TankDroppedList = new List<TankDrop>();
        }


        public Boolean ProductChangePerInterval(float value)
        {
            return SetProductVolume(ProductVolume + value);
        }

        public void ProductChangeThreadDelivery(float volume, DateTime startTime, TimeSpan duration)
        {
            if (TankDelivering)
            {
                TankDrop td = new TankDrop(0,
                                            startTime,
                                            ProductVolume,
                                            ProductLevel,
                                            GetGrossStandardVolume(),
                                            WaterVolume,
                                            ProductTemperature);
                float droppedVolume = 0f;
                while (TankDelivering && droppedVolume < volume)
                {
                    if ((droppedVolume + TankDeliveringPerInterval) <= volume)
                    {
                        ProductChangePerInterval(TankDeliveringPerInterval);
                        droppedVolume += TankDeliveringPerInterval;
                        Thread.Sleep(100);
                    }
                    else
                    {
                        ProductChangePerInterval(volume - droppedVolume);
                        droppedVolume += (volume - droppedVolume);
                        Thread.Sleep(100);
                    }
                }
                td.Volume = droppedVolume;
                td.EndingTime = startTime + duration;
                td.EndingVolume = ProductVolume;
                td.EndingLevel = ProductLevel;
                td.EndingTemperatureCompensatedVolume = GetGrossStandardVolume();
                td.EndingWaterVolume = WaterVolume;
                td.EndingTemperature = ProductTemperature;
                TankDropCount++;
                TankDroppedList.Add(td);
                TankDelivering = false;
                return;
            }
            return;
        }

        public void ProductChangeThreadLeaking()
        {
            if (TankLeaking)
            {
                while (TankLeaking & ProductChangePerInterval(-TankLeakingPerInterval))
                {
                    Thread.Sleep(100);
                }
                TankLeaking = false;
                return;
            }
        }

        public void DeliverySwitch(float volume, DateTime startTime, TimeSpan duration)
        {

            if (TankDelivering)
            {
                TankDelivering = false;
            }
            else
            {
                TankDelivering = true;
                Thread ProductChanging = new Thread(() => ProductChangeThreadDelivery(volume, startTime, duration));
                ProductChanging.Start();
            }
        }

        public void LeakingSwitch()
        {

            if (TankLeaking)
            {
                TankLeaking = false;
            }
            else
            {
                TankLeaking = true;
                Thread ProductChanging = new Thread(() => ProductChangeThreadLeaking());
                ProductChanging.Start();
            }
        }

        public float GetGrossObservedVolume()
        {
            return Models.Helper.LevelToVolume_Horizontal(ProductLevel + WaterLevel, TankProbeLength, TankProbeDiameter);
        }

        public float GetGrossStandardVolume()
        {
            float tempDelta = ProductTemperature - 15;
            return Models.Helper.LevelToVolume_Horizontal(ProductLevel, TankProbeLength, TankProbeDiameter) * (1 - thermalExpansionCoefficient * tempDelta);
        }

        public float GetUllage()
        {
            return Models.Helper.LevelToVolume_Horizontal(TankProbeDiameter-ProductLevel - WaterLevel, TankProbeLength, TankProbeDiameter);
        }

        public Boolean[] GetTankStatus()
        {

            Boolean[] temp = { TankDelivering, TankLeaking };

            return temp;
        }

        public void ClearDeliveryReport()
        {
            TankDroppedList.Clear();
        }

    


        public void TankConnectiongThread(TankProbe t)
        {
            float speed = Math.Min(TankDeliveringPerInterval, t.TankDeliveringPerInterval);
            float volumeDifference = ProductVolume - t.ProductVolume;
            while (Connecting)
            {
                volumeDifference = ProductVolume - t.ProductVolume;

                if (volumeDifference > 0)
                {
                    if (Math.Abs(speed) < volumeDifference)
                    {
                        SetProductVolume(ProductVolume - speed);
                        t.SetProductVolume(t.ProductVolume + speed);
                    }
                    else if (Math.Abs(speed) >= volumeDifference)
                    {
                        SetProductVolume(ProductVolume - volumeDifference / 2);
                        t.SetProductVolume(t.ProductVolume + volumeDifference / 2);
                    }
                }

                if (volumeDifference < 0)
                {
                    if (Math.Abs(speed) < Math.Abs(volumeDifference))
                    {
                        SetProductVolume(ProductVolume + speed);
                        t.SetProductVolume(t.ProductVolume - speed);
                    }
                    else if (Math.Abs(speed) >= Math.Abs(volumeDifference))
                    {
                        SetProductVolume(ProductVolume + volumeDifference / 2);
                        t.SetProductVolume(t.ProductVolume - volumeDifference / 2);
                    }

                }
                Thread.Sleep(100);
            }

        }

        public Boolean Connect(TankProbe t)
        {
            if (t.Connecting | Connecting)
            {
                return false;
            }
            t.Connecting = true;
            t.ConnectedTo = TankProbeId;

            Connecting = true;
            ConnectedTo = t.TankProbeId;
            Thread tankConnection = new Thread(() => TankConnectiongThread(t));
            tankConnection.Start();
            return true;
        }

        public Boolean Disconnect(TankProbe t)
        {
            if (t.ConnectedTo == TankProbeId)
            {
                Connecting = false;
                ConnectedTo = 456789; // 456789 means the tank is not connecting any

                t.ConnectedTo = 456789;
                t.Connecting = false;

                return true;
            }

            return false;
        }



        public override string ToString()
        {
            String returnString = "";
            returnString += "TankProbeId = " + TankProbeId.ToString() + "                                              ";
            returnString += "productVolume = " + ProductVolume.ToString() + "                             ";
            returnString += "productLevel = " + ProductLevel.ToString("0.00") + "                                  ";
            returnString += "waterVolume = " + WaterVolume.ToString() + "                        ";
            returnString += "waterLevel = " + WaterLevel.ToString("0.00") + "                                                 ";
            returnString += "ProductTemerature = " + ProductTemperature.ToString() + "                           ";
            returnString += "TankDropCount = " + TankDropCount.ToString() + "                           ";


            return returnString;
        }

      
    }
}
