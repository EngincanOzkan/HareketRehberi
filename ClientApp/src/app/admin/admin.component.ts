import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  public reportData: any[] = [];

  constructor(
    private shared: SharedService
  ) { }

  ngOnInit(): void {
    this.shared.getUsersAllLogList().subscribe(response => {
      this.reportData = response;
    })
  }

}
