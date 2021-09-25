import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnswerAddEditDeleteQuestionComponent } from './answer-add-edit-delete-question.component';

describe('AnswerAddEditDeleteQuestionComponent', () => {
  let component: AnswerAddEditDeleteQuestionComponent;
  let fixture: ComponentFixture<AnswerAddEditDeleteQuestionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AnswerAddEditDeleteQuestionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AnswerAddEditDeleteQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
