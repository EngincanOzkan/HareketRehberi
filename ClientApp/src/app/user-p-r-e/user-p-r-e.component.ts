
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-user-p-r-e',
  templateUrl: './user-p-r-e.component.html',
  styleUrls: ['./user-p-r-e.component.css']
})
export class UserPREComponent implements OnInit {

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
    this.shared.getUsers_p_r_e(this.userId).subscribe(data => {
      this.shared.getUserLessonLogsToday(this.userId).subscribe(response => {
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
