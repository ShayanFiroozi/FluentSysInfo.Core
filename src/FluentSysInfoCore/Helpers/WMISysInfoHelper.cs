/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo.Core


---------------------------------------------------------------------------------------------*/


using FluentSysInfo.Core.Enums;
using System.Linq;

namespace FluentSysInfo.Core.Helpers
{
    public sealed class WMISysInfoHelper
    {
        private const string PowerShellCommandPattern = "Get-CimInstance -Class {TargetClassName} -ErrorAction Stop | Select-Object *";


        public string GetSysInfo(FluentSysInfoTypes SysInfoType)
        {
            if (SysInfoType <= 0)
            {
                throw new System.ArgumentException($"'{nameof(SysInfoType)}' is not supported.", nameof(SysInfoType));
            }

            // DateTime use the C# internal 'DateTime' class to get the data not WMI class 
            if (SysInfoType == FluentSysInfoTypes.DateTime)
            {
                return new GetDateTimeHelper().GetInfo();
            }
            else // Others will use 'WMI Classes' via 'PowreShell'
            {

                // Get the target WMI Class name from related 'SysInfoType' argument
                string targetWMIClassName = WMIClassNameHelper.WMIClassNames.Single(t => t.SysInfoType == SysInfoType).RelatedWMIClassName;

                return GetUserDefinedWMIClassSysInfo(targetWMIClassName);
            }
        }



        public string GetUserDefinedWMIClassSysInfo(string WMIClassName)
        {

            if (string.IsNullOrEmpty(WMIClassName))
            {
                throw new System.ArgumentException("Invalid or Unsupported class name.");
            }

            return new PowerShellHelper()
                         .GetPowerShellCommandResultAsync(PowerShellCommandPattern.Replace("{TargetClassName}", WMIClassName), true);
        }


    }

}

