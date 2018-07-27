// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file= NinjectWebCommon.cs company="Perimatics Inc.">
// //   Copyright (C) 2018 Perimatics Inc. All rights reserved.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Filters;
using Core.Logging;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using PrimeCare;
using PrimeCare.Common;
using PrimeCare.Repository;
using WebActivatorEx;
using WebApiContrib.IoC.Ninject;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace PrimeCare
{
    /// <summary>
    ///     The NinjectWebCommon
    /// </summary>
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>
        ///     The created kernel.
        /// </returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            // Support WebAPI
            GlobalConfiguration.Configuration.DependencyResolver =
                new NinjectResolver(kernel);
            GlobalConfiguration.Configuration.Services.Add(typeof(IFilterProvider),
                new NinjectWebApiFilterProvider(kernel));


            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        ///     Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IProcedureRepository>().To<ProcedureRepository>();
            kernel.Bind<ILogger>().ToMethod(ctx =>
                new Logger(new LogConfiguration {FileLocation = WebConfigurationManager.AppSettings["FilePath"]}));
        }
    }
}