import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { UserService } from './user.service';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private userService: UserService, private router: Router) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

        if (sessionStorage.getItem('currentuser')) {
            // logged in so return true
            return true;
        }

        console.log('not auth');
        this.router.navigate(['/signin'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}
