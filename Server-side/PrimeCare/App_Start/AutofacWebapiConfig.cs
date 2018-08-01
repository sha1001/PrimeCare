using System.Reflection;
using System.Web.Configuration;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Core.Logging;
using PrimeCare.Repository;

namespace PrimeCare
{
    public class AutofacWebapiConfig
    {

        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ProcedureRepository>().As<IProcedureRepository>().InstancePerRequest();

            builder.Register(c => new Logger(new LogConfiguration { FileLocation = WebConfigurationManager.AppSettings["FilePath"] })).As<ILogger>().SingleInstance();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}