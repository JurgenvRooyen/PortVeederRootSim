using System;
using System.Collections.Generic;
using System.Text;

namespace PortVeederRootGaugeSimulator
{
    class RootSim
    {
        public RootSim(List<Tank> tankList)
        {
            TankList = tankList;
        }

        public List<Tank> TankList { get; set; }

        public void addTank(Tank t)
        {
            TankList.Add(t);
        }

        public void removeTank(int tankId)
        {
            for (int i = 0; i < TankList.Count; i++)
            {
                if (TankList[i].TankId == tankId)
                {
                    TankList.Remove(TankList[i]);
                }
            }
        }

    }
}
