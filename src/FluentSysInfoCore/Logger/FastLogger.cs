/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo.Core


---------------------------------------------------------------------------------------------*/

using FastLog.Core;
using FastLog.Internal;
using System.IO;

namespace FluentSysInfo.Core
{
    internal static class FastLogger
    {

        internal static Logger logger { get; private set; }

        internal static void InitializeLogger(string LogPath)
        {


            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }


            InternalLogger internalLogger = InternalLogger.Create()
                                                          .UseJsonFormat()
                                                          .SaveInternalEventsToFile(Path.Combine(LogPath, "Logs", "InternalEventsLogs.log"))
                                                          .DeleteTheLogFileWhenExceededTheMaximumSizeOf(10);


            ConfigManager loggerConfig = ConfigManager.Create()
                                      .WithLoggerName($"FluentSysInfo LoggerAgent");


            logger = Logger.Create()
                      .WithInternalLogger(internalLogger)
                      .WithConfiguration(loggerConfig)
                      .WithAgents()


                         // Add a "TextFile Agent" with Json format and will be re-created when reached to 50 megabytes.
                         .AddTextFileAgent()
                          .UseJsonFormat()
                          .SaveLogToFile(Path.Combine(LogPath, "Logs", "FluentSysInfoLog.log"))
                          .DeleteTheLogFileWhenExceededTheMaximumSizeOf(50)
                         .BuildAgent()

                         .AddConsoleAgent()
                         .BuildAgent()

                       // And Finally build the logger.
                       .BuildLogger();


            // Start the FastLog.Net engine in the background.
            logger.StartLogger();


        }

        internal static void StopLogger()
        {
            if (logger != null)
            {
                // Ensure the last log(s) in the list have been processed before stopping the logger engine.
                logger.ProcessAllEventsInQueue().GetAwaiter().GetResult();

                logger.StopLogger();
            }
        }


    }

}

