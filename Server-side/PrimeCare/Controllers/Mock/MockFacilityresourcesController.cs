using System;
using System.IO;
using System.Web.Http;
using PrimeCare.Common;

namespace PrimeCare.Controllers
{
    [Route("institution/v1.0/devicepersonalization")]
    public class MockFacilityresourcesController : ApiController
    {

        // GET api/<controller>/5
        public IHttpActionResult Get()
        {
            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Resource.json") ?? throw new InvalidOperationException());

            return new RawJsonActionResult(text);
        }
    }
}
