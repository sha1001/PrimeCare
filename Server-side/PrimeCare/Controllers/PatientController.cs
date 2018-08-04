using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Core.Logging;
using Newtonsoft.Json;
using PrimeCare.Common;
using PrimeCare.Models;
using PrimeCare.Repository;

namespace PrimeCare.Controllers
{
    [RoutePrefix("api")]
    public class PatientController : ApiController
    {
        private readonly ILogger logger;

        private readonly IProcedureRepository procedureRepository;

        public PatientController(IProcedureRepository procedureRepository, ILogger logger)
        {
            this.procedureRepository = procedureRepository;
            this.logger = logger;
        }

        // GET api/values
        [Route("get/patient")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            logger.LogInformation("This is test dfdf");
            return new[] { "value1", "value2" };
        }


        [Route("fake/patient")]
        [HttpGet]
        public IHttpActionResult GetFake()
        {
            var app = HttpContext.Current.Application["Count"];
            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Patient.json") ?? throw new InvalidOperationException());
            var result = JsonConvert.DeserializeObject<List<PatientScreen>>(text);
            var response = result.FirstOrDefault(x => x.ID == (int)app);

            return Ok(response);
        }
    }
}
