using System.Collections.Generic;
using System.Data.Common;
using PrimeCare.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using DataStructure.Entity;
using USLBM.Mobile.Common;

namespace PrimeCare.Repository
{
    public class PatientRepository : Repository<object, PatientEntity>, IPatientRepository, ILoadListFactory<object, PatientEntity>
    {
        public PatientRepository()
           : base("PeriVision")
        {
        }

        public List<PatientEntity> LoadList(object id)
        {
            return base.LoadList(null, PrepareCommandForLoadPatient, ExecuteReader);
        }

        private PatientEntity ExecuteReader(IDataReader reader, PatientEntity entity)
        {
            if (entity == null)
                entity = new PatientEntity();
            entity.ID = GetInt(reader, "ID");
            entity.ORName = GetString(reader, "ORName");
            entity.SurgeonFirstName = GetString(reader, "SurgeonFirstName");
            entity.SurgeonLastName = GetString(reader, "SurgeonLastName");
            entity.AnestFirstName = GetString(reader, "AnestFirstName");
            entity.AnestLastName = GetString(reader, "AnestLastName");
            entity.ProcedureName = GetString(reader, "ProcedureName");
            entity.StartTime = GetDateTime(reader, "StartTime");
            entity.Status = GetString(reader, "Status");
            entity.ConsentStatus = GetString(reader, "ConsentStatus");
            entity.HPstatus = GetString(reader, "HPstatus");
            entity.XRayStatus = GetString(reader, "XRayStatus");
            entity.LabsStatus = GetString(reader, "LabsStatus");
            entity.EKGStatus = GetString(reader, "EKGStatus");
            entity.Disposition = GetString(reader, "DispositionType");

            return entity;

        }

        private DbCommand PrepareCommandForLoadPatient(Database db, object id)
        {
            DbCommand command = db.GetStoredProcCommand(StoredProcedureConstants.LoadPatientStoredProcedure);

            return command;
        }
    }
}