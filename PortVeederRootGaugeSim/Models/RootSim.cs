using System;
using System.Collections.Generic;

namespace PortVeederRootGaugeSim
{
    class RootSim
    {
 
        public List<TankProbe> TankProbeList { get; set; }
        public TimeSpan SystemTime { get; set; }


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

    }
}

