import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonUserMatchComponent } from './lesson-user-match.component';

describe('LessonUserMatchComponent', () => {
  let component: LessonUserMatchComponent;
  let fixture: ComponentFixture<LessonUserMatchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonUserMatchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LessonUserMatchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
