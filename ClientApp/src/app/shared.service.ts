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

  deleteSystemUser(val: any) {
    return this.http.delete(this.APIUrl+"/SystemUser/"+val);
  }
  ///END SYSTEMUSER

  ///START LESSON
  getLessonList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Lesson");
  }

  getLesson(val: any): Observable<any>{
    return this.http.get(this.APIUrl+"/Lesson/" + val)
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

  ///START PDF FILE OPERATIONS
  uploadLessonPdf(val: any){
    return this.http.post(this.APIUrl +'/PdfFile/upload', val, { reportProgress: true, observe: 'events' });
  }
  downloadLessonPdf(val: any){
    return this.http.get(this.APIUrl +'/PdfFile/download/'+val,  { responseType: 'blob' });
  }
  downloadLessonPdfUrl(val: any):string{
    return this.APIUrl +'/PdfFile/download/'+val;
  }
  lessonPdfFileInfo(val: any): any{
    return this.http.get(this.APIUrl +'/PdfFile/LessonFileInfo/'+val);
  }
  ///END PDF FILE OPERATIONS

  ///START SOUND FILE OPERATIONS
  uploadLessonSound(val: any){
    return this.http.post(this.APIUrl +'/SoundFile/upload', val, { reportProgress: true, observe: 'events' });
  }
  downloadLessonSound(val: any){
    return this.http.get(this.APIUrl +'/SoundFile/download/'+val,  { responseType: 'blob' });
  }
  downloadLessonSoundBlob(lessonId: any, pageNumber: any){
    return this.http.get(this.APIUrl +'/SoundFile/download/'+lessonId+"/"+pageNumber,  { responseType: 'blob' });
  }
  lessonSoundFileInfo(val: any): any{
    return this.http.get(this.APIUrl +'/SoundFile/LessonFileInfo/'+val);
  }
  deleteLessonSound(val: any): any{
    return this.http.delete(this.APIUrl +'/SoundFile/'+val);
  }
  ///END SOUND FILE OPERATIONS

  ///START EVALUATION
  getEvaluationList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Evaluation");
  }

  getEvaluation(val: any): Observable<any>{
    return this.http.get(this.APIUrl+"/Evaluation/" + val)
  }

  addEvaluation(val: any){
    return this.http.post(this.APIUrl+"/Evaluation", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  updateEvaluation(val: any){
    return this.http.patch(this.APIUrl+"/Evaluation", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  deleteEvaluation(val: any){
    return this.http.delete(this.APIUrl+"/Evaluation/"+val);
  }
  ///END EVALUATION
}
