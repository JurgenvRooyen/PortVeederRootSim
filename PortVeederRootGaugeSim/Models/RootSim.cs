using System.Collections.Generic;

namespace PortVeederRootGaugeSim
{
    class RootSim
    {
        public List<TankProbe> TankProbeList { get; set; }

        public RootSim(List<TankProbe> tankList)
        {
            TankProbeList = tankList;
        }

    

        public void addTankProbek(TankProbe t)
        {
            TankProbeList.Add(t);
        }

        public void removeTankProbe(int tankId)
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
