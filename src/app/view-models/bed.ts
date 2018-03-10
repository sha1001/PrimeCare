
export class BedItem {
    Name: string;
    Text: Array<string>;
    color: string;
    height: number;
    width: number;
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
