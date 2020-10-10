using System.Collections.Generic;

namespace PortVeederRootGaugeSim.IO.PortVeederRoot
{
    public class DebugPortVeederRoot
    {
        // Class essentially a datastore for debug flags
        public bool IncludeHeights { get; set; }
        public bool InvalidTankDropNumber { get; set; } 
        public bool SupportBIR { get; set; } 
        public bool VersionRespond { get; set; }
        public bool TankDropRespond { get; set; }
        public bool DateTimeRespond { get; set; }
        public bool RespondToAllProbes { get; set; }
        public bool EventAckNakRespond { get; set; }
        public bool DeliveryTankZeroBased { get; set; }
        public bool InvalidDataTerminationFlag { get; set; }
        public bool RandomizeLevels { get; set; }
        public bool ForceRndMsg { get; set; }
        public bool UpdateVolumeUsingBIR { get; set; }

        public DebugPortVeederRoot()
        {
            // Constructor builds default behaviour of the application to support normal operation
            IncludeHeights = true;
            VersionRespond = true;
            TankDropRespond = true;
            DateTimeRespond = true;
            RespondToAllProbes = true;
            InvalidTankDropNumber = false;
            SupportBIR = true;
            EventAckNakRespond = false;
            InvalidDataTerminationFlag = false;
            DeliveryTankZeroBased = false;
            UpdateVolumeUsingBIR = true;
            RandomizeLevels = false;
            ForceRndMsg = false;
        }

        private bool InvertBool(bool input)
        {
            return !input;
        }

        public Dictionary<string, bool> MenuOutput()
        {
#if ITLDEBUG
            Dictionary<string, bool> menuItems = new Dictionary<string, bool>
            {
                {"Include Heights", IncludeHeights},
                {"Invalid Drop Number", InvalidTankDropNumber},
                {"Support BIR", SupportBIR},
                {"Version Respond", VersionRespond},
                {"Tank Drop Respond", TankDropRespond},
                {"Date Time Respond", DateTimeRespond},
                {"Respond to All Probes", RespondToAllProbes},
                {"Event AckNak Respond", EventAckNakRespond},
                {"Invalid Data Termination Flag", InvalidDataTerminationFlag},
                {"Zero Based Tank Delivery", DeliveryTankZeroBased},
                {"Update Volume Using BIR", UpdateVolumeUsingBIR},
                {"Randomize Levels", RandomizeLevels},
                {"Force Rnd Msg", ForceRndMsg }
            };
#else
            Dictionary<string, bool> menuItems = new Dictionary<string, bool>
            {
                {"Invalid Drop Number", InvalidTankDropNumber},
                {"Invalid Data Termination Flag", InvalidDataTerminationFlag}
            };
#endif
            return menuItems;
        
        }

        public bool ToggleIncludeHeights()
        {
            IncludeHeights = InvertBool(IncludeHeights);
            return IncludeHeights;
        }

        public bool ToggleInvalidDropNumber()
        {
            InvalidTankDropNumber = InvertBool(InvalidTankDropNumber);
            return InvalidTankDropNumber;
        }

        public bool ToggleSupportBIR()
        {
            SupportBIR = InvertBool(SupportBIR);
            return SupportBIR;
        }

        public bool ToggleVersionRespond()
        {
            VersionRespond = InvertBool(VersionRespond);
            return VersionRespond;
        }

        public bool ToggleTankDropRespond()
        {
            TankDropRespond = InvertBool(TankDropRespond);
            return TankDropRespond;
        }

        public bool ToggleDateTimeRespond()
        {
            DateTimeRespond = InvertBool(DateTimeRespond);
            return DateTimeRespond;
        }

        public bool ToggleRespondToAllProbes()
        {
            RespondToAllProbes = InvertBool(RespondToAllProbes);
            return RespondToAllProbes;
        }

        public bool ToggleEventAckNakRespond()
        {
            EventAckNakRespond = InvertBool(EventAckNakRespond);
            return EventAckNakRespond;
        }

        public bool ToggleInvalidDataTerminationFlag()
        {
            InvalidDataTerminationFlag = InvertBool(InvalidDataTerminationFlag);
            return InvalidDataTerminationFlag;
        }

        public bool ToggleDeliveryTankZeroBased()
        {
            DeliveryTankZeroBased = InvertBool(DeliveryTankZeroBased);
            return DeliveryTankZeroBased;
        }

        public bool ToggleRandomizeLevels()
        {
            RandomizeLevels = InvertBool(RandomizeLevels);
            return RandomizeLevels;
        }

        public bool ToggleForceRndMsg()
        {
            ForceRndMsg = InvertBool(ForceRndMsg);
            return ForceRndMsg;
        }
      
        public bool ToggleUpdatevolumeUsingBIR()
        {
            UpdateVolumeUsingBIR = InvertBool(UpdateVolumeUsingBIR);
            return UpdateVolumeUsingBIR;

        }
    }
}
