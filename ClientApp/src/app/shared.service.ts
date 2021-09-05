import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "https://localhost:5001/api"

  public AddSystemUsertitle: string="";
  public SystemUser: any = null;
  
  public AddLessonTitle: string="";
  public Lesson: any = null;

  constructor(private http:HttpClient) { 
    this.AddSystemUsertitle = "Yeni Kullanıcı Tanımla";
    this.SystemUser = null;

    this.AddLessonTitle = "Yeni Eğitim Tanımla";
    this.Lesson = null;
  }

  ///START SYSTEMUSER
  getSystemUserList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/SystemUser");
  }

  addSystemUser(val: any){
    return this.http.post(this.APIUrl+"/SystemUser", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  updateSystemUser(val: any){
    return this.http.patch(this.APIUrl+"/SystemUser", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  deleteSystemUser(val: any){
    return this.http.delete(this.APIUrl+"/SystemUser/"+val);
  }
  ///END SYSTEMUSER

  ///START LESSON
  getLessonList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Lesson");
  }

  addLesson(val: any){
    return this.http.post(this.APIUrl+"/Lesson", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  updateLesson(val: any){
    return this.http.patch(this.APIUrl+"/Lesson", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  deleteLesson(val: any){
    return this.http.delete(this.APIUrl+"/Lesson/"+val);
  }
  ///END LESSON

  ///START FILE OPERATIONS
  uploadLessonPdf(val: any){
    return this.http.post(this.APIUrl +'/PdfFile/upload', val, { reportProgress: true, observe: 'events' });
  }
  downloadLessonPdf(val: any){
    return this.http.get(this.APIUrl +'/PdfFile/download/'+val,  { responseType: 'blob' });
  }
  LessonPdfFileInfo(val: any): any{
    return this.http.get(this.APIUrl +'/PdfFile/FileInfo/'+val);
  }
  ///END FILE OPERATIONS
}
