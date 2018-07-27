import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Procedure } from '../view-models/Ord';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';

@Injectable()
export class AppDataService2 {
    constructor(private http: Http) {
    }
    fetchData() {
        return this.http.get('assets/Procedure.json').map(
          (response) => response.json()
        );
    }
}
