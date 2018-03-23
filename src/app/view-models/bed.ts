
export class BedItem {
    Name: string;
    EstDischargeTime: string;
    Color: string;
    RX: number;
}
export class OperationBed {
   Beds: BedItem[];
}
export class Bed {
    OperationBeds: OperationBed[];
    CurrentOccupancy: string;
    BedOccupied: number;
    BedEmpty: number;
}
export class Resources {
    Id: number;
    OperationBeds: OperationBed[];
    CurrentOccupancy: string;
    BedOccupied: number;
    BedEmpty: number;
}
