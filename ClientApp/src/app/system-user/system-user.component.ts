import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-system-user',
  templateUrl: './system-user.component.html',
  styleUrls: ['./system-user.component.css']
})
export class SystemUserComponent implements OnInit {

  public showSystemUserEdit: boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
