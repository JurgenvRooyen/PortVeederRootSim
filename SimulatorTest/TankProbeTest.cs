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
            TankDrop drop1 = new TankDrop(100, DateTime.Now, 20);
            Assert.AreEqual(tank1.TankDropCount, 0);
            Assert.True(tank1.TankDrop(drop1));
            Assert.AreEqual(tank1.TankDropCount, 1);
            Assert.AreEqual(tank1.GetProductVolume(), 200);
        }

        [Test]
        public void TestTankDropTooMuch()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            TankDrop drop1 = new TankDrop(100000000000, DateTime.Now, 20);
            Assert.AreEqual(tank1.TankDropCount, 0);
            Assert.False(tank1.TankDrop(drop1));
            Assert.AreEqual(tank1.TankDropCount, 0);
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
            tank1.DeliverySwitch(100);
            Assert.False(tank1.TankDelivering);
        }

        [Test]
        public void TestLeakingSwitchTrue()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            tank1.TankLeaking = true;
            tank1.LeakingSwitch(50);
            Assert.False(tank1.TankLeaking);
        }

        [Test]
        public void TestGetGrossObservedVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            Assert.AreEqual(tank1.GetGrossObservedVolume(), 1570796.38F);
        }

        [Test]
        public void TestGetGrossStandardVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            Assert.AreEqual(tank1.GetGrossStandardVolume(), 792466.75F);
        }

        [Test]
        public void TestGetUllage()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "level", "cylinder");
            Assert.AreEqual(tank1.GetUllage(), 5890486);
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
    }
}
