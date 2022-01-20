import { AfterViewInit, Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from '../shared.service';
import { AdminAuthGuard } from '../guards/admin-auth.guard';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, AfterViewInit {
  public invalidLogin: boolean;

  constructor(
    private router: Router,
    private http: HttpClient,
    private shared: SharedService,
    private authAdminGuard: AdminAuthGuard,
    private jwtHelper: JwtHelperService,
    private spinner: NgxSpinnerService) {
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(){
  }

  login(form: NgForm) {
    this.spinner.show();
    const credentials = JSON.stringify(form.value);
    this.http.post(this.shared.APIUrl+"/auth/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      this.spinner.hide();
      const token = (<any>response).token;
      const userId = (<any>response).id;
      localStorage.setItem("jwt", token);
      localStorage.setItem("userId", userId);
      this.invalidLogin = false;

      if(token && !this.jwtHelper.isTokenExpired(token) && this.jwtHelper.decodeToken(token)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === "Admin"){
        this.router.navigate(["/admin"]);
      }else {
        this.router.navigate(["/home"]);
      }
      
    }, err => {
      this.spinner.hide();
      this.invalidLogin = true;
    });
  }
}
