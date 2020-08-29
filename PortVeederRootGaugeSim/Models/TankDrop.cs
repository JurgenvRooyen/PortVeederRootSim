using System;

namespace PortVeederRootGaugeSim
{
    class TankDrop
    {
        public float Volume { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public float DeliveringVolumePerInterval;
        public Boolean Dropped = false;

        // Need to change the type of attr when link this with GUI
        public TankDrop(float volume, DateTime startDate, int duration)
        {
            Volume = volume;
            StartDate = startDate;
            Duration = duration;
            DeliveringVolumePerInterval = (volume / (60 * duration))/10;
        }

        
        public float DeliveringPerInterval() 
        {
            float DroppedVolume = 0;
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
