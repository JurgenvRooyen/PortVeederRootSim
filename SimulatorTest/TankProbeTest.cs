using NUnit.Framework;
using NUnit.Framework.Internal;
using PortVeederRootGaugeSim;
using System;

namespace SimulatorTest
{
    class TankProbeTest
    {
        [Test]
        public void TestSetTankProbeId()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            tank1.TankProbeId = 2;
            Assert.AreEqual(2, tank1.TankProbeId);
        }


        [Test]
        public void TestSetTankLength()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            tank1.SetTankLength(120);
            Tank tank = tank1.MyTank;
            Assert.AreEqual(120, tank.TankLength);
        }

        [Test]
        public void TestSetTankDiameter()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            tank1.SetTankDiameter(120);
            Tank tank = tank1.MyTank;
            Assert.AreEqual(120, tank.TankDiameter);
        }

        [Test]
        public void TestGetProductLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            Assert.AreEqual(tank1.ProductLevel, 100);
        }

        [Test]
        public void TestSetProductLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            Assert.IsTrue(tank1.SetProductLevel(50));
            Assert.AreEqual(tank1.ProductLevel, 50);
        }

        [Test]
        public void TestSetTooMuchProductLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            Assert.IsFalse(tank1.SetProductLevel(10000000000));
            Assert.AreEqual(tank1.ProductLevel, 100);
        }

        [Test]
        public void TestSetNegativeProductLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            Assert.IsFalse(tank1.SetProductLevel(-1));
        }

        [Test]
        public void TestGetProductVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            float totalVolume = PortVeederRootGaugeSim.Models.Helper.LevelToVolume_Horizontal(tank1.ProductLevel+ tank1.WaterLevel, tank1.MyTank.TankLength, tank1.MyTank.TankDiameter);
            float waterVolume = PortVeederRootGaugeSim.Models.Helper.LevelToVolume_Horizontal(tank1.WaterLevel, tank1.MyTank.TankLength, tank1.MyTank.TankDiameter);
            Assert.AreEqual(tank1.ProductVolume, totalVolume-waterVolume);
        }

        [Test]
        public void TestSetProductVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            Assert.IsTrue(tank1.SetProductVolume(150));
            Assert.AreEqual(tank1.ProductVolume, 150);
        }

        [Test]
        public void TestSetTooMuchProductVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            Assert.IsFalse(tank1.SetProductVolume(10000000000));
            Assert.AreEqual(tank1.ProductLevel, 100);
        }

        [Test]
        public void TestSetNegativeProductVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            Assert.IsFalse(tank1.SetProductVolume(-1));
        }

        [Test]
        public void TestGetWaterLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            Assert.AreEqual(tank1.WaterLevel, 100);
        }

        [Test]
        public void TestSetWaterLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            Assert.IsTrue(tank1.SetWaterLevel(50));
            Assert.AreEqual(tank1.WaterLevel, 50);
        }

        [Test]
        public void TestSetTooMuchWaterLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            Assert.IsFalse(tank1.SetWaterLevel(10000000000));
            Assert.AreEqual(tank1.WaterLevel, 100);
        }

        [Test]
        public void TestSetNegativeWaterLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            Assert.IsFalse(tank1.SetWaterLevel(-1));
        }

        [Test]
        public void TestGetWaterVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            Assert.AreEqual(tank1.WaterVolume, PortVeederRootGaugeSim.Models.Helper.LevelToVolume_Horizontal(tank1.WaterLevel,tank1.MyTank.TankLength,tank1.MyTank.TankDiameter));
        }

        [Test]
        public void TestProductChangePerInterval()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            float productVolume = tank1.ProductVolume;
            tank1.ProductChangePerInterval(100);           
            Assert.AreEqual(tank1.ProductVolume, productVolume+100);
        }

        [Test]
        public void TestProductChangePerIntervalValueTooHigh()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            tank1.TankLeaking = true;
            tank1.ProductChangePerInterval(1000);
            Assert.AreEqual(tank1.ProductVolume, 0);
        }

        [Test]
        public void TestDeliverySwitchTrue()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10)
            {
                TankDelivering = true
            };
            tank1.StartDelivery(100, DateTime.Now, TimeSpan.Zero);
            Assert.False(tank1.TankDelivering);
        }

        [Test]
        public void TestDeliverySwitchFalse()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10)
            {
                TankDelivering = false
            };
            tank1.StartDelivery(100, DateTime.Now, TimeSpan.Zero);
            Assert.True(tank1.TankDelivering);
        }

        [Test]
        public void TestLeakingSwitchTrue()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10)
            {
                TankLeaking = true
            };
            tank1.LeakingSwitch();
            Assert.False(tank1.TankLeaking);
        }

        [Test]
        public void TestLeakingSwitchFalse()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10)
            {
                TankLeaking = false
            };
            tank1.LeakingSwitch();
            Assert.True(tank1.TankLeaking);
        }

        [Test]
        public void TestGetGrossObservedVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 300, 100, 10);
            float expectedResult = PortVeederRootGaugeSim.Models.Helper.LevelToVolume_Horizontal(tank1.ProductLevel+ tank1.WaterLevel, tank1.MyTank.TankLength, tank1.MyTank.TankDiameter);
            Assert.AreEqual(tank1.GetGrossObservedVolume(), expectedResult);
        }

        [Test]
        public void TestGetGrossStandardVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 300, 100, 10);

            float expectedResult = tank1.ProductVolume * (1  - 0.0018F * (tank1.ProductTemperature - 15));
            Assert.AreEqual(tank1.GetGrossStandardVolume(), expectedResult);
        }

        [Test]
        public void TestGetUllage()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 300, 100, 10);


            Assert.AreEqual(Math.Round(tank1.GetUllage(),2), Math.Round(PortVeederRootGaugeSim.Models.Helper.LevelToVolume_Horizontal(tank1.MyTank.TankDiameter - tank1.WaterLevel - tank1.ProductLevel, tank1.MyTank.TankLength, tank1.MyTank.TankDiameter),2));
        }

        [Test]
        public void TestClearDeliveryReport()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,2000), 100, 100, 10);
            tank1.TankDroppedList.Add(new TankDrop());
            Assert.True(tank1.TankDroppedList.Count > 0);
            tank1.ClearDeliveryReport();
            Assert.AreEqual(tank1.TankDroppedList.Count, 0);
        }

        [Test]
        public void TestSetMaxSafeWorkingCapacityByLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            tank1.SetMaxSafeWorkingCapacityByLevel(500);
            float expectedResult = PortVeederRootGaugeSim.Models.Helper.LevelToVolume_Horizontal(500,tank1.MyTank.TankLength, tank1.MyTank.TankDiameter);
            Assert.AreEqual(expectedResult, tank1.MyTank.MaxSafeWorkingCapacity);
        }

        [Test]
        public void TestConnectTrue()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            TankProbe tank2 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            Assert.True(tank1.Connect(tank2));
        }

        [Test]
        public void TestConnectFalse()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            TankProbe tank2 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            TankProbe tank3 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            tank1.Connect(tank2);
            Assert.False(tank1.Connect(tank3));
        }

        [Test]
        public void TestDisconnectIncorrectTank()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            TankProbe tank2 = new TankProbe(2, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            TankProbe tank3 = new TankProbe(3, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            tank1.Connect(tank2);
            Assert.False(tank1.Disconnect(tank3));
        }

        [Test]
        public void TestDisconnect()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            TankProbe tank2 = new TankProbe(2, char.Parse("P"), new Tank(1000, 2000), 100, 100, 10);
            tank1.Connect(tank2);
            Assert.True(tank1.Disconnect(tank2));
        }
    }
}
