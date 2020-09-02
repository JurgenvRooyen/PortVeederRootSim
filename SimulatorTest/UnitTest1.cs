using NUnit.Framework;
using NUnit.Framework.Internal;
using PortVeederRootGaugeSim;
using System;
using System.Collections.Generic;

namespace SimulatorTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAddTankProbe()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbe(tank1);
            Assert.AreEqual(test.TankProbeList.Count, 1);
        }

        [Test]
        public void TestAddMultipleTankProbes()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            TankProbe tank2 = new TankProbe(2, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            TankProbe tank3 = new TankProbe(3, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbe(tank1);
            test.AddTankProbe(tank2);
            test.AddTankProbe(tank3);
            Assert.AreEqual(test.TankProbeList.Count, 3);
        }

        [Test]
        public void TestDeleteTankProbe()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbe(tank1);
            Assert.AreEqual(test.TankProbeList.Count, 1);
            test.RemoveTankProbe(1);
            Assert.AreEqual(test.TankProbeList.Count, 0);

        }

        [Test]
        public void TestDeleteMultipleTankProbe()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            TankProbe tank2 = new TankProbe(2, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            TankProbe tank3 = new TankProbe(3, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbe(tank1);
            test.AddTankProbe(tank2);
            test.AddTankProbe(tank3);
            Assert.AreEqual(test.TankProbeList.Count, 3);
            test.RemoveTankProbe(1);
            test.RemoveTankProbe(2);
            test.RemoveTankProbe(3);
            Assert.AreEqual(test.TankProbeList.Count, 0);
        }

        [Test]
        public void TestDeleteTooManyTankProbe()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbe(tank1);
            Assert.AreEqual(test.TankProbeList.Count, 1);
            test.RemoveTankProbe(1);
            test.RemoveTankProbe(2);
            test.RemoveTankProbe(3);
            test.RemoveTankProbe(4);
            Assert.AreEqual(test.TankProbeList.Count, 0);
        }

        [Test]
        public void TestDeleteIndexThatDoesntExistTankProbe()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbe(tank1);
            Assert.AreEqual(test.TankProbeList.Count, 1);
            test.RemoveTankProbe(-1);
            Assert.AreEqual(test.TankProbeList.Count, 1);
        }

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
            Assert.AreEqual(tank1.GetwaterVolume(), 100);
        }

        [Test]
        public void TestSetWaterVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            Assert.IsTrue(tank1.SetwaterVolume(150));
            Assert.AreEqual(tank1.GetwaterVolume(), 150);
        }

        [Test]
        public void TestSetTooMuchWaterVolume()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), 1000, 100, 100, 100, 10, "volume", "cylinder");
            Assert.IsFalse(tank1.SetwaterVolume(10000000000));
            Assert.AreEqual(tank1.GetwaterVolume(), 100);
        }
    }
}