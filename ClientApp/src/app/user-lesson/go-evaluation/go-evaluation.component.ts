import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-go-evaluation',
  templateUrl: './go-evaluation.component.html',
  styleUrls: ['./go-evaluation.component.css']
})
export class GoEvaluationComponent implements OnInit {

  @Input() lessonId: any;
  @Input() evaluationId: any;

  constructor() { }

  ngOnInit(): void {
  }

}
