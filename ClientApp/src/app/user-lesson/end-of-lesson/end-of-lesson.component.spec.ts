import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EndOfLessonComponent } from './end-of-lesson.component';

describe('EndOfLessonComponent', () => {
  let component: EndOfLessonComponent;
  let fixture: ComponentFixture<EndOfLessonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EndOfLessonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EndOfLessonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
