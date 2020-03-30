using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace CleanUp_H1
{
    public class SystemAnalysis
    {
        //Stringbuilder for all string returned to GUI
        StringBuilder builder;
        private SystemAnalysis()
        {
        }
        private static SystemAnalysis instance = null;
        public static SystemAnalysis Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SystemAnalysis();
                }
                return instance;
            }
        }

        /// <summary>
        /// Gets total & available visible/virtual memory
        /// </summary>
        public string GetMemorySize()
        {
            builder = new StringBuilder();
            foreach (ManagementObject result in SysInformation.Instance.GetAllFromOS())
            {
                builder.AppendLine("Total Visible Memory: {0}KB" + result["TotalVisibleMemorySize"]);
                builder.AppendLine("Free Physical Memory: {0}KB" + result["FreePhysicalMemory"]);
                builder.AppendLine("Total Virtual Memory: {0}KB" + result["TotalVirtualMemorySize"]);
                builder.AppendLine("Free Virtual Memory: {0}KB" + result["FreeVirtualMemory"]);
            }
            return builder.ToString();
        }
        /// <summary>
        /// Gets how much percentage each process takes from the CPU
        /// </summary>
        /// <returns></returns>
        public string GetCPUUsage()
        {
            builder = new StringBuilder();
            foreach (ManagementObject obj in SysInformation.Instance.GetCPUUsage())
            {
                builder.AppendLine(obj["Name"].ToString() + " : " + obj["PercentProcessorTime"]);
                //Is this necessary in any way, shape or form????
                builder.AppendLine("CPU");
            }
            return builder.ToString();
        }

        /// <summary>
        /// Gets all registered users
        /// </summary>
        public string GetUsersAndOS()
        {
            builder = new StringBuilder();
            foreach (ManagementObject result in SysInformation.Instance.GetAllFromOS())
            {
                builder.AppendLine("User:\t{0}" + result["RegisteredUser"]);
                builder.AppendLine("Org.:\t{0}" + result["Organization"]);
                builder.AppendLine("O/S :\t{0}" + result["Name"]);
            }
            return builder.ToString();
        }


        /// <summary>
        /// Gets all boot devices
        /// </summary>
        public string GetBootDevices()
        {
            builder = new StringBuilder();
            //enumerate the collection.
            foreach (ManagementObject obj in SysInformation.Instance.GetBootDevices())
            {
                // access properties of the WMI object
                builder.AppendLine("BootDevice : {0}" + " " + obj["BootDevice"]);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Lists all Services
        /// </summary>
        public string ListServices()
        {
            builder = new StringBuilder();
            ManagementObjectCollection objectCollection = SysInformation.Instance.GetServices();
            builder.AppendLine("There are {0} Windows services: " + " " + objectCollection.Count);

            foreach (ManagementObject windowsService in objectCollection)
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        builder.AppendLine("Windows service property name: {0}" + " " + serviceProperty.Name);
                        builder.AppendLine("Windows service property value: {0}" + " " + serviceProperty.Value);
                    }
                }
                builder.AppendLine("---------------------------------------");
            }
            return builder.ToString();
        }
    }
}
