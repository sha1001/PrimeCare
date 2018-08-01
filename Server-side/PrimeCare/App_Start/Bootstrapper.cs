using System.Web.Http;

namespace PrimeCare
{
    public class Bootstrapper
    {
      
            public static void Run()
            {
                //Configure AutoFac  
                AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            }

   
    }
}