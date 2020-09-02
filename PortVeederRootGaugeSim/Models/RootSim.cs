using System.Collections.Generic;
using System.Security.AccessControl;

namespace PortVeederRootGaugeSim
{
    public class RootSim
    {
        public List<TankProbe> TankProbeList;

        public RootSim()
        {
            TankProbeList = new List<TankProbe>();
        }

        public void addTankProbe(TankProbe t)
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

        public TankProbe getProbe (int probeNumber)
        {
                return TankProbeList[probeNumber];
        }

    }
}
