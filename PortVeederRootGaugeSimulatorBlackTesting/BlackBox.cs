using NUnit.Framework;
using PortVeederRootGaugeSim;
using PortVeederRootGaugeSim.IO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace BlackBoxTest
{
    class BlackBox
    {
        TLS3XXProtocol protocol;
        TcpServer server;
        TcpClient client;
        string soh = "\x02";
        string eof = "\x03";

        [SetUp]
        public void SetUp()
        {
            TankProbe tankProbe = new TankProbe(1, 't', 100, 1, 10, 10, 15, "level");
            List<TankProbe> tankprobeList = new List<TankProbe>();
            TimeSpan timeSpan = new TimeSpan();
            tankprobeList.Add(tankProbe);
            RootSim rootSim = new RootSim(tankprobeList, timeSpan);
            protocol = new TLS3XXProtocol(rootSim);
            server = new TcpServer(protocol);
            server.Start();
            client = new TcpClient("127.0.0.1", 10001);
        }

        [Test]
        public void Response()
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("test");
            NetworkStream nStream = client.GetStream();
            nStream.Write(data);

            string response;
            Int32 bytes = nStream.Read(data, 0, data.Length);
            response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

            nStream.Close();
            Console.WriteLine(response);
            Assert.IsNotNull(response);
            Assert.AreNotEqual(response, String.Empty);
            Assert.AreEqual($"{soh}9999{eof}", response);
        }
    }
}
