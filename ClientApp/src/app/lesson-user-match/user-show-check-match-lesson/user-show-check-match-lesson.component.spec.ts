import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserShowCheckMatchLessonComponent } from './user-show-check-match-lesson.component';

describe('UserShowCheckMatchLessonComponent', () => {
  let component: UserShowCheckMatchLessonComponent;
  let fixture: ComponentFixture<UserShowCheckMatchLessonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserShowCheckMatchLessonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserShowCheckMatchLessonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
