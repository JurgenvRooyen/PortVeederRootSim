﻿using System;
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

        private string CalculateChecksum(String message)
        {
            int stringValue = 0;

            foreach(char c in message)
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
            replyString.Append(probeID.ToString().PadLeft(2, '0'));
            replyString.Append(DateFormat(simulator.SystemTime));
            
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

        public string Parse(string toParse)
        {
            StringBuilder sb = new StringBuilder("\x01");
            string protocolCommand;
            string tankNumber;
            int probeID;


            // possible exceptions arise from:
            // String.Substring - ArgumentOutOfRangeException
            // Convert.ToInt32 - FormatException, OverflowException
            try
            {
                protocolCommand = toParse.Substring(1, 4);
                tankNumber = toParse.Substring(5, 2);
                probeID = Convert.ToInt32(tankNumber);

                Debug.WriteLine("Protocol Parses");
                Debug.WriteLine("Protocol Command: " + protocolCommand);
                Debug.WriteLine("Tank Number: " + tankNumber);

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
                    case "i501":
                        sb.Append(I501());
                        break;
                    case "i902":
                        sb.Append(I902());
                        break;

                    case "s051":
                        sb.Append(CommandResponse("s051", probeID, S051));
                        break;
                    case "s501":
                        sb.Append(S501(toParse.Substring(7, 10)));
                        break;
                    case "s628":
                        sb.Append(S628(probeID, toParse.Substring(7, 8)));
                        break;
                    default:
                        sb.Append("9999");
                        break;
                    }
                }
            catch (ArgumentOutOfRangeException e)
            {
                sb.Append("9999");
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }
            catch (FormatException e)
            {
                sb.Append("9999");
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }catch (OverflowException e)
            {
                sb.Append("9999");
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }

            sb.Append("&&");
            sb.Append(CalculateChecksum(sb.ToString()));
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
            probeString.Append(SingleToHex(probe.ProductLevel));
            probeString.Append(SingleToHex(probe.WaterLevel));
            probeString.Append(SingleToHex(probe.ProductTemperature));
            probeString.Append(SingleToHex(probe.WaterVolume));

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
            if(probe.WaterLevel >= probe.HighWaterAlarmLevel)
            {
                codes += "03";
            }
            // TODO need check  after change tank from Vertical to Horizontal
            if (probe.ProductLevel + probe.WaterLevel >= probe.OverFillLimitLevel)
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

            if(probe.WaterLevel >= probe.HighWaterWarningLevel)
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

            // TODO need check  after change tank from Vertical to Horizontal
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
