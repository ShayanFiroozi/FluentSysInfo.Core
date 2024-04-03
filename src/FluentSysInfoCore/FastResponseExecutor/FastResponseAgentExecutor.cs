/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo.Core


---------------------------------------------------------------------------------------------*/

using FluentSysInfo.Core.Models;
using System;
using System.Threading;

namespace FluentSysInfo.Core.FastResponseExecutor
{
    public sealed partial class FastResponseAgentExecutor
    {

        private readonly ReaderWriterLockSlim SlimLock = new ReaderWriterLockSlim();

        private string result;
        private readonly FastResponseTimer ExecutionTimer;

        public string WMIClassName { get; set; }

        public event EventHandler<string> OnExecution;

        public string Result
        {
            get
            {
                try
                {

                    SlimLock.EnterReadLock();
                    return result;
                }
                finally
                {
                    SlimLock.ExitReadLock();
                }
            }

            set
            {
                try
                {
                    SlimLock.EnterWriteLock();
                    result = value;
                }
                finally
                {
                    SlimLock.ExitWriteLock();
                }
            }

        }

        public FastResponseAgentModel Agent { get; set; }



        public FastResponseAgentExecutor(FastResponseAgentModel fastResponseAgent)
        {
            if (fastResponseAgent is null)
            {
                throw new ArgumentNullException(nameof(fastResponseAgent));
            }

            ExecutionTimer = new FastResponseTimer(fastResponseAgent);
            Agent = fastResponseAgent;
            WMIClassName = fastResponseAgent.WMIClassName;
        }




        private void Timer_OnTimerExecution(object sender, string e)
        {
            // Gett the Result data from the SysInfo functions.
            Result = e;

            OnExecution?.Invoke(sender, Result);
        }


        public void StartAgent()
        {
            ExecutionTimer.OnTimerExecution += Timer_OnTimerExecution;
            ExecutionTimer.StartTimer();
        }

        public void StopAgent()
        {
            ExecutionTimer.StopTimer();
            ExecutionTimer.OnTimerExecution -= Timer_OnTimerExecution;
        }

        public bool IsRunning()
        {
            return ExecutionTimer != null && ExecutionTimer.IsRunning;
        }




    }
}
