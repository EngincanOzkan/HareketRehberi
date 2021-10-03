import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-user-main-screen',
  templateUrl: './user-main-screen.component.html',
  styleUrls: ['./user-main-screen.component.css']
})
export class UserMainScreenComponent implements OnInit {
  public userId: any;
  public LessonList: any[];

  constructor(
    public shared: SharedService,
    public router: Router
  ) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem('userId');
    this.fillLessons();
  }

  fillLessons() {
    this.shared.getUsersLessons(this.userId).subscribe(data => {
      this.shared.getUserLessonLogsGeneral(this.userId).subscribe(response => {
        let usersProgresses = response.map(a => a.lessonId);
        data.forEach(q => {
          if(usersProgresses.includes(q.id))
          {
            q.done = true
          }else {
            q.done = false;
          }
        });
      })
      this.LessonList = data;
    }) 
  }

  startLesson(val: any){
    this.router.navigate(['/lesson', { id: val }]);
  }

}
