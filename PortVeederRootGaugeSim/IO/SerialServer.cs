using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace PortVeederRootGaugeSim.IO.PortVeederRoot
{
    class SerialServer
    {
        // Basic server for serial communication, doesn't support full duplex operations and requires further work
        readonly string[] ports;
        readonly IProtocol protocol;
        readonly SerialPort serial;

        public SerialServer(IProtocol protocol)
        {
            this.protocol = protocol;
            ports = SerialPort.GetPortNames();
            Debug.WriteLine(ports);
            Debug.WriteLine("SelectedGridItemChangedEventArgs:" + ports[1]);
            serial = new SerialPort("COM5", 9600)
            {
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None,

                ReadTimeout = 1000,
                WriteTimeout = 1000
            };

            serial.DataReceived += new SerialDataReceivedEventHandler(ReceiveData);

            // Close before attempting to open incase the application somehow already has taken control of the comport and is holding it open
            serial.Close();
            Thread.Sleep(1000);

            serial.Close();
            if (serial.IsOpen)
            {
                Debug.WriteLine("open");
            }
            else
            {
                Debug.WriteLine("closed");
                serial.Open();
            }

        }

        public void ReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(200);
            string data = serial.ReadExisting();
            string parsed = protocol.Parse(data);
            Debug.WriteLine("recv");
            Debug.WriteLine(data);
            Debug.WriteLine("pars");
            Debug.WriteLine(parsed);

            serial.Write(parsed);
        }
    }
}