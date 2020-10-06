using System;
using System.Collections.Generic;

namespace PortVeederRootGaugeSim.IO.PortVeederRoot
{
    class DebugPortVeederRoot
    {
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
        }

        private bool InvertBool(bool input)
        {
            return !input;
        }

        public Dictionary<string, Func<bool>> MenuOutput()
        {

            Dictionary<string, Func<bool>> menuItems = new Dictionary<string, Func<bool>>();

            menuItems.Add("Include Heights", ToggleIncludeHeights);
            menuItems.Add("Invalid Drop Number", ToggleInvalidDropNumber);
            menuItems.Add("Support BIR", ToggleSupportBIR);
            menuItems.Add("Version Respond", ToggleVersionRespond);
            menuItems.Add("Tank Drop Respond", ToggleTankDropRespond);
            menuItems.Add("Date Time Respond", ToggleDateTimeRespond);
            menuItems.Add("Respond to All Probes", ToggleRespondToAllProbes);
            menuItems.Add("Invalid Data Termination Flag", ToggleInvalidDataTerminationFlag);
            menuItems.Add("Zero Based Tank Delivery", ToggleDeliveryTankZeroBased);
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
            //TODO support BIR logic
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
    }
}
