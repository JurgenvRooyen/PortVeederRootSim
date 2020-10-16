using NUnit.Framework;
using PortVeederRootGaugeSim;
using PortVeederRootGaugeSim.IO.PortVeederRoot;
using PortVeederRootGaugeSim.Models;
using System;
using System.Collections.Generic;


namespace PortVeederRootGaugeSimulatorTest
{
    class HelperTest
    {
        [Test]
        public void WorkingSafeCapacityTest() {
            float workingSafeCapacity = Helper.GetWorkingSafeCapacity(0.95f, 1000);
            Assert.AreEqual(workingSafeCapacity, 950);
        }
        [Test]
        public void GetFullVolumeTest()
        {
            float fullVolume = Helper.GetFullVolume(60, 500);
            Assert.AreEqual(Math.Round(fullVolume, 2), 1.41d);
        }

        [Test]

        public void ProductFlowingTest()
        {
            Tuple<float, float> productFlowing = Helper.ProductFlowing(10, 20, 2);
            Tuple<float, float> expectedValue = new Tuple<float, float>(18.0f, 12.0f);
            Assert.AreEqual(productFlowing, expectedValue);
        }

        [Test]
        public void SearchLevelOnVolumeChange_HorizontalTest()
        {
            float level = Helper.SearchLevelOnVolumeChange_Horizontal(1000, 1500, 5, 500, 60);
            Assert.AreEqual(level, 60.2f);
        }
        [Test]
        public void SearchLevelOnVolumeChange_HorizontalNegativeTest()
        {
            float level = Helper.SearchLevelOnVolumeChange_Horizontal(40, -50, 5, 500, 60);
            Assert.AreEqual(level, 0f);
        }



    }
}
