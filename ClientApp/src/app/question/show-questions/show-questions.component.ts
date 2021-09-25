import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-questions',
  templateUrl: './show-questions.component.html',
  styleUrls: ['./show-questions.component.css']
})
export class ShowQuestionsComponent implements OnInit {
  public questionList: any = [];
  private selectedQuestionIdForRemove: number = 0;
  private evaluationId: any = 0;

  constructor(
    private route: ActivatedRoute,
    private service:SharedService,
    private router: Router
  ) { }

  ngOnInit(): void {
    const evaluationId = this.route.snapshot.paramMap.get('evaluationid');
    this.evaluationId = evaluationId;
    this.refreshQuestionList(evaluationId);
  }

  public refreshQuestionList(evaluationId: any){
    this.service.getEvaluationQuestionsList(evaluationId).subscribe(data => {
      this.questionList = data;
    })
  }

  public addClick(): void{
    this.router.navigate(["/evaluations/" + this.evaluationId + "/questions/add"]);
  }

  public editClick(lesson: any): void{
    this.router.navigate(["/evaluations/"+this.evaluationId+"/questions/edit/"+lesson.id]);
  }

  public removeClick(lessonId: number): void{
    this.selectedQuestionIdForRemove = lessonId;
  }

  public removeApproveClick(): void{
    this.service.deleteEvaluation(this.selectedQuestionIdForRemove).subscribe(response => {
      window.location.reload();
    }, err => {
      console.log(err);
    });
  }
}
