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
            System.Diagnostics.Debug.WriteLine("tank probe ID" + t.TankProbeId);
            TankProbeList.Add(t);
            System.Diagnostics.Debug.WriteLine("Number of tanks in Root Sim " + TankProbeList.Count);
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
            try
            {
                return TankProbeList[probeNumber];
            } catch (System.ArgumentOutOfRangeException e)
            {
                System.Diagnostics.Debug.WriteLine("probe number " + probeNumber + " " + "list length " + TankProbeList.Count);
                return TankProbeList[0];
                   
            }
            
        }

    }
}
