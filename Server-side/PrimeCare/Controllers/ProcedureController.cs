// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file= ProcedureController.cs company="Perimatics Inc.">
// //   Copyright (C) 2018 Perimatics Inc. All rights reserved.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
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
    public class ProcedureController : ApiController
    {
        private readonly ILogger logger;

        private readonly IProcedureRepository procedureRepository;

        public ProcedureController(IProcedureRepository procedureRepository, ILogger logger)
        {
            this.procedureRepository = procedureRepository;
            this.logger = logger;
        }

        // GET api/values
        [Route("get/procedure")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            logger.LogInformation("This is test dfdf");
            return new[] {"value1", "value2"};
        }


        [Route("fake/procedure")]
        [HttpGet]
        public IHttpActionResult GetFake()
        {
            var app = HttpContext.Current.Application["Count"];

            if ((int)HttpContext.Current.Application["Count"] != 101)
            {
                var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Procedure_full.json") ?? throw new InvalidOperationException());
                var result = JsonConvert.DeserializeObject<List<Procedure>>(text);
                var response = result.FirstOrDefault(x => x.Id == (int)app);

                return Ok(response);
            }
            return (Ok(string.Empty));
        }
    }
}