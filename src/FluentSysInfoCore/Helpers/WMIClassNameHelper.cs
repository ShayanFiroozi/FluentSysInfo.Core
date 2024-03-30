/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo.Core


---------------------------------------------------------------------------------------------*/

using FluentSysInfo.Core.Models;
using System.Collections.Generic;
using System.Threading;

namespace FluentSysInfo.Core.Helpers
{
    internal static class WMIClassNameHelper
    {

        // Using Singleton behaviour !!

        private static readonly ReaderWriterLockSlim SlimLock = new ReaderWriterLockSlim();

        public static IEnumerable<SysInfoModel> WMIClassNames
        {
            get
            {
                try
                {
                    SlimLock.EnterReadLock();

                    return sysInfoWMIClassData;
                }
                finally
                {
                    SlimLock.ExitReadLock();
                }
            }
        }

        private static readonly List<SysInfoModel> sysInfoWMIClassData = new List<SysInfoModel>();


        private static void InitializeWMIClassesInfo()
        {

            sysInfoWMIClassData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.BIOS, "CIM_BIOSElement"));
            sysInfoWMIClassData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.CPU, "CIM_Processor"));
            sysInfoWMIClassData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.Disk, "CIM_DiskDrive"));
            sysInfoWMIClassData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.Drive, "win32_logicaldisk"));
            sysInfoWMIClassData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.GraphicCard, "CIM_VideoController"));
            sysInfoWMIClassData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.InstalledServices, "Win32_Service"));
            sysInfoWMIClassData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.MainBoard, "Win32_BaseBoard"));
            sysInfoWMIClassData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.NetworkInterface, "CIM_NetworkAdapter"));
            sysInfoWMIClassData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.OperatingSystem, "CIM_OPeratingSystem"));
            sysInfoWMIClassData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.Partition, "CIM_DiskPartition"));
            sysInfoWMIClassData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.PhysicalMemory, "Win32_PhysicalMemory"));
            sysInfoWMIClassData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.RunningProcesses, "CIM_Process"));
            //SysInfoData.Add(new SysInfoModel(Enums.FluentSysInfoTypes.DateTime, "Not Using WMI Class !")); // <--- No WMI Class ( Get via C# DateTime class )


        }


        static WMIClassNameHelper()
        {
            InitializeWMIClassesInfo();
        }

    }
}
