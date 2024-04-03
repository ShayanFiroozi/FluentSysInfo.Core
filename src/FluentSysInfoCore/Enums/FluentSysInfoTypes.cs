/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo.Core


---------------------------------------------------------------------------------------------*/

namespace FluentSysInfo.Core.Enums
{
    public enum FluentSysInfoTypes : sbyte
    {
        ListAllWMIClassNames = -1,
        UserDefinedWMIClass = 0,
        DateTime = 1,
        MainBoard = 2,
        BIOS = 3,
        CPU = 4,
        PhysicalMemory = 5,
        GraphicCard = 6,
        Disk = 7,
        Drive = 8,
        Partition = 9,
        NetworkInterface = 10,
        OperatingSystem = 11,
        RunningProcesses = 12,
        InstalledServices = 13

    }

}
