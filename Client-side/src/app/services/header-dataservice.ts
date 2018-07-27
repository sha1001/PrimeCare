import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Header } from '../view-models/header';

@Injectable()
export class HeaderDataservice {

  constructor(private http: Http) { }

  getData(): Observable<Header> {
    return this.http.get('assets/header.json').map(
      (response) => response.json()
    );
  }
}
