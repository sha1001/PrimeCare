using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PrimeCare.Common;

namespace PrimeCare.Controllers
{
    public class MockPatientController : ApiController
    {
        // GET api/<controller>/5
        public IHttpActionResult Get()
        {
            string text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Patient.json") ?? throw new InvalidOperationException());

            return new RawJsonActionResult(text);
        }
    }
}
