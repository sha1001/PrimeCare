import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Patient } from '../view-models/personel.model';

@Injectable()
export class PersonelDataservice {

  constructor(private http: Http) { }

  getPatientsData() {
    return this.http.get('assets/personel.json').map(
      (response) => response.json()
    );
  }
}
