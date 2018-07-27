import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import {Observable} from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { UserApi } from '../users/user-api';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/delay';
import { User } from '../view-models/user';

@Injectable()
export class UserService implements UserApi {

  constructor(private router: Router) { }

  signIn(username: string, password: string): Observable<any> {
    console.log('UserService.signIn: ' + username + ' ' + password);

    if (username === 'admin' && password === 'admin') {

     const user = new User();
     user.username = username;
     user.password = password;

    sessionStorage.setItem('currentuser', JSON.stringify(user));
      return Observable.of({}).delay(2000);
    }

    this.router.navigate(['/signin']);
    return Observable.throw('Username or password is incorrect');
  }

  signOut(): Observable<any> {
      this.router.navigate(['/signin']);
      return Observable.of({});
  }
}
