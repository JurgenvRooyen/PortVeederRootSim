using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace PortVeederRootGaugeSim.IO
{
    class TcpServer
    {
        readonly TcpListener listener;
        // Dependecy injection for the protocol to call, possibly specify an interface for protocol to support multiple protocols?
        IProtocol protocol;
        bool acceptIncoming;

        public TcpServer(PortVeederRoot protocol)
        {
            Int32 port = 10001;
            IPAddress addr = IPAddress.Parse("127.0.0.1");
            this.protocol = protocol;
            this.listener = new TcpListener(addr, port);
        }

        public void Start()
        {
            listener.Start();
            acceptIncoming = true;
            Listen();
        }

        private async void Listen()
        {
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
            try
            {
                while ((await nStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    Debug.WriteLine(System.Text.Encoding.ASCII.GetString(buffer));
                    string parsed = protocol.Parse((System.Text.Encoding.ASCII.GetString(buffer)));
                    Debug.WriteLine(parsed);
                    nStream.Write(System.Text.Encoding.ASCII.GetBytes(parsed));
                }

                nStream.Close();
                client.Close();

            }
            catch (IOException)
            {
                nStream.Close();
            }
        }
    }
}
