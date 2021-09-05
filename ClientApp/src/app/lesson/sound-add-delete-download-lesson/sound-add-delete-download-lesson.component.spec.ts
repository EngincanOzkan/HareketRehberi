import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SoundAddDeleteDownloadLessonComponent } from './sound-add-delete-download-lesson.component';

describe('SoundAddDeleteDownloadLessonComponent', () => {
  let component: SoundAddDeleteDownloadLessonComponent;
  let fixture: ComponentFixture<SoundAddDeleteDownloadLessonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SoundAddDeleteDownloadLessonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SoundAddDeleteDownloadLessonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
