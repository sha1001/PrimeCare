import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import {DataSource} from '@angular/cdk/collections';
import {BehaviorSubject} from 'rxjs/BehaviorSubject';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/observable/fromEvent';
import { Http } from '@angular/http';
import { environment } from '../../../environments/environment';
import { Patient, PatientScreen } from '../../view-models/patient.model';
import { PatientDataservice } from '../../services/patient-dataservice';
import {Globals} from '../globals';


@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})
export class PatientComponent  implements OnInit,  AfterViewInit, OnDestroy {

  color: string;
  patientscreen: PatientScreen;
  interval: any;
  patientSc: Observable<any>;
  dataSource: PatientDataSource;
  myData: Patient[] ;
  myDataPatScreen: PatientScreen[] ;
  displayedColumns = [ 'patient', 'location', 'disposition', 'surgeon', 'anesthesia', 'procedure', 'start',  'status', 'cons',
   'hp', 'xray', 'lab', 'ekg' ];
  globals1: Globals;


  constructor(private http: Http, private globals: Globals) {
    this.globals1 = globals;
    this.loadFromFile();
  }

  ngAfterViewInit() {
    this.loadFromFile();
    this.getDatas();
  }

  changeBackground(data): object {
    return {'background-color': data};
}

public loadFromFile() {

  this.http.get(environment.api_url + '/Patient')
    .map(response => response.json())
    .subscribe(res => {
      this.patientscreen = res;
      this.dataSource = new PatientDataSource(this.patientscreen.Patient);
    });
}

  ngOnInit() {
  }

  ngOnDestroy() {
    clearInterval(this.interval);
  }

  getDatas() {
    this.interval = setInterval(() => {
      this.loadFromFile();
    },  this.globals1.timeinterval);
  }
}


export class PatientDataSource extends DataSource<any> {
  constructor(private data: Patient[]) {
    super();
  }
   /** Connect function called by the table to retrieve one stream containing the data to render. */
  connect(): Observable<Patient[]> {
    return Observable.of(this.data);
  }

  disconnect() {}
  }
