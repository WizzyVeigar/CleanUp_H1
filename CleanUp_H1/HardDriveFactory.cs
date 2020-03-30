using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace CleanUp_H1
{
    class HardDriveFactory
    {
        private HardDriveFactory()
        {
        }
        private static HardDriveFactory instance = null;
        public static HardDriveFactory Instance
        { 
            get
            {
                if (instance == null)
                {
                    instance = new HardDriveFactory();
                }
                return instance;
            }
        }

        public List<HardDrive> GetHardDrives()
        {
            return GetDiskMetadata();
        }

        /// <summary>
        /// Collects information to harddrives and adds them to a list
        /// </summary>
        /// <returns></returns>
        private List<HardDrive> GetDiskMetadata()
        {
            List<HardDrive> drives = new List<HardDrive>();

            foreach (ManagementObject managementObject in SysInformation.Instance.GetDiskMetaData())
            {
                HardDrive drive = new HardDrive(managementObject["Name"].ToString(), managementObject["FreeSpace"].ToString(), managementObject["Size"].ToString(), GetHardDiskSerialNumber(managementObject["Name"].ToString()));
                drives.Add(drive);
            }

            return drives;
        }

        /// <summary>
        /// Gets <paramref name="drive"/>'s serial number
        /// </summary>
        /// <param name="drive"></param>
        /// <returns></returns>
        public string GetHardDiskSerialNumber(string drive)
        {
            return SysInformation.Instance.GetHardDiskSerialNumber(drive);
        }
    }
}
