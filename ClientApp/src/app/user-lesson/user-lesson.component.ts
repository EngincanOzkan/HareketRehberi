import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SharedService } from '../shared.service';
import { PdfViewerModule } from 'ng2-pdf-viewer';

@Component({
  selector: 'app-user-lesson',
  templateUrl: './user-lesson.component.html',
  styleUrls: ['./user-lesson.component.css']
})
export class UserLessonComponent implements OnInit {
  public lessonId: any;
  public token: string | null;
  public pdfUrl: string;
  public lessonTitle: string;
  public page: number = 1;
  public blob: any;
  public soundDownloadUrl: any;
  public audio = new Audio();

  public pdfObject = {
    url: 'some url to PDF',
    httpHeaders: { Authorization: 'Bearer XYZ' },
  }

  constructor(
    public route: ActivatedRoute,
    public shared: SharedService
  ) { 
    this.lessonId = Number(this.route.snapshot.paramMap.get('id'));
    this.token = localStorage.getItem('jwt');
    if(this.lessonId){
      this.pdfUrl = this.shared.downloadLessonPdfUrl(this.lessonId);
      this.pdfObject.url = this.pdfUrl;
      this.pdfObject.httpHeaders.Authorization = "Bearer " + this.token;
    }
  }

  ngOnInit(): void {
    this.getLesson();
    this.showSound(this.lessonId);
  }

  getLesson() {
    this.shared.getLesson(this.lessonId).subscribe(data => {
      this.lessonTitle = data.lessonName;
    })
  }

  nextPage() {
      this.page++;
      this.showSound(this.lessonId);
  }

  playAudio(){
    
    if(this.audio.paused)
    {
      this.audio.src = this.soundDownloadUrl;
      this.audio.load();
      this.audio.play();
    }else {
      this.audio.pause();
      this.audio.currentTime = 0;
    }
  }

  public showSound(lessonId: any): void {
    this.shared.downloadLessonSoundBlob(lessonId, this.page)
        .subscribe(data => {
          this.blob = new Blob([data], {type: '.mp3'});
          this.soundDownloadUrl = window.URL.createObjectURL(data);
      });
  }

  previousPage() {
    if(this.page > 1)
    {
      this.page--;
    }
    this.showSound(this.lessonId);
  }
}
