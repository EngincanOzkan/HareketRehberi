import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonEvaluationMatchComponent } from './lesson-evaluation-match.component';

describe('LessonEvaluationMatchComponent', () => {
  let component: LessonEvaluationMatchComponent;
  let fixture: ComponentFixture<LessonEvaluationMatchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonEvaluationMatchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LessonEvaluationMatchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
