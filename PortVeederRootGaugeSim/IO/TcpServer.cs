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
        // A basic non-blocking TcpServer to handle requests, includes the capability to delay final Tx if necessary (currently not implemented on the front end)
        readonly TcpListener listener;
        public IProtocol protocol { get; set; }
        bool acceptIncoming;

        public int Wait { get; set; }
        public int Offset { get; set; }

        public TcpServer(IProtocol protocol)
        {
            // Default settings for the simulator to simulate PVR gauages
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

        private async Task Listen() // returns a Task so that exceptions can still be raised
        { 
            while (acceptIncoming)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                await HandleClient(client);
            }
        }

        private async Task HandleClient(TcpClient client) // returns a Task so that exceptions can still be raised
        {
            NetworkStream nStream = client.GetStream();
            byte[] buffer = new byte[1024];
            try
            {
                while ((await nStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string parsed = protocol.Parse((System.Text.Encoding.ASCII.GetString(buffer)));

                    // Used for debugging and functional testing - only included with debug symbol present
                    Debug.WriteLine(DateTime.Now.ToString());
                    Debug.WriteLine("Received");
                    Debug.WriteLine(System.Text.Encoding.ASCII.GetString(buffer));
                    Debug.WriteLine("Parsed");
                    Debug.WriteLine(parsed);
                    if(parsed == "") 
                    {
                        break;
                    }
                    if (parsed.Length > Offset + 1)
                    {
                        // If the break position is reached (impossible on a value of zero), transmit the pre break message wait for the necessary time and transmit the final portion
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