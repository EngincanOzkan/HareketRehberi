import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserLessonComponent } from './user-lesson.component';

describe('UserLessonComponent', () => {
  let component: UserLessonComponent;
  let fixture: ComponentFixture<UserLessonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserLessonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserLessonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
