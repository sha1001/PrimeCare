export interface Patient {
    patient: Array<string>;
    location: string;
    disposition: string;
    surgeon: string;
    anesthesia: string;
    procedure: string;
    start: string;
    status: string;
    StatusColor: string;
    cons: string;
    hp: string;
    xray: string;
    lab: string;
    ekg: string;
    }
    export interface PatientScreen {
       Id: number;
       screen: Patient[];
    }
