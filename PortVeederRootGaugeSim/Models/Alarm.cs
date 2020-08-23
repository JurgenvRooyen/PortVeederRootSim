namespace PortVeederRootGaugeSim
{
    public class Alarm
    {

        public int Count { get; set; }
        public string AlarmString { get; set; }

        public Alarm(int count, string alarmString)
        {
            Count = count;
            AlarmString = alarmString;
        }
    }
}