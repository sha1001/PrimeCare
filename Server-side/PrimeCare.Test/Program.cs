using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;
using DataStructure.Entity;
using PrimeCare.Repository;
using PrimeCare.Business;

namespace PrimeCare.Test
{
    class Program
    {
        static void Main(string[] args)
        {
             GetProcedure();
            //GetPatient();
            //GetResource();
        }
        public static void GetProcedure()
        {
            //ProcedureRepository procedureRepository = new ProcedureRepository();
            //List<ProcedureEntity> list =  procedureRepository.LoadList(null);
            ProcedureManager procedureManager = new ProcedureManager();
            Procedure procedure = procedureManager.GetProcedureData();

        }

        public static void GetPatient()
        {
            PatientRepository patientRepository = new PatientRepository();
            List<PatientEntity> list = patientRepository.LoadList(null);
        }
        public static void GetResource()
        {
            ResourceRepository resourceRepository = new ResourceRepository();
            List<ResourceEntity> list = resourceRepository.LoadList(null);
        }
    }
}
