// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file= CustomApiExceptionLogger.cs company="Perimatics Inc.">
// //   Copyright (C) 2018 Perimatics Inc. All rights reserved.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------

using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using Core.Logging;

namespace PrimeCare.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ExceptionHandling.ExceptionLogger" />
    public class CustomApiExceptionLogger : ExceptionLogger
    {
        /// <summary>
        /// When overridden in a derived class, logs the exception synchronously.
        /// </summary>
        /// <param name="context">The exception logger context.</param>
        public override void Log(ExceptionLoggerContext context)
        {
            var requestScope = context.Request.GetDependencyScope();

            var logger = requestScope.GetService(typeof(ILogger)) as ILogger;

            logger?.LogError($"{context.Exception.GetBaseException()}");
        }
    }
}