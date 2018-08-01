using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using Core.Logging;
using PrimeCare.Common;
using PrimeCare.Repository;

namespace PrimeCare.Controllers
{
    [RoutePrefix("api")]
    public class PersonelController : ApiController
    {
        private readonly ILogger logger;

        private readonly IProcedureRepository procedureRepository;

        public PersonelController(IProcedureRepository procedureRepository, ILogger logger)
        {
            this.procedureRepository = procedureRepository;
            this.logger = logger;
        }

        // GET api/values
        [Route("get/personel")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            logger.LogInformation("This is test dfdf");
            return new[] { "value1", "value2" };
        }


        [Route("fake/personel")]
        [HttpGet]
        public IHttpActionResult GetFake()
        {
            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/personel.json") ?? throw new InvalidOperationException());

            return new RawJsonActionResult(text);
        }
    }
}
