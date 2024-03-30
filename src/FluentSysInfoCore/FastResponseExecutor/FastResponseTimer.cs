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

        internal sealed class FastResponseTimer
        {
            private Timer Timer;

            private readonly double Interval;
            private readonly FluentSysInfoTypes SysInfoType;
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

                if (fastResponseAgent.FastResponseAgent == 0 || fastResponseAgent.FastResponseAgent == FluentSysInfoTypes.DateTime)
                {
                    throw new ArgumentException($"'{nameof(fastResponseAgent.FastResponseAgent)}' is not supported.", nameof(fastResponseAgent.FastResponseAgent));
                }

                Interval = fastResponseAgent.ExecutionInterval.TotalMilliseconds;
                SysInfoType = fastResponseAgent.FastResponseAgent;

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
                OnTimerExecution?.Invoke(sender, new WmiSysInfoHelper().GetSysInfo(SysInfoType));

            }


            internal void StopTimer()
            {
                Timer.Enabled = false;
                Timer.Stop();
            }


        }


    }
}
