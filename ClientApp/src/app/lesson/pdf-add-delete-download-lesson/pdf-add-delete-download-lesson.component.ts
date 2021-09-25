import { HttpEventType } from '@angular/common/http';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-pdf-add-delete-download-lesson',
  templateUrl: './pdf-add-delete-download-lesson.component.html',
  styleUrls: ['./pdf-add-delete-download-lesson.component.css']
})
export class PdfAddDeleteDownloadLessonComponent implements OnInit {
  public UploadedPdfFileStatus: string;
  public UploadedPdfFileName: string;
  public PdfFileProgress: number;
  public blob: any;
  @Output() public onUploadFinished = new EventEmitter();
  @Input() public LessonId: number;

  constructor(
    private shared: SharedService
  ) { }

  ngOnInit(): void {
    this.uploadedFileName(this.LessonId);
  }

  public uploadedFileName(lessonId: number) {
    this.shared.lessonPdfFileInfo(lessonId).subscribe((data: { fileName: string; }) => {
      if(data) this.UploadedPdfFileName = data.fileName ? data.fileName : "";
    });
  }

  public uploadFile(files: any) {
    if (files.length === 0) return;

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append("file", fileToUpload, fileToUpload.name);
    formData.append("LessonId", this.LessonId.toString());
    this.shared.uploadLessonPdf(formData).subscribe(event => {
      console.log(event);
      if (event.type === HttpEventType.UploadProgress) {
        const total: number = event.total ? event.total : 1;  
        this.PdfFileProgress = Math.round(100 * event.loaded / total);
      }
      else if (event.type === HttpEventType.Response) {

        this.UploadedPdfFileStatus = 'Yüklem Tamamlandı';
        this.UploadedPdfFileName = fileToUpload.name;
        this.onUploadFinished.emit(event.body);
      }
    });
  }

  public showPDF(lessonId: any): void {
    this.shared.downloadLessonPdf(lessonId)
        .subscribe(data => {
          this.blob = new Blob([data], {type: 'application/pdf'});
          
          var downloadURL = window.URL.createObjectURL(data);
          var link = document.createElement('a');
          link.href = downloadURL;
          link.target = "_blank";
          link.download = this.UploadedPdfFileName;
          link.click();
      });
  }
}
