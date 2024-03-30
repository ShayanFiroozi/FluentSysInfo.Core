/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo.Core


---------------------------------------------------------------------------------------------*/






using FluentSysInfo.Core.Enums;
using FluentSysInfo.Core.FastResponseExecutor;
using FluentSysInfo.Core.Helpers;
using System;
using System.Collections.Generic;

namespace FluentSysInfo.Core
{
    public sealed class FluentSysInfoCore
    {

        public string GetSystemInfo(FluentSysInfoTypes SysInfoType)
        {

            if (FastResponseManagementHelper.IsAgentActive(SysInfoType))
            {
                // Gte the system info result from the 'Fast Response Agent'  ( if is active )
                return FastResponseManagementHelper.GetAgentResult(SysInfoType);
            }
            else
            {
                // Get a fresh system information from WMI class via executing a powershell command 👇
                return new WMISysInfoHelper().GetSysInfo(SysInfoType);
            }
        }


        public void AddFastResponseAgent(FluentSysInfoTypes fastResponseAgent, TimeSpan ExecutionInterval)
        {
            FastResponseManagementHelper.AddAgent(fastResponseAgent, ExecutionInterval);
        }


        public void RemoveFastResponseAgent(FluentSysInfoTypes fastResponseAgent)
        {
            FastResponseManagementHelper.RemoveAgent(fastResponseAgent);
        }


        public void StartFastResponseAgent(FluentSysInfoTypes fastResponseAgent)
        {
            FastResponseManagementHelper.StartAgent(fastResponseAgent);
        }


        public void StopFastResponseAgent(FluentSysInfoTypes fastResponseAgent)
        {
            FastResponseManagementHelper.StopAgent(fastResponseAgent);
        }


        public void StartAllFastResponseAgents()
        {
            foreach (FastResponseAgentExecutor Agent in FastResponseManagementHelper.ActiveAgents)
            {
                FastResponseManagementHelper.StartAgent(Agent);
            }

        }

        public void StopAllFastResponseAgents()
        {
            foreach (FastResponseAgentExecutor Agent in FastResponseManagementHelper.ActiveAgents)
            {
                FastResponseManagementHelper.StopAgent(Agent);
            }

        }


        public IEnumerable<FastResponseAgentExecutor> ActiveAgents => FastResponseManagementHelper.ActiveAgents; //.Select(a => a.Agent);

    }
}
