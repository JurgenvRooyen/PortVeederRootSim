using NUnit.Framework;
using NUnit.Framework.Internal;
using PortVeederRootGaugeSim;
using System;
using System.Collections.Generic;
using System.IO;

namespace SimulatorTest
{
    public class RootSimTest
    {
        [Test]
        public void TestAddTankProbe()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,100), 100, 100, 10);
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbe(tank1);
            Assert.AreEqual(test.TankProbeList.Count, 1);
        }

        [Test]
        public void TestAddMultipleTankProbes()
        {
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,100), 100, 100, 10);
            TankProbe tank2 = new TankProbe(2, char.Parse("P"), new Tank(1000,100), 100, 100, 10);
            TankProbe tank3 = new TankProbe(3, char.Parse("P"), new Tank(1000,100), 100, 100, 10);
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
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,100), 100, 100, 10);
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
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,100), 100, 100, 10);
            TankProbe tank2 = new TankProbe(2, char.Parse("P"), new Tank(1000,100), 100, 100, 10);
            TankProbe tank3 = new TankProbe(3, char.Parse("P"), new Tank(1000,100), 100, 100, 10);
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
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,100), 100, 100, 10);
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
            TankProbe tank1 = new TankProbe(1, char.Parse("P"), new Tank(1000,100), 100, 100, 10);
            List<TankProbe> testList = new List<TankProbe>();
            TimeSpan testTime = new DateTime(2010, 8, 18, 13, 30, 30) - new DateTime(2010, 1, 1, 8, 0, 15);
            RootSim test = new RootSim(testList, testTime);
            test.AddTankProbe(tank1);
            Assert.AreEqual(test.TankProbeList.Count, 1);
            test.RemoveTankProbe(-1);
            Assert.AreEqual(test.TankProbeList.Count, 1);
        }

        [Test]
        public void TestLoadFileDoesNotExist()
        {
            String file = "testFile";
            RootSim test = new RootSim();
            Assert.Throws<FileNotFoundException>(() => test.LoadFile(file));
        }
    }
}