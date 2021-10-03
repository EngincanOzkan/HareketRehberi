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

  getUsersLessons(val: any): Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+"/Lesson/GetUsersLessons/" + val)
  }

  getUsers_p_r_e(val: any): Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+"/Lesson/GetUsersProgressiveRelaxationExercises/" + val)
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

  ///START QUESTION
  getQuestionList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Evaluation");
  }

  getEvaluationQuestionsList(val: any): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Evaluation/"+val+"/Questions");
  }

  getQuestion(val: any): Observable<any>{
    return this.http.get(this.APIUrl+"/Question/" + val)
  }

  addQuestion(val: any){
    return this.http.post(this.APIUrl+"/Question", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  updateQuestion(val: any){
    return this.http.patch(this.APIUrl+"/Question", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  deleteQuestion(val: any){
    return this.http.delete(this.APIUrl+"/Question/"+val);
  }
  ///END QUESTION

  ///START ANSWER
  getAnswerList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Answer");
  }

  getQuestionAnswerList(val: any): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Question/"+val+"/Answers");
  }

  getAnswer(val: any): Observable<any>{
    return this.http.get(this.APIUrl+"/Answer/" + val)
  }

  addAnswer(val: any): Observable<any>{
    return this.http.post<any>(this.APIUrl+"/Answer", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  updateAnswer(val: any):  Observable<any>{
    return this.http.patch<any>(this.APIUrl+"/Answer", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  deleteAnswer(val: any){
    return this.http.delete(this.APIUrl+"/Answer/"+val);
  }
  ///END ANSWER

  ///START LESSONEVALUATION
  getLessonEvaluationList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/LessonEvaluationMatch");
  }

  getLessonEvaluation(val: any): Observable<any>{
    return this.http.get(this.APIUrl+"/LessonEvaluationMatch/" + val)
  }

  getLessonsEvaluationsByLessonId(val: any): Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+"/Lesson/"+val+"/evaluations")
  }

  addLessonEvaluation(val: any){
    return this.http.post(this.APIUrl+"/LessonEvaluationMatch", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  updateLessonEvaluation(val: any){
    return this.http.patch(this.APIUrl+"/LessonEvaluationMatch", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  deleteLessonEvaluation(val: any){
    return this.http.delete(this.APIUrl+"/LessonEvaluationMatch/"+val);
  }

  deleteLessonsEvaluation(val: any){
    return this.http.delete(this.APIUrl+"/LessonEvaluationMatch/DeleteLessonsEvaluation/"+val);
  }
  ///END LESSONEVALUATION

  ///START LESSONUSER
  getLessonUserMatchList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/LessonUserMatch");
  }

  getLessonUserMatch(val: any): Observable<any>{
    return this.http.get(this.APIUrl+"/LessonUserMatch/" + val)
  }

  getLessonUserMatchByLessonId(val: any): Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+"/LessonUserMatch/GetByLessonId/"+val)
  }

  getLessonUserMatchByUserId(val: any): Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+"/LessonUserMatch/GetByUserId/"+val)
  }

  addLessonUserMatch(val: any){
    return this.http.post(this.APIUrl+"/LessonUserMatch", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  updateLessonUserMatch(val: any){
    return this.http.patch(this.APIUrl+"/LessonUserMatch", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  deleteLessonUserMatch(val: any){
    return this.http.delete(this.APIUrl+"/LessonUserMatch/"+val);
  }

  deleteLessonUserMatchByLessonId(val: any){
    return this.http.delete(this.APIUrl+"/LessonUserMatch/DeleteLessonsUserMatches/"+val);
  }
  ///END LESSONUSER

  ///START USERLESSONPROGRESSLOG
  getUserLessonProgressLogList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/UserLessonProgressLog");
  }

  getUserLessonProgressLog(val: any): Observable<any>{
    return this.http.get(this.APIUrl+"/UserLessonProgressLog/" + val)
  }

  addUserLessonProgressLog(val: any): Observable<any>{
    return this.http.post<any>(this.APIUrl+"/UserLessonProgressLog", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  updateUserLessonProgressLog(val: any):  Observable<any>{
    return this.http.patch<any>(this.APIUrl+"/UserLessonProgressLog", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  deleteUserLessonProgressLog(val: any){
    return this.http.delete(this.APIUrl+"/UserLessonProgressLog/"+val);
  }

  userLessonProgressLogCreateStartLog(val: any): Observable<any>{
    return this.http.post<any>(this.APIUrl+"/UserLessonProgressLog/CreateStartLog", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  userLessonProgressLogCreateEndLog(val: any): Observable<any>{
    return this.http.post<any>(this.APIUrl+"/UserLessonProgressLog/CreateEndLog", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  getUserLessonLastStartLog(userId: any, lessonId:any): Observable<any>{
    return this.http.get(this.APIUrl+"/UserLessonProgressLog/GetUserLessonLastStartLog/" + userId + "/" + lessonId)
  }

  getUserLessonLastEndLog(userId: any, lessonId:any): Observable<any>{
    return this.http.get(this.APIUrl+"/UserLessonProgressLog/GetUserLessonLastEndLog/" + userId + "/" + lessonId)
  }

  getUserLessonEndLogByGuid(guid: any): Observable<any>{
    return this.http.get(this.APIUrl+"/UserLessonProgressLog/getUserLessonEndLogByGuid/" + guid)
  }

  getUserLessonStartLogByGuid(guid: any): Observable<any>{
    return this.http.get(this.APIUrl+"/UserLessonProgressLog/GetUserLessonStartLogByGuid/" + guid)
  }

  getUserLessonStartLogs(userId: any, lessonId:any): Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+"/UserLessonProgressLog/GetUserLessonStartLogs/" + userId + "/" + lessonId)
  }

  getUserLessonEndLogs(userId: any, lessonId:any): Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+"/UserLessonProgressLog/GetUserLessonEndLogs/" + userId + "/" + lessonId)
  }

  getUserLessonLogsGeneral(userId: any): Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+"/UserLessonProgressLog/GetUserLessonLogsGeneral/" + userId)
  }

  
  getUserLessonLogsToday(userId: any): Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+"/UserLessonProgressLog/GetUserLessonLogsToday/" + userId)
  }
  
  getUserLessonLogsGeneralPre(userId: any): Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+"/UserLessonProgressLog/getUserLessonLogsGeneralPre/" + userId)
  }
  ///END USERLESSONPROGRESSLOG

  ///START UserLessonsEvaluationsQuestionsAnswers
  getLEQAList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/UserLessonsEvaluationsQuestionsAnswers");
  }

  getLEQA(val: any): Observable<any>{
    return this.http.get(this.APIUrl+"/UserLessonsEvaluationsQuestionsAnswers/" + val)
  }

  addLEQA(val: any): Observable<any>{
    return this.http.post<any>(this.APIUrl+"/UserLessonsEvaluationsQuestionsAnswers", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  updateLEQA(val: any):  Observable<any>{
    return this.http.patch<any>(this.APIUrl+"/UserLessonsEvaluationsQuestionsAnswers", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  updateEvaluationAnswer(leqaId: any, answerId: any):  Observable<any>{
    return this.http.patch<any>(this.APIUrl+"/UserLessonsEvaluationsQuestionsAnswers/UpdateAnswer/"+leqaId+"/"+answerId, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  startEvaluation(val: any): Observable<any>{
    return this.http.post<any>(this.APIUrl+"/UserLessonsEvaluationsQuestionsAnswers/StartEvaluation", val, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  deleteLEQA(val: any){
    return this.http.delete(this.APIUrl+"/UserLessonsEvaluationsQuestionsAnswers/"+val);
  }
  ///END UserLessonsEvaluationsQuestionsAnswers
}
