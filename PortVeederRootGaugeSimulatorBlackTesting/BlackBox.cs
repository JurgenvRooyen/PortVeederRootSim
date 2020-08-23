using NUnit.Framework;
using PortVeederRootGaugeSim.IO;

namespace SimulatorTest
{
    class ProtocolTest
    {
        TLS3XXProtocol protocol;

        [SetUp]
        public void SetUp()
        {
            protocol = new TLS3XXProtocol();
        }

        [Test]
        public void InvalidProtocol()
        {
            Assert.AreEqual(protocol.parse("i000"), "\x02" +"9999"+"\x03");
        }
    }
}
