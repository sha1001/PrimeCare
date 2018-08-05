using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeCare.Repository
{
    public class StoredProcedureConstants
    {
        public const string LoadProcedureStoredProcedure = "[dbo].[sp_getProcedure]";
        public const string LoadPatientStoredProcedure = "[dbo].[sp_getPatientInfo]";
        public const string LoadResourceStoredProcedure = "[dbo].[sp_getResource]";
    }
}