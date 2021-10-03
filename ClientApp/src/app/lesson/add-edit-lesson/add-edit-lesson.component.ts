import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { NotificationsService } from 'angular2-notifications';
import { SoundFile } from 'src/app/Models/SoundFileModel';
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
  public ProgressiveRelaxationExercise: boolean;
  public SoundComponentValues: SoundFile[] = [];

  constructor(
    private shared: SharedService,
    private router: Router,
    private _notifications: NotificationsService
  ) { 
    this.AddEditPageTitle = shared.AddLessonTitle;
    this.Lesson = shared.Lesson;
    if(this.Lesson && this.Lesson.lessonName) this.LessonName = this.Lesson.lessonName;
    if(this.Lesson && this.Lesson.progressiveRelaxationExercise) this.ProgressiveRelaxationExercise = this.Lesson.progressiveRelaxationExercise;
  }

  ngOnInit(): void {
    this.listSounds();
  }

  save(form: NgForm) {
    if(!this.Lesson)
    {
      const credentials = JSON.stringify(form.value);
      this.shared.addLesson(credentials).subscribe(response => {
        this._notifications.success("Başarılı", "Kaydetme işlemi başarıyla tamamlandı", {timeOut:2000})
        this.router.navigate(["/lessons"]);
      }, err => {
        console.log(err);
      });
    }else //update mode
    {
      form.value.id = this.Lesson.id;
      var credentials = JSON.stringify(form.value);
      this.shared.updateLesson(credentials).subscribe(response => {
        this._notifications.success("Başarılı", "Güncelleme işlemi başarıyla tamamlandı", {timeOut:2000})
        this.router.navigate(["/lessons"]);
      }, err => {
        console.log(err);
      });
    }
  }

  addComponent() {
    this.SoundComponentValues.push(new SoundFile());
  }

  listSounds() {
    if(this.Lesson) {
      this.shared.lessonSoundFileInfo(this.Lesson.id).subscribe((data: SoundFile[]) => {
        this.SoundComponentValues = data;
      });
   }
  }
}
