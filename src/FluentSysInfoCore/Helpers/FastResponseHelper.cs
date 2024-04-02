/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo.Core


---------------------------------------------------------------------------------------------*/


using FluentSysInfo.Core.Enums;
using FluentSysInfo.Core.FastResponseExecutor;
using FluentSysInfo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

///*---------------------------------------------------------------------------------------------
namespace FluentSysInfo.Core.Helpers
{
    internal static class FastResponseManagementHelper
    {
        private static readonly ReaderWriterLockSlim SlimLock = new ReaderWriterLockSlim();

        private static readonly List<FastResponseAgentExecutor> activeAgents = new List<FastResponseAgentExecutor>();


        public static IEnumerable<FastResponseAgentExecutor> ActiveAgents
        {
            get
            {
                try
                {
                    SlimLock.EnterReadLock();
                    return activeAgents;
                }
                finally
                {
                    SlimLock.ExitReadLock();
                }
            }

        }


        public static void AddAgent(FastResponseAgentExecutor fastResponseAgent)
        {
            if (IsAgentExists(fastResponseAgent))
            {
                throw new InvalidOperationException("The Agent is already exists on the list");
            }

            try
            {
                SlimLock.EnterWriteLock();
                activeAgents.Add(fastResponseAgent);
            }
            finally
            {
                SlimLock.ExitWriteLock();
            }

        }

        public static void AddAgent(FastResponseAgentModel fastResponseAgent)
        {
            if (IsAgentExists(fastResponseAgent))
            {
                throw new InvalidOperationException("The Agent is already exists on the list");
            }

            try
            {
                SlimLock.EnterWriteLock();
                activeAgents.Add(new FastResponseAgentExecutor(fastResponseAgent));
            }
            finally
            {
                SlimLock.ExitWriteLock();
            }

        }

        public static void AddAgent(FluentSysInfoTypes fastResponseAgent, TimeSpan ExecutionInterval)
        {
            if (IsAgentExists(fastResponseAgent))
            {
                throw new InvalidOperationException("The Agent is already exists on the list");
            }

            try
            {
                SlimLock.EnterWriteLock();
                activeAgents.Add(new FastResponseAgentExecutor(new FastResponseAgentModel(fastResponseAgent, ExecutionInterval)));
            }
            finally
            {
                SlimLock.ExitWriteLock();
            }

        }


        public static void RemoveAgent(FastResponseAgentExecutor fastResponseAgent)
        {
            if (!IsAgentExists(fastResponseAgent)) return;
            try
            {
                SlimLock.EnterWriteLock();
                activeAgents.Remove(ActiveAgents.Single(a => a == fastResponseAgent));
            }
            finally
            {
                SlimLock.ExitWriteLock();
            }



        }

        public static void RemoveAgent(FastResponseAgentModel fastResponseAgent)
        {
            if (!IsAgentExists(fastResponseAgent)) return;
            try
            {
                SlimLock.EnterWriteLock();
                activeAgents.Remove(ActiveAgents.Single(a => a.Agent == fastResponseAgent));
            }
            finally
            {
                SlimLock.ExitWriteLock();
            }



        }

        public static void RemoveAgent(FluentSysInfoTypes fastResponseAgent)
        {
            if (!IsAgentExists(fastResponseAgent)) return;
            try
            {
                SlimLock.EnterWriteLock();
                StopAgent(fastResponseAgent);
                activeAgents.Remove(ActiveAgents.Single(a => a.Agent.FastResponseAgent == fastResponseAgent));
            }
            finally
            {
                SlimLock.ExitWriteLock();
            }



        }


        public static bool IsAgentExists(FastResponseAgentExecutor fastResponseAgent)
        {
            return ActiveAgents.Any(a => a == fastResponseAgent);
        }

        public static bool IsAgentExists(FastResponseAgentModel fastResponseAgent)
        {
            return ActiveAgents.Any(a => a.Agent == fastResponseAgent);
        }

        public static bool IsAgentExists(FluentSysInfoTypes fastResponseAgent)
        {
            return ActiveAgents.Any(a => a.Agent.FastResponseAgent == fastResponseAgent);
        }

        public static bool IsAgentActive(FastResponseAgentExecutor fastResponseAgent)
        {
            if (!IsAgentExists(fastResponseAgent)) return false;

            return ActiveAgents.Single(a => a == fastResponseAgent).IsRunning();
        }

        public static bool IsAgentActive(FastResponseAgentModel fastResponseAgent)
        {
            if (!IsAgentExists(fastResponseAgent)) return false;

            return ActiveAgents.Single(a => a.Agent == fastResponseAgent).IsRunning();
        }

        public static bool IsAgentActive(FluentSysInfoTypes fastResponseAgent)
        {
            if (!IsAgentExists(fastResponseAgent)) return false;

            return ActiveAgents.Single(a => a.Agent.FastResponseAgent == fastResponseAgent).IsRunning();
        }



        public static void StartAgent(FastResponseAgentExecutor fastResponseAgent)
        {
            if (!IsAgentExists(fastResponseAgent) || IsAgentActive(fastResponseAgent)) return;

            ActiveAgents.Single(a => a == fastResponseAgent).StartAgent();
        }

        public static void StartAgent(FastResponseAgentModel fastResponseAgent)
        {
            if (!IsAgentExists(fastResponseAgent) || IsAgentActive(fastResponseAgent)) return;

            ActiveAgents.Single(a => a.Agent == fastResponseAgent).StartAgent();
        }

        public static void StartAgent(FluentSysInfoTypes fastResponseAgent)
        {
            if (!IsAgentExists(fastResponseAgent) || IsAgentActive(fastResponseAgent)) return;

            ActiveAgents.Single(a => a.Agent.FastResponseAgent == fastResponseAgent).StartAgent();
        }


        public static void StopAgent(FastResponseAgentExecutor fastResponseAgent)
        {
            if (!IsAgentExists(fastResponseAgent)) return;

            ActiveAgents.Single(a => a == fastResponseAgent).StopAgent();
        }

        public static void StopAgent(FastResponseAgentModel fastResponseAgent)
        {
            if (!IsAgentExists(fastResponseAgent)) return;

            ActiveAgents.Single(a => a.Agent == fastResponseAgent).StopAgent();
        }

        public static void StopAgent(FluentSysInfoTypes fastResponseAgent)
        {
            if (!IsAgentExists(fastResponseAgent)) return;

            ActiveAgents.Single(a => a.Agent.FastResponseAgent == fastResponseAgent).StopAgent();
        }





        public static string GetAgentResult(FastResponseAgentExecutor SysInfoFastResponseAgentType)
        {
            if (!IsAgentActive(SysInfoFastResponseAgentType)) return string.Empty;

            return ActiveAgents.Single(a => a == SysInfoFastResponseAgentType).Result;
        }

        public static string GetAgentResult(FastResponseAgentModel SysInfoFastResponseAgentType)
        {
            if (!IsAgentActive(SysInfoFastResponseAgentType)) return string.Empty;

            return ActiveAgents.Single(a => a.Agent == SysInfoFastResponseAgentType).Result;
        }

        public static string GetAgentResult(FluentSysInfoTypes SysInfoFastResponseAgentType)
        {
            if (!IsAgentActive(SysInfoFastResponseAgentType)) return string.Empty;

            return ActiveAgents.Single(a => a.Agent.FastResponseAgent == SysInfoFastResponseAgentType).Result;
        }



    }
}

