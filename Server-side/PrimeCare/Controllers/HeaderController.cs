using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using Core.Logging;
using Newtonsoft.Json;
using PrimeCare.Models;
using PrimeCare.Repository;

namespace PrimeCare.Controllers
{
    [RoutePrefix("api")]
    public class HeaderController : ApiController
    {
        private readonly ILogger logger;

        private readonly IProcedureRepository procedureRepository;

        public HeaderController(IProcedureRepository procedureRepository, ILogger logger)
        {
            this.procedureRepository = procedureRepository;
            this.logger = logger;
        }

        // GET api/values
        [Route("get/header")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            logger.LogInformation("This is test dfdf");
            return new[] { "value1", "value2" };
        }

        [Route("fake/header")]
        [HttpGet]
        public IHttpActionResult GetFakeHeader()
        {
            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Header.json") ?? throw new InvalidOperationException());

            var response = JsonConvert.DeserializeObject<Header>(text);

            return Ok(response);
        }

        [Route("fake/headerchart")]
        [HttpGet]
        public IHttpActionResult GetFakeHeaderChart()
        {
            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/headerchart.json") ?? throw new InvalidOperationException());

            var response = JsonConvert.DeserializeObject<HeaderChart>(text);

            return Ok(response);
        }

        [Route("fake/headeralert")]
        [HttpGet]
        public IHttpActionResult GetFakeHeaderAlert()
        {
            var app = HttpContext.Current.Application["Count"];

            var count = (int)app + 1;
            if (count == 101)
            {
                HttpContext.Current.Application["Count"] = 0;
                count = (int)HttpContext.Current.Application["Count"];
            }

            HttpContext.Current.Application["Count"] = count;
            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Procedure_full.json") ?? throw new InvalidOperationException());
            var result = JsonConvert.DeserializeObject<List<Procedure>>(text);
            var response = result.FirstOrDefault(x => x.Id == count);

            return Ok(response);
        }
    }
}
