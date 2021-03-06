import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SharedService } from '../shared.service';
import { PDFDocumentProxy, PdfViewerModule } from 'ng2-pdf-viewer';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-user-lesson',
  templateUrl: './user-lesson.component.html',
  styleUrls: ['./user-lesson.component.css']
})
export class UserLessonComponent implements OnInit,  AfterViewInit {
  public lessonId: any;
  public token: string | null;
  public pdfUrl: string;
  public lessonTitle: string;
  public page: number = 1;
  public blob: any;
  public soundDownloadUrl: any;
  public audio = new Audio();
  public totalPages: number;
  public endLesson: boolean = false;
  public goEvaluation: boolean = false;
  public startLesson: boolean = false;
  public startEvaluation: boolean = false;
  public evaluation: any;
  public operationIdentifier: any; //guid
  public userId: any;
  public endText: string = "";

  public pdfObject = {
    url: 'some url to PDF',
    httpHeaders: { Authorization: 'Bearer XYZ' },
  }

  constructor(
    public route: ActivatedRoute,
    public shared: SharedService,
    private spinner: NgxSpinnerService
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
    this.userId = Number(localStorage.getItem("userId"));
    this.getLesson();
    this.showSound(this.lessonId);
  }

  ngAfterViewInit(){
    this.spinner.show();
  }

  getLesson() {
    this.shared.getLesson(this.lessonId).subscribe(data => {
      this.lessonTitle = data.lessonName;
      this.getLessonEvaluation();
    })
  }

  getLessonEvaluation() {
    this.shared.getLessonsEvaluationsByLessonId(this.lessonId).subscribe(data => {
      this.evaluation = data[0];
    })
  }

  nextPage() {
    if(this.page < this.totalPages)
    {
      this.page++;
      this.audio.pause();
      this.audio.currentTime = 0;
      this.showSound(this.lessonId);
      if(this.page >= this.totalPages-1){
        this.endText = "Bitir";
      }
    }else if(this.page >= this.totalPages && !this.evaluation)
    {
      var data = {
        UserId: Number(this.userId),
        lessonId: Number(this.lessonId),
        operationIdentifier: this.operationIdentifier,
      }
      this.shared.userLessonProgressLogCreateEndLog(data).subscribe(response => {
        this.audio.pause();
        this.audio.currentTime = 0;
        this.endLesson = true;
      });

    }else if(this.page >= this.totalPages && this.evaluation)
    {
      this.audio.pause();
      this.audio.currentTime = 0;
      this.goEvaluation = true;
    }
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
    this.soundDownloadUrl = null;
    this.shared.downloadLessonSoundBlob(lessonId, this.page)
        .subscribe(data => {
          this.blob = new Blob([data], {type: '.mp3'});
          this.soundDownloadUrl = window.URL.createObjectURL(data);
      }, (error) => {
        this.soundDownloadUrl = null;
      });
  }

  previousPage() {
    this.audio.pause();
    this.audio.currentTime = 0;

    this.endText = "";
    if(this.page > 1)
    {
      this.page--;
    }
    this.showSound(this.lessonId);
  }

  callBackFn(pdf: PDFDocumentProxy){
    this.totalPages = pdf.numPages;
    this.spinner.hide();
  }
}
