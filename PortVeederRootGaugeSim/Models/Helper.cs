using System;
using System.Collections.Generic;
using System.Text;

namespace PortVeederRootGaugeSim.Models
{
    static class Helper
    {




        // Horizontal cylinder only
        public static float LevelToVolume_Horizontal(double l, double length, double diameter)
        {
            double R = diameter / 2;
            double L = length;
            double level = l;
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
    }
}
