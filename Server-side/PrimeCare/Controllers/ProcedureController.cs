// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file= ProcedureController.cs company="Perimatics Inc.">
// //   Copyright (C) 2018 Perimatics Inc. All rights reserved.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Web.Http;
using PrimeCare.Repository;

namespace PrimeCare.Controllers
{
    public class ProcedureController : ApiController
    {
        private readonly IProcedureRepository procedureRepository;

        public ProcedureController(IProcedureRepository procedureRepository)
        {
            this.procedureRepository = procedureRepository;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}