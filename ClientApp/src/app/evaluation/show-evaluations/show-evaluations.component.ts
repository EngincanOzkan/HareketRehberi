import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-evaluations',
  templateUrl: './show-evaluations.component.html',
  styleUrls: ['./show-evaluations.component.css']
})
export class ShowEvaluationsComponent implements OnInit {

  public evaluationList: any = [];
  private selectedEvaluationIdForRemove: number = 0;

  constructor(
    private service:SharedService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.refreshEvaluationList();
  }

  public refreshEvaluationList(){
    this.service.getEvaluationList().subscribe(data => {
      this.evaluationList = data;
    })
  }

  public addClick(): void{
    this.router.navigate(["/evaluations/add"]);
  }

  public editClick(evaluation: any): void{
    this.router.navigate(["/evaluations/edit/"+evaluation.id]);
  }

  public getQuestions(id: any) {
    this.router.navigate((["/evaluations/"+id+"/questions"]));
  }

  public removeClick(lessonId: number): void{
    this.selectedEvaluationIdForRemove = lessonId;
  }

  public removeApproveClick(): void{
    this.service.deleteEvaluation(this.selectedEvaluationIdForRemove).subscribe(response => {
      window.location.reload();
    }, err => {
      console.log(err);
    });
  }
}
