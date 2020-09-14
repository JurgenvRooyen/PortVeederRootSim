using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PortVeederRootGaugeSim.IO
{

    class TLS3XXProtocol
    {
        RootSim simulator;
        string dateFormatString = "yyMMddHHmm";

        public TLS3XXProtocol(RootSim simulator)
        {
            this.simulator = simulator;
        }

        private string DateFormat(TimeSpan offset)
        {
            DateTime simulatorTime = System.DateTime.Now + offset;
            string formattedTime = simulatorTime.ToString(dateFormatString);
            return formattedTime;
        }

        public string Parse(string toParse)
        {
            StringBuilder sb = new StringBuilder("\x02");

            char protocolCategory;
            string protocolCommand;
            string tankNumber;
            int probeID;
            try
            {
                protocolCategory = toParse[1];
                protocolCommand = toParse.Substring(2, 3);
                tankNumber = toParse.Substring(5, 2);
                probeID = Convert.ToInt32(tankNumber);

                Debug.WriteLine("Protocol Parses");
                Debug.WriteLine("Protocol Category: " + protocolCategory);
                Debug.WriteLine("Protocol Command: " + protocolCommand);
                Debug.WriteLine("Tank Number: " + tankNumber);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                sb.Append("9999" + "\x03");
                return sb.ToString();
            }

            // This can probably be replaced with a key:value store to call functions
            if (protocolCategory == 'i')
            {
                switch (protocolCommand)
                {
                    case "201":
                        sb.Append(I201(probeID));
                        break;
                    case "202":
                        sb.Append(I202(probeID));
                        break;
                    case "205":
                        sb.Append(I205(probeID));
                        break;
                    case "902":
                        sb.Append(I902());
                        break;
                    default:
                        sb.Append("9999");
                        break;
                }

            }
            else if (protocolCategory == 's')
            {
                switch (protocolCommand)
                {
                    case "051":
                        sb.Append(S051(probeID));
                        break;
                    case "501":
                        sb.Append(S501(toParse.Substring(6)));
                        break;
                    case "628":
                        sb.Append(S628(toParse.Substring(6)));
                        break;
                    default:
                        sb.Append("9999");
                        break;
                }
            }
            else
            {
                sb.Append("9999");
            }

            // TLS3XX protocol requires an ending ETX char to mark a messages end, this can be disabled if necessary.
            // TODO: investigate if enabler requires ETX marking or supports it?
            sb.Append("\x03");
            return sb.ToString();
        }

        private string SingleToHex(Single number)
        {
            int converted = BitConverter.SingleToInt32Bits(number);
            return converted.ToString("x");
        }

        //Command I201 - In Tank inventory
        private string I201(int probeID)
        {

            List<TankProbe> probes = simulator.TankProbeList;
            StringBuilder replyString = new StringBuilder();
            replyString.Append("i201");
            replyString.Append(probeID.ToString().PadLeft(2, '0'));
            replyString.Append(DateFormat(simulator.SystemTime));

            string ProbeDetails(int probeID)
            {
                StringBuilder probeString = new StringBuilder();
                TankProbe probe = probes[probeID - 1];

                probeString.Append(probeID.ToString().PadLeft(2, '0'));
                probeString.Append(probe.ProductCode);
                //Not implemented yet, as Delivery and Leak not implemented. Need clarification as to fuel height alarm.
                probeString.Append("0000");
                probeString.Append("07");
                probeString.Append(SingleToHex((float)probe.GetGrossObservedVolume()));
                Console.WriteLine(SingleToHex((float)probe.GetGrossObservedVolume()));
                probeString.Append(SingleToHex((float)probe.GetGrossStandardVolume()));
                probeString.Append(SingleToHex((float)probe.GetUllage()));
                probeString.Append(SingleToHex((float)probe.GetProductLevel()));
                probeString.Append(SingleToHex((float)probe.GetWaterLevel()));
                probeString.Append(SingleToHex((float)probe.ProductTemperature));
                probeString.Append(SingleToHex((float)probe.GetWaterVolume()));

                return probeString.ToString();
            }

            if (probeID == 0)
            {
                probeID++;
                foreach (TankProbe probe in probes)
                {
                    replyString.Append(ProbeDetails(probeID));
                    probeID++;
                }
            }
            else
            {
                replyString.Append(ProbeDetails(probeID));
            }

            return replyString.ToString();
        }

        //Command I202 - In Tank delivery report
        private string I202(int probeID)
        {
            List<TankProbe> probes = simulator.TankProbeList;
            StringBuilder replyString = new StringBuilder();

            replyString.Append("i202");
            replyString.Append(probeID.ToString().PadLeft(2, '0'));
            replyString.Append(DateFormat(simulator.SystemTime));

            string ProbeDetails(int ProbeID)
            {
                StringBuilder probeString = new StringBuilder();
                TankProbe probe = probes[probeID - 1];

                probeString.Append(probeID.ToString().PadLeft(2, '0'));
                probeString.Append(probe.ProductCode);

                int totolDrops = probe.TankDroppedList.Count;
                probeString.Append(totolDrops.ToString().PadLeft(2, '0'));

                foreach (TankDrop drop in probe.TankDroppedList)
                {
                    probeString.Append(drop.StartTime.ToString(dateFormatString));
                    probeString.Append(drop.EndingTime.ToString(dateFormatString));
                    probeString.Append("10");

                    probeString.Append(SingleToHex(drop.StartingVolume));
                    probeString.Append(SingleToHex(drop.StartingTemperatureCompensatedVolume));
                    probeString.Append(SingleToHex(drop.StartingWaterVolume));
                    probeString.Append(SingleToHex(drop.StartingTemperature));

                    probeString.Append(SingleToHex(drop.EndingVolume));
                    probeString.Append(SingleToHex(drop.EndingTemperatureCompensatedVolume));
                    probeString.Append(SingleToHex(drop.EndingWaterVolume));
                    probeString.Append(SingleToHex(drop.EndingTemperature));
                    probeString.Append(SingleToHex(drop.StartingVLevel));
                    probeString.Append(SingleToHex(drop.EndingVLevel));
                }

                return probeString.ToString();
            }

            if (probeID == 0)
            {
                probeID++;
                foreach (TankProbe probe in probes)
                {
                    replyString.Append(ProbeDetails(probeID));
                    probeID++;
                }
            }
            else
            {
                replyString.Append(ProbeDetails(probeID));
            }

            return replyString.ToString();
        }

        //Command I205 - In Tank Status Report
        private string I205(int probeID)
        {
            List<TankProbe> probes = simulator.TankProbeList;
            StringBuilder replyString = new StringBuilder();

            replyString.Append("i205");
            replyString.Append(probeID.ToString().PadLeft(2, '0'));
            replyString.Append(DateFormat(simulator.SystemTime));

            string ProbeDetails(int probeID)
            {
                StringBuilder probeString = new StringBuilder();
                TankProbe probe = probes[probeID - 1];
                string codes = "";

                if(probe.TankLeaking)
                {
                    codes.Concat("02");
                }

                if(probe.waterLevel >= probe.HighWaterAlarmLevel)
                {
                    codes.Concat("03");
                }
                if(probe.ProductLevel + probe.waterLevel >= probe.OverFillLimit)
                {
                    codes.Concat("04");
                }
                if(probe.ProductLevel <= probe.LowProductAlarmLevel);
                {
                    codes.Concat("05");
                }
                if(probe.ProductLevel >= probe.HighProductAlarmLevel)
                {
                    codes.Concat("07");
                }
                // Check for invalid fuel level alarm?
                if(probe.ProductLevel <= 15)
                {
                    codes.Concat("08");
                }
                //Probe disconnected not implemented

                if(probe.waterLevel >= probe.HighWaterWarningLevel)
                {
                    codes.Concat("10");
                }
                if(probe.ProductLevel <= probe.DeliveryNeededWarningLevel)
                {
                    codes.Concat("11");
                }
                if(probe.ProductLevel >= probe.MaxSafeWorkingCapacity)
                {
                    codes.Concat("12");
                }
                if(probe.ProductTemperature < 8)
                {
                    codes.Concat("27");
                }

                string totalAlarms = (codes.Length / 2).ToString().PadLeft(2, '0');
                probeString.Append(totalAlarms);
                probeString.Append(codes);

                return probeString.ToString();
            }

            if (probeID == 0)
            {
                probeID++;
                foreach (TankProbe probe in probes)
                {
                    replyString.Append(ProbeDetails(probeID));
                    probeID++;
                }
            }
            else
            {
                replyString.Append(ProbeDetails(probeID));
            }
            return replyString.ToString();
        }

        //Command I902 - Getting Software and revision version
        private string I902()
        {
            StringBuilder replyString = new StringBuilder();
            replyString.Append("i90200");
            replyString.Append(DateFormat(simulator.SystemTime));
            replyString.Append("SOFTWARE# ");
            replyString.Append(simulator.GetSoftWareVersion());
            replyString.Append("-");
            replyString.Append(simulator.GetSoftWareRevision());
            replyString.Append("CREATED -  ");
            replyString.Append(simulator.GetCreationDate());

            return replyString.ToString();
        }

        //Command S051 - Clear In Tank delivery reports
        private string S051(int probeID)
        {
            List<TankProbe> probes = simulator.TankProbeList;
            StringBuilder replyString = new StringBuilder();

            replyString.Append("s051");
            replyString.Append(probeID.ToString().PadLeft(2, '0'));
            replyString.Append(DateFormat(simulator.SystemTime));

            if (probeID == 0)
            {
                foreach (TankProbe probe in probes)
                {
                    probe.ClearDeliveryReport();
                }
            }
            else
            {
                probes[probeID].ClearDeliveryReport();
            }
                return replyString.ToString();
        }

        //Command S501 - Setting date and time
        private string S501(string setString)
        {
            return null;
        }

        //Command S628 - Set Tank Maximum Value
        private string S628(string setString)
        {
            return null;
        }
    }
}
