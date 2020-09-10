﻿using NUnit.Framework;
using PortVeederRootGaugeSim;
using PortVeederRootGaugeSim.IO;
using System;
using System.Collections.Generic;

namespace SimulatorTest
{
    class ProtocolTest
    {
        TLS3XXProtocol protocol;
        RootSim rootSim;

        private float HexToSingle(string hex)
        {
            byte[] singleByte = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                singleByte[singleByte.Length - i - 1] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return BitConverter.ToSingle(singleByte);
        }

        [SetUp]
        public void SetUp()
        {
            //tankId, productCode, tankLength, tankDiameter, productValue, waterValue, productTemerature
            TankProbe tankProbe = new TankProbe(1, 't', 100, 1, 10, 10, 15, "volume");
            List<TankProbe> tankprobeList = new List<TankProbe>();
            TimeSpan timeSpan = new TimeSpan();
            tankprobeList.Add(tankProbe);
            rootSim = new RootSim(tankprobeList, timeSpan);
            protocol = new TLS3XXProtocol(rootSim);

            TankDrop td = new TankDrop(10, DateTime.Now, 5, 5, 15, 6, 15);
            td.EndingTemperatureCompensatedVolume = 10;
            td.EndingTemperature = 20;
            td.EndingVolume = 10;
            td.EndingWaterVolume = 11;
            td.EndingTime = DateTime.Now;
            td.EndingVLevel = 10;

            tankProbe.TankDroppedList.Add(td);
        }

        [Test]
        public void InvalidProtocolTest()
        {
            Assert.AreEqual(protocol.Parse("i000"), "\x02" +"9999"+"\x03");
        }

        // Parameterised Tests

        [TestCase("i20100")]
        [TestCase("i20101")]
        [TestCase("i20200")]
        [TestCase("i20201")]
        public void CommandEchoTest(string command)
        {
            string response = protocol.Parse(command);

            Assert.AreEqual(command, response.Substring(1, 6));
        }

        [TestCase("i20101")]
        [TestCase("i20201")]
        public void ProductCodeTest(string command)
        {
            string response = protocol.Parse(command);
            Assert.AreEqual('t', response[19]);
        }

        [Test]
        public void i201FloatTest()
        {
            //Testing against known values specified in constructor
            string response = protocol.Parse("i20101");

            string hexVolume = response.Substring(26, 8);
            string hexTemperature = response.Substring(66, 8);
            string hexWaterVol = response.Substring(74, 8);

            float volume = HexToSingle(hexVolume);
            float temperature = HexToSingle(hexTemperature);
            float waterVolume = HexToSingle(hexWaterVol);

            Assert.AreEqual(20, volume);
            Assert.AreEqual(15, temperature);
            Assert.AreEqual(10, waterVolume);
        }

        [Test]
        public void i201MultipleTest()
        {
            rootSim.AddTankProbe(new TankProbe(2, 't', 100, 1, 10, 10, 15, "volume"));
            string response = protocol.Parse("i20100");

            Assert.AreEqual(148, response.Length);
        }

        [Test]
        public void i202FloatTest()
        {
            string response = protocol.Parse("i20201");
            string hexStartGOV = response.Substring(44, 8);
            string hexStartWater = response.Substring(60, 8);
            string hexStartTemp = response.Substring(68, 8);
            string hexEndGOV = response.Substring(76, 8);
            string hexEndWater = response.Substring(92, 8);
            string hexEndTemp = response.Substring(100, 8);

            float startGOV = HexToSingle(hexStartGOV);
            float startWater = HexToSingle(hexStartWater);
            float startTemp = HexToSingle(hexStartTemp);
            float endGOV = HexToSingle(hexEndGOV);
            float endWater = HexToSingle(hexEndWater);
            float endTemp = HexToSingle(hexEndTemp);

            Assert.AreEqual(5, startGOV);
            Assert.AreEqual(6, startWater);
            Assert.AreEqual(15, startTemp);
            Assert.AreEqual(10, endGOV);
            Assert.AreEqual(11, endWater);
            Assert.AreEqual(20, endTemp);
        }

        [Test]
        public void i202MultipleDropsTest()
        {
            TankDrop td = new TankDrop(5, DateTime.Now, 5, 5, 5, 6, 10);
            td.EndingTemperatureCompensatedVolume = 10;
            td.EndingTemperature = 20;
            td.EndingVolume = 10;
            td.EndingWaterVolume = 11;
            td.EndingTime = DateTime.Now;
            td.EndingVLevel = 10;

            rootSim.TankProbeList[0].TankDroppedList.Add(td);
            string response = protocol.Parse("i20201");

            Assert.AreEqual(227, response.Length);
        }
    }
}
