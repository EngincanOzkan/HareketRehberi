import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SoundFile } from 'src/app/Models/SoundFileModel';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-sound-add-delete-download-lesson',
  templateUrl: './sound-add-delete-download-lesson.component.html',
  styleUrls: ['./sound-add-delete-download-lesson.component.css']
})
export class SoundAddDeleteDownloadLessonComponent implements OnInit {
  
  public UploadedSoundFileStatus: string;
  public UploadedSoundFileName: string;
  public UploadedSoundFileId: number = 0;
  public SoundFileProgress: number;
  public PageNumber: number;

  public blob: any;
  @Output() public onUploadFinished = new EventEmitter();
  @Input() public LessonId: number;

  @Input() soundFile: SoundFile;
  @Input() Index: string;

  @Input() SoundComponentValues: any[];
  @Output() SoundComponentValuesChange = new EventEmitter();

  constructor(
    public shared: SharedService
  ) { }

  ngOnInit(): void {
    this.UploadedSoundFileName = this.soundFile.fileName;
    this.UploadedSoundFileId = this.soundFile.id;
    this.PageNumber = this.soundFile.pageNumber;
  }

  removeComponent() {
    if(this.UploadedSoundFileId && this.UploadedSoundFileId != 0)
    {
      this.shared.deleteLessonSound(this.UploadedSoundFileId).subscribe(() => {
        this.SoundComponentValues.splice(Number(this.Index), 1);
      });
    }else {
      this.SoundComponentValues.splice(Number(this.Index), 1);
    }
  }

  public uploadFile(files: any) {
    if (files.length === 0) return;
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append("file", fileToUpload, fileToUpload.name);
    formData.append("LessonId", this.LessonId.toString());
    formData.append("PageNumber", this.PageNumber.toString());
    this.shared.uploadLessonSound(formData).subscribe(event => {
      console.log(event);
      if (event.type === HttpEventType.UploadProgress) {
        const total: number = event.total ? event.total : 1;  
        this.SoundFileProgress = Math.round(100 * event.loaded / total);
      }
      else if (event.type === HttpEventType.Response) {
        this.soundFile = event.body as any;
        this.UploadedSoundFileStatus = 'Yüklem Tamamlandı';
        this.UploadedSoundFileName = fileToUpload.name;
        this.UploadedSoundFileId = this.soundFile.id;
        this.onUploadFinished.emit(event.body);
      }else {
        this.UploadedSoundFileStatus = 'Yüklem Tamamlanamadı, sayfa numaralarının aynı olmadığından emin olunuz.';
      }
    });
  }

  public showSound(lessonId: any): void {
    this.shared.downloadLessonSound(this.UploadedSoundFileId)
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

  setPageNumber(val:any){
    this.PageNumber = val;
  }

}
