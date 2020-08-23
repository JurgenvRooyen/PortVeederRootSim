using NUnit.Framework;
using PortVeederRootGaugeSim.IO;
using System;
using System.Net;
using System.Net.Sockets;

namespace BlackBoxTest
{
    class BlackBox
    {
        TLS3XXProtocol protocol;
        TcpServer server;
        TcpClient client;

        [SetUp]
        public void SetUp()
        {
            protocol = new TLS3XXProtocol();
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
            Assert.IsNotNull(response);
            Assert.AreNotEqual(response, String.Empty);
            Assert.AreEqual(response, "\x02" + "9999" + "\x03");
        }
    }
}
