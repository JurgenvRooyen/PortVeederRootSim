using System;

namespace PortVeederRootGaugeSim
{
    [Serializable]
    public class Tank
    {
        public float TankLength { get; set; }
        public float TankDiameter { get; set; }

        // Alarm attributes
        public float FullVolume { get; set; }
        public float MaxSafeWorkingCapacity { get; set; }
        public float OverFillLimitLevel { get; set; }
        public float HighProductAlarmLevel { get; set; }
        public float DeliveryNeededWarningLevel { get; set; }
        public float LowProductAlarmLevel { get; set; }
        public float HighWaterAlarmLevel { get; set; }
        public float HighWaterWarningLevel { get; set; }

        public float TankDeliveringPerInterval { get; set; }
        public float TankLeakingPerInterval { get; set; }

        public Boolean Connecting { get; set; }
        public int ConnectedTo { get; set; } // store other tank's ID

        public Tank(float tankLength, float tankDiameter)
        {
            this.TankLength = tankLength;
            this.TankDiameter = tankDiameter;

            FullVolume = Models.Helper.LevelToVolume_Horizontal(tankDiameter, tankLength, TankDiameter);

            MaxSafeWorkingCapacity = 0.95F * FullVolume;
            OverFillLimitLevel = 0.90F * TankDiameter;
            HighProductAlarmLevel = 0.80F * TankDiameter;
            DeliveryNeededWarningLevel = 0.30F * TankDiameter;
            LowProductAlarmLevel = 0.20F * TankDiameter;
            HighWaterAlarmLevel = 0.10F * TankDiameter;
            HighWaterWarningLevel = 0.05F * TankDiameter;

            TankDeliveringPerInterval = 10;
            TankLeakingPerInterval = 10;
        }
    }
}
