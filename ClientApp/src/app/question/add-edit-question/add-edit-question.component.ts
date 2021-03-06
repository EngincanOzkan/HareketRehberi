import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationsService } from 'angular2-notifications';
import { AnswerModel } from 'src/app/Models/AnswerModel';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-question',
  templateUrl: './add-edit-question.component.html',
  styleUrls: ['./add-edit-question.component.css']
})
export class AddEditQuestionComponent implements OnInit {

  public addEditPageTitle: string;
  public evaluationId: any;
  public questionText: string;
  public question: any;
  public AnswerEditComponentValues: AnswerModel[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private shared: SharedService,
    private _notifications: NotificationsService,
  ) { }

  ngOnInit(): void {
    const evaluationId = this.route.snapshot.paramMap.get('evaluationid');
    const id = this.route.snapshot.paramMap.get('id');
    this.evaluationId = evaluationId;
    if(id){
      this.addEditPageTitle = "Soruyu Düzenle";
      console.log(id);
      this.loadInfo(id);
    }else {
      this.addEditPageTitle = "Yeni Soru Tanımla";
    }
  }

  loadInfo(id: any) {
    this.shared.getQuestion(id).subscribe(data => {
      this.question = data;
      if(this.question && this.question.questionText) this.questionText = this.question.questionText;

      this.listAnswers();
    });
  }

  save(form: NgForm) {
    if(!this.question)
    {
      form.value.evaluationId = Number(this.evaluationId);
      const credentials = JSON.stringify(form.value);
      this.shared.addQuestion(credentials).subscribe(response => {
        this._notifications.success("Başarılı", "Kaydetme işlemi başarıyla tamamlandı", {timeOut:2000})
        this.router.navigate(["/evaluations/"+this.evaluationId+"/questions"]);
      }, err => {
        console.log(err);
      });
    }else //update mode
    {
      form.value.id = Number(this.question.id);
      form.value.evaluationId = Number(this.evaluationId);
      var credentials = JSON.stringify(form.value);
      this.shared.updateQuestion(credentials).subscribe(response => {
        this._notifications.success("Başarılı", "Güncelleme işlemi başarıyla tamamlandı", {timeOut:2000})
        this.router.navigate(["/evaluations/"+this.evaluationId+"/questions"]);
      }, err => {
        console.log(err);
      });
    }
  }

  addComponent() {
    this.AnswerEditComponentValues.push(new AnswerModel());
  }

  listAnswers() {
    if(this.question) {
      this.shared.getQuestionAnswerList(this.question.id).subscribe((data: AnswerModel[]) => {
        this.AnswerEditComponentValues = data;
      });
   }
  }

}
