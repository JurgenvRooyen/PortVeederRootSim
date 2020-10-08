using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace PortVeederRootGaugeSim.IO.PortVeederRoot
{
    class SerialServer
    {
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

            serial.Close();
            System.Threading.Thread.Sleep(1000);

            serial.Close();
            if (serial.IsOpen)
            {
                Debug.WriteLine("opend");
            }
            else
            {
                Debug.WriteLine("closed");
                serial.Open();
            }

        }

        public void ReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
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