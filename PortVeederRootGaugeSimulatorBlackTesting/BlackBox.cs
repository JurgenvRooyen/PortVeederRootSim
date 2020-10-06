using NUnit.Framework;
using PortVeederRootGaugeSim;
using PortVeederRootGaugeSim.IO;
using PortVeederRootGaugeSim.IO.PortVeederRoot;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace BlackBoxTest
{
    class BlackBox
    {
        ProtocolPortVeederRoot protocol;
        TcpServer server;
        TcpClient client;
        TankProbe tankProbe, tankProbe2;
        DebugPortVeederRoot debug;
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
            debug = new DebugPortVeederRoot();
            protocol = new ProtocolPortVeederRoot(rootSim, debug);
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

        [TearDown]
        public void TearDown()
        {
            debug.IncludeHeights = true;
            debug.VersionRespond = true;
            debug.TankDropRespond = true;
            debug.DateTimeRespond = true;
            debug.RespondToAllProbes = true;
            debug.InvalidTankDropNumber = false;
            debug.SupportBIR = true;
            debug.EventAckNakRespond = false;
            debug.InvalidDataTerminationFlag = false;
            rootSim.SystemTime = new TimeSpan();
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
            Console.WriteLine(request.Length);
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
                if (decode == "\x03" || decode == "\x06") { break; }
            }

            nStream.Close();
            client.Close();

            return response;
        }

        [Test]
        public void BIRPollTest()
        {
            debug.ToggleEventAckNakRespond();
            string response = SendRequest("D");
            Assert.AreEqual("\x06", response);
        }

        [Test]
        public void BIRStartTest()
        {
            string response = SendRequest("B");
            Assert.AreEqual("\x06", response);
        }

        [Test]
        public void BIREndNoUpdateTest()
        {
            string response = SendRequest("CQlTv15tBMeTGy" + "\x03");
            Assert.AreEqual("\x06", response);
        }

        [TestCase("D")]
        [TestCase("B")]
        [TestCase("CQlTv15tBMeTGy")]
        public void BIRNotSupportTest(string toTest)
        {
            debug.SupportBIR = false;
            string response = SendRequest(toTest);
            Assert.AreEqual(response, "\x01" + "9999&&FECF" + "\x03");
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

        [TestCase("i20100")]
        [TestCase("i20200")]
        [TestCase("i20500")]
        [TestCase("i90200")]
        [TestCase("s05100")]
        [TestCase("s501002001010101")]
        [TestCase("s6280000000000")]
        public void InvalidTerminatorTest(string toTest)
        {
            debug.InvalidDataTerminationFlag = true;
            string response = SendRequest(toTest);
            Assert.AreEqual("B8", response.Substring(response.Length-7, 2));
        }

        [TestCase("i20100")]
        [TestCase("i20200")]
        [TestCase("i20500")]
        [TestCase("s05100")]
        [TestCase("s6280000000000")]
        public void NoRespondToAllTest(string toTest)
        {
            debug.RespondToAllProbes = false;
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
            Assert.AreEqual(131, response.Length);
        }

        [Test]
        public void i202InvalidTankDropNumber()
        {
            debug.InvalidTankDropNumber = true;
            string response = SendRequest("i20201");
            Assert.AreEqual("xx", response.Substring(5, 2));
        }

        [Test]
        public void i202NoRespondTest()
        {
            debug.ToggleTankDropRespond();
            string response = SendRequest("i20200");

            Assert.AreEqual("\x001" + "9999&&FECF" + "\x003", response);
        }

        [Test]
        public void i202NoIncludeHeightTest()
        {
            debug.ToggleIncludeHeights();
            string response = SendRequest("i20201");

            Assert.AreEqual(115, response.Length);
        }

        [Test]
        public void i501Test()
        {
            string response = SendRequest("i50100");
            string current = DateTime.Now.ToString("yyMMddHHmm");

            Assert.AreEqual(current, response.Substring(17, 10));
        }

        [Test]
        public void i501NoRespondTest()
        {
            debug.ToggleDateTimeRespond();
            string response = SendRequest("i50100");
    

            Assert.AreEqual("\x001" + "9999&&FECF" + "\x003", response);
        }

        [Test]
        public void i902Test()
        {
            string response = SendRequest("i90200");
            Assert.AreEqual(73, response.Length);
        }

        [Test]
        public void i902NoRespondTest()
        {
            debug.ToggleVersionRespond();
            string response = SendRequest("i90200");

            Assert.AreEqual("\x001" + "9999&&FECF" + "\x003", response);
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
