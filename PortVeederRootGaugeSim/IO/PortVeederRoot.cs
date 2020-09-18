using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace PortVeederRootGaugeSim.IO
{

    class PortVeederRoot : IProtocol
    {
        readonly RootSim simulator;
        readonly string dateFormatString = "yyMMddHHmm";

        public PortVeederRoot(RootSim simulator)
        {
            this.simulator = simulator;
        }

        // HELPER FUNCTIONS
        private string DateFormat(TimeSpan offset)
        {
            DateTime simulatorTime = System.DateTime.Now + offset;
            string formattedTime = simulatorTime.ToString(dateFormatString);
            return formattedTime;
        }

        private float HexToSingle(string hex)
        {
            byte[] singleByte = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                singleByte[singleByte.Length - i - 1] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return BitConverter.ToSingle(singleByte);
        }

        private string SingleToHex(Single number)
        {
            int converted = BitConverter.SingleToInt32Bits(number);
            return converted.ToString("x");
        }

        // Function to provide the necessary logic for looping where necessary
        private string CommandResponse(string echo, int probeID, Func<int, string> function)
        {
            List<TankProbe> probes = simulator.TankProbeList;
            StringBuilder replyString = new StringBuilder();
            replyString.Append(echo);
            replyString.Append(probeID.ToString().PadLeft(2, '0'));
            replyString.Append(DateFormat(simulator.SystemTime));

            try
            {
                if (probeID == 0)
                {
                    probeID++;
                    foreach (TankProbe probe in probes)
                    {
                        replyString.Append(function(probeID));
                        probeID++;
                    }
                }
                else
                {
                    replyString.Append(function(probeID));
                }
                return replyString.ToString();
            } 
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return "9999";
            }
        }

        public string Parse(string toParse)
        {
            StringBuilder sb = new StringBuilder("\x02");
            string protocolCommand;
            string tankNumber;
            int probeID;
            try
            {
                protocolCommand = toParse.Substring(1, 4);
                tankNumber = toParse.Substring(5, 2);
                probeID = Convert.ToInt32(tankNumber);

                Debug.WriteLine("Protocol Parses");
                Debug.WriteLine("Protocol Command: " + protocolCommand);
                Debug.WriteLine("Tank Number: " + tankNumber);
            }
            // possible exceptions arise from:
            // String.Substring - ArgumentOutOfRangeException
            // Convert.ToInt32 - FormatException, OverflowException
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                sb.Append("9999" + "\x03");
                return sb.ToString();
            }

            // This can probably be replaced with a key:value store to call functions

                switch (protocolCommand)
                {
                    case "i201":
                        sb.Append(CommandResponse("i201", probeID, I201));
                        break;
                    case "i202":
                        sb.Append(CommandResponse("i202", probeID, I202));
                        break;
                    case "i205":
                        sb.Append(CommandResponse("i205", probeID, I205));
                        break;
                    case "i902":
                        sb.Append(I902());
                        break;

                    case "s051":
                        sb.Append(CommandResponse("s051", probeID, S051));
                        break;
                    case "s501":
                        try
                        {
                            sb.Append(S501(toParse.Substring(7,10)));
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            sb.Append("9999");
                        }
                        break;
                    case "s628":
                        sb.Append(S628(probeID, toParse.Substring(6)));
                        break;
                    default:
                        sb.Append("9999");
                        break;
                }


            // TLS3XX protocol requires an ending ETX char to mark a messages end, this can be disabled if necessary.
            // TODO: investigate if enabler requires ETX marking or supports it?
            sb.Append("\x03");
            return sb.ToString();
        }

        //Command I201 - In Tank inventory
        private string I201(int probeID)
        {
            List<TankProbe> probes = simulator.TankProbeList;
            StringBuilder probeString = new StringBuilder();
            TankProbe probe = probes[probeID - 1];

            probeString.Append(probeID.ToString().PadLeft(2, '0'));
            probeString.Append(probe.ProductCode);
            //Not implemented yet, as Delivery and Leak not implemented. Need clarification as to fuel height alarm.
            probeString.Append("0000");
            probeString.Append("07");
            probeString.Append(SingleToHex(probe.GetGrossObservedVolume()));
            probeString.Append(SingleToHex(probe.GetGrossStandardVolume()));
            probeString.Append(SingleToHex(probe.GetUllage()));
            probeString.Append(SingleToHex(probe.GetProductLevel()));
            probeString.Append(SingleToHex(probe.GetWaterLevel()));
            probeString.Append(SingleToHex(probe.ProductTemperature));
            probeString.Append(SingleToHex(probe.GetWaterVolume()));

            return probeString.ToString();
        }

        //Command I202 - In Tank delivery report
        private string I202(int probeID)
        {
            List<TankProbe> probes = simulator.TankProbeList;

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
                probeString.Append(SingleToHex(drop.StartingLevel));
                probeString.Append(SingleToHex(drop.EndingLevel));
            }

            return probeString.ToString();
        }

        //Command I205 - In Tank Status Report
        private string I205(int probeID)
        {
            List<TankProbe> probes = simulator.TankProbeList;

            StringBuilder probeString = new StringBuilder();
            TankProbe probe = probes[probeID - 1];
            string codes = "";

            if(probe.TankLeaking)
            {
                codes += "02";
            }
            if(probe.waterLevel >= probe.HighWaterAlarmLevel)
            {
                codes += "03";
            }
            if(probe.ProductLevel + probe.waterLevel >= probe.OverFillLimit)
            {
                codes += "04";
            }
            if(probe.ProductLevel <= probe.LowProductAlarmLevel)
            {
                codes += "05";
            }
            if(probe.ProductLevel >= probe.HighProductAlarmLevel)
            {
                codes += "07";
            }
            // Check for invalid fuel level alarm?
            if(probe.ProductLevel <= 15)
            {
                codes += "08";
            }
            //Probe disconnected not implemented

            if(probe.waterLevel >= probe.HighWaterWarningLevel)
            {
                codes += "10";
            }
            if(probe.ProductLevel <= probe.DeliveryNeededWarningLevel)
            {
                codes += "11";
            }
            if(probe.ProductLevel >= probe.MaxSafeWorkingCapacity)
            {
                codes += "12";
            }
            if(probe.ProductTemperature < 8)
            {
                codes += "27";
            }

            string totalAlarms = (codes.Length / 2).ToString().PadLeft(2, '0');
            probeString.Append(totalAlarms);
            probeString.Append(codes);

            return probeString.ToString();
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
            TankProbe probe = simulator.TankProbeList[probeID-1];
            probe.ClearDeliveryReport();

            return "";
        }

        //Command S501 - Setting date and time
        private string S501(string setString)
        {
            StringBuilder replyString = new StringBuilder();
            replyString.Append("s501");
            replyString.Append("00");
            replyString.Append(DateFormat(simulator.SystemTime));

            DateTime dateToSet = DateTime.ParseExact(setString, dateFormatString, new CultureInfo("en-NZ"));
            TimeSpan dateAsOffset = dateToSet - DateTime.Now;
            simulator.SystemTime = dateAsOffset;
            replyString.Append(setString);

            return replyString.ToString();
        }

        //Command S628 - Set Tank Maximum Value
        private string S628(int probeID, string setString)
        {
            StringBuilder replyString = new StringBuilder();
            List<TankProbe> probes = simulator.TankProbeList;
            replyString.Append("s628");
            replyString.Append(probeID.ToString().PadLeft(2, '0'));
            replyString.Append(DateFormat(simulator.SystemTime));

            void ProbeDetails(int probeID, Single limit)
            {
                TankProbe probe = probes[probeID];

                probe.SetMaxSafeWorkingCapacityByLevel(limit);
            }

            if (probeID == 0)
            {
                foreach (TankProbe probe in probes)
                {
                    ProbeDetails(probeID, HexToSingle(setString));
                    replyString.Append(setString);
                    probeID++;
                }
            }
            else
            {
                ProbeDetails(probeID, HexToSingle(setString));
                replyString.Append(setString);
            }
            return replyString.ToString();
        }
    }
}
