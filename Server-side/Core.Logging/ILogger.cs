// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file= ILogger.cs company="Perimatics Inc.">
// //   Copyright (C) 2018 Perimatics Inc. All rights reserved.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------

using System;

namespace Core.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        void LogInformation(string logMessage);

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="exception">The exception.</param>
        void LogError(string logMessage, Exception exception);

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        void LogError(string logMessage);

        /// <summary>
        /// Logs the fatal.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="exception">The exception.</param>
        void LogFatal(string logMessage, Exception exception);

        /// <summary>
        /// Logs the fatal.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        void LogFatal(string logMessage);

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        void LogWarning(string logMessage);
    }
}