using NUnit.Framework;
using PortVeederRootGaugeSim;
using PortVeederRootGaugeSim.IO.PortVeederRoot;
using System;
using System.Collections.Generic;

namespace SimulatorTest
{
    class ProtocolTest
    {
        ProtocolPortVeederRoot protocol;
        DebugPortVeederRoot debug;
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
            // Test tank capacity is 3140L
            TankProbe tankProbe = new TankProbe(1, 't', new Tank(1000,2000), 500, 500, 15);
            List<TankProbe> tankprobeList = new List<TankProbe>();
            TimeSpan timeSpan = new TimeSpan();
            tankprobeList.Add(tankProbe);
            rootSim = new RootSim(tankprobeList, timeSpan);
            debug = new DebugPortVeederRoot();
            protocol = new ProtocolPortVeederRoot(rootSim, debug);

            TankDrop td = new TankDrop(10, DateTime.Now, 5, 5, 15, 6, 15);
            td.EndingTemperatureCompensatedVolume = 10;
            td.EndingTemperature = 20;
            td.EndingVolume = 10;
            td.EndingWaterVolume = 11;
            td.EndingTime = DateTime.Now;
            td.EndingLevel = 10;

            tankProbe.TankDroppedList.Add(td);
        }

        [Test]
        public void InvalidProtocolTest()
        {
            Assert.AreEqual(protocol.Parse("i000"), "\x01" + "9999&&FECF" + "\x03");
        }

        // Parameterised Tests
        [TestCase("i20100")]
        [TestCase("i20101")]
        [TestCase("i20200")]
        [TestCase("i20201")]
        public void CommandEchoTest(string command)
        {
            string response = protocol.Parse("\x02" + command);
            Console.WriteLine(response);
            Assert.AreEqual(command, response.Substring(1, 6));
        }

        [TestCase("i20101")]
        [TestCase("i20201")]
        public void ProductCodeTest(string command)
        {
            string response = protocol.Parse("\x02" + command);
            Assert.AreEqual('t', response[19]);
        }

        [Test]
        public void i201FloatTest()
        {
            //Testing against known values specified in constructor
            string response = protocol.Parse("\x02i20101");
            string hexVolume = response.Substring(26, 8);
            string hexTemperature = response.Substring(66, 8);
            string hexWaterVol = response.Substring(74, 8);

            float volume = HexToSingle(hexVolume);
            float temperature = HexToSingle(hexTemperature);
            float waterVolume = HexToSingle(hexWaterVol);

            Assert.AreEqual(1570, (int)volume);
            Assert.AreEqual(15, temperature);
            Assert.AreEqual(614, (int)waterVolume);
        }

        [Test]
        public void i201MultipleTest()
        {
            rootSim.AddTankProbe(new TankProbe(2, 't', new Tank(100, 1), 10, 10, 15));
            string response = protocol.Parse("\x02i20100");

            Assert.AreEqual(154, response.Length);
        }

        [Test]
        public void i202FloatTest()
        {
            string response = protocol.Parse("\x02i20201");
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
            td.EndingLevel = 10;

            rootSim.TankProbeList[0].TankDroppedList.Add(td);
            string response = protocol.Parse("\x02i20201");

            Assert.AreEqual(233, response.Length);
        }

        [Test]
        public void s628Test()
        {
            float originalMax = rootSim.TankProbeList[0].MyTank.MaxSafeWorkingCapacity;
            string newMax = BitConverter.SingleToInt32Bits(rootSim.TankProbeList[0].MyTank.FullVolume / 2).ToString("x");
            string response = protocol.Parse("\x02s62800"+ newMax);
            Console.WriteLine(newMax);
            Assert.AreNotEqual(originalMax, rootSim.TankProbeList[0]);
            Assert.AreNotEqual("\x002" + "9999" + "\x003", response);
        }
      
        [Test]
        public void s051ClearReportsTest()
        {
            string response = protocol.Parse("\x02s05101");
            Assert.AreEqual(0, rootSim.TankProbeList[0].TankDroppedList.Count);
        }

        [Test]
        public void s501SetDateTest()
        {
            string newDateToSet = "1801010101";
            protocol.Parse("\x02s50100" + newDateToSet);
            DateTime newDate = DateTime.Now + rootSim.SystemTime;

            Assert.AreEqual(2018, newDate.Year);
            Assert.AreEqual(01, newDate.Month);
            Assert.AreEqual(01, newDate.Day);
            Assert.AreEqual(01, newDate.Hour);
            Assert.AreEqual(01, newDate.Minute);
        }

        [Test]
        public void s501SetBadDateTest()
        {
            string newDateToSet = "ABCDEFG";
            string response = protocol.Parse("\x02s50100" + newDateToSet);

            Assert.AreEqual("\x01" + "9999" + "&&", response.Substring(0, 7));
            Assert.AreEqual("\x03", response.Substring(response.Length-1));
        }
    }
}
