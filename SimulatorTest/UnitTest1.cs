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
            TankProbe tank1 = new TankProbe(1, (char)65, 1000, 100, 100, 100, 10, "volume", "cylinder");
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbek(tank1);
            Assert.AreEqual(test.TankProbeList.Count, 1);
        }

        [Test]
        public void TestAddMultipleTankProbes()
        {
            TankProbe tank1 = new TankProbe(1, (char)65, 1000, 100, 100, 100, 10, "volume", "cylinder");
            TankProbe tank2 = new TankProbe(2, (char)65, 1000, 100, 100, 100, 10, "volume", "cylinder");
            TankProbe tank3 = new TankProbe(3, (char)65, 1000, 100, 100, 100, 10, "volume", "cylinder");
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbek(tank1);
            test.AddTankProbek(tank2);
            test.AddTankProbek(tank3);
            Assert.AreEqual(test.TankProbeList.Count, 3);
        }

        [Test]
        public void TestDeleteTankProbe()
        {
            TankProbe tank1 = new TankProbe(1, (char)65, 1000, 100, 100, 100, 10, "volume", "cylinder");
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbek(tank1);
            Assert.AreEqual(test.TankProbeList.Count, 1);
            test.RemoveTankProbe(1);
            Assert.AreEqual(test.TankProbeList.Count, 0);

        }

        [Test]
        public void TestDeleteMultipleTankProbe()
        {
            TankProbe tank1 = new TankProbe(1, (char)65, 1000, 100, 100, 100, 10, "volume", "cylinder");
            TankProbe tank2 = new TankProbe(2, (char)65, 1000, 100, 100, 100, 10, "volume", "cylinder");
            TankProbe tank3 = new TankProbe(3, (char)65, 1000, 100, 100, 100, 10, "volume", "cylinder");
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbek(tank1);
            test.AddTankProbek(tank2);
            test.AddTankProbek(tank3);
            Assert.AreEqual(test.TankProbeList.Count, 3);
            test.RemoveTankProbe(1);
            test.RemoveTankProbe(2);
            test.RemoveTankProbe(3);
            Assert.AreEqual(test.TankProbeList.Count, 0);
        }

        [Test]
        public void TestDeleteTooManyTankProbe()
        {
            TankProbe tank1 = new TankProbe(1, (char)65, 1000, 100, 100, 100, 10, "volume", "cylinder");
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbek(tank1);
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
            TankProbe tank1 = new TankProbe(1, (char)65, 1000, 100, 100, 100, 10, "volume", "cylinder");
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbek(tank1);
            Assert.AreEqual(test.TankProbeList.Count, 1);
            test.RemoveTankProbe(-1);
            Assert.AreEqual(test.TankProbeList.Count, 1);
        }
    }
}