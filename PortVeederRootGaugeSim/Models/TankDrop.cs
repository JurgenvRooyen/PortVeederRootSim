using System;

namespace PortVeederRootGaugeSim
{
    [Serializable]
    public class TankDrop
    {
        public float Volume { get; set; }
        public DateTime StartTime { get; set; }
        public float StartingVolume { get; set; }
        public float StartingLevel { get; set; }
        public float StartingTemperatureCompensatedVolume { get; set; }
        public float StartingWaterVolume { get; set; }
        public float StartingTemperature { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime EndingTime { get; set; }
        public float EndingVolume { get; set; }
        public float EndingLevel { get; set; }
        public float EndingTemperatureCompensatedVolume { get; set; }
        public float EndingWaterVolume { get; set; }
        public float EndingTemperature { get; set; }
       
        public TankDrop() { }


        public TankDrop(float volume, DateTime startTime, float startingVolume, float startingVLevel, float startingTemperatureCompensatedVolume, float startingWaterVolume, float startingTemperature)
        {
            Volume = volume;
            StartTime = startTime;
            StartingVolume = startingVolume;
            StartingLevel = startingVLevel;
            StartingTemperatureCompensatedVolume = startingTemperatureCompensatedVolume;
            StartingWaterVolume = startingWaterVolume;
            StartingTemperature = startingTemperature;
        }
    }
}
