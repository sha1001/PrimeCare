export interface Patient {
    StatusColor: string;
    EKG: string;
    Lab: string;
    XRay: string;
    HP: string;
    Consent: string;
    Status: string;
    StartTime: string;
    Procedure: string;
    Anesthologist: string;
    SurgeonName: string;
    Disposition: string;
    Location: string;
    Info: string;
    PatientID: string;
    }
    export interface PatientScreen {
       ID: number;
       Patient: Patient[];
    }
