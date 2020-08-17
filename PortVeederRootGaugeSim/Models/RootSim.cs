using System;
using System.Collections.Generic;
using System.Text;

namespace PortVeederRootGaugeSim
{
    class RootSim
    {
        public List<Tank> TankList { get; set; }

        public RootSim(List<Tank> tankList)
        {
            TankList = tankList;
        }

    

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
