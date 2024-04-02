using FluentSysInfo.Core;
using FluentSysInfo.Core.Enums;
using System;
using System.Threading.Tasks;

namespace FluentSysInfoTest
{
    internal static class Program
    {

        

        static async Task Main(string[] args)
        {

            // Example with custrom WMI Class Name
            Console.WriteLine(new FluentSysInfoCore().GetSystemInfo("CIM_Display"));

            Console.WriteLine("Initializing the 'Fast Response Agent(s)'....");

            await Task.Run(() =>
            {

                FluentSysInfoCore fluentSysInfoCore = new FluentSysInfoCore();

                fluentSysInfoCore.AddFastResponseAgent(FluentSysInfoTypes.InstalledServices, TimeSpan.FromSeconds(5));
                fluentSysInfoCore.AddFastResponseAgent(FluentSysInfoTypes.RunningProcesses, TimeSpan.FromSeconds(5));
                fluentSysInfoCore.AddFastResponseAgent(FluentSysInfoTypes.Disk, TimeSpan.FromSeconds(5));
                fluentSysInfoCore.AddFastResponseAgent(FluentSysInfoTypes.Drive, TimeSpan.FromSeconds(5));
                fluentSysInfoCore.AddFastResponseAgent(FluentSysInfoTypes.NetworkInterface, TimeSpan.FromSeconds(5));
                fluentSysInfoCore.AddFastResponseAgent(FluentSysInfoTypes.PhysicalMemory, TimeSpan.FromSeconds(5));



                fluentSysInfoCore.StartAllFastResponseAgents();

            });

            Console.WriteLine("'Fast Response Agent(s)' have been initialized.");

            await Task.Delay(2_000);



            FluentSysInfoCore fluentSysInfoCore2 = new FluentSysInfoCore();

            for (int i = 0; i < 2_000; i++)
            {

                Console.WriteLine(fluentSysInfoCore2.GetSystemInfo(FluentSysInfoTypes.InstalledServices));
                Console.WriteLine(fluentSysInfoCore2.GetSystemInfo(FluentSysInfoTypes.RunningProcesses));
                Console.WriteLine(fluentSysInfoCore2.GetSystemInfo(FluentSysInfoTypes.Disk));
                Console.WriteLine(fluentSysInfoCore2.GetSystemInfo(FluentSysInfoTypes.Drive));
                Console.WriteLine(fluentSysInfoCore2.GetSystemInfo(FluentSysInfoTypes.PhysicalMemory));

            }

            Console.WriteLine("All Fisnihed !");

            Console.ReadLine();

        }


    }
}
