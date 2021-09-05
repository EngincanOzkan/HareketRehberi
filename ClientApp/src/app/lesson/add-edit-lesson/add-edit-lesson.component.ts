import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-lesson',
  templateUrl: './add-edit-lesson.component.html',
  styleUrls: ['./add-edit-lesson.component.css']
})
export class AddEditLessonComponent implements OnInit {
  public Lesson: any;
  public AddEditPageTitle: string;
  public LessonName: string;
  public SoundComponentValues: any[] = [];

  constructor(
    private shared: SharedService,
    private router: Router,
  ) { 
    this.AddEditPageTitle = shared.AddLessonTitle;
    this.Lesson = shared.Lesson;
    if(this.Lesson && this.Lesson.lessonName) this.LessonName = this.Lesson.lessonName;
  }

  ngOnInit(): void {
  }

  save(form: NgForm) {
    if(!this.Lesson)
    {
      const credentials = JSON.stringify(form.value);
      this.shared.addLesson(credentials).subscribe(response => {
        alert("Kaydetme işlemi başarıyla tamamlandı");
        this.router.navigate(["/lessons"]);
      }, err => {
        console.log(err);
      });
    }else //update mode
    {
      form.value.id = this.Lesson.id;
      var credentials = JSON.stringify(form.value);
      this.shared.updateLesson(credentials).subscribe(response => {
        alert("Güncelleme işlemi başarıyla tamamlandı");
        this.router.navigate(["/lessons"]);
      }, err => {
        console.log(err);
      });
    }
  }
  
  addComponent() {
    this.SoundComponentValues.push({value:""});
  }
}
