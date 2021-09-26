import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-end-of-lesson',
  templateUrl: './end-of-lesson.component.html',
  styleUrls: ['./end-of-lesson.component.css']
})
export class EndOfLessonComponent implements OnInit {

  @Input() lessonId: any;
  @Input() evaluationId: any;

  constructor() { }

  ngOnInit(): void {
  }

}
