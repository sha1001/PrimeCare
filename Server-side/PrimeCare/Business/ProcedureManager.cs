using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataStructure;
using DataStructure.Entity;
using PrimeCare.Repository;

namespace PrimeCare.Business
{
    public class ProcedureManager
    {

        public Procedure GetProcedureData()
        {
            // get the procedure list entity from the database. 
            ProcedureRepository procedureRepository = new ProcedureRepository();
            List<ProcedureEntity> list = procedureRepository.LoadList(null);

            Procedure procedure = CalculateScreenTimeWindow(list[0]);
            procedure.SetData(list[0].CurrentTime.ToString("HH:mm"));
            GetOperationRooms(list, ref procedure);

            return procedure;
        }
        private void GetOperationRooms(List<ProcedureEntity> list, ref Procedure procedure)
        {
            // get the list of all the operation.
            List<Operation> operationList = GetOperationsList(list, procedure);
            // get the unique list of operation room. 
            var opRoomsName = operationList.Select(o => o.ORName).Distinct();

            // create operation room object with the each 
            foreach(string opRoomName in opRoomsName)
            {
                OperationRoom operationRoom = new OperationRoom();
                operationRoom.Name = opRoomName;
                // get all the operations from from opRoomName
                var opList = from op in operationList
                             where op.ORName == opRoomName
                             select op;
                // add the list of operation to the operation room.
                operationRoom.Add(opList);
                // add the operation room to the procedure object.
                procedure.AddOperationRoom(operationRoom);
            }
        }
        private List<Operation> GetOperationsList(List<ProcedureEntity> list, Procedure procedure)
        {
            List<Operation> operationList = new List<Operation>();

            if (list == null || list.Count == 0)
                return operationList;
            // loop each procedure and create operation item.

            foreach(ProcedureEntity pro in list)
            {
                Operation operation = new Operation(procedure.StartTime, procedure.EndTime, pro.CurrentTime.ToString("HH:mm"));
                operation.Id = pro.ProcedureId;
                operation.PatientCaseId = pro.MRN;
                operation.OpName = pro.ProcedureType;
                operation.Status = pro.Status;
                operation.ImageName = pro.SpecialEquipCodes; // this need to be mapped correctly.
                operation.SchStartTime = pro.ScheduleStartTime.ToString("HH:mm");
                operation.SchEndTime = pro.ScheduleEndTime.ToString("HH:mm");
                operation.StartDelay =Helper.StringToIntTime(GetDelayTime(pro.ScheduleStartTime, pro.ProcedureStartTime));
                operation.EndDelay = Helper.StringToIntTime(GetDelayTime(pro.ScheduleEndTime, pro.ProcedureEndTime));
                operation.RX = 0.0;
                operation.Patient = GetPatientData(pro);
                operation.ORName = pro.ORName;

                operationList.Add(operation);
            }
            return operationList;
        }

        private PatientInfo GetPatientData(ProcedureEntity pro)
        {
            PatientInfo patientInfo = new PatientInfo();
            patientInfo.Name = $"{pro.FirstName},{pro.LastName}";
            patientInfo.Info = pro.MRN;
            patientInfo.SurgeonName = $"{pro.SurgeonFirstName},{pro.SurgeonLastName}";
            patientInfo.Anesthologist = $"{pro.AnestFirstName},{pro.AnestLastName}";
            patientInfo.Crna = $"{pro.CrnaFirstName},{pro.CrnaLastName}";
            patientInfo.CircleNurse = $"{pro.NuresFirstName},{pro.NurseLastName}";

            return patientInfo;

        }

        private Procedure CalculateScreenTimeWindow(ProcedureEntity procedureEntity)
        {
            if(procedureEntity == null)
            {
                return null;
            }
            string currentTime = procedureEntity.CurrentTime.ToString("HH:mm");
            Procedure procedure = new Procedure(currentTime);

            int.TryParse(procedureEntity.CurrentTime.ToString("HH"), out int currentHour);
            // set the startpoint and end point of the procedure screen. 
            // start point is -2hr of the current hour and end is +8hr of start hour
            // below logic is to handle if current time is 0 hr, 1 hr
            int stPoint = (currentHour - 2) % 24;
            if (stPoint < 0)
                stPoint += 24;

            procedure.StartTime = Helper.StringToIntTime($"{stPoint.ToString()}:00");
            procedure.EndTime = Helper.StringToIntTime($"{((currentHour + 6) % 24).ToString()}:00");

            return procedure;
        }
        private string GetDelayTime(DateTime st, DateTime end)
        {
            string diff =   (end - st).ToString();

            string[] timeSplit = diff.Split(':');

            return $"{timeSplit[0]}:{timeSplit[1]}";
        }
    }
}