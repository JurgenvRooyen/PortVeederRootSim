using NUnit.Framework;
using PortVeederRootGaugeSim;
using PortVeederRootGaugeSim.IO;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace BlackBoxTest
{
    class BlackBox
    {
        PortVeederRoot protocol;
        TcpServer server;
        TcpClient client;
        TankProbe tankProbe, tankProbe2;
        RootSim rootSim;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            tankProbe = new TankProbe(1, 't', new Tank(100, 1), 10, 10, 15);
            tankProbe2 = new TankProbe(1, 't', new Tank(100, 1), 10, 10, 15);
            List<TankProbe> tankprobeList = new List<TankProbe>();
            TimeSpan timeSpan = new TimeSpan();
            tankprobeList.Add(tankProbe);
            tankprobeList.Add(tankProbe2);
            rootSim = new RootSim(tankprobeList, timeSpan);
            protocol = new PortVeederRoot(rootSim);
            server = new TcpServer(protocol);
            server.Start();
        }

        [SetUp]
        public void SetUp()
        {
            tankProbe.TankDroppedList.Clear();
            client = new TcpClient();

            TankDrop td = new TankDrop(10, DateTime.Now, 5, 5, 15, 6, 15);
            td.EndingTemperatureCompensatedVolume = 10;
            td.EndingTemperature = 20;
            td.EndingVolume = 10;
            td.EndingWaterVolume = 11;
            td.EndingTime = DateTime.Now;
            td.EndingLevel = 10;

            tankProbe.TankDroppedList.Add(td);
        }

        private float HexToSingle(string hex)
        {
            byte[] singleByte = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                singleByte[singleByte.Length - i - 1] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return BitConverter.ToSingle(singleByte);
        }

        private string SingleToHex(Single number)
        {
            int converted = BitConverter.SingleToInt32Bits(number);
            return converted.ToString("x");
        }

        private string SendRequest(String request)
        {
            client.Connect("127.0.0.1", 10001);
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("\x02" + request);
            NetworkStream nStream = client.GetStream();
            nStream.Write(data);

            string response = "";

            while (true)
            {
                byte[] bytes = new byte[1];
                nStream.Read(bytes, 0, 1);
                string decode = Encoding.UTF8.GetString(bytes);
                response += decode;
                if (decode == "\x03") { break; }
            }

            nStream.Close();
            client.Close();

            return response;
        }

        [TestCase("test")]
        [TestCase("i99900")]
        [TestCase("i20199")]
        public void InvalidCommandTest(string toTest)
        {

            string response = SendRequest(toTest);

            Assert.IsNotNull(response);
            Assert.AreEqual("\x01" + "9999&&FECF" + "\x03", response);
        }

        [TestCase("i20100")]
        [TestCase("i20200")]
        [TestCase("i20500")]
        [TestCase("i90200")]
        [TestCase("s05100")]
        [TestCase("s501002001010101")]
        [TestCase("s6280000000000")]
        public void CommandEchoTest(string toTest)
        {
            string response = SendRequest(toTest);

            Assert.AreEqual(toTest.Substring(0,6), response.Substring(1, 6));
        }

        [TestCase("i20199")]
        [TestCase("i20299")]
        [TestCase("i20599")]
        [TestCase("s05199")]
        [TestCase("s6289900000000")]
        public void OutOfRangeTankTest(string toTest)
        {
            string response = SendRequest(toTest);

            Assert.AreEqual("\x001" + "9999&&FECF" + "\x003", response);
        }

        [Test]
        public void i201Test()
        {
            string response = SendRequest("i20101");

            string hexVolume = response.Substring(26, 8);
            string hexTemperature = response.Substring(66, 8);
            string hexWaterVol = response.Substring(74, 8);

            float volume = HexToSingle(hexVolume);
            float temperature = HexToSingle(hexTemperature);
            float waterVolume = HexToSingle(hexWaterVol);

            Assert.AreEqual(tankProbe.GetGrossObservedVolume(), volume);
            Assert.AreEqual(tankProbe.ProductTemperature, temperature);
            Assert.AreEqual(tankProbe.WaterVolume, waterVolume);
        }

        [Test]
        public void i202Test()
        {
            string response = SendRequest("i20201");

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
        public void s051Test()
        {
            SendRequest("s05101");
            client = new TcpClient();
            string response = SendRequest("i20201");

            Assert.AreEqual("00", response.Substring(20, 2));
        }

        [Test]
        public void s501SetDateTest()
        {
            string newDateToSet = "1801010101";
            string response = SendRequest("s50100" + newDateToSet);

            client = new TcpClient();
            string queryResponse = SendRequest("i20101");

            Assert.AreEqual(newDateToSet, response.Substring(17, 10));
            Assert.AreEqual(newDateToSet, queryResponse.Substring(7, 10));
        }

        [Test]
        public void i628Test()
        {
            string newMax = BitConverter.SingleToInt32Bits(rootSim.TankProbeList[0].MyTank.FullVolume / 2)
                .ToString("x");

            string response = SendRequest("s62800" + newMax);

            Assert.AreNotEqual("\x002" + "9999" + "\x003", response);
        }
    }
}
