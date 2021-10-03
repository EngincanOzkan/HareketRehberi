import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';
import { DOCUMENT } from '@angular/common';
import { NotificationsService } from 'angular2-notifications';

@Component({
  selector: 'app-user-show-check-match-lesson',
  templateUrl: './user-show-check-match-lesson.component.html',
  styleUrls: ['./user-show-check-match-lesson.component.css']
})
export class UserShowCheckMatchLessonComponent implements OnInit {

  public userList: any = [];
  public lessonId: any;
  public lessonName: string;
  public lessonUsers: any[] = [];
  public selectedUserIds: any[] = [];

  constructor(
    private route: ActivatedRoute,
    private service: SharedService,
    private router: Router,
    private _notifications: NotificationsService,
    @Inject(DOCUMENT) private document: Document,
  ) { }

  ngOnInit(): void {
    this.lessonId = this.route.snapshot.paramMap.get('lessonid');
    this.refreshUserList();
    this.loadInfo();
  }

  public refreshUserList(){
    this.service.getSystemUserList().subscribe(data => {
      this.userList = data;
    })
  }

  public loadInfo(){
    this.service.getLesson(this.lessonId).subscribe(response => {
      this.lessonName = response.lessonName;
    });
    this.service.getLessonUserMatchByLessonId(this.lessonId).subscribe(respose => {
      this.lessonUsers = respose;
      debugger;
      this.lessonUsers.forEach(lessonUser => {
        debugger;
        var input = this.document.getElementById("user_"+lessonUser.userId) as HTMLInputElement;
        input.checked = true;
      })
    })
  }

  save(){
    if(this.lessonId)
    {
      var data = {
        LessonId: this.lessonId,
        userIds: this.selectedUserIds,
      }
      this.service.addLessonUserMatch(data).subscribe(response => {
        this._notifications.success("Başarılı", "Kaydetme işlemi başarıyla tamamlandı", {timeOut:2000})
      }, err => {
        console.log(err);
      });
    }
  }

  deleteMatch(){
    this.service.deleteLessonUserMatchByLessonId(this.lessonId).subscribe(response => {
      this._notifications.success("Başarılı", "Silme işlemi başarıyla tamamlandı", {timeOut:2000})
      window.location.reload();
    }, err => {
      console.log(err);
    });
  }

  onChangeCheckbox(userId: any, event:any) {
    if(event.target.checked){
      debugger;
      this.selectedUserIds.push(userId);
    }else {
      debugger;
      const index = this.selectedUserIds.indexOf(userId);
      if(index > -1) {
        this.selectedUserIds.splice(index, 1);
      }
      debugger;
    }
  }

}
