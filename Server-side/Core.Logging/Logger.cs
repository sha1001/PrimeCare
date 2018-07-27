// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file= Logger.cs company="Perimatics Inc.">
// //   Copyright (C) 2018 Perimatics Inc. All rights reserved.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using Serilog;

namespace Core.Logging
{
    public class Logger : ILogger
    {
        /// <summary>
        ///     The logger
        /// </summary>
        private Serilog.ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Logger(LogConfiguration configuration)
        {
            InitializeLogger(configuration);
        }

        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public void LogInformation(string logMessage)
        {
            logger.Information("{LogMessage}", logMessage);
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="exception">The exception.</param>
        public void LogError(string logMessage, Exception exception)
        {
            logger.Error(exception, "{LogMessage}", logMessage);
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public void LogError(string logMessage)
        {
            logger.Error("{LogMessage}", logMessage);
        }

        /// <summary>
        /// Logs the fatal.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="exception">The exception.</param>
        public void LogFatal(string logMessage, Exception exception)
        {
            logger.Fatal(exception, logMessage);
        }

        /// <summary>
        /// Logs the fatal.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public void LogFatal(string logMessage)
        {
            logger.Fatal("{LogMessage}", logMessage);
        }

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public void LogWarning(string logMessage)
        {
            logger.Warning("{LogMessage}", logMessage);
        }

        /// <summary>
        /// Initializes the logger.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        private void InitializeLogger(LogConfiguration configuration)
        {
            logger = new LoggerConfiguration().WriteTo.File(configuration.FileLocation).CreateLogger();
        }
    }
}