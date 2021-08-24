import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AdminAuthGuard implements CanActivate {

  constructor(
    private router: Router,
    private jwtHelper: JwtHelperService
  ){}

  canActivate() {
    const token = localStorage.getItem('jwt');

    if(token && !this.jwtHelper.isTokenExpired(token) && this.jwtHelper.decodeToken(token)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === "Admin"){
      return true;
    }else {
      this.router.navigate(["/login"]);
      return false;
    }
  }
}


