import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  
  public userId: any;
  public questionIndex: number = 0;
  public questionData: any;
  public questionAnswers: number[] = [];
  public selectedAnswer: any;

  constructor(
    public route: ActivatedRoute,
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
    if(this.questionIndex < this.questionData.length){
      this.questionIndex++;
      this.selectedAnswer = this.questionAnswers[this.questionIndex];
    }
  }

  goPrevious() {
    if(this.questionIndex > 0){
      this.questionIndex--;
      this.selectedAnswer = this.questionAnswers[this.questionIndex];
    }
  }
}
