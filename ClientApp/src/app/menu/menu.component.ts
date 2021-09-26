import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  @Input() isUserAuthenticated: boolean;
  @Input() isUserAdmin: boolean;

  constructor() { }

  ngOnInit(): void {
  }

  logOut() {
    localStorage.removeItem("jwt");
    localStorage.removeItem("userId");
  }
}
