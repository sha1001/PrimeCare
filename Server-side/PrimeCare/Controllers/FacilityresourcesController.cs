using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class FacilityresourcesController : ApiController
    {
        private readonly ILogger logger;

        private readonly IProcedureRepository procedureRepository;

        public FacilityresourcesController(IProcedureRepository procedureRepository, ILogger logger)
        {
            this.procedureRepository = procedureRepository;
            this.logger = logger;
        }

        // GET api/values
        [Route("get/facilityresources")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            logger.LogInformation("This is test dfdf");
            return new[] { "value1", "value2" };
        }


        [Route("fake/facilityresources")]
        [HttpGet]
        public IHttpActionResult GetFake()
        {
            var app = HttpContext.Current.Application["Count"];

            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Resource.json") ?? throw new InvalidOperationException());
            var result = JsonConvert.DeserializeObject<List<Resources>>(text);
            var response = result.FirstOrDefault(x => x.Id == (int)app);

            return Ok(response);
        }

        [Route("fake/facilityresources/PACUThroughChart")]
        [HttpGet]
        public IHttpActionResult GetFakePACUThroughChart()
        {
            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/PACUThroughChart.json") ?? throw new InvalidOperationException());
            var response = JsonConvert.DeserializeObject<PACUThroughChart>(text);
            return Ok(response);
        }


        [Route("fake/facilityresources/PACUChart")]
        [HttpGet]
        public IHttpActionResult GetFakePACUChart()
        {
            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/PACUChart.json") ?? throw new InvalidOperationException());
            var response = JsonConvert.DeserializeObject<PACUChart>(text);
            return Ok(response);
        }
    }
}
