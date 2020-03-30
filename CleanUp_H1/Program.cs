using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace CleanUp_H1
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (HardDrive drive in HardDriveFactory.Instance.GetHardDrives())
            {
                Console.WriteLine(drive.ToString());
            }
            Console.WriteLine(SystemAnalysis.Instance.GetCPUUsage());
            Console.WriteLine(SystemAnalysis.Instance.GetMemorySize());
            Console.WriteLine(SystemAnalysis.Instance.GetUsersAndOS());
            Console.WriteLine(SystemAnalysis.Instance.GetBootDevices());

            Console.WriteLine("process search, press enter to continue...");
            Console.ReadKey();
            Console.WriteLine(SystemAnalysis.Instance.ListServices());

            Console.ReadKey();
        }        
    }
}
