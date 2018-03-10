import { Component, OnInit } from '@angular/core';
import {DataSource} from '@angular/cdk/collections';
import {BehaviorSubject} from 'rxjs/BehaviorSubject';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/observable/fromEvent';

import { Patient } from '../../view-models/patient.model';
import { PatientDataservice } from '../../services/patient-dataservice';


@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})
export class PatientComponent  implements OnInit {

  color:string;

  dataSource = new PatientDataSource(this.patientService);
  displayedColumns = ['patient', 'location', 'disposition', 'surgeon', 'anesthesia', 'procedure', 'start', 'status' , 'cons', 'hp', 'xray', 'lab', 'ekg' ];
  constructor(private patientService: PatientDataservice) { 

  }
  
  changeBackground(data):object {
    return {'background-color': data};
}

  ngOnInit() {
  }
}
export class PatientDataSource extends DataSource<any> {
  constructor(private patientService: PatientDataservice) {
    super();
  }
  connect(): Observable<Patient[]> {
    return this.patientService.getPatientsData();
  }
  disconnect() {}
} 
