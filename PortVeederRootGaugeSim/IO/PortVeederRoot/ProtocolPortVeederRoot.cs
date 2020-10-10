using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PortVeederRootGaugeSim.IO.PortVeederRoot
{

    class ProtocolPortVeederRoot : IProtocol
    {
        readonly RootSim simulator;
        readonly DebugPortVeederRoot pvDebug;
        // String constants
        readonly string dateFormatString = "yyMMddHHmm"; // date format as specified by TLS3XX protocol
        readonly string notSupported = "9999";
        public ProtocolPortVeederRoot(RootSim simulator, DebugPortVeederRoot debug)
        {
            this.simulator = simulator;
            this.pvDebug = debug;
        }

        // HELPER FUNCTIONS
        private string DateFormat(TimeSpan offset)
        {
            // Take the offset found in the RootSim object and apply it to the current date time to get the simulated date and return its appropriate string representation
            DateTime simulatorTime = System.DateTime.Now + offset;
            string formattedTime = simulatorTime.ToString(dateFormatString);
            return formattedTime;
        }

        private float HexToSingle(string hex)
        {
            // Convert a hex representation of 4 byte float to c#
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

        private string AddTerminator()
        {
            string terminator = "&&";

            // Check for the invalid data terminator flag ES-3653
            if (pvDebug.InvalidDataTerminationFlag)
            {
                terminator = "B8";
            }

            return terminator;
        }

        private string CalculateChecksum(String message)
        {
            int stringValue = 0;
            foreach (char c in message)
            {
                stringValue += c;
            }

            // Get the twos compliment of the given total string value and convert to a hex representation
            int compliment = 0 - stringValue;
            string hexValue = compliment.ToString("X");

            // TLS3XX protocol ignores overflows, so simply return four characters, along with the ETX as checksums always precede message ending
            return hexValue.Substring(hexValue.Length - 4) + "\x03";


        }

        private string CommandResponse(string echo, int probeID, Func<int, string> function)
        {
            // Provides the necessary logic to query a tank, or in the case of a 00 command, all tanks.
            // Only supports functions that have the tank number parameter, if necessary function could be overloaded or reflection used for additional Func<> support.
            List<TankProbe> probes = simulator.TankProbeList;
            StringBuilder replyString = new StringBuilder();
            replyString.Append(echo);

            // Check for invalid drop tank data flag ES-3653
            if (echo == "i202" && pvDebug.InvalidTankDropNumber)
            {
                replyString.Append("xx");
            }
            else
            {
                replyString.Append(probeID.ToString().PadLeft(2, '0'));
            }

            replyString.Append(DateFormat(simulator.SystemTime));

            if (probeID == 0) // An all tank '00' query will only be supported if the RespondToAllProbes flag is true
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
                else
                {
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

            //BIR Commands - seperate control flow as they don't echo back in the normal fashion but instead use ACK/NACK control characters with no SOH or ETX
            //Error codes for the BIR commands however retain the <SOH>9999&&CHKS<ETX> format, requiring possible use of the strinbuilder
            if (pvDebug.SupportBIR)
            {
                if (toParse.Substring(1, 1) == "D")  //Polling for events
                {
                    if (pvDebug.EventAckNakRespond)
                    {
                        return ("\x06");
                    }
                    return "";
                }

                //Start an event, check if BIR infact supported
                else if (toParse[1] == 'B')
                {
                    return ("\x06");
                }
                //End an event, in this case it is not necessary to update the tank volumne
                else if (toParse[1] == 'C' && toParse[15] == '\x03')
                {
                    return ("\x06");
                }
                //End an event, with BIR data to update the tank volume
                else if (toParse[1] == 'C' && toParse[35] == '\x03')
                {
                    return EndDelivery(toParse);
                }
            }
            //Normal TLS3XX protocols
            if (toParse[1] == 'i' || toParse[1] == 's')
            {
                sb.Append(NormalCommandParse(toParse));
            }
            else
            {
                sb.Append(notSupported);
            }
            sb.Append(AddTerminator());
            sb.Append(CalculateChecksum(sb.ToString()));
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
                // If exceptions occur it is due to a malformed query, as a result a not supported error is returned. Possible exceptions arise from:
                // String.Substring - ArgumentOutOfRangeException
                // Convert.ToInt32 - FormatException, OverflowException
                protocolCommand = toParse.Substring(1, 4);
                tankNumber = toParse.Substring(5, 2);
                probeID = Convert.ToInt32(tankNumber);

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
            if (pvDebug.UpdateVolumeUsingBIR)
            {
                try
                {
                    // Attempt to get the tank number directly from the fueling position in a 1:1 fashion
                    // Does NOT support blended operations in current setup
                    int tankNumber = int.Parse(toParse.Substring(12, 1));
                    if (pvDebug.DeliveryTankZeroBased)
                    {
                        tankNumber++;
                    }

                    float transactionTotal = float.Parse(toParse.Substring(13, 9));
                    TankProbe tank = simulator.TankProbeList[tankNumber];

                    tank.SetProductVolume(tank.ProductVolume - transactionTotal);

                    return "\x06";
                }
                // Failures due to bad decimal encoding return a NAK
                catch (InvalidCastException e)
                {
                    Debug.WriteLine(e.Message);
                    return "\x15";
                }
            }
            else
            {
                return "";
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

            // If randomize levels flag is true, create a constant variation to apply to tank levels
            float variance = 0;
            if (pvDebug.RandomizeLevels)
            {
                Random rand = new Random();
                variance = Convert.ToSingle(rand.NextDouble() * 5);
                variance -= 2.5f;
            }

            // Build standard fields for the status bits and fields and update if necessary
            char delivering = '0';
            string preceedingBits = "000";
            string fieldsToFollow = "07";

            if (probe.TankDelivering)
            {
                delivering = '1';
            }
            if (pvDebug.ForceRndMsg)
            {
                preceedingBits = "00";
                fieldsToFollow = "7";
            }

            probeString.Append(preceedingBits + delivering);
            probeString.Append(fieldsToFollow);
            probeString.Append(SingleToHex(probe.GetGrossObservedVolume() + variance).PadLeft(8, '0'));
            probeString.Append(SingleToHex(probe.GetGrossStandardVolume() + variance).PadLeft(8, '0'));
            probeString.Append(SingleToHex(probe.GetUllage()).PadLeft(8, '0'));
            probeString.Append(SingleToHex(probe.ProductLevel + variance).PadLeft(8, '0'));
            probeString.Append(SingleToHex(probe.WaterLevel + variance).PadLeft(8, '0'));
            probeString.Append(SingleToHex(probe.ProductTemperature + variance).PadLeft(8, '0'));
            probeString.Append(SingleToHex(probe.WaterVolume + variance).PadLeft(8, '0'));

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

                // Fields to follow will depend on if hieghts are included in the delivery reports
                if (pvDebug.IncludeHeights)
                {
                    probeString.Append("0A");
                }
                else
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
            probeString.Append(probeID.ToString().PadLeft(2, '0'));
            string codes = "";

            if (probe.TankprobeStatus == "ERR") // Tank Setup Data Warning
            {
                codes += "01";
            }
            if (probe.TankLeaking) // Leak Alarm
            {
                codes += "02";
            }
            if (probe.WaterLevel >= probe.MyTank.HighWaterAlarmLevel) // High Water Alarm
            {
                codes += "03";
            }
            if (probe.ProductLevel + probe.WaterLevel >= probe.MyTank.OverFillLimitLevel) // Overfill Alarm
            {
                codes += "04";
            }
            if (probe.ProductLevel <= probe.MyTank.LowProductAlarmLevel) // Low Product Alarm
            {
                codes += "05";
            }
            if (probe.ProductLevel >= probe.MyTank.HighProductAlarmLevel) // High Product Alarm
            {
                codes += "07";
            }
            if (probe.ProductLevel <= 15) // Tank Invalid Fuel Level Alarm
            {
                codes += "08";
            }
            if (probe.TankprobeStatus == "OUT") // Probe Out Alarm
            {
                codes += "09";
            }
            if (probe.WaterLevel >= probe.MyTank.HighWaterWarningLevel) // High Water Warning
            {
                codes += "10";
            }
            if (probe.ProductLevel <= probe.MyTank.DeliveryNeededWarningLevel) // Delivery Needed Warning
            {
                codes += "11";
            }
            if (probe.ProductLevel >= probe.MyTank.MaxSafeWorkingCapacity) // Maximum Product Alarm
            {
                codes += "12";
            }
            if (probe.ProductTemperature < 8) // Cold Temperature Warning
            {
                codes += "27";
            }

            string totalAlarms = (codes.Length / 2).ToString("X").PadLeft(2, '0');
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

            // Get the date time value of the new time to set and calculate the offset that will be passed to the RootSim object
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

            if (!pvDebug.RespondToAllProbes)
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
