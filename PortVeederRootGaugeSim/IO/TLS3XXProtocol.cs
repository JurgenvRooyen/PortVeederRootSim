using System.Text;

namespace PortVeederRootGaugeSim.IO
{

    class TLS3XXProtocol
    {
        
        public string parse(string toParse)
        {
            StringBuilder sb = new StringBuilder("\x02");

            char protocolCategory;
            string protocolCommand;
            string tankNumber;

            try
            {
                //Skip first char due to SOH marker
                 protocolCategory = toParse[1];
                 protocolCommand = toParse.Substring(2, 3);
                 tankNumber = toParse.Substring(4, 5);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                sb.Append("9999" + "\x03");
                return sb.ToString();
            }

            // TLS3XX protocol requires a prepended SOH char to mark a messages start
            

            // This can probably be replaced with a key:value store to call functions
            if (protocolCategory == 'I')
            {         
                switch (protocolCommand)
                {
                    case "201":
                        sb.Append(I201(tankNumber));
                        break;
                    case "202":
                        sb.Append(I202(tankNumber));
                        break;
                    case "205":
                        sb.Append(I205(tankNumber));
                        break;
                    case "902":
                        sb.Append(I902());
                        break;
                    default:
                        sb.Append("9999");
                        break;
                }

            } else if(protocolCategory == 'S')
            {
                switch (protocolCommand)
                {
                    case "051":
                        sb.Append(S051(tankNumber));
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


   
        //Command I201 - In Tank inventory
        private string I201(string TankNumber)
        {
            return null;
        }

        //Command I202 - In Tank delivery report
        private string I202(string TankNumber)
        {
            return null;
        }

        //Command I205 - In Tank Status Report
        private string I205(string TankNumber)
        {
            return null;
        }

        //Command I902 - Getting Software and revision version
        private string I902()
        {
            return null;
        }

        //Command S051 - Clear In Tank delivery reports
        private string S051(string TankNumber)
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
