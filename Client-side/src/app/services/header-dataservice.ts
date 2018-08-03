import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Header } from '../view-models/header';
import { environment } from '../../environments/environment';


@Injectable()
export class HeaderDataservice {

  constructor(private http: Http) { }

  getData(): Observable<Header> {
    return this.http.get(environment.api_url + '/header').map(
      (response) => response.json()
    );
  }
}
