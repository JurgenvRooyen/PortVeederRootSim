using System;

namespace PortVeederRootGaugeSim
{
    class TankDrop
    {
        public double Volume { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public double DeliveringVolumePerInterval;
        public Boolean Dropped = false;

        // Need to change the type of attr when link this with GUI
        public TankDrop(double volume, DateTime startDate, int duration)
        {
            Volume = volume;
            StartDate = startDate;
            Duration = duration;
            DeliveringVolumePerInterval = (volume / (60 * duration))/10;
        }

        
        public double DeliveringPerInterval() 
        {
            double DroppedVolume = 0;
            if (Volume > DeliveringVolumePerInterval)
            {
                DroppedVolume = DeliveringVolumePerInterval;
                Volume -= DeliveringVolumePerInterval;
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
