using PortVeederRootGaugeSim.IO;
using PortVeederRootGaugeSim.IO.PortVeederRoot;
using System;
using System.Windows.Forms;

namespace PortVeederRootGaugeSim
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RootSim rootSim = new RootSim();
            DebugPortVeederRoot debug = new DebugPortVeederRoot();
            ProtocolPortVeederRoot protocol = new ProtocolPortVeederRoot(rootSim, debug);            
            TcpServer server = new TcpServer(protocol);
            server.Start();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(rootSim, debug));
        }
    }
}
