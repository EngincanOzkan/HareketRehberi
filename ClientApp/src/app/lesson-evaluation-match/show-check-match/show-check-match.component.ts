import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
    private router: Router
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
        alert("Kaydetme işlemi başarıyla tamamlandı");
      }, err => {
        console.log(err);
      });
    }
  }

  deleteMatch(){
    this.service.deleteLessonsEvaluation(this.lessonId).subscribe(response => {
      alert("Silme işlemi başarıyla tamamlandı");
      window.location.reload();
    }, err => {
      console.log(err);
    });
  }
}
