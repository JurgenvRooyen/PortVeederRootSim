using System;
using System.Collections.Generic;
using System.Text;

namespace PortVeederRootGaugeSim
{
    class TankDrop
    {
        public double Volume { get; set; }
        public String StartDate { get; set; }
        public int Duration { get; set; }
        public double DropingVolimePerSecond;
        public Boolean Dropped = false;


        public TankDrop(int volume, String startDate, int duration)
        {
            Volume = volume;
            StartDate = startDate;
            Duration = duration;
            DropingVolimePerSecond = volume / (60 * duration);
        }

        
        public double DropingTankPerSecond() 
        {
            double DroppedVolume = 0;
            if (Volume > DropingVolimePerSecond)
            {
                DroppedVolume = DropingVolimePerSecond;
                Volume -= DropingVolimePerSecond;
            }
            else 
            {
                DroppedVolume = Volume;
                Volume = 0;
                Dropped = true;
            }

            return DroppedVolume;
        }



    }
}
