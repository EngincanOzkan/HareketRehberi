import { Component, OnInit, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-user',
  templateUrl: './add-edit-user.component.html',
  styleUrls: ['./add-edit-user.component.css']
})
export class AddEditUserComponent implements OnInit {

  public SystemUser: any;
  public AddEditPageTitle: string;
  public UserName: string;
  public Email: string;
  public Phone: string;
  public IsAdmin: boolean;
  public Password: string;
  public PasswordAgain: string;
  public PasswordsNotDone: boolean = false;

  constructor(
    private shared: SharedService,
    private router: Router,
  ) { 
    this.AddEditPageTitle = shared.AddSystemUsertitle;
    this.SystemUser = shared.SystemUser;
    if(this.SystemUser && this.SystemUser.userName) this.UserName = this.SystemUser.userName;
    if(this.SystemUser && this.SystemUser.email) this.Email = this.SystemUser.email;
    if(this.SystemUser && this.SystemUser.phone) this.Phone = this.SystemUser.phone;
    if(this.SystemUser && this.SystemUser.isAdmin) this.IsAdmin = this.SystemUser.isAdmin;
  }

  ngOnInit(): void {
  }

  save(form: NgForm) {
    this.checkPasswordsAreSame();
    if(!this.SystemUser)
    {
      if(!this.PasswordsNotDone)
      {
        const credentials = JSON.stringify(form.value);
        this.shared.addSystemUser(credentials).subscribe(response => {
          alert("Kaydetme işlemi başarıyla tamamlandı");
          this.router.navigate(["/users"]);
        }, err => {
          console.log(err);
        });
      }
    }else //update mode
    {
      if(!this.PasswordsNotDone)
      {
        form.value.id = this.SystemUser.id;
        var credentials = JSON.stringify(form.value);
        this.shared.updateSystemUser(credentials).subscribe(response => {
          alert("Güncelleme işlemi başarıyla tamamlandı");
          this.router.navigate(["/users"]);
        }, err => {
          console.log(err);
        });
      }
    }
  }

  checkPasswordsAreSame() {
    if(this.Password 
      && this.PasswordAgain
      && this.Password === this.PasswordAgain){
      this.PasswordsNotDone = false;
      return;
    }
    this.PasswordsNotDone = true;
  }
}
