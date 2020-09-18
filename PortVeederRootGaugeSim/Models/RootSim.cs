using System;
using System.Collections.Generic;

namespace PortVeederRootGaugeSim
{
    public class RootSim
    {
        // need to be changed after things are done 
        private const string SoftWareVersion = "612760-100";
        public string GetSoftWareVersion()
        {
            string temp = SoftWareVersion;
            return temp;
        }

        // need to be changed after things are done 
        private const string SoftWareRevision = "001";
        public string GetSoftWareRevision()
        {
            string temp = SoftWareRevision;
            return temp;
        }
        // DateTime can not be const and need to be changed after things are done 
        private string CreationDate = "20.09.08.12.01";
        public string GetCreationDate()
        {
            return CreationDate;
        }

        public List<TankProbe> TankProbeList { get; set; }
        public TimeSpan SystemTime { get; set; }

        public RootSim()
        {
            TankProbeList = new List<TankProbe>();
            SystemTime = new TimeSpan();
        }

        public RootSim(List<TankProbe> tankProbeList, TimeSpan systemTime)
        {
            TankProbeList = tankProbeList;
            SystemTime = systemTime;
        }




        public void AddTankProbe(TankProbe t)
        {
            TankProbeList.Add(t);
        }

        public void RemoveTankProbe(int tankId)
        {
            for (int i = 0; i < TankProbeList.Count; i++)
            {
                if (TankProbeList[i].TankProbeId == tankId)
                {
                    TankProbeList.Remove(TankProbeList[i]);
                }
            }
        }

        public TankProbe GetProbe(int probeNumber)
        {
            return TankProbeList[probeNumber];
        }

    }
}

