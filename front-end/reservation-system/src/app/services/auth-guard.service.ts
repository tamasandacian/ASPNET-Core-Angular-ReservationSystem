import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router, CanActivate } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private router: Router) { }

  canActivate(router: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (localStorage.getItem('customer')) {
      // logged in so return true
      return true;
    }
    else {
      // not logged in so return to login page with the return url
      this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
      return false;
    }
  }
}
