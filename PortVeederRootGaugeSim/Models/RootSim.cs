using System;
using System.Collections.Generic;

namespace PortVeederRootGaugeSim
{
    public class RootSim
    {
        // need to be changed after things are done 
        public const String SoftWareVersion = "0.1";
        public string GetSoftWareVersion()
        {
            string temp = SoftWareVersion;
            return temp;
        }

        // need to be changed after things are done 
        public const String SoftWareRevision = "0.1";
        public string GetSoftWareRevision()
        {
            string temp = SoftWareRevision;
            return temp;
        }
        // DateTime can not be const and need to be changed after things are done 
        public DateTime CreationDate = Convert.ToDateTime("10/9/2020");
        public DateTime GetCreationDate()
        {
            return this.CreationDate;
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

