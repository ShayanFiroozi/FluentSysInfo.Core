/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo.Core


---------------------------------------------------------------------------------------------*/

using FluentSysInfo.Core.Enums;
using FluentSysInfo.Core.Helpers;
using FluentSysInfo.Core.Models;
using System;
using System.Timers;

namespace FluentSysInfo.Core.FastResponseExecutor
{
    public sealed partial class FastResponseAgentExecutor
    {

        private sealed class FastResponseTimer
        {
            private Timer Timer;
            private readonly double Interval;
            private readonly FluentSysInfoTypes SysInfoType;
            private readonly string WMIClassName;
            internal event EventHandler<string> OnTimerExecution;

            internal bool IsRunning
            {
                get
                {
                    if (Timer == null) return false;
                    return Timer.Enabled;
                }

            }

            internal FastResponseTimer(FastResponseAgentModel fastResponseAgent)
            {
                if (fastResponseAgent is null)
                {
                    throw new ArgumentNullException(nameof(fastResponseAgent));
                }

                if (fastResponseAgent.FastResponseAgent == FluentSysInfoTypes.DateTime)
                {
                    throw new ArgumentOutOfRangeException(nameof(fastResponseAgent), "Not supported agent.");
                }

                Interval = fastResponseAgent.ExecutionInterval.TotalMilliseconds;

                if (fastResponseAgent.FastResponseAgent != FluentSysInfoTypes.UserDefinedWMIClass)
                {
                    SysInfoType = fastResponseAgent.FastResponseAgent;
                }
                else
                {
                    WMIClassName = fastResponseAgent.WMIClassName;
                }

            }


            internal FastResponseTimer(string WMIClassName, TimeSpan ExecutionInterval)
            {
                if (string.IsNullOrWhiteSpace(WMIClassName))
                {
                    throw new ArgumentException($"'{nameof(WMIClassName)}' cannot be null or whitespace.", nameof(WMIClassName));
                }

                Interval = ExecutionInterval.TotalMilliseconds;
                SysInfoType = FluentSysInfoTypes.UserDefinedWMIClass; // User-Defined ClassName
                this.WMIClassName = WMIClassName;

            }


            internal void StartTimer()
            {
                Timer = new Timer(Interval);


                Timer.Elapsed += Timer_Elapsed;
                Timer.Enabled = true;
                Timer.AutoReset = true;
                Timer.Start();

                // Call the T.GetInfo() for the first time
                Timer_Elapsed(null, null);
            }


            private void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                OnTimerExecution?.Invoke(sender,
                                         SysInfoType != FluentSysInfoTypes.UserDefinedWMIClass ?
                                         new WmiSysInfoHelper().GetSysInfo(SysInfoType) :
                                         new WmiSysInfoHelper().GetSysInfo(WMIClassName));

            }


            internal void StopTimer()
            {
                Timer.Enabled = false;
                Timer.Stop();
            }


        }


    }
}
