import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  @Input() isUserAuthenticated: boolean;
  @Input() isUserAdmin: boolean;

  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  logOut() {
    localStorage.removeItem("jwt");
    localStorage.removeItem("userId");
    this.router.navigate(["/login"]);
  }
}
