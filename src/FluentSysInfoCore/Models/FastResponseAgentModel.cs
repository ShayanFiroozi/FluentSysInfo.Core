/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo.Core


---------------------------------------------------------------------------------------------*/


using FluentSysInfo.Core.Enums;
using System;

namespace FluentSysInfo.Core.Models
{
    public sealed class FastResponseAgentModel
    {
        public FluentSysInfoTypes FastResponseAgent { get; set; }
        public TimeSpan ExecutionInterval { get; set; }


        public FastResponseAgentModel(FluentSysInfoTypes fastResponseAgent,
                                      TimeSpan executionInterval)
        {
            FastResponseAgent = fastResponseAgent;
            ExecutionInterval = executionInterval;
        }



    }
}
