using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PortVeederRootGaugeSim.IO
{
    class TcpServer
    {
        TcpListener listener;
        // Dependecy injection for the protocol to call, possibly specify an interface for protocol to support multiple protocols?
        TLS3XXProtocol protocol;
        bool acceptIncoming;
        Byte[] bytes;

        public TcpServer(TLS3XXProtocol protocol)
        {
            Int32 port = 10001;
            IPAddress addr = IPAddress.Parse("127.0.0.1");
            this.protocol = protocol;
            this.listener = new TcpListener(addr, port);
            this.bytes = new Byte[256];
        }

        public void Start()
        {
            listener.Start();
            acceptIncoming = true;
            Listen();
        }

        private async void Listen()
        {        
            Console.WriteLine("Start listening");
            while (acceptIncoming)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                HandleClient(client);
            }
        }

        private async void HandleClient(TcpClient client)
        {
            NetworkStream nStream = client.GetStream();
            byte[] buffer = new byte[256];
            while ((await nStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string parsed = protocol.parse((System.Text.Encoding.ASCII.GetString(buffer)));
                nStream.Write(System.Text.Encoding.ASCII.GetBytes(parsed));
            }

            nStream.Close();
        }
    }
}
