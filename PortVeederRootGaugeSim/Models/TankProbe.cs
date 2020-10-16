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
        public Tank MyTank { get; set; }

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
        public float MaxSafeWorkingCapacityModifier { get; set; }

        // A list for store dropped tank
        public List<TankDrop> TankDroppedList { get; set; }
        public Boolean TankDelivering { get; set; }
        public Boolean TankLeaking { get; set; }

        // Getters and Setters
        // set the tank length. Then regulate water level and product level based on current water volume and product volume
        public void SetTankLength(float value)
        {          
            MyTank.TankLength = value;
            MyTank.FullVolume = Models.Helper.LevelToVolume_Horizontal(MyTank.TankDiameter, value, MyTank.TankDiameter);
            MyTank.MaxSafeWorkingCapacity = MyTank.FullVolume * MaxSafeWorkingCapacityModifier;
            WaterLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0,WaterVolume,0,MyTank.TankLength, MyTank.TankDiameter);
            float totalVolume = WaterVolume + ProductVolume;
            float totalLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0, totalVolume, 0, MyTank.TankLength, MyTank.TankDiameter);
            ProductLevel = totalLevel - WaterLevel;

        }

        // set the tank diameter. Then regulate water level and product level based on current water volume and product volume
        public void SetTankDiameter(float value)
        {
            MyTank.TankDiameter = value;
            MyTank.FullVolume = Models.Helper.LevelToVolume_Horizontal(MyTank.TankDiameter, MyTank.TankLength, MyTank.TankDiameter);
            MyTank.MaxSafeWorkingCapacity = MyTank.FullVolume * MaxSafeWorkingCapacityModifier;
            WaterLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0, WaterVolume, 0, MyTank.TankLength, MyTank.TankDiameter);
            float totalVolume = WaterVolume + ProductVolume;
            float totalLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0, totalVolume, 0, MyTank.TankLength, MyTank.TankDiameter);
            ProductLevel = totalLevel - WaterLevel;
        }

        // set the product level with a base level of water level
        public Boolean SetProductLevel(float value)
        {

            if (value + WaterLevel > MyTank.TankDiameter || value < 0)
            {
                return false;
            }
            lock (ProductLevelLock)
            {
                ProductLevel = value;
            }
            
            lock (ProductVolumeLock)
            {
                float totalLevel = WaterLevel + ProductLevel;
                float totalVolume = Models.Helper.LevelToVolume_Horizontal(totalLevel, MyTank.TankLength, MyTank.TankDiameter);

                float productVolume = totalVolume - WaterVolume;

                ProductVolume = Math.Max(0,productVolume);
            }

            return true;
        }

        // set product volume. Then regulate product level based on product valume and water volume
        public Boolean SetProductVolume(float value)
        {

            if (value + WaterVolume > MyTank.FullVolume || value < 0)
            {
                return false;
            }

            lock (ProductVolumeLock)
            {
                ProductVolume = value;
            }

            lock (ProductLevelLock)
            {
                float totalLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0, value+WaterVolume, 0, MyTank.TankLength, MyTank.TankDiameter);
                ProductLevel = totalLevel - WaterLevel;
            }

            return true;
        }

        // set water level. Then regulate water volume and product level
        // this funciton cause a minor product volume calculation error
        public Boolean SetWaterLevel(float value)
        {
            if (value < 0 || value > MyTank.TankDiameter)
            {
                return false;
            }

            float waterVolume = Models.Helper.LevelToVolume_Horizontal(value, MyTank.TankLength, MyTank.TankDiameter);

            if (waterVolume + ProductVolume > MyTank.FullVolume)
            {
                return false;
            }

            float totalVolume = waterVolume + ProductVolume;
            float totalLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0,totalVolume,0, MyTank.TankLength, MyTank.TankDiameter);


            WaterVolume = waterVolume;
            WaterLevel = value;

            lock (ProductLevelLock)
            {
                ProductLevel = Math.Max(0,totalLevel - value);
            }
            return true;
        }

        public float GetGrossObservedVolume()
        {
            return WaterVolume + ProductVolume;
        }

        public float GetGrossStandardVolume()
        {
            float tempDelta = ProductTemperature - 15;
            return ProductVolume * (1 - thermalExpansionCoefficient * tempDelta);
        }

        public float GetUllage()
        {
            return MyTank.FullVolume - WaterVolume - ProductVolume;
        }

        public void SetMaxSafeWorkingCapacityByLevel(float level)
        {
            MyTank.MaxSafeWorkingCapacity = Models.Helper.LevelToVolume_Horizontal(level,MyTank.TankLength, MyTank.TankDiameter);
        }

        private void InitializeTankLevels(Tank tank, float productLevel, float waterLevel)
        {
            WaterLevel = waterLevel;
            WaterVolume = Models.Helper.LevelToVolume_Horizontal(waterLevel, tank.TankLength,tank.TankDiameter);
            ProductLevel = productLevel;
            float totalVolume = Models.Helper.LevelToVolume_Horizontal(waterLevel + productLevel, tank.TankLength, tank.TankDiameter);
            ProductVolume = totalVolume - WaterVolume;

        }

        public TankProbe(int tankId, char productCode, Tank tank,  float productLevel, float waterLevel, float productTemperature)
        {
            TankProbeId = tankId;
            ProductCode = productCode;
            TankprobeStatus = "OK";

            ProductTemperature = productTemperature;

            MyTank = tank;

            InitializeTankLevels(MyTank,productLevel, waterLevel);

            TankDelivering = false;
            TankLeaking = false;

            MaxSafeWorkingCapacityModifier = 0.95f;

            TankDroppedList = new List<TankDrop>();
        }

        public void ClearDeliveryReport()
        {
            TankDroppedList.Clear();
        }

        // the method to increase or decrease product volume. used in delivery and leak
        public Boolean ProductChangePerInterval(float value)
        {
            if (TankLeaking && ProductVolume < Math.Abs(value))
            {
                return SetProductVolume(0);
            }
            return SetProductVolume(ProductVolume + value);
        }

        // the thread for delivering product into the tank
        // could change the delivery speed by change <Mytank.TankDeliveringPerInterval>   OR  change the thread sleep time
        // after finish deliver,  the dropped tank will be stored in  <TankDroppedList>
        private void ProductChangeThreadDelivery(float volume, DateTime startTime, TimeSpan duration)
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
                    if ((droppedVolume + MyTank.TankDeliveringPerInterval) <= volume)
                    {
                        ProductChangePerInterval(MyTank.TankDeliveringPerInterval);
                        droppedVolume += MyTank.TankDeliveringPerInterval;
                        Thread.Sleep(200);
                    }
                    else
                    {
                        ProductChangePerInterval(volume - droppedVolume);
                        droppedVolume += (volume - droppedVolume);
                        Thread.Sleep(200);
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

        // the thread for leak product 
        // could change the leak speed by change <Mytank.TankLeakingPerInterval>   OR  change the thread sleep time
        private void ProductChangeThreadLeaking()
        {
            while (TankLeaking)
            {
                if (ProductVolume > 0)
                {
                    ProductChangePerInterval(-MyTank.TankLeakingPerInterval);
                }
                else
                {
                    TankLeaking = false;
                }
                Thread.Sleep(200);
            }
        }

        // start the delivery thread
        public Boolean StartDelivery(float volume, DateTime startTime, TimeSpan duration)
        {

            if (TankDelivering)
            {
                TankDelivering = false;
            }
            else
            {
                if (volume+ProductVolume > MyTank.FullVolume)
                {
                    return false;
                }
                TankDelivering = true;
                Thread ProductChanging = new Thread(() => ProductChangeThreadDelivery(volume, startTime, duration));
                ProductChanging.Start();
            }
            return true;
        }

        // start or stop tank leaking thread
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

        // this thread will balance product volume between two connected tanks
        // could be more realistic if improve it to balance the levels between two tanks but may need to consider leak water if there's no product left
        private void TankConnectiongThread(TankProbe t)
        {
            float speed = Math.Min(MyTank.TankDeliveringPerInterval, t.MyTank.TankDeliveringPerInterval);
            while (MyTank.Connecting)
            {
                while (MyTank.Connecting && ProductVolume != t.ProductVolume)
                {
                    Tuple<float, float> Levels = Models.Helper.ProductFlowing(ProductVolume, t.ProductVolume, speed);
                    if (ProductVolume > t.ProductVolume)
                    {
                        SetProductVolume(Levels.Item1);
                        t.SetProductVolume(Levels.Item2);
                    }
                    else
                    {
                        SetProductVolume(Levels.Item2);
                        t.SetProductVolume(Levels.Item1);
                    }
                    Thread.Sleep(200);
                }
                Thread.Sleep(200);
            }
            

        }
        
        // start the connection between two tank
        public Boolean Connect(TankProbe t)
        {
            if (t.MyTank.Connecting || MyTank.Connecting)
            {
                return false;
            }
            t.MyTank.Connecting = true;
            t.MyTank.ConnectedTo = TankProbeId;
            MyTank.Connecting = true;
            MyTank.ConnectedTo = t.TankProbeId;
            Thread tankConnection = new Thread(() => TankConnectiongThread(t));
            tankConnection.Start();
            return true;
        }

        public Boolean Disconnect(TankProbe t)
        {
            if (t.MyTank.ConnectedTo == TankProbeId)
            {
                MyTank.Connecting = false;
                MyTank.ConnectedTo = 456789; // 456789 means the tank is not MyTank.Connecting any

                t.MyTank.ConnectedTo = 456789;
                t.MyTank.Connecting = false;

                return true;
            }

            return false;
        } 
    }
}
