using System;

namespace PortVeederRootGaugeSim
{
    class TankDrop
    {
        public double Volume { get; set; }
        public String StartDate { get; set; }
        public int Duration { get; set; }
        public double DropingVolimePerInterval;
        public Boolean Dropped = false;

        // Need to change the type of attr when link this with GUI
        public TankDrop(double volume, String startDate, int duration)
        {
            Volume = volume;
            StartDate = startDate;
            Duration = duration;
            DropingVolimePerInterval = (volume / (60 * duration))/10;
        }

        
        public double DropingTankPerInterval() 
        {
            double DroppedVolume = 0;
            if (Volume > DropingVolimePerInterval)
            {
                DroppedVolume = DropingVolimePerInterval;
                Volume -= DropingVolimePerInterval;
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
