import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-user',
  templateUrl: './show-user.component.html',
  styleUrls: ['./show-user.component.css']
})
export class ShowUserComponent implements OnInit {
  public SystemUsersList: any = [];
  private SelectedUserIdForRemove: number = 0;

  constructor(
    private service:SharedService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.refreshSystemUserList();
  }

  public refreshSystemUserList(){
    this.service.getSystemUserList().subscribe(data => {
      this.SystemUsersList = data;
    })
  }

  public addClick(): void{
    this.service.AddSystemUsertitle = "Yeni Kullanıcı Tanımla";
    this.service.SystemUser = null;
    this.router.navigate(["/users/add"]);
  }

  public editClick(user: any): void{
    this.service.AddSystemUsertitle = "Kullanıcı Düzenle";
    this.service.SystemUser = user;
    this.router.navigate(["/users/edit"]);
  }

  public removeClick(userId: number): void{
    this.SelectedUserIdForRemove = userId;
  }

  public removeApproveClick(): void{
    this.service.deleteSystemUser(this.SelectedUserIdForRemove).subscribe(response => {
      this.router.navigate(["/users"]);
    }, err => {
      console.log(err);
    });
  }
}
