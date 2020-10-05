using System;

namespace PortVeederRootGaugeSim.Models
{
    static class Helper
    {

        public static float GetWorkingSafeCapacity(float workingSafeCapacity, float workingFullVolume)
        {
            return workingSafeCapacity * workingFullVolume;
        }

        public static float GetFullVolume(float workingTankDiameter, float workingTankLength)
        {
            return LevelToVolume_Horizontal(workingTankDiameter, workingTankLength, workingTankDiameter);
        }

        public static float LevelToVolume_Horizontal(double l, double length, double diameter)
        {
            double R = diameter / 2 ;
            double L = length ;
            double level = l ;
            double v = L * ((R * R * Math.Acos((R - level) / R)) - (R - level) * Math.Sqrt((2 * R * level) - (level * level))) / 1000000;
            return (float)v;
        }



        public static float SearchLevelOnVolumeChange_Horizontal(double old_v, double change_v, double currentLevel, float length, float diameter)
        {
            double goal_v = old_v + change_v;
            double current_L = currentLevel;
            double searchLevelChangingPerTime = diameter / 100;

            if (change_v > 0)
            {
                while (goal_v - LevelToVolume_Horizontal(current_L, length, diameter) > 0.001)
                {
                    while (LevelToVolume_Horizontal(current_L + searchLevelChangingPerTime, length, diameter) > goal_v)
                    {
                        searchLevelChangingPerTime /= 3.0000;
                    }
                    current_L += searchLevelChangingPerTime;
                }

                return (float)current_L;
            }

            if (change_v < 0 && old_v + change_v > 0 )
            {
                while (LevelToVolume_Horizontal(current_L, length, diameter) - goal_v > 0.0001)
                {

                    while (LevelToVolume_Horizontal(current_L - searchLevelChangingPerTime, length, diameter) < goal_v)
                    {
                        searchLevelChangingPerTime /= 3.0000;
                    }
                    current_L -= searchLevelChangingPerTime;

                }

                return (float)current_L;
            }
            return 0;

        }

        public static Tuple<float, float> ProductFlowing(float productT1, float productT2,float speed)
        {
            float high = Math.Max(productT1, productT2);
            float low = Math.Min(productT1, productT2);
            float difference = high - low;
            if (difference/2 <= speed)
            {
                return Tuple.Create((high + low) / 2, (high + low) / 2);
            }

            return Tuple.Create(high- speed, low+speed);
        }


    }
}
