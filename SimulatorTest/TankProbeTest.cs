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
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            Assert.AreEqual(tank1.GetProductLevel(), 100);
        }

        [Test]
        public void TestSetProductLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            Assert.IsTrue(tank1.SetProductLevel(150));
            Assert.AreEqual(tank1.GetProductLevel(), 150);
        }

        [Test]
        public void TestSetTooMuchProductLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            Assert.IsFalse(tank1.SetProductLevel(10000000000));
            Assert.AreEqual(tank1.GetProductLevel(), 100);
        }

        [Test]
        public void TestSetNegativeProductLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            Assert.IsFalse(tank1.SetProductLevel(-1));
        }

        [Test]
        public void TestGetProductVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            Assert.AreEqual(tank1.GetProductVolume(), 100);
        }

        [Test]
        public void TestSetProductVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            Assert.IsTrue(tank1.SetProductVolume(150));
            Assert.AreEqual(tank1.GetProductVolume(), 150);
        }

        [Test]
        public void TestSetTooMuchProductVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            Assert.IsFalse(tank1.SetProductVolume(10000000000));
            Assert.AreEqual(tank1.GetProductVolume(), 100);
        }

        [Test]
        public void TestSetNegativeProductVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            Assert.IsFalse(tank1.SetProductVolume(-1));
        }

        [Test]
        public void TestGetWaterLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            Assert.AreEqual(tank1.GetWaterLevel(), 100);
        }

        [Test]
        public void TestSetWaterLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            Assert.IsTrue(tank1.SetWaterLevel(150));
            Assert.AreEqual(tank1.GetWaterLevel(), 150);
        }

        [Test]
        public void TestSetTooMuchWaterLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            Assert.IsFalse(tank1.SetWaterLevel(10000000000));
            Assert.AreEqual(tank1.GetWaterLevel(), 100);
        }

        [Test]
        public void TestSetNegativeWaterLevel()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            Assert.IsFalse(tank1.SetWaterLevel(-1));
        }

        [Test]
        public void TestGetWaterVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            Assert.AreEqual(tank1.GetWaterVolume(), 100);
        }

        [Test]
        public void TestSetWaterVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            Assert.IsTrue(tank1.SetWaterVolume(150));
            Assert.AreEqual(tank1.GetWaterVolume(), 150);
        }

        [Test]
        public void TestSetTooMuchWaterVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            Assert.IsFalse(tank1.SetWaterVolume(10000000000));
            Assert.AreEqual(tank1.GetWaterVolume(), 100);
        }

        [Test]
        public void TestTankDrop()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            TimeSpan duration = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            Assert.AreEqual(tank1.TankDroppedList.Count, 0);
            Assert.True(tank1.DropTank(100, DateTime.Now, duration));
            Assert.AreEqual(tank1.TankDroppedList.Count, 1);
            Assert.AreEqual(tank1.GetProductVolume(), 200);
        }

        [Test]
        public void TestTankDropTooMuch()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            TimeSpan duration = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            Assert.AreEqual(tank1.TankDroppedList.Count, 0);
            Assert.False(tank1.DropTank(100000000000, DateTime.Now, duration));
            Assert.AreEqual(tank1.TankDroppedList.Count, 0);
            Assert.AreEqual(tank1.GetProductVolume(), 100);
        }

        [Test]
        public void TestProductChangePerInterval()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            tank1.ProductChangePerInterval(100);
            Assert.AreEqual(tank1.GetProductVolume(), 200);
        }

        [Test]
        public void TestDeliverySwitchTrue()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            tank1.TankDelivering = true;
            tank1.DeliverySwitch(100, DateTime.Now, TimeSpan.Zero);
            Assert.False(tank1.TankDelivering);
        }

        [Test]
        public void TestDeliverySwitchFalse()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            tank1.TankDelivering = false;
            tank1.DeliverySwitch(100, DateTime.Now, TimeSpan.Zero);
            Assert.True(tank1.TankDelivering);
        }

        [Test]
        public void TestLeakingSwitchTrue()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            tank1.TankLeaking = true;
            tank1.LeakingSwitch();
            Assert.False(tank1.TankLeaking);
        }

        [Test]
        public void TestLeakingSwitchFalse()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            tank1.TankLeaking = false;
            tank1.LeakingSwitch();
            Assert.True(tank1.TankLeaking);
        }

        [Test]
        public void TestGetGrossObservedVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            float productLevel = (float)(tank1.GetProductLevel() * (Math.PI * Math.Pow(tank1.TankProbeDiameter / 2, 2)));
            float waterLevel = (float)(tank1.GetWaterLevel() * (Math.PI * Math.Pow(tank1.TankProbeDiameter / 2, 2)));
            float expectedResult = productLevel + waterLevel;
            Assert.AreEqual(tank1.GetGrossObservedVolume(), expectedResult);
        }

        [Test]
        public void TestGetGrossStandardVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            float productLevel = (float)(tank1.GetProductLevel() * (Math.PI * Math.Pow(tank1.TankProbeDiameter / 2, 2)));
            float tempDelta = tank1.ProductTemperature - 15;
            float thermalExpansionCoefficient = TankProbe.thermalExpansionCoefficient;
            float expectedResult = productLevel * (1 - thermalExpansionCoefficient * tempDelta);
            Assert.AreEqual(tank1.GetGrossStandardVolume(), expectedResult);
        }

        [Test]
        public void TestGetUllage()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            float height = tank1.TankProbeHeight;
            float productLevel = tank1.GetProductLevel();
            float waterLevel = tank1.GetWaterLevel();
            float l = height - productLevel - waterLevel;
            float expectedResult = (float)(l * (Math.PI * Math.Pow(tank1.TankProbeDiameter / 2, 2)));
            Assert.AreEqual(tank1.GetUllage(), expectedResult);
        }

        [Test]
        public void TestGetTankStatus()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
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
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            TimeSpan duration = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            Assert.AreEqual(tank1.TankDroppedList.Count, 0);
            Assert.True(tank1.DropTank(100, DateTime.Now, duration));
            Assert.AreEqual(tank1.TankDroppedList.Count, 1);
            Assert.AreEqual(tank1.GetProductVolume(), 200);
            tank1.ClearDeliveryReport();
            Assert.AreEqual(tank1.TankDroppedList.Count, 0);
        }
    }
}
