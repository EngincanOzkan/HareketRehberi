import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public invalidLogin: boolean;

  constructor(
    private router: Router,
    private http: HttpClient ) {
  }

  ngOnInit(): void {
  }

  login(form: NgForm) {
    const credentials = JSON.stringify(form.value);
    this.http.post("https://localhost:5001/api/auth/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      const token = (<any>response).token;
      const userId = (<any>response).id;
      localStorage.setItem("jwt", token);
      localStorage.setItem("userId", userId);
      this.invalidLogin = false;
      this.router.navigate(["/"]);
    }, err => {
      this.invalidLogin = true;
    });
  }
}
