<p align="center">
 <img src="https://github.com/ShayanFiroozi/FluentSysInfo.Core/blob/master/src/FluentSysInfoCore/Icon.ico"
</p>

# FluentSysInfo.Core <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/> <img src="https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white"/>
[![with-coffee](https://img.shields.io/badge/made%20with-%E2%98%95%EF%B8%8F%20coffee-yellow.svg)](https://github.com/ShayanFiroozi/FluentSysInfo.Core/tree/master?tab=readme-ov-file#buy-me-a-coffee-for-more-coding-effort--)
[![Nuget](https://img.shields.io/nuget/v/FluentSysInfo.Core)](https://www.nuget.org/packages/FluentSysInfo.Core/#readme-body-tab)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo.Core&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo.Core)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo.Core&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo.Core)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo.Core&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo.Core)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo.Core&metric=bugs)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo.Core)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo.Core&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo.Core)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo.Core&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo.Core)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo.Core&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo.Core)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo.Core&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo.Core)
[![GitHub License](https://img.shields.io/github/license/ShayanFiroozi/FluentSysInfo.Core)](https://github.com/ShayanFiroozi/FluentSysInfo.Core/blob/master/LICENSE.md)
 
**FluentSysInfo.Core** Provides the accessibility to the various System Informations.

<br/>


  
 
## Whats is special about **FluentSysInfo** ? 👍
**FluentSysInfo** uses an internal caching machanism called **'Fast Response'**.<br/><br/>
Getting the System Information could be a **huge I/O** load and makes your app slow ! Specially when your are requesting a Disk , Partition , CPU information , Running Processes , Installed Services or etc ...<br/><br/>
The **Fast Response** feature is designed to deliver the information almost **immediately** after requesting a system infomation 👌
    
 <br/>  


## Features 💯
 **Supported System Information :**
 <br/>  
    ✔ Date Time Info  
    ✔ OS Info  
    ✔ Main Board Info  
    ✔ BIOS Info  
    ✔ CPU Info  
    ✔ Physical Memory Info  
    ✔ Disk , Partition And Drive Info  
    ✔ Network Interfaces Info  
    ✔ Graphic Card Info  
    ✔ Running Processes Info  
    ✔ Windows Services Info  
    



<br/>
 
## How To Use ❔
It's really simple to use the **FluentSysInfo.Core** :

 <br/>
 
- **Example for the Physical Memory (RAM) Info** ⬇
<p align="center">
<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"
</p>
 
 ```csharp

Console.WriteLine(new FluentSysInfoCore().GetSystemInfo(FluentSysInfoTypes.PhysicalMemory));

```   

And the result from the **FluentSysInfo.Core** would be something like this :  
<p align="center">
<img src="https://img.shields.io/badge/json-5E5C5C?style=for-the-badge&logo=json&logoColor=white"
</p>
 
```json
{
 "Caption": "Physical Memory",
 "Description": "Physical Memory",
 "Name": "Physical Memory",
 "Manufacturer": "04CB",
 "SerialNumber": "2B960400",
 "Tag": "Physical Memory 0",
 "FormFactor": "8",
 "BankLabel": "BANK 0",
 "Capacity": "8589934592",
 "DataWidth": "64",
 "InterleavePosition": "0",
 "MemoryType": "0",
 "Speed": "2133",
 "TotalWidth": "64",
 "Attributes": "2",
 "ConfiguredClockSpeed": "2133",
 "ConfiguredVoltage": "1200",
 "DeviceLocator": "ChannelA-DIMM0",
 "InterleaveDataDepth": "0",
 "MaxVoltage": "1200",
 "MinVoltage": "1200",
 "SMBIOSMemoryType": "26",
 "TypeDetail": "128"
}
{
 "Caption": "Physical Memory",
 "Description": "Physical Memory",
 "Name": "Physical Memory",
 "Manufacturer": "04CB",
 "SerialNumber": "55960400",
 "Tag": "Physical Memory 1",
 "FormFactor": "8",
 "BankLabel": "BANK 1",
 "Capacity": "8589934592",
 "DataWidth": "64",
 "InterleavePosition": "0",
 "MemoryType": "0",
 "Speed": "2133",
 "TotalWidth": "64",
 "Attributes": "2",
 "ConfiguredClockSpeed": "2133",
 "ConfiguredVoltage": "1200",
 "DeviceLocator": "ChannelA-DIMM1",
 "InterleaveDataDepth": "0",
 "MaxVoltage": "1200",
 "MinVoltage": "1200",
 "SMBIOSMemoryType": "26",
 "TypeDetail": "128"
}
```

 <br/>
 
- **Example for the OS Info** ⬇
<p align="center">
<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"
</p>
 
 ```csharp

  Console.WriteLine(new FluentSysInfoCore().GetSystemInfo(FluentSysInfoTypes.OperatingSystem));

```   

And the result from the **FluentSysInfo.Core** would be something like this :  
<p align="center">
<img src="https://img.shields.io/badge/json-5E5C5C?style=for-the-badge&logo=json&logoColor=white"
</p>
 
```json
{
 "Status": "OK",
 "Name": "Microsoft Windows 10 Enterprise|C:\\Windows|\\Device\\Harddisk1\\Partition3",
 "FreePhysicalMemory": "9428600",
 "FreeSpaceInPagingFiles": "2479588",
 "FreeVirtualMemory": "9278148",
 "Caption": "Microsoft Windows 10 Enterprise",
 "Description": "Removed! 😎",
 "InstallDate": "9/30/2022 1:36:54 PM",
 "CSName": "Removed! 😉",
 "CurrentTimeZone": "210",
 "Distributed": "False",
 "LastBootUpTime": "3/21/2024 6:56:09 AM",
 "LocalDateTime": "3/21/2024 11:39:42 PM",
 "MaxNumberOfProcesses": "4294967295",
 "MaxProcessMemorySize": "137438953344",
 "NumberOfLicensedUsers": "0",
 "NumberOfProcesses": "222",
 "NumberOfUsers": "2",
 "OSType": "18",
 "SizeStoredInPagingFiles": "2490368",
 "TotalVirtualMemorySize": "19224724",
 "TotalVisibleMemorySize": "16734356",
 "Version": "10.0.19045",
 "BootDevice": "\\Device\\HarddiskVolume10",
 "BuildNumber": "19045",
 "BuildType": "Multiprocessor Free",
 "CodeSet": "1252",
 "CountryCode": "1",
 "DataExecutionPrevention_32BitApplications": "True",
 "DataExecutionPrevention_Available": "True",
 "DataExecutionPrevention_Drivers": "True",
 "DataExecutionPrevention_SupportPolicy": "2",
 "Debug": "False",
 "EncryptionLevel": "256",
 "ForegroundApplicationBoost": "2",
 "Locale": "0409",
 "Manufacturer": "Microsoft Corporation",
 "MUILanguages": "{en-US}",
 "OperatingSystemSKU": "4",
 "OSArchitecture": "64-bit",
 "OSLanguage": "1033",
 "OSProductSuite": "256",
 "PortableOperatingSystem": "False",
 "Primary": "True",
 "ProductType": "1",
 "RegisteredUser": "Shayan",
 "SerialNumber": "00329-00000-00003-AA310",
 "ServicePackMajorVersion": "0",
 "ServicePackMinorVersion": "0",
 "SuiteMask": "272",
 "SystemDevice": "\\Device\\HarddiskVolume12",
 "SystemDirectory": "C:\\Windows\\system32",
 "SystemDrive": "C:",
 "WindowsDirectory": "C:\\Windows"
}
```

<br/>

- **How to enable the Fast Response feature ?** ⬇
<p align="center">
<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"
</p>
 
 ```csharp

  FluentSysInfoCore fluentSysInfoCore = new FluentSysInfoCore();

  fluentSysInfoCore.AddFastResponseAgent(FluentSysInfoTypes.InstalledServices, TimeSpan.FromSeconds(5));
  fluentSysInfoCore.AddFastResponseAgent(FluentSysInfoTypes.RunningProcesses, TimeSpan.FromSeconds(5));
  fluentSysInfoCore.AddFastResponseAgent("CIM_Display", TimeSpan.FromSeconds(5));

  fluentSysInfoCore.StartAllFastResponseAgents();

```   

<br/>



- **How to use a custom WMI class name ?** ⬇
<p align="center">
<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"
</p>
 
 ```csharp

  Console.WriteLine(new FluentSysInfoCore().GetSystemInfo("CIM_Display"));

```   

And the result from the **FluentSysInfo.Core** would be something like this :  
<p align="center">
<img src="https://img.shields.io/badge/json-5E5C5C?style=for-the-badge&logo=json&logoColor=white"
</p>
 
```json
{
 "DeviceID": "DesktopMonitor1",
 "Name": "HP EliteDisplay E221 LED Backlit Monitor",
 "PixelsPerXLogicalInch": "96",
 "PixelsPerYLogicalInch": "96",
 "Status": "OK",
 "Caption": "HP EliteDisplay E221 LED Backlit Monitor",
 "Description": "HP EliteDisplay E221 LED Backlit Monitor",
 "Availability": "8",
 "ConfigManagerErrorCode": "0",
 "ConfigManagerUserConfig": "False",
 "PNPDeviceID": "DISPLAY\\HWP3061\\5&132B4D04&0&UID4352",
 "SystemName": "Removed! 🤘",
 "MonitorManufacturer": "HP",
 "MonitorType": "HP EliteDisplay E221 LED Backlit Monitor"
}
```

<br/>
 
## Known Issues ‼ 
 **Not Reported Yet!** 😎

<br/>
 
 ## © License
**FluentSysInfo.Core** is an open source software, licensed under the terms of MIT license.
See [**LICENSE**](LICENSE.md) for more details.

<br/>
 
## 🛠 How to build
<p align="center">
<img src="https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white"
</p>
  
Use **Visual Studio 2022** and open the solution file **FluentSysInfo.Core.sln**

**FluentSysInfo.Core** solution is setup to support following .Net versions :

- .Net Core 8.0
- .Net Core 7.0
- .Net Core 6.0
- .Net Framework 4.8


> **Note**:  
Since the **FluentSysInfo.Core** solution is supporting multi target frameworks , to build the solution successfully you should install all .Net versions above , otherwise you can easily exclude not interested framework(s) by editing **TargetFrameworks** tag in the [FluentSysInfo.Core Project File](https://github.com/ShayanFiroozi/FluentSysInfo.Core/blob/master/src/FluentSysInfoCore/FluentSysInfo.Core.csproj).

<br/>

   
 
## Contributions 🤝
Since this is a new repository , there's no contributor yet! But **FluentSysInfo.Core** welcomes and appreciates any contribution , pull request or bug report.

<br/>  
   
 
## Buy me a coffee for more coding effort ! ☕
[![BuyMeACoffee](https://img.shields.io/badge/Buy%20Me%20a%20Coffee-ffdd00?style=for-the-badge&logo=buy-me-a-coffee&logoColor=black)](https://github.com/ShayanFiroozi/FluentSysInfo.Core/blob/master/DONATIONS.md) <a href="https://github.com/ShayanFiroozi/FluentSysInfo.Core/blob/master/DONATIONS.md"><img src="https://img.shields.io/badge/Bitcoin-000000?style=for-the-badge&logo=bitcoin&logoColor=white"/></a><a href="https://github.com/ShayanFiroozi/FluentSysInfo.Core/blob/master/DONATIONS.md"><img src="https://img.shields.io/badge/tether-168363?style=for-the-badge&logo=tether&logoColor=white"/></a><a href="https://github.com/ShayanFiroozi/FluentSysInfo.Core/blob/master/DONATIONS.md"><img src="https://img.shields.io/badge/dogecoin-C2A633?style=for-the-badge&logo=dogecoin&logoColor=white"/></a> <a href="https://github.com/ShayanFiroozi/FluentSysInfo.Core/blob/master/DONATIONS.md"><img src="https://img.shields.io/badge/Ethereum-3C3C3D?style=for-the-badge&logo=Ethereum&logoColor=white"/></a>
 
If you would like to financially support **FluentSysInfo.Core**, first of all, thank you! Please read [**DONATIONS**](DONATIONS.md) for my crypto wallets !

<br/>
 
## Version History 🕙
Please read [**CHANGELOG**](CHANGELOG.md) for more and track changing details.
