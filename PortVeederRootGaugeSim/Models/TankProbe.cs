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

        


        // Alarm attributes TODO

        public float MaxSafeWorkingCapacityModifier { get; set; }


        // tank dropping attributes
        public List<TankDrop> TankDroppedList { get; set; }


        public Boolean TankDelivering { get; set; }
        public Boolean TankLeaking { get; set; }


        // Getters and Setters

        public void SetTankLength(float value)
        {          
            MyTank.TankLength = value;
            MyTank.FullVolume = Models.Helper.LevelToVolume_Horizontal(MyTank.TankDiameter, value, MyTank.TankDiameter);
            WaterLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0,WaterVolume,0,MyTank.TankLength, MyTank.TankDiameter);
            float totalVolume = WaterVolume + ProductVolume;
            float totalLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0, totalVolume, 0, MyTank.TankLength, MyTank.TankDiameter);
            ProductLevel = totalLevel - WaterLevel;

        }

        public void SetTankDiameter(float value)
        {
            MyTank.TankDiameter = value;
            MyTank.FullVolume = Models.Helper.LevelToVolume_Horizontal(MyTank.TankDiameter, MyTank.TankLength, MyTank.TankDiameter);
            WaterLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0, WaterVolume, 0, MyTank.TankLength, MyTank.TankDiameter);
            float totalVolume = WaterVolume + ProductVolume;
            float totalLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0, totalVolume, 0, MyTank.TankLength, MyTank.TankDiameter);
            ProductLevel = totalLevel - WaterLevel;
        }


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



        public Boolean SetWaterLevel(float value)
        {
            if (value + ProductLevel > MyTank.TankDiameter || value < 0)
            {
                return false;
            }
            WaterLevel = value;
            WaterVolume = Models.Helper.LevelToVolume_Horizontal(value, MyTank.TankLength, MyTank.TankDiameter); ;
            float totalVolume = WaterVolume + ProductVolume;
            float totalLevel = Models.Helper.SearchLevelOnVolumeChange_Horizontal(0,totalVolume,0, MyTank.TankLength, MyTank.TankDiameter);
            lock (ProductLevelLock)
            {
                float productVolume = totalVolume - WaterVolume;
                if (productVolume < 0)
                {
                    productVolume = 0;
                }

                ProductVolume = productVolume;
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

        public Boolean[] GetTankStatus()
        {

            Boolean[] temp = { TankDelivering, TankLeaking };

            return temp;
        }

        public void ClearDeliveryReport()
        {
            TankDroppedList.Clear();
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


        public Boolean ProductChangePerInterval(float value)
        {
            if (TankLeaking && ProductVolume < Math.Abs(value))
            {
                return SetProductVolume(0);
            }
            return SetProductVolume(ProductVolume + value);
        }

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

        public Boolean DeliverySwitch(float volume, DateTime startTime, TimeSpan duration)
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

 

    


        private void TankConnectiongThread(TankProbe t)
        {
            float speed = Math.Min(MyTank.TankDeliveringPerInterval, t.MyTank.TankDeliveringPerInterval);
            while (MyTank.Connecting)
            {
                while (MyTank.Connecting & ProductVolume != t.ProductVolume)
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



        public override string ToString()
        {
            String returnString = "";
            returnString += "TankProbeId = " + TankProbeId.ToString() + "                                              ";
            returnString += "productVolume = " + ProductVolume.ToString("0.00") + "                             ";
            returnString += "productLevel = " + ProductLevel.ToString("0.00") + "                                        ";
            returnString += "waterVolume = " + WaterVolume.ToString("0.00") + "                               ";
            returnString += "waterLevel = " + WaterLevel.ToString("0.00") + "                                             ";
            returnString += "ProductTemerature = " + ProductTemperature.ToString() + "                           ";
            returnString += "TankDropCount = " + TankDropCount.ToString() + "                                         ";
            returnString += "GOV = " + GetGrossObservedVolume().ToString("0.00") + "                                             ";
            returnString += "GSV = " + GetGrossStandardVolume().ToString("0.00") + "                                             ";
            returnString += "Ullage = " + GetUllage().ToString("0.00") + "                           ";
            returnString += (WaterVolume + ProductVolume).ToString();


            return returnString;
        }

      
    }
}
