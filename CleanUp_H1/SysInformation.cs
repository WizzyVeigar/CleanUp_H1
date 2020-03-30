using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace CleanUp_H1
{
    /// <summary>
    /// Used for Data accessing(DAL)
    /// </summary>
    class SysInformation
    {
        private SysInformation()
        {
        }
        private static SysInformation instance = null;
        public static SysInformation Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SysInformation();
                }
                return instance;
            }
        }

        public ManagementObjectCollection GetDiskMetaData()
        {
            ManagementScope managementScope = new ManagementScope();
            ObjectQuery objectQuery = new ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            return managementObjectSearcher.Get();
        }

        public ManagementObjectCollection GetAllFromOS()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            return searcher.Get();
        }

        public string GetHardDiskSerialNumber(string driveLetter)
        {
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + driveLetter + "\"");
            managementObject.Get();
            return managementObject["VolumeSerialNumber"].ToString();
        }

        public ManagementObjectCollection GetCPUUsage()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            return searcher.Get();
        }

        public ManagementObjectCollection GetBootDevices()
        {
            //create object searcher
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\\\.\\ROOT\\cimv2", "SELECT * FROM Win32_OperatingSystem");
            return searcher.Get();
        }

        public ManagementObjectCollection GetServices()
        {
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            return windowsServicesSearcher.Get();
        }

    }
}
