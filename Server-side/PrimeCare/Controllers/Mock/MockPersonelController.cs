using System;
using System.IO;
using System.Web.Http;
using PrimeCare.Common;

namespace PrimeCare.Controllers
{
    public class MockPersonelController : ApiController
    {
        // GET api/<controller>/5
        public IHttpActionResult Get()
        {
            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/personel.json") ?? throw new InvalidOperationException());

            return new RawJsonActionResult(text);
        }
    }
}
