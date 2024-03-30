/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo.Core


---------------------------------------------------------------------------------------------*/

using System;
using System.Diagnostics;

namespace FluentSysInfo.Core.Helpers
{

    internal sealed class PowerShellHelper
    {

        internal string GetPowerShellCommandResultAsync(string command, bool AsJSON)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = "powershell.exe";
                processStartInfo.Arguments = $"-Command \"{command}\"";
                processStartInfo.UseShellExecute = false;
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processStartInfo.ErrorDialog = false;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.Verb = "runas"; // run as administrator



                using (Process process = new Process())
                {
                    process.StartInfo = processStartInfo;
                    process.Start();

                    string result = process.StandardOutput.ReadToEnd();

                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        return AsJSON ? new JsonHelper().ConvertPowerShellResultToJSON(result) : result;
                    }
                    else
                    {
                        return string.Empty;
                    }

                }
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }




    }


}
