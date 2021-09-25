import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EvaluationComponent } from 'src/app/evaluation/evaluation.component';
import { AnswerModel } from 'src/app/Models/AnswerModel';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-answer-add-edit-delete-question',
  templateUrl: './answer-add-edit-delete-question.component.html',
  styleUrls: ['./answer-add-edit-delete-question.component.css']
})
export class AnswerAddEditDeleteQuestionComponent implements OnInit {

  public answerId: number;
  public answerText: string;
  public operationStatus: string;
  public isSurvey: boolean;
  public isRightAnswer?: boolean;
  public evaluation: any;
  public evaluationId: any;

  @Input() public QuestionId: number;

  @Input() Answer: AnswerModel;
  @Input() Index: string;
  
  @Input() AnswerEditComponentValues: any[];
  @Output() AnswerEditComponentValuesChange = new EventEmitter();

  constructor(
    public shared: SharedService,
    private route: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.answerId = this.Answer.id
    this.answerText = this.Answer.answerText;
    this.isSurvey = this.Answer.isSurvey;
    debugger;
    this.isRightAnswer = this.Answer.isRightAnswer;
    this.evaluationId = this.route.snapshot.paramMap.get('evaluationid');
    this.getIsSurveyInfo(this.evaluationId);
  }

  getIsSurveyInfo(id: any) {
    this.shared.getEvaluation(id).subscribe(data => {
      this.evaluation = data;
      debugger;
      this.isSurvey = data.isSurvey;
    });
  }
    
  save(form: NgForm) {
    if(!this.answerId)
    {
      form.value.questionId = this.QuestionId;
      form.value.isRightAnswer = this.isRightAnswer;
      const credentials = JSON.stringify(form.value);
      this.shared.addAnswer(credentials).subscribe(response => {
        this.Answer.id = response.id;
        this.answerId = response.id
        this.answerText = response.answerText;
        this.isSurvey = response.isSurvey;
        this.isRightAnswer = response.isRightAnswer;
        alert("Kaydetme işlemi başarıyla tamamlandı");
        this.router.navigate(["/evaluations/"+this.evaluationId+"/questions/edit/"+this.QuestionId]);
      }, err => {
        console.log(err);
      });
    }else //update mode
    {
      form.value.id = this.Answer.id;
      form.value.isSurvey = this.isSurvey;
      form.value.questionId = this.QuestionId;
      var credentials = JSON.stringify(form.value);
      this.shared.updateAnswer(credentials).subscribe(response => {
        this.answerId = response.id
        this.answerText = response.answerText;
        this.isSurvey = response.isSurvey;
        this.isRightAnswer = response.isRightAnswer;
        alert("Güncelleme işlemi başarıyla tamamlandı");
        this.router.navigate(["/evaluations/"+this.evaluationId+"/questions/edit/"+this.QuestionId]);
      }, err => {
        console.log(err);
      });
    }
  }

  removeComponent() {
    if(this.answerId && this.answerId != 0)
    {
      this.shared.deleteAnswer(this.answerId).subscribe(() => {
        this.AnswerEditComponentValues.splice(Number(this.Index), 1);
      });
    }else {
      this.AnswerEditComponentValues.splice(Number(this.Index), 1);
    }
  }

}
