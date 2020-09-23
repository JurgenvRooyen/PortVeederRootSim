using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

namespace PortVeederRootGaugeSim
{
    [Serializable]
    public class TankProbe
    {
        // Tank attributes
        public int TankProbeId { get; set; }
        public char ProductCode { get; set; }
        public string TankProbeShape { get; set; }
        public float TankProbeHeight { get; set; }
        public float TankProbeDiameter { get; set; }
        public void SetTankProbeHeight(float probeHeight)
        {
            TankProbeHeight = probeHeight;
            FullVolume = LevelToVolume(probeHeight);
            SetWaterLevel(waterLevel);
            MaxSafeWorkingCapacity = TankProbeHeight * safeWorkingCapacityModifier;
        }
        public void SetTankProbeDiameter(float probeDiameter)
        {
            TankProbeDiameter = probeDiameter;
            FullVolume = LevelToVolume(TankProbeHeight);
            SetWaterLevel(waterLevel);
            MaxSafeWorkingCapacity = TankProbeHeight * safeWorkingCapacityModifier;
        }

        private readonly object ProductLevelLock = new object();

        public float ProductLevel { get; set; }
        public float GetProductLevel()
        {
            return ProductLevel;
        }
        public Boolean SetProductLevel(float value)
        {

            if (value + GetWaterLevel() > TankProbeHeight | value < 0)
            {
                return false;
            }
            lock (ProductLevelLock)
            {
                ProductLevel = value;
            }
            lock (ProductVolumeLock)
            {
                ProductVolume = (LevelToVolume(value));
            }

            return true;
        }
        private readonly object ProductVolumeLock = new object();

        private float ProductVolume = 0;
        public float GetProductVolume()
        {
            return ProductVolume;
        }
        public Boolean SetProductVolume(float value)
        {

            if (value + waterVolume > FullVolume | value < 0)
            {
                return false;
            }

            lock (ProductVolumeLock)
            {
                ProductVolume = value;
            }

            lock (ProductLevelLock)
            {
                ProductLevel = (VolumeToLevel(value));
            }

            return true;
        }
        public float waterLevel = 0;
        public float GetWaterLevel()
        {
            return waterLevel;
        }
        public Boolean SetWaterLevel(float value)
        {
            if (value + ProductLevel > TankProbeHeight | value < 0)
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
            if (value + ProductVolume > FullVolume | value < 0)
            {
                return false;
            }
            waterLevel = VolumeToLevel(value);
            waterVolume = value;
            return true;
        }
        public float ProductTemperature { get; set; }
        public float TankDropCount { get; set; }
        public const float thermalExpansionCoefficient = 0.0018F;
        public float safeWorkingCapacityModifier;
        public void setSafeWorkingCapacityModifier(float workingCapacity)
        {
            safeWorkingCapacityModifier = workingCapacity;
            MaxSafeWorkingCapacity = TankProbeHeight * workingCapacity;
        }

        // Alarm attributes

        public float FullVolume { get; set; }
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
        //public Thread ProductChanging { get; set; }

        // connection status


        public Boolean Connecting { get; set; }
        public int ConnectedTo { get; set; } // store other tank's ID



        public TankProbe(int tankId, char productCode, float tankLength, float tankDiameter, float productValue, float waterValue, float productTemperature, string unit, string tankShapeString = "cylinder")
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
            }
            else if (unit == "volume")
            {
                SetProductVolume(productValue);
                SetWaterVolume(waterValue);
            }
            this.ProductTemperature = productTemperature;


            this.TankDelivering = false;
            this.TankLeaking = false;

            this.safeWorkingCapacityModifier = 0.95F;

            MaxSafeWorkingCapacity = 0.95F * TankProbeHeight;
            OverFillLimit = 0.90F * TankProbeHeight;
            HighProductAlarmLevel = 0.80F * TankProbeHeight;
            DeliveryNeededWarningLevel = 0.30F * TankProbeHeight;
            LowProductAlarmLevel = 0.20F * TankProbeHeight;
            HighWaterAlarmLevel = 0.10F * TankProbeHeight;
            HighWaterWarningLevel = 0.05F * TankProbeHeight;

            TankDeliveringPerInterval = 50;
            TankLeakingPerInterval = 50;

            TankDroppedList = new List<TankDrop>();
        }

        // DropTank is no longer used as there is not Tank Drop button on UI
        // TODO: delete this if it is never used in future
        public Boolean DropTank(float volume, DateTime startTime, TimeSpan duration)
        {
            TankDrop td = new TankDrop(volume,
                                        startTime,
                                        this.GetProductVolume(),
                                        this.ProductLevel,
                                        this.GetGrossStandardVolume(),
                                        this.GetWaterVolume(),
                                        this.ProductTemperature);

            if (SetProductVolume(this.ProductVolume + volume))
            {
                td.EndingTime = startTime + duration;
                td.EndingVolume = this.GetProductVolume();
                td.EndingLevel = this.ProductLevel;
                td.EndingTemperatureCompensatedVolume = this.GetGrossStandardVolume();
                td.EndingWaterVolume = this.GetWaterVolume();
                td.EndingTemperature = this.ProductTemperature;
                TankDropCount++;
                this.TankDroppedList.Add(td);
                return true;
            }
            return false;
        }

        public Boolean ProductChangePerInterval(float value)
        {
            return SetProductVolume(this.GetProductVolume() + value);
        }

        public void ProductChangeThreadDelivery(float volume, DateTime startTime, TimeSpan duration)
        {
            if (TankDelivering)
            {
                TankDrop td = new TankDrop(0,
                                            startTime,
                                            this.GetProductVolume(),
                                            this.ProductLevel,
                                            this.GetGrossStandardVolume(),
                                            this.GetWaterVolume(),
                                            this.ProductTemperature);
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
                td.EndingVolume = this.GetProductVolume();
                td.EndingLevel = this.ProductLevel;
                td.EndingTemperatureCompensatedVolume = this.GetGrossStandardVolume();
                td.EndingWaterVolume = this.GetWaterVolume();
                td.EndingTemperature = this.ProductTemperature;
                TankDropCount++;
                this.TankDroppedList.Add(td);
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

            if (this.TankLeaking)
            {
                this.TankLeaking = false;
            }
            else
            {
                this.TankLeaking = true;
                Thread ProductChanging = new Thread(() => ProductChangeThreadLeaking());
                ProductChanging.Start();
            }
        }

        public float GetGrossObservedVolume()
        {
            return LevelToVolume(ProductLevel) + LevelToVolume(GetWaterLevel());
        }

        public float GetGrossStandardVolume()
        {
            float tempDelta = ProductTemperature - 15;
            return LevelToVolume(ProductLevel) * (1 - thermalExpansionCoefficient * tempDelta);
        }

        public float GetUllage()
        {
            return Math.Max(0, LevelToVolume(TankProbeHeight - GetProductLevel() - GetWaterLevel()));
        }

        public Boolean[] GetTankStatus()
        {
            //TODO
            //Need To Add Invalid Fuel Height Alarm !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Boolean[] temp = { this.TankDelivering, this.TankLeaking };

            return temp;
        }

        public void ClearDeliveryReport()
        {
            this.TankDroppedList.Clear();
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

        public void SetMaxSafeWorkingCapacityByLevel(float volume)
        {
            MaxSafeWorkingCapacity = VolumeToLevel(volume);
        }

        public void TankConnectiongThread(TankProbe t)
        {
            float speed = Math.Min(this.TankDeliveringPerInterval, t.TankDeliveringPerInterval);
            float volumeDifference = GetProductVolume() - t.GetProductVolume();
            while (this.Connecting)
            {
                volumeDifference = this.GetProductVolume() - t.GetProductVolume();

                if (volumeDifference > 0)
                {
                    if (Math.Abs(speed) < volumeDifference)
                    {
                        this.SetProductVolume(this.GetProductVolume() - speed);
                        t.SetProductVolume(t.GetProductVolume() + speed);
                    }
                    else if (Math.Abs(speed) >= volumeDifference)
                    {
                        this.SetProductVolume(this.GetProductVolume() - volumeDifference / 2);
                        t.SetProductVolume(t.GetProductVolume() + volumeDifference / 2);
                    }
                }

                if (volumeDifference < 0)
                {
                    if (Math.Abs(speed) < Math.Abs(volumeDifference))
                    {
                        this.SetProductVolume(this.GetProductVolume() + speed);
                        t.SetProductVolume(t.GetProductVolume() - speed);
                    }
                    else if (Math.Abs(speed) >= Math.Abs(volumeDifference))
                    {
                        this.SetProductVolume(this.GetProductVolume() + volumeDifference / 2);
                        t.SetProductVolume(t.GetProductVolume() - volumeDifference / 2);
                    }

                }
                Thread.Sleep(100);
            }

        }

        public Boolean Connect(TankProbe t)
        {
            if (t.Connecting | this.Connecting)
            {
                return false;
            }
            t.Connecting = true;
            t.ConnectedTo = this.TankProbeId;

            this.Connecting = true;
            this.ConnectedTo = t.TankProbeId;
            Thread tankConnection = new Thread(() => TankConnectiongThread(t));
            tankConnection.Start();
            return true;
        }

        public Boolean Disconnect(TankProbe t)
        {
            if (t.ConnectedTo == this.TankProbeId)
            {
                this.Connecting = false;
                this.ConnectedTo = 456789; // 456789 means the tank is not connecting any

                t.ConnectedTo = 456789;
                t.Connecting = false;

                return true;
            }

            return false;
        }



        public override string ToString()
        {
            String returnString = "";
            returnString += "TankProbeId = " + TankProbeId.ToString() + "                                               ";

            returnString += "productVolume = " + ProductVolume.ToString() + "                               ";
            returnString += "productLevel = " + ProductLevel.ToString() + "                                  ";
            returnString += "productVolume = " + ProductVolume.ToString() + "                               ";
            returnString += "waterLevel = " + waterLevel.ToString() + "                                                 ";
            returnString += "waterVolume = " + waterVolume.ToString() + "                        ";
            returnString += "ProductTemerature = " + ProductTemperature.ToString() + "                           ";
            returnString += "TankDropCount = " + TankDropCount.ToString() + "                           ";


            return returnString;
        }

        public float getSafeWorkingCapacityVolume()
        {
            return LevelToVolume(MaxSafeWorkingCapacity);

        }
    }
}
