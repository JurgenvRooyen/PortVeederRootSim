using NUnit.Framework;
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
        }

        [Test]
        public void InvalidProtocolTest()
        {
            Assert.AreEqual(protocol.Parse("i000"), "\x02" +"9999"+"\x03");
        }

        [Test]
        public void i201ProductCodeTest()
        {
            string response = protocol.Parse("i20100");
            Assert.AreEqual('t', response[19]);
        }

        [Test]
        public void i201FloatTest()
        {
            //Testing against known values specified in constructor
            string response = protocol.Parse("i20100");

            string hexVolume = response.Substring(26, 8);
            string hexTemperature = response.Substring(66, 8);
            string hexWaterVol = response.Substring(74, 8);
            byte[] byteVolume = new byte[4];
            byte[] byteTemperature = new byte[4];
            byte[] byteWaterVol = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                byteVolume[byteVolume.Length - i - 1] = Convert.ToByte(hexVolume.Substring(i * 2, 2), 16);
                byteTemperature[byteTemperature.Length - i - 1] = Convert.ToByte(hexTemperature.Substring(i * 2, 2), 16);
                byteWaterVol[byteWaterVol.Length - i - 1] = Convert.ToByte(hexWaterVol.Substring(i * 2, 2), 16);
            }
            Assert.AreEqual(20, BitConverter.ToSingle(byteVolume));
            Assert.AreEqual(15, BitConverter.ToSingle(byteTemperature));
            Assert.AreEqual(10, BitConverter.ToSingle(byteWaterVol));
        }

        [Test]
        public void i201MultipleTest()
        {
            rootSim.AddTankProbe(new TankProbe(2, 't', 100, 1, 10, 10, 15, "volume"));
            string response = protocol.Parse("i20100");

            Assert.AreEqual(148, response.Length);
        }
    }
}
