using NUnit.Framework;
using PortVeederRootGaugeSim;
using PortVeederRootGaugeSim.IO;
using System;
using System.Collections.Generic;

namespace SimulatorTest
{
    class ProtocolTest
    {
        TLS3XXProtocol protocol;

        [SetUp]
        public void SetUp()
        {
            TankProbe tankProbe = new TankProbe(1, 't', 100, 1, 10, 10, 15, "level");
            List<TankProbe> tankprobeList = new List<TankProbe>();
            TimeSpan timeSpan = new TimeSpan();
            tankprobeList.Add(tankProbe);
            RootSim rootSim = new RootSim(tankprobeList, timeSpan);
            protocol = new TLS3XXProtocol(rootSim);
        }

        [Test]
        public void InvalidProtocol()
        {
            Assert.AreEqual(protocol.Parse("i000"), "\x02" +"9999"+"\x03");
        }
    }
}
