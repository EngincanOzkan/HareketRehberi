import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationsService } from 'angular2-notifications';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-check-match',
  templateUrl: './show-check-match.component.html',
  styleUrls: ['./show-check-match.component.css']
})
export class ShowCheckMatchComponent implements OnInit {

  public evaluationList: any = [];
  public lessonId: any;
  public lessonName: string;
  public lessonEvaluations: any[] = [];
  public selectedEvaluationId: any;

  constructor(
    private route: ActivatedRoute,
    private service: SharedService,
    private router: Router,
    private _notifications: NotificationsService
  ) { }

  ngOnInit(): void {
    this.lessonId = this.route.snapshot.paramMap.get('lessonid');
    this.loadInfo();
    this.refreshEvaluationList();
  }

  public refreshEvaluationList(){
    this.service.getEvaluationList().subscribe(data => {
      this.evaluationList = data;
    })
  }

  public loadInfo(){
    this.service.getLesson(this.lessonId).subscribe(response => {
      this.lessonName = response.lessonName;
    });
    this.service.getLessonsEvaluationsByLessonId(this.lessonId).subscribe(respose => {
      this.lessonEvaluations = respose;
      this.lessonEvaluations.forEach(match => {
        this.selectedEvaluationId = match.id
      });
    })
  }

  save(){
    if(this.lessonId && this.selectedEvaluationId)
    {
      var data = {
        LessonId: this.lessonId,
        EvaluationId: this.selectedEvaluationId
      }
      this.service.addLessonEvaluation(data).subscribe(response => {
        this._notifications.success("Başarılı", "Kaydetme işlemi başarıyla tamamlandı", {timeOut:2000})
      }, err => {
        console.log(err);
      });
    }
  }

  deleteMatch(){
    this.service.deleteLessonsEvaluation(this.lessonId).subscribe(response => {
      this._notifications.success("Başarılı", "Silme işlemi başarıyla tamamlandı", {timeOut:2000})
      window.location.reload();
    }, err => {
      console.log(err);
    });
  }
}
