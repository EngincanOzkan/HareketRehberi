import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-end-of-lesson',
  templateUrl: './end-of-lesson.component.html',
  styleUrls: ['./end-of-lesson.component.css']
})
export class EndOfLessonComponent implements OnInit {

  @Input() lessonId: any;
  @Input() evaluationId: any;

  constructor(
    public router: Router
  ) { }

  ngOnInit(): void {
  }

  endLesson() {
    this.router.navigate(['/my']);
  }
  
}
