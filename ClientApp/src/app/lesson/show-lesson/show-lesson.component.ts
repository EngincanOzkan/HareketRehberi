import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-lesson',
  templateUrl: './show-lesson.component.html',
  styleUrls: ['./show-lesson.component.css']
})
export class ShowLessonComponent implements OnInit {
  public LessonList: any = [];
  private SelectedLessonIdForRemove: number = 0;

  constructor(
    private service:SharedService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.refreshLessonList();
  }

  public refreshLessonList(){
    this.service.getLessonList().subscribe(data => {
      this.LessonList = data;
    })
  }

  public addClick(): void{
    this.service.AddLessonTitle = "Yeni Eğitim Tanımla";
    this.service.Lesson = null;
    this.router.navigate(["/lessons/add"]);
  }

  public editClick(lesson: any): void{
    this.service.AddLessonTitle = "Eğitim Düzenle";
    this.service.Lesson = lesson;
    this.router.navigate(["/lessons/edit"]);
  }

  public removeClick(lessonId: number): void{
    this.SelectedLessonIdForRemove = lessonId;
  }

  public selectEvaluationClick(lessonId: number): void{
    debugger;
    this.router.navigate(["/lessons/"+lessonId+"/evaluation/match"]);
  }

  public removeApproveClick(): void{
    this.service.deleteLesson(this.SelectedLessonIdForRemove).subscribe(response => {
      window.location.reload();
    }, err => {
      console.log(err);
    });
  }
}
