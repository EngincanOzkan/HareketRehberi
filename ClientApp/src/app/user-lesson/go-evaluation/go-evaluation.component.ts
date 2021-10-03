import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-go-evaluation',
  templateUrl: './go-evaluation.component.html',
  styleUrls: ['./go-evaluation.component.css']
})
export class GoEvaluationComponent implements OnInit {

  @Input() lessonId: any;
  
  @Input() evaluationId: any;
  @Input() lessonTitle:string;
  @Input() evaluationName: string;
  @Input() startEvaluation: boolean;
  @Output() startEvaluationChange = new EventEmitter();
  @Input() operationIdentifier: any;
  
  public endText: string = "";
  public userId: any;
  public questionIndex: number = 0;
  public questionData: any;
  public questionAnswers: number[] = [];
  public selectedAnswer: any;
  public evaluationEnd: boolean;

  constructor(
    public route: ActivatedRoute,
    public router: Router,
    public shared: SharedService
  ) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem("userId");
  }

  startEvaluationClick() {
    var data = {
      UserId: this.userId,
      LessonId: this.lessonId,
      EvaluationId: this.evaluationId,
      OperationIdentifier: this.operationIdentifier
    }
    this.shared.startEvaluation(data).subscribe(response => {
      this.questionData = response;
      this.startEvaluation=true;
      this.startEvaluationChange.emit(this.startEvaluation);
    });
  }

  onItemChange(value: any){
    this.shared.updateEvaluationAnswer(this.questionData[this.questionIndex].id, value).subscribe(response => {
      this.questionAnswers[this.questionIndex] = value;
    });
    console.log(" Value is : ", value );
  }

  goNext() {
    console.log(this.questionIndex)
    if(this.questionIndex < this.questionData.length-1){
      this.questionIndex++;
      this.selectedAnswer = this.questionAnswers[this.questionIndex];
      if(this.questionIndex == this.questionData.length-1)
      {
        this.endText = "Bitir";
      }
    }else if(this.questionIndex >= this.questionData.length-1) {
      var data = {
        UserId: this.userId,
        lessonId: this.lessonId,
        operationIdentifier: this.operationIdentifier,
      }
      this.shared.userLessonProgressLogCreateEndLog(data).subscribe(response => {
        this.evaluationEnd = true;
      });
    }
  }

  goPrevious() {
    if(this.questionIndex > 0){
      this.questionIndex--;
      this.selectedAnswer = this.questionAnswers[this.questionIndex];
      this.endText = "";
    }
  }
}
