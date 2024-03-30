<p align="center">
 <img src="https://github.com/ShayanFiroozi/FluentSysInfo.Core/blob/master/Icon.ico"
</p>

# FluentSysInfo.Core <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/> <img src="https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white"/>
![with-coffee](https://img.shields.io/badge/made%20with-%E2%98%95%EF%B8%8F%20coffee-yellow.svg)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=bugs)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![GitHub License](https://img.shields.io/github/license/ShayanFiroozi/FluentSysInfo.Core)](https://github.com/ShayanFiroozi/FluentSysInfo.Core/blob/master/LICENSE.md)
 
**FluentSysInfo.Core** Provides the accessibility to the various System Informations.

✔ FluentSysInfo.Core uses [FastLog.Net](https://github.com/ShayanFiroozi/FastLog.Net) , Ultra Fast and High performance logger for .NET 💯 

<br/>

## Features 💯
 **FluentSysInfo.Core features :**
 * **Supported System Information :**  
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

  
 
## Contributions 🤝
Since this is a new repository , there's no contributor yet! But **FluentSysInfo.Core** welcomes and appreciates any contribution , pull request or bug report.

 


<br/>
 
## How To Use ❔
It's really simple to call the **FluentSysInfo.Core** WebAPI :
 - Example for the Date Time : ⬇
<p align="center">
<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"
</p>
 
 ```csharp
            string ServerSecteyKey = "FluentSysInfoSecretKeyXXX";
            string TargetUrl = $"http://localhost:54800/api/SysInfo/GetDateTimeInfo/{ServerSecteyKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(TargetUrl);

                string result = await response.Content.ReadAsStringAsync();

                Console.WriteLine(result);

            }

            Console.ReadLine();

```   

And the result from the **FluentSysInfo.Core** would be something like this :  
<p align="center">
<img src="https://img.shields.io/badge/json-5E5C5C?style=for-the-badge&logo=json&logoColor=white"
</p>
 
```json
{
  "DateTime": "3/19/2024 3:51:49 PM",
  "DateTimeUTC": "3/19/2024 12:21:49 PM",
  "DateOnly": "3/19/2024",
  "TimeOnly": "3:51:49 PM",
  "LongDate": "Tuesday, March 19, 2024",
  "FullDateTime": "Tuesday, March 19, 2024  3:51:49 PM"
}
```

- Example for the OS Info : ⬇
<p align="center">
<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"
</p>
 
 ```csharp
            string ServerSecteyKey = "FluentSysInfoSecretKeyXXX";
            string TargetUrl = $"http://localhost:54800/api/SysInfo/GetOsInfo/{ServerSecteyKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(TargetUrl);

                string result = await response.Content.ReadAsStringAsync();

                Console.WriteLine(result);

            }

            Console.ReadLine();

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


> :information_source: 
**FluentSysInfo.Core** settings can be easily changed via [Service Settings File](https://github.com/ShayanFiroozi/FluentSysInfo.Core/blob/master/Settings/ServiceSettings.json).  
    
> :warning: 
It is recommended to keep the **UseAuthentication** setting enable to prevent unwanted access to the target machine information.

<br/>

    
### Available APIs : 
* **Date And Time Info -> /api/SysInfo/GetDateTimeInfo**
* **OS Info -> /api/SysInfo/GetOsInfo**
* **CPU Info -> /api/SysInfo/GetCpuInfo**
* **Mother Board Info -> /api/SysInfo/GetMotherBoardInfo**
* **BIOS Info -> /api/SysInfo/GetBiosInfo**
* **Physical Memory Info -> /api/SysInfo/GetPhysicalMemoryInfo**
* **Running Processes Info -> /api/SysInfo/GetRunningProcessesInfo**
* **Windows Services Info -> /api/SysInfo/GetWindowsServicesInfo**
* **Graphic Card Info -> /api/SysInfo/GetGraphicCardInfo**
* **Network Interface(s) Info -> /api/SysInfo/GetNetworkInterfaceInfo**
* **Disk(s) Info -> /api/SysInfo/GetDiskInfo**
* **Disk's Partition(s) Info -> /api/SysInfo/GetPartitionInfo**
* **Logical Drive(s) Info -> /api/SysInfo/GetDriveInfo**


  

<br/>  
  
> :warning:  If **UseAuthentication** settings is enable the secret key should be sent by each **Get** request.


> :information_source: **Example With Authentication** : http://localhost:54800/api/SysInfo/GetDateTimeInfo/FluentSysInfoSecretKeyXXX
<br/>


> :information_source: **Example Without Authentication** : http://localhost:54800/api/SysInfo/GetOsInfo
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
  
Use **Visual Studio 2022** and open the solution 'FluentSysInfo.Core.sln'.

**FluentSysInfo.Core** solution is setup to support following .Net versions :

- .Net Core 8.0
- .Net Core 7.0
- .Net Core 6.0
- .Net Framework 4.8


> **Note**:  
Since the **FluentSysInfo.Core** solution is supporting multi target frameworks , to build the solution successfully you should install all .Net versions above , otherwise you can easily exclude not interested framework(s) by editing **TargetFrameworks** tag in the [FluentSysInfo.Core Project File](https://github.com/ShayanFiroozi/FluentSysInfo.Core/blob/master/FluentSysInfo.Core.csproj).

<br/>
 
## Buy me a coffee for more coding effort ! ☕
![BuyMeACoffee](https://img.shields.io/badge/Buy%20Me%20a%20Coffee-ffdd00?style=for-the-badge&logo=buy-me-a-coffee&logoColor=black) <img src="https://img.shields.io/badge/Bitcoin-000000?style=for-the-badge&logo=bitcoin&logoColor=white"/> <img src="https://img.shields.io/badge/tether-168363?style=for-the-badge&logo=tether&logoColor=white"/> <img src="https://img.shields.io/badge/dogecoin-C2A633?style=for-the-badge&logo=dogecoin&logoColor=white"/> <img src="https://img.shields.io/badge/Ethereum-3C3C3D?style=for-the-badge&logo=Ethereum&logoColor=white"/>
 
If you would like to financially support **FluentSysInfo.Core**, first of all, thank you! Please read [**DONATIONS**](DONATIONS.md) for my crypto wallets !

<br/>
 
## Version History 🕙
Please read [**CHANGELOG**](CHANGELOG.md) for more and track changing details.
