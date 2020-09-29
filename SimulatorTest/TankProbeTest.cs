using NUnit.Framework;
using NUnit.Framework.Internal;
using PortVeederRootGaugeSim;
using System;
using System.Collections.Generic;

namespace SimulatorTest
{
    class TankProbeTest
    {
        [Test]
        public void TestGetProductLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            Assert.AreEqual(tank1.ProductLevel, 100);
        }

        [Test]
        public void TestSetProductLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            Assert.IsTrue(tank1.SetByProductLevel(50));
            Assert.AreEqual(tank1.ProductLevel, 50);
        }

        [Test]
        public void TestSetTooMuchProductLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            Assert.IsFalse(tank1.SetByProductLevel(10000000000));
            Assert.AreEqual(tank1.ProductLevel, 100);
        }

        [Test]
        public void TestSetNegativeProductLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            Assert.IsFalse(tank1.SetByProductLevel(-1));
        }

        [Test]
        public void TestGetProductVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);

            Assert.AreEqual(tank1.ProductVolume, PortVeederRootGaugeSim.Models.Helper.LevelToVolume_Horizontal(tank1.ProductLevel,tank1.TankProbeLength,tank1.TankProbeDiameter));
        }

        [Test]
        public void TestSetProductVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            Assert.IsTrue(tank1.SetProductVolume(150));
            Assert.AreEqual(tank1.ProductVolume, 150);
        }

        [Test]
        public void TestSetTooMuchProductVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            Assert.IsFalse(tank1.SetProductVolume(10000000000));
            Assert.AreEqual(tank1.ProductLevel, 100);
        }

        [Test]
        public void TestSetNegativeProductVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10);
            Assert.IsFalse(tank1.SetProductVolume(-1));
        }

        [Test]
        public void TestGetWaterLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10);
            Assert.AreEqual(tank1.WaterLevel, 100);
        }

        [Test]
        public void TestSetWaterLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10);
            Assert.IsTrue(tank1.SetWaterLevel(50));
            Assert.AreEqual(tank1.WaterLevel, 50);
        }

        [Test]
        public void TestSetTooMuchWaterLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            Assert.IsFalse(tank1.SetWaterLevel(10000000000));
            Assert.AreEqual(tank1.WaterLevel, 100);
        }

        [Test]
        public void TestSetNegativeWaterLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            Assert.IsFalse(tank1.SetWaterLevel(-1));
        }

        [Test]
        public void TestGetWaterVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            Assert.AreEqual(tank1.WaterVolume, PortVeederRootGaugeSim.Models.Helper.LevelToVolume_Horizontal(tank1.WaterLevel,tank1.TankProbeLength,tank1.TankProbeDiameter));
        }

        [Test]
        public void TestSetWaterVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            Assert.IsTrue(tank1.SetWaterVolume(150));
            Assert.AreEqual(tank1.WaterVolume, 150);
        }

        [Test]
        public void TestSetTooMuchWaterVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            float waterVolume = PortVeederRootGaugeSim.Models.Helper.LevelToVolume_Horizontal(100, tank1.TankProbeLength, tank1.TankProbeDiameter);
            Assert.IsFalse(tank1.SetWaterVolume(10000000000));
            Assert.AreEqual(tank1.WaterVolume, waterVolume);
        }


        [Test]
        public void TestProductChangePerInterval()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            float productVolume = tank1.ProductVolume;
            tank1.ProductChangePerInterval(100);           
            Assert.AreEqual(tank1.ProductVolume, productVolume+100);
        }

        [Test]
        public void TestDeliverySwitchTrue()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            tank1.TankDelivering = true;
            tank1.DeliverySwitch(100, DateTime.Now, TimeSpan.Zero);
            Assert.False(tank1.TankDelivering);
        }

        [Test]
        public void TestDeliverySwitchFalse()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            tank1.TankDelivering = false;
            tank1.DeliverySwitch(100, DateTime.Now, TimeSpan.Zero);
            Assert.True(tank1.TankDelivering);
        }

        [Test]
        public void TestLeakingSwitchTrue()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            tank1.TankLeaking = true;
            tank1.LeakingSwitch();
            Assert.False(tank1.TankLeaking);
        }

        [Test]
        public void TestLeakingSwitchFalse()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            tank1.TankLeaking = false;
            tank1.LeakingSwitch();
            Assert.True(tank1.TankLeaking);
        }

        [Test]
        public void TestGetGrossObservedVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 300, 100, 10);
            float expectedResult = PortVeederRootGaugeSim.Models.Helper.LevelToVolume_Horizontal(tank1.ProductLevel+ tank1.WaterLevel, tank1.TankProbeLength, tank1.TankProbeDiameter);
            Assert.AreEqual(tank1.GetGrossObservedVolume(), expectedResult);
        }

        [Test]
        public void TestGetGrossStandardVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 300, 100, 10);

            float expectedResult = tank1.ProductVolume * (1  - 0.0018F * (tank1.ProductTemperature - 15));
            Assert.AreEqual(tank1.GetGrossStandardVolume(), expectedResult);
        }

        [Test]
        public void TestGetUllage()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 300, 100, 10);
            float waterVolume = PortVeederRootGaugeSim.Models.Helper.LevelToVolume_Horizontal(tank1.WaterLevel, tank1.TankProbeLength, tank1.TankProbeDiameter);
            float productVolume = PortVeederRootGaugeSim.Models.Helper.LevelToVolume_Horizontal(tank1.ProductLevel, tank1.TankProbeLength, tank1.TankProbeDiameter);
            float Ullage = tank1.FullVolume - waterVolume - productVolume;
            Assert.AreEqual(tank1.GetUllage(), Ullage);
        }

        [Test]
        public void TestGetTankStatus()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            Boolean[] boolTest = { false, false };
            Assert.AreEqual(tank1.GetTankStatus(), boolTest);
            tank1.TankDelivering = true;
            Boolean[] boolTest2 = { true, false };
            Assert.AreEqual(tank1.GetTankStatus(), boolTest2);
            tank1.TankDelivering = false;
            tank1.TankLeaking = true;
            Boolean[] boolTest3 = { false, true };
            Assert.AreEqual(tank1.GetTankStatus(), boolTest3);
            tank1.TankDelivering = true;
            tank1.TankLeaking = true;
            Boolean[] boolTest4 = { true, true };
            Assert.AreEqual(tank1.GetTankStatus(), boolTest4);
            tank1.TankDelivering = false;
            tank1.TankLeaking = false;
            Boolean[] boolTest5 = { false, false };
            Assert.AreEqual(tank1.GetTankStatus(), boolTest5);
        }

        [Test]
        public void TestClearDeliveryReport()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 2000, 100, 100, 10);
            tank1.TankDroppedList.Add(new TankDrop());
            Assert.True(tank1.TankDroppedList.Count > 0);
            tank1.ClearDeliveryReport();
            Assert.AreEqual(tank1.TankDroppedList.Count, 0);
        }
    }
}
