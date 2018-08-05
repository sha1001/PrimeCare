// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file= ProcedureRepository.cs company="Perimatics Inc.">
// //   Copyright (C) 2018 Perimatics Inc. All rights reserved.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------

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
    /// <inheritdoc />
    /// <summary>
    ///     The Procedure repository
    /// </summary>
    public class ProcedureRepository : Repository<object, ProcedureEntity>, IProcedureRepository, ILoadListFactory<object, ProcedureEntity>
    {
        public ProcedureRepository()
           : base("PeriVision")
        {
        }

        public List<ProcedureEntity> LoadList(object id)
        {
            return base.LoadList(null, PrepareCommandForLoadProcedure, ExecuteReader);
        }

        private ProcedureEntity ExecuteReader(IDataReader reader, ProcedureEntity entity)
        {
            //if (entity == null)
            entity = new ProcedureEntity();
            entity.ProcedureId = GetString(reader, "ProcedureId");
            entity.ProcedureType = GetString(reader, "ProcedureType");
            entity.Status = GetString(reader, "Status");
            entity.SpecialEquipCodes = GetString(reader, "SpecialEquipCodes");
            entity.ScheduleStartTime = GetDateTime(reader, "ScheduleStartTime");
            entity.ScheduleEndTime = GetDateTime(reader, "ScheduleEndTime");
            entity.ProcedureStartTime = GetDateTime(reader, "ProcedureStartTime");
            entity.ProcedureEndTime = GetDateTime(reader, "ProcedureEndTime");
            entity.CurrentTime = GetDateTime(reader, "CurrentTime");
            entity.MRN = GetString(reader, "MRN");
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
            entity.ORName = GetString(reader, "ORName");
            entity.ORId = GetInt(reader, "ORId");
            entity.StartPoint = GetDateTime(reader, "StartPoint");
            entity.EndPoint = GetDateTime(reader, "EndPoint");


            return entity;
        }

        private DbCommand PrepareCommandForLoadProcedure(Database db, object id)
        {
            DbCommand command = db.GetStoredProcCommand(StoredProcedureConstants.LoadProcedureStoredProcedure);

            return command;
        }
    }
}