import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PdfAddDeleteDownloadLessonComponent } from './pdf-add-delete-download-lesson.component';

describe('PdfAddDeleteDownloadLessonComponent', () => {
  let component: PdfAddDeleteDownloadLessonComponent;
  let fixture: ComponentFixture<PdfAddDeleteDownloadLessonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PdfAddDeleteDownloadLessonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PdfAddDeleteDownloadLessonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
