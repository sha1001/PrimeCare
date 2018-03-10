import { Observable } from 'rxjs/Observable';

export abstract class UserApi {
    signIn: (username: string, password: string) => Observable<any>;
    signOut: () => Observable<any>;
}
