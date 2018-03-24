import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Patient, PatientScreen } from '../view-models/patient.model';

@Injectable()
export class PatientDataservice {
patientSc: Observable<any>;
  constructor(private http: Http) { }

  getPatientsData() {
    return this.http.get('assets/Patient.json').map(
      (response) => response.json()
    );
  }

  getPatientsData1() {
    this.patientSc = this.http.get('assets/Patient.json').map(
      (response) => response.json()
    );
    let item: PatientScreen;
    return this.patientSc.subscribe((items: PatientScreen[]) => item = items.find(p => p.ID === 3));
  }
}
