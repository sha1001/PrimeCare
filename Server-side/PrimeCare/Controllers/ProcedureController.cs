// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file= ProcedureController.cs company="Perimatics Inc.">
// //   Copyright (C) 2018 Perimatics Inc. All rights reserved.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------

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
            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Procedure_full.json") ?? throw new InvalidOperationException());

            return new RawJsonActionResult(text);
        }
    }
}