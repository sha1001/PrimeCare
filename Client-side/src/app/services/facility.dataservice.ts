import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Patient } from '../view-models/patient.model';

@Injectable()
export class FacilityDataservice {

  constructor(private http: Http) { }

  getfacilityRessourceData() {
    return this.http.get('http://primecaredev.centralus.cloudapp.azure.com/api/MockFacilityresources').map(
      (response) => response.json()
    );
  }
}
