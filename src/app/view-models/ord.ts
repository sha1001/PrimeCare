import { Patient } from './patientinfo';

export class Ord {
    ordItem: OrdItem[];
    ordNumber: number;
}
export class OrdItem {
    name: string;
    color: string;
    height: number;
    width: number;
    px: number;
}
export class Operation {
    Id: number;
    Status: string;
    OpName: string;
    ImageName: string;
    SchStartTime: number;
    SchEndTime: number;
    StartDelay: number;
    EndDelay: number;
    OperationDuration: number;
    RX: number;
    Width: number;
    Patient: Patient;
}
export class OperationRoom {
    Name: string;
    ID: number;
    Operations: Operation[];
}
export class Procedure {
    TimeList: string;
    OperationRooms: OperationRoom[];
    CurrentTime: string;
    Id: number;
    Alert: string[];
}


