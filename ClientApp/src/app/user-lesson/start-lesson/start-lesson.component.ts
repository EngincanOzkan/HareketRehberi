import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-start-lesson',
  templateUrl: './start-lesson.component.html',
  styleUrls: ['./start-lesson.component.css']
})
export class StartLessonComponent implements OnInit {

  @Input() lessonId: any;
  @Input() userId: any;
  @Input() lessonTitle:string;
  @Input() startLesson: boolean;
  @Output() startLessonChange = new EventEmitter();
  @Input() operationIdentifier: any;
  @Output() operationIdentifierChange = new EventEmitter();

  constructor(
    public route: ActivatedRoute,
    public shared: SharedService
  ) { }

  ngOnInit(): void {

  }

  startLessonClick() {
    var data = {
      UserId: this.userId,
      lessonId: this.lessonId
    }
    this.shared.userLessonProgressLogCreateStartLog(data).subscribe(response => {
      this.operationIdentifier = response.operationIdentifier;
      this.operationIdentifierChange.emit(this.operationIdentifier);
      this.startLesson=true;
      this.startLessonChange.emit(this.startLesson);
    });
  }

}
