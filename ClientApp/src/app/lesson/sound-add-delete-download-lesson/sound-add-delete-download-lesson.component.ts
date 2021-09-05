import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-sound-add-delete-download-lesson',
  templateUrl: './sound-add-delete-download-lesson.component.html',
  styleUrls: ['./sound-add-delete-download-lesson.component.css']
})
export class SoundAddDeleteDownloadLessonComponent implements OnInit {

  public UploadedSoundFileStatus: string;
  public UploadedSoundFileName: string;
  public SoundFileProgress: number;
  public blob: any;
  @Output() public onUploadFinished = new EventEmitter();
  @Input() public LessonId: number;

  @Input() Index: string;

  @Input() SoundComponentValues: any[];
  @Output() SoundComponentValuesChange = new EventEmitter();

  constructor(
    public shared: SharedService
  ) { }

  ngOnInit(): void {
    this.uploadedFileName(this.LessonId);
  }
  
  public uploadedFileName(lessonId: number) {
    this.shared.LessonPdfFileInfo(lessonId).subscribe((data: { fileName: string; }) => {
      this.UploadedSoundFileName = data.fileName ? data.fileName : "";
    });
  }

  removeComponent() {
    console.log(this.Index)
    this.SoundComponentValues.splice(Number(this.Index), 1);
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
        this.SoundFileProgress = Math.round(100 * event.loaded / total);
      }
      else if (event.type === HttpEventType.Response) {

        this.UploadedSoundFileStatus = 'Yüklem Tamamlandı';
        this.UploadedSoundFileName = fileToUpload.name;
        this.onUploadFinished.emit(event.body);
      }
    });
  }

  public showSound(lessonId: any): void {
    this.shared.downloadLessonPdf(lessonId)
        .subscribe(data => {
          this.blob = new Blob([data], {type: '.mp3'});
          
          var downloadURL = window.URL.createObjectURL(data);
          var link = document.createElement('a');
          link.href = downloadURL;
          link.target = "_blank";
          link.download = this.UploadedSoundFileName;
          link.click();
      });
  }

}
