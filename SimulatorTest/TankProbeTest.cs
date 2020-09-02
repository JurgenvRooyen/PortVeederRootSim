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
    }
}
