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

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TankProbe tankProbe = new TankProbe(1, 't', 100, 1, 10, 10, 15, "level");
            List<TankProbe> tankprobeList = new List<TankProbe>();
            TimeSpan timeSpan = new TimeSpan();
            tankprobeList.Add(tankProbe);
            RootSim rootSim = new RootSim(tankprobeList, timeSpan);
            protocol = new PortVeederRoot(rootSim);
            server = new TcpServer(protocol);
            server.Start();
        }

        [SetUp]
        public void SetUp()
        {
            client = new TcpClient();
        }

        [TestCase("test")]
        [TestCase("i99900")]
        [TestCase("i20199")]
        public void InvalidCommandTest(string toTest)
        {
            client.Connect("127.0.0.1", 10001);
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(toTest);
            NetworkStream nStream = client.GetStream();
            nStream.Write(data);

            System.Threading.Thread.Sleep(1000);

            string response = "";

            while (true)
            {
                byte[] bytes = new byte[1];
                nStream.Read(bytes, 0, 1);
                string decode = Encoding.UTF8.GetString(bytes);
                response += decode;
                if (decode == "\x03") { break; }
            }

            Assert.IsNotNull(response);
            Assert.AreEqual("\x002" + "9999" + "\x003", response);

            nStream.Close();
            client.Close();
        }
    }
}
