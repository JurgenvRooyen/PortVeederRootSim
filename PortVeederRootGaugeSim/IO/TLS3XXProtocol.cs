using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text;

namespace PortVeederRootGaugeSim.IO
{

    class TLS3XXProtocol
    {
        readonly RootSim simulator;

        public TLS3XXProtocol(RootSim simulator)
        {
            this.simulator = simulator;
        }

        private string DateFormat(TimeSpan offset)
        {
            DateTime simulatorTime = System.DateTime.Now + offset;
            string formattedTime = simulatorTime.ToString("yyMMddHHmm");
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
                protocolCategory = toParse[0];
                protocolCommand = toParse.Substring(1, 3);
                tankNumber = toParse.Substring(4, 2);
                probeID = Convert.ToInt32(tankNumber);
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

            } else if(protocolCategory == 's')
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
            } else
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
                TankProbe probe = probes[probeID-1];

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
                foreach(TankProbe probe in probes)
                {
                    replyString.Append(ProbeDetails(probeID));
                    probeID++;
                }
            } else
            {
                replyString.Append(ProbeDetails(probeID));
            }

            return replyString.ToString();
        }

        //Command I202 - In Tank delivery report
        private string I202(int probeID)
        {
            return null;
        }

        //Command I205 - In Tank Status Report
        private string I205(int TankNumber)
        {
            return null;
        }

        //Command I902 - Getting Software and revision version
        private string I902()
        {
            return null;
        }

        //Command S051 - Clear In Tank delivery reports
        private string S051(int TankNumber)
        {
            return null;
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
