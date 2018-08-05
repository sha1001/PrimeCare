using System;
using System.Collections.Generic;
using System.Data.Common;
using PrimeCare.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using DataStructure.Entity;
using USLBM.Mobile.Common;

namespace PrimeCare.Repository
{
    public class ResourceRepository : Repository<object, ResourceEntity>, IResourceRepository, ILoadListFactory<object, ResourceEntity>
    {
        public ResourceRepository()
           : base("PeriVision")
        {
        }

        public List<ResourceEntity> LoadList(object id)
        {
            return base.LoadList(null, PrepareCommandForLoadResource, ExecuteReader);
        }

        private ResourceEntity ExecuteReader(IDataReader reader, ResourceEntity entity)
        {
            if (entity == null)
                entity = new ResourceEntity();
            entity.ID = GetInt(reader, "ID");
            entity.BedName = GetString(reader, "BedName");
            entity.Status = GetString(reader, "Status");
            entity.PacuAdmitTime = GetDateTime(reader, "PacuAdmitTime");
            entity.PacuDischargeTime = GetDateTime(reader, "PacuDischargeTime");
            entity.CurrentTime = GetDateTime(reader, "CurrentTime");
            entity.LastName = GetString(reader, "LastName");
            entity.FirstName = GetString(reader, "FirstName");
            entity.SurgeonFirstName = GetString(reader, "SurgeonFirstName");
            entity.SurgeonLastName = GetString(reader, "SurgeonLastName");
            entity.AnestFirstName = GetString(reader, "AnestFirstName");
            entity.AnestLastName = GetString(reader, "AnestLastName");
            entity.CrnaFirstName = GetString(reader, "CrnaFirstName");
            entity.CrnaLastName = GetString(reader, "CrnaLastName");
            entity.NuresFirstName = GetString(reader, "NuresFirstName");
            entity.NurseLastName = GetString(reader, "NurseLastName");

            return entity;
        }

        private DbCommand PrepareCommandForLoadResource(Database db, object id)
        {
            DbCommand command = db.GetStoredProcCommand(StoredProcedureConstants.LoadResourceStoredProcedure);

            return command;
        }
    }
}