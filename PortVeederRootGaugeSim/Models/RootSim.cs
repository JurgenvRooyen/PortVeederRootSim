using System;
using System.Collections.Generic;
using System.Threading;

namespace PortVeederRootGaugeSim
{
    class RootSim
    {
        public List<TankProbe> TankProbeList { get; set; }
        public TimeSpan SystemTime { get; set; }

        public RootSim(List<TankProbe> tankList)
        {
            TankProbeList = tankList;
            Thread timer = new Thread(() => TickingTime());
            timer.Start();
        }

        private void TickingTime()
        {
            while (true)
            {
                SystemTime = DateTime.Now.TimeOfDay;
                Thread.Sleep(100);
            }
            
        }

         
    

        public void AddTankProbek(TankProbe t)
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

