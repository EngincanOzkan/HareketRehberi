import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-evaluation',
  templateUrl: './add-edit-evaluation.component.html',
  styleUrls: ['./add-edit-evaluation.component.css']
})
export class AddEditEvaluationComponent implements OnInit {

  public addEditPageTitle: string;
  public evaluation: any;
  public evaluationName: string;
  public isSurvey: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private shared: SharedService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if(id){
      this.addEditPageTitle = "Değerlendirmeyi Düzenle";
      console.log(id);
      this.loadInfo(id);
      console.log(this.evaluation);
    }else {
      this.addEditPageTitle = "Yeni Değerlendirme Tanımla";
    }
  }

  loadInfo(id: any) {
    this.shared.getEvaluation(id).subscribe(data => {
      this.evaluation = data;
      if(this.evaluation && this.evaluation.evaluationName) this.evaluationName = this.evaluation.evaluationName;
      if(this.evaluation && this.evaluation.isSurvey) this.isSurvey = this.evaluation.isSurvey;
    });
  }

  save(form: NgForm) {
    if(!this.evaluation)
    {
      const credentials = JSON.stringify(form.value);
      this.shared.addEvaluation(credentials).subscribe(response => {
        alert("Kaydetme işlemi başarıyla tamamlandı");
        this.router.navigate(["/evaluations"]);
      }, err => {
        console.log(err);
      });
    }else //update mode
    {
      form.value.id = this.evaluation.id;
      var credentials = JSON.stringify(form.value);
      this.shared.updateEvaluation(credentials).subscribe(response => {
        alert("Güncelleme işlemi başarıyla tamamlandı");
        this.router.navigate(["/evaluations"]);
      }, err => {
        console.log(err);
      });
    }
  }
}
