import { Component } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';

  constructor(
    private jwtHelper: JwtHelperService
  ){}

  get isUserAuthenticated(): boolean {
    const token: string | null = localStorage.getItem('jwt');
    if(token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }else{
      return false;
    }
  }

  get isUserAdmin(): boolean {
    const token: string | null = localStorage.getItem('jwt');
    if(token && !this.jwtHelper.isTokenExpired(token) && this.jwtHelper.decodeToken(token)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === "Admin"){
      return true;
    }else{
      return false;
    }
  }
}
