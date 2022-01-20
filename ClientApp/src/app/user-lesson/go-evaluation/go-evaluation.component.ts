import { Component, ElementRef, EventEmitter, Inject, Input, OnInit, Output, QueryList, ViewChildren } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-go-evaluation',
  templateUrl: './go-evaluation.component.html',
  styleUrls: ['./go-evaluation.component.css']
})
export class GoEvaluationComponent implements OnInit {

  @Input() lessonId: any;

  @Input() isSurvey: boolean;
  @Input() evaluationId: any;
  @Input() lessonTitle: string;
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
  public answersDisabled: boolean;
  public notAnsweredQuestionIndexes: number[] = [];

  public goWithUnansweredQuestion: number = 0;

  @ViewChildren("myAnswers") answerElements: QueryList<any>

  public readonly answerIdTag: string = "answer_cell_"

  constructor(
    public route: ActivatedRoute,
    public router: Router,
    public shared: SharedService
  ) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem("userId");
  }

  startEvaluationClick() {
    console.log(this.questionIndex)
    console.log(this.questionData)
    var data = {
      UserId: Number(this.userId),
      LessonId: Number(this.lessonId),
      EvaluationId: this.evaluationId,
      OperationIdentifier: this.operationIdentifier
    }
    this.shared.startEvaluation(data).subscribe(response => {
      this.questionData = response;
      this.startEvaluation = true;
      this.startEvaluationChange.emit(this.startEvaluation);
    });
  }

  onItemChange(value: any) {
    this.shared.updateEvaluationAnswer(this.questionData[this.questionIndex].id, value).subscribe(response => {
      this.questionAnswers[this.questionIndex] = value;
    });
    console.log(" Value is : ", value);
    this.answersDisabled = true;

    this.showTrueAndFalseAnswers(value);
  }

  goNext() {
    if (this.questionIndex < this.questionData.length - 1) {
      if (!this.questionAnswers[this.questionIndex] && !this.notAnsweredQuestionIndexes.includes(this.questionIndex) && !this.isSurvey) {
        var response = confirm("Cevap vermediniz yine de geçmek istiyor musunuz? Soru boş kalacak ve değiştiremeyeceksiniz.");
        if (response) {
          this.notAnsweredQuestionIndexes.push(this.questionIndex);
          if(this.goWithUnAnsweredQuestionProcessor())
          {
            this.nextOperation();
          }
        }
      } else {
        if(this.notAnsweredQuestionIndexes.includes(this.questionIndex))
        {
          if(this.goWithUnAnsweredQuestionProcessor()) this.nextOperation()
        }else {
          this.nextOperation()
        }
      }
    } else if (this.questionIndex >= this.questionData.length - 1) {
      if (!this.questionAnswers[this.questionIndex] && !this.notAnsweredQuestionIndexes.includes(this.questionIndex) && !this.isSurvey) {
        var response = confirm("Cevap vermediniz yine de geçmek istiyor musunuz? Soru boş kalacak ve değiştiremeyeceksiniz.");
        if (response) {
          this.notAnsweredQuestionIndexes.push(this.questionIndex);
          if(this.goWithUnAnsweredQuestionProcessor()){
            var data = {
              UserId: Number(this.userId),
              lessonId: Number(this.lessonId),
              operationIdentifier: this.operationIdentifier,
            }
            this.shared.userLessonProgressLogCreateEndLog(data).subscribe(response => {
            });
          }
        }
      }else {
        if(this.goWithUnAnsweredQuestionProcessor())
        {
          var data = {
            UserId: Number(this.userId),
            lessonId: Number(this.lessonId),
            operationIdentifier: this.operationIdentifier,
          }
          this.shared.userLessonProgressLogCreateEndLog(data).subscribe(response => {
            this.evaluationEnd = true;
          });
        }
      }
    }
  }

  nextOperation() {
    this.questionIndex++;
    this.selectedAnswer = this.questionAnswers[this.questionIndex];

    if (this.selectedAnswer != undefined) {
      this.answersDisabled = true;
    } else {
      this.answersDisabled = false;
    }

    this.answerElements.changes.subscribe(t => {
      this.showTrueAndFalseAnswers(this.selectedAnswer);
    })

    if (this.questionIndex == this.questionData.length - 1) {
      this.endText = "Bitir";
    }
  }

  goPrevious() {
    if (this.questionIndex > 0) {
      this.questionIndex--;
      this.selectedAnswer = this.questionAnswers[this.questionIndex];
      this.endText = "";
      this.goWithUnansweredQuestion = 0;

      if (this.selectedAnswer != undefined) {
        this.answersDisabled = true;
      }

      this.answerElements.changes.subscribe(t => {
        this.showTrueAndFalseAnswers(this.selectedAnswer);
      })
    }
  }

  showTrueAndFalseAnswers(value: any) {
    if (!this.isSurvey) {
      this.answerElements.forEach((element: any) => {

        var emojiItem = element.nativeElement.children[1]
        console.log(emojiItem?.id);
        var addItem = true
        if ((emojiItem?.id == 'ans' || emojiItem?.id == 'realans' || this.selectedAnswer == null || this.selectedAnswer == undefined) && (emojiItem?.id == 'ans' || emojiItem?.id == 'realans' || !this.notAnsweredQuestionIndexes.includes(this.questionIndex))) {
          addItem = false;
        }

        if (addItem) {
          if (this.notAnsweredQuestionIndexes.includes(this.questionIndex)) {
            this.questionData[this.questionIndex].rightAnswers.forEach((rightAnswer: any) => {
              if (element.nativeElement.id == this.answerIdTag + rightAnswer) {
                element.nativeElement.insertAdjacentHTML('beforeend', '<i id="realans" class="bi bi-emoji-neutral-fill fs-6 text-warning"> </i>');
                this.answersDisabled = true;
              }
            })
          } else {
            if (element.nativeElement.id == this.answerIdTag + value) {

              if (this.questionData[this.questionIndex].rightAnswers.includes(value)) {
                element.nativeElement.insertAdjacentHTML('beforeend', '<i id="ans" class="bi bi-emoji-smile-fill fs-6 text-success"></i>');
              } else {
                element.nativeElement.insertAdjacentHTML('beforeend', '<i id="ans" class="bi bi-emoji-frown-fill fs-6 text-danger"> </i>');
              }
            }

            this.questionData[this.questionIndex].rightAnswers.forEach((rightAnswer: any) => {
              if ((element.nativeElement.id == this.answerIdTag + rightAnswer) && !this.questionData[this.questionIndex].rightAnswers.includes(value)) {
                element.nativeElement.insertAdjacentHTML('beforeend', '<i id="realans" class="bi bi-arrow-left-circle-fill fs-6 text-success"></i>');
              }
            })
          }
        }
      });
    }
  }

  goWithUnAnsweredQuestionProcessor() {
    if(this.selectedAnswer) return true;
    if(this.goWithUnansweredQuestion < 1){
      this.goWithUnansweredQuestion = this.goWithUnansweredQuestion + 1;
      this.showTrueAndFalseAnswers(undefined);
      return false;
    }else{
      this.goWithUnansweredQuestion = 0;
      return true;
    }
  }

}