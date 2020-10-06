using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PortVeederRootGaugeSim
{
    [Serializable]
    public class RootSim
    {
        // need to be changed after things are done 
        private const string SoftWareVersion = "612760-100";
        public string GetSoftWareVersion()
        {
            string temp = SoftWareVersion;
            return temp;
        }

        // need to be changed after things are done 
        private const string SoftWareRevision = "001";
        public string GetSoftWareRevision()
        {
            string temp = SoftWareRevision;
            return temp;
        }
        // DateTime can not be const and need to be changed after things are done 
        private string CreationDate = "20.09.08.12.01";
        public string GetCreationDate()
        {
            return CreationDate;
        }

        public List<TankProbe> TankProbeList { get; set; }
        public TimeSpan SystemTime { get; set; }

        public RootSim()
        {
            TankProbeList = new List<TankProbe>();
            SystemTime = new TimeSpan();
        }

        public RootSim(List<TankProbe> tankProbeList, TimeSpan systemTime)
        {
            TankProbeList = tankProbeList;
            SystemTime = systemTime;
        }

        public void AddTankProbe(TankProbe t)
        {
            TankProbeList.Add(t);
        }

        public void RemoveTankProbe(int tankId)
        {
            for (int i = 0; i < TankProbeList.Count; i++)
            {
                if (TankProbeList[i].TankProbeId == tankId)
                {
                    TankProbeList.Remove(TankProbeList[i]);
                }
            }
        }

        public void LoadFile(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            else
            {
                this.TankProbeList.Clear();
                Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    List<TankProbe> newList = (List<TankProbe>)formatter.Deserialize(stream);
                    foreach (TankProbe tank in newList)
                    {
                        this.AddTankProbe(tank);
                    }
                }
                catch (Exception e) 
                { 
                    Console.WriteLine(e);
                }
                stream.Close();
            }
        }

        public void SaveFile(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.CreateNew);
            formatter.Serialize(stream, this.TankProbeList);
            stream.Close();
        }
    }
}

