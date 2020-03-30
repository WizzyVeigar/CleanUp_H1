using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace CleanUp_H1
{
    class HardDrive
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private long freeSpace;

        public long FreeSpace
        {
            get { return freeSpace; }
            set { freeSpace = value; }
        }

        private long diskSpace;

        public long DiskSpace
        {
            get { return diskSpace; }
            set { diskSpace = value; }
        }

        private string serialNumber;


        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        public HardDrive(string name, long freeSpace, long diskSpace, string serialNumber)
        {
            Name = name;
            FreeSpace = freeSpace;
            DiskSpace = diskSpace;
            SerialNumber = serialNumber;
        }

        public override string ToString()
        {
            return "Drive Name : " + Name.First() + "\n" + "Free Space : " + FreeSpace + "\n" + "Disk Space : " + DiskSpace + "\n" + "SerialNumb : " + SerialNumber + "\n" + "-----------------------";
        }
    }
}
