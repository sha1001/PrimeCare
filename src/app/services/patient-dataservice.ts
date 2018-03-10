import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Patient } from '../view-models/patient.model';

@Injectable()
export class PatientDataservice {

  constructor(private http: Http) { }

  getPatientsData() {
    return this.http.get('assets/Patient.json').map(
      (response) => response.json()
    );
  }
}
