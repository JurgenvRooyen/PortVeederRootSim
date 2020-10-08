using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PortVeederRootGaugeSim.IO
{
    class TcpServer
    {
        readonly TcpListener listener;
        public IProtocol protocol { get; set; }
        bool acceptIncoming;
        public int Wait { get; set; }
        public int Offset { get; set; }

        public TcpServer(IProtocol protocol)
        {
            Int32 port = 10001;
            IPAddress addr = IPAddress.Parse("127.0.0.1");
            this.protocol = protocol;
            listener = new TcpListener(addr, port);
            Wait = 100;
            Offset = 0;
        }

        public void Start()
        {
            listener.Start();
            acceptIncoming = true;
            _ = Listen();
        }

        private async Task Listen()
        {
            while (acceptIncoming)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                await HandleClient(client);
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            NetworkStream nStream = client.GetStream();
            byte[] buffer = new byte[1024];
            try
            {
                while ((await nStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    Debug.WriteLine("Received");
                    Debug.WriteLine(System.Text.Encoding.ASCII.GetString(buffer));
                    string parsed = protocol.Parse((System.Text.Encoding.ASCII.GetString(buffer)));
                    Debug.WriteLine("Parsed");
                    Debug.WriteLine(parsed);
                    if(parsed == "")
                    {
                        break;
                    }
                    if (parsed.Length > Offset + 1)
                    {
                        int breakPosition = parsed.Length - Offset;
                        string starter = parsed.Substring(0, breakPosition);
                        string ending = parsed.Substring(breakPosition, Offset);

                        nStream.Write(System.Text.Encoding.ASCII.GetBytes(starter));
                        System.Threading.Thread.Sleep(Wait);
                        nStream.Write(System.Text.Encoding.ASCII.GetBytes(ending));
                    } else
                    {
                        nStream.Write(System.Text.Encoding.ASCII.GetBytes(parsed));
                    }
                }

                nStream.Close();
                client.Close();
                Debug.WriteLine("Stream Closed");
            }
            catch (IOException)
            {
                nStream.Close();
            }
        }
    }
}