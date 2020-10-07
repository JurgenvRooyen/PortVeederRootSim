using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace PortVeederRootGaugeSim.IO.PortVeederRoot
{

    class ProtocolPortVeederRoot : IProtocol
    {
        readonly RootSim simulator;
        readonly string dateFormatString = "yyMMddHHmm";
        readonly string notSupported = "9999";
        readonly DebugPortVeederRoot pvDebug;

        public ProtocolPortVeederRoot(RootSim simulator, DebugPortVeederRoot debug)
        {
            this.simulator = simulator;
            this.pvDebug = debug;
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

        private string CalculateChecksum(String message)
        {
            int stringValue = 0;

            foreach (char c in message)
            {
                stringValue += c;
            }

            int compliment = 0 - stringValue;
            string hexValue = compliment.ToString("X");

            return hexValue.Substring(hexValue.Length - 4);
        }

        // Function to provide the necessary logic for looping where necessary
        private string CommandResponse(string echo, int probeID, Func<int, string> function)
        {
            List<TankProbe> probes = simulator.TankProbeList;
            StringBuilder replyString = new StringBuilder();
            replyString.Append(echo);

            if (echo == "i202" && pvDebug.InvalidTankDropNumber)
            {
                replyString.Append("xx");
            } else
            { 
                replyString.Append(probeID.ToString().PadLeft(2, '0'));
            }

            replyString.Append(DateFormat(simulator.SystemTime));

            if (probeID == 0)
            {
                if (pvDebug.RespondToAllProbes)
                {
                    probeID++;
                    foreach (TankProbe probe in probes)
                    {
                        replyString.Append(function(probeID));
                        probeID++;
                    }
                }
                else { 
                    return notSupported; 
                }
            }
            else
            {
                replyString.Append(function(probeID));
            }
            return replyString.ToString();
        }

        public string Parse(string toParse)
        {
            StringBuilder sb = new StringBuilder("\x01");
            Debug.WriteLine(toParse.Length + " " + toParse.Length + " " + toParse.Length);

            //BIR Commands - seperate control flow as they don't echo back in the normal fashion but instead use ACK/NACK control characters with no SOH or ETX
            //Error codes however retain the <SOH>9999&&CHKS<ETX> format
            //Polling for events
            if (toParse.Substring(1, 1) == "D")
            {
               if(pvDebug.SupportBIR && pvDebug.EventAckNakRespond)
                {
                   return("\x06");
                } 
               else if(pvDebug.SupportBIR && !pvDebug.EventAckNakRespond)
                {
                    return "";
                } 
                else
                {
                    sb.Append(notSupported);
                }
            }

            //Start an event, check if BIR infact supported
            else if(toParse[1] == 'B')
            {
                if (pvDebug.SupportBIR)
                {
                    return ("\x06");
                }
                else
                {
                    sb.Append(notSupported);
                }
            }
            //End an event, in this case it is not necessary to update the tank volumne
            else if (toParse[1] == 'C' && toParse[15] == '\x03')
            {
                if (pvDebug.SupportBIR)
                {
                    return ("\x06");
                }
                else
                {
                    sb.Append(notSupported);
                }
            }
            //End an event, with BIR data to update the tank volume
            else if (toParse[1] == 'C' && toParse[35] == '\x03')
            {
                if (pvDebug.SupportBIR && pvDebug.UpdatevolumeUsingBIR)
                {
                    return EndDelivery(toParse);
                } else if (!pvDebug.SupportBIR)
                {
                    sb.Append(notSupported);
                }
            }

            else if(toParse[1] == 'i' || toParse[1] == 's')
            {
                sb.Append(NormalCommandParse(toParse));
            }
            else
            {
                sb.Append(notSupported);
            }
            if (pvDebug.InvalidDataTerminationFlag)
            {
                sb.Append("B8");
            }
            else
            { 
                sb.Append("&&"); 
            }
            sb.Append(CalculateChecksum(sb.ToString()));
            sb.Append("\x03");
            return sb.ToString();
        }

        private string NormalCommandParse(string toParse)
        {
            StringBuilder nsb = new StringBuilder();
            string protocolCommand;
            string tankNumber;
            int probeID;

            try
            {
                // possible exceptions arise from:
                // String.Substring - ArgumentOutOfRangeException
                // Convert.ToInt32 - FormatException, OverflowException
                protocolCommand = toParse.Substring(1, 4);
                tankNumber = toParse.Substring(5, 2);
                probeID = Convert.ToInt32(tankNumber);

                Debug.WriteLine("Protocol Parses");
                Debug.WriteLine("Protocol Command: " + protocolCommand);
                Debug.WriteLine("Tank Number: " + tankNumber);

                switch (protocolCommand)
                {
                    case "i201":
                        nsb.Append(CommandResponse("i201", probeID, I201));
                        break;
                    case "i202":
                        if (pvDebug.TankDropRespond)
                        {
                            nsb.Append(CommandResponse("i202", probeID, I202));
                        }
                        else
                        {
                            nsb.Append(notSupported);
                        }
                        break;
                    case "i205":
                        nsb.Append(CommandResponse("i205", probeID, I205));
                        break;
                    case "i501":
                        if (pvDebug.DateTimeRespond)
                        {
                            nsb.Append(I501());
                        }
                        else
                        {
                            nsb.Append(notSupported);
                        }
                        break;
                    case "i902":
                        if (pvDebug.VersionRespond)
                        {
                            nsb.Append(I902());
                        }
                        else
                        {
                            nsb.Append(notSupported);
                        }
                        break;

                    case "s051":
                        nsb.Append(CommandResponse("s051", probeID, S051));
                        break;
                    case "s501":
                        nsb.Append(S501(toParse.Substring(7, 10)));
                        break;
                    case "s628":
                        nsb.Append(S628(probeID, toParse.Substring(7, 8)));
                        break;
                    default:
                        nsb.Append(notSupported);
                        break;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                nsb.Append(notSupported);
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }
            catch (FormatException e)
            {
                nsb.Append(notSupported);
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }
            catch (OverflowException e)
            {
                nsb.Append(notSupported);
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }

            return nsb.ToString();
        }

        //BIR Command Ending a hose delivery
        private string EndDelivery(string toParse)
        {
            try
            {
                // Attempt to get the tank number directly from the fueling position in a 1:1 fashion
                // Does NOT support blended operations in current setup
                int tankNumber = int.Parse(toParse.Substring(12,1)); 
                if(pvDebug.DeliveryTankZeroBased)
                {
                    tankNumber++;
                }
    
                float transactionTotal = float.Parse(toParse.Substring(13, 9));
                TankProbe tank = simulator.TankProbeList[tankNumber];
    
                tank.SetProductVolume(tank.ProductVolume - transactionTotal);

                return "\x06";
            }
            // Failures due to bad decimal encoding return a NAK
            catch(InvalidCastException e)
            {
                Debug.WriteLine(e.Message);
                return "\x15";
            }
        }

        //Command I201 - In Tank inventory
        private string I201(int probeID)
        {
            List<TankProbe> probes = simulator.TankProbeList;
            StringBuilder probeString = new StringBuilder();
            TankProbe probe = probes[probeID - 1];
    
            probeString.Append(probeID.ToString().PadLeft(2, '0'));
            probeString.Append(probe.ProductCode);
            
            float variance = 0;
            if(pvDebug.RandomizeLevels)
            {
                Random rand = new Random();
                variance = Convert.ToSingle(rand.NextDouble()*5);
                variance -= 2.5f;
            }

            char delivering = '0';
            string preceedingBits = "000";
            string fieldsToFollow = "07";

            if(probe.TankDelivering)
            {
                delivering = '1';
            }
            if(pvDebug.ForceRndMsg)
            {
                preceedingBits = "00";
                fieldsToFollow = "7";
            }

            probeString.Append(preceedingBits + delivering);
            probeString.Append(fieldsToFollow);
            probeString.Append(SingleToHex(probe.GetGrossObservedVolume() + variance).PadLeft(8, '0'));
            probeString.Append(SingleToHex(probe.GetGrossStandardVolume()+ variance).PadLeft(8, '0'));
            probeString.Append(SingleToHex(probe.GetUllage()).PadLeft(8, '0'));
            probeString.Append(SingleToHex(probe.ProductLevel+ variance).PadLeft(8, '0'));
            probeString.Append(SingleToHex(probe.WaterLevel+ variance).PadLeft(8, '0'));
            probeString.Append(SingleToHex(probe.ProductTemperature+ variance).PadLeft(8, '0'));
            probeString.Append(SingleToHex(probe.WaterVolume+ variance).PadLeft(8, '0'));

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
                if (pvDebug.IncludeHeights)
                {
                    probeString.Append("0A");
                } else
                {
                    probeString.Append("08");
                }

                probeString.Append(SingleToHex(drop.StartingVolume).PadLeft(8, '0'));
                probeString.Append(SingleToHex(drop.StartingTemperatureCompensatedVolume).PadLeft(8, '0'));
                probeString.Append(SingleToHex(drop.StartingWaterVolume).PadLeft(8, '0'));
                probeString.Append(SingleToHex(drop.StartingTemperature).PadLeft(8, '0'));

                probeString.Append(SingleToHex(drop.EndingVolume).PadLeft(8, '0'));
                probeString.Append(SingleToHex(drop.EndingTemperatureCompensatedVolume).PadLeft(8, '0'));
                probeString.Append(SingleToHex(drop.EndingWaterVolume).PadLeft(8, '0'));
                probeString.Append(SingleToHex(drop.EndingTemperature).PadLeft(8, '0'));

                if (pvDebug.IncludeHeights)
                {
                    probeString.Append(SingleToHex(drop.StartingLevel).PadLeft(8, '0'));
                    probeString.Append(SingleToHex(drop.EndingLevel).PadLeft(8, '0'));
                }
            }

            return probeString.ToString();
        }

        //Command I205 - In Tank Status Report
        private string I205(int probeID)
        {
            List<TankProbe> probes = simulator.TankProbeList;

            StringBuilder probeString = new StringBuilder();
            TankProbe probe = probes[probeID - 1];
            probeString.Append(probeID);
            string codes = "";

            if (probe.TankprobeStatus == "ERR")
            {
                codes += "01";
            }
            if (probe.TankLeaking)
            {
                codes += "02";
            }
            if (probe.WaterLevel >= probe.MyTank.HighWaterAlarmLevel)
            {
                codes += "03";
            }

            if (probe.ProductLevel + probe.WaterLevel >= probe.MyTank.OverFillLimitLevel)
            {
                codes += "04";
            }
            if (probe.ProductLevel <= probe.MyTank.LowProductAlarmLevel)
            {
                codes += "05";
            }
            if (probe.ProductLevel >= probe.MyTank.HighProductAlarmLevel)
            {
                codes += "07";
            }
            // Check for invalid fuel level alarm?
            if (probe.ProductLevel <= 15)
            {
                codes += "08";
            }
            //Probe disconnected not implemented
            if (probe.TankprobeStatus == "OUT")
            {
                codes += "09";
            }
            if (probe.WaterLevel >= probe.MyTank.HighWaterWarningLevel)
            {
                codes += "10";
            }
            if (probe.ProductLevel <= probe.MyTank.DeliveryNeededWarningLevel)
            {
                codes += "11";
            }
            if (probe.ProductLevel >= probe.MyTank.MaxSafeWorkingCapacity)
            {
                codes += "12";
            }
            if (probe.ProductTemperature < 8)
            {
                codes += "27";
            }

            string totalAlarms = (codes.Length / 2).ToString().PadLeft(2, '0');
            probeString.Append(totalAlarms);
            probeString.Append(codes);

            return probeString.ToString();
        }

        //Command I501 - Time of Day Inquiry
        private string I501()
        {
            StringBuilder replyString = new StringBuilder();

            replyString.Append("i50100");
            replyString.Append(DateFormat(simulator.SystemTime));
            replyString.Append(DateFormat(simulator.SystemTime));

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
            TankProbe probe = simulator.TankProbeList[probeID - 1];
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

            if(!pvDebug.RespondToAllProbes)
            {
                return (notSupported);
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
