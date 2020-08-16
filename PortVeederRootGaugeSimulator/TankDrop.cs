using System;
using System.Collections.Generic;
using System.Text;

namespace PortVeederRootGaugeSimulator
{
    class TankDrop
    {
        public int Volume { get; set; }
        public String StartDate { get; set; }
        public int Duration { get; set; }


        public TankDrop(int volume, String startDate, int duration)
        {
            Volume = volume;
            StartDate = startDate;
            Duration = duration;
        }



    }
}
