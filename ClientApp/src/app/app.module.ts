import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';

import dayjs from 'dayjs';
import { CalendarDateFormatter,
  CalendarModule,
  CalendarMomentDateFormatter,
  DateAdapter,
  MOMENT
} from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SimpleNotificationsModule } from 'angular2-notifications';

import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './guards/auth.guard';
import { AdminAuthGuard } from './guards/admin-auth.guard';
import { SystemUserComponent } from './system-user/system-user.component';
import { ShowUserComponent } from './system-user/show-user/show-user.component';
import { AddEditUserComponent } from './system-user/add-edit-user/add-edit-user.component';
import { SharedService } from './shared.service';
import { LessonComponent } from './lesson/lesson.component';
import { AddEditLessonComponent } from './lesson/add-edit-lesson/add-edit-lesson.component';
import { ShowLessonComponent } from './lesson/show-lesson/show-lesson.component';
import { PdfAddDeleteDownloadLessonComponent } from './lesson/pdf-add-delete-download-lesson/pdf-add-delete-download-lesson.component';
import { SoundAddDeleteDownloadLessonComponent } from './lesson/sound-add-delete-download-lesson/sound-add-delete-download-lesson.component';
import { UserMainScreenComponent } from './user-main-screen/user-main-screen.component';
import { UserLessonComponent } from './user-lesson/user-lesson.component';
import { PdfViewerModule } from 'ng2-pdf-viewer';
import { EvaluationComponent } from './evaluation/evaluation.component';
import { AddEditEvaluationComponent } from './evaluation/add-edit-evaluation/add-edit-evaluation.component';
import { ShowEvaluationsComponent } from './evaluation/show-evaluations/show-evaluations.component';
import { QuestionComponent } from './question/question.component';
import { AddEditQuestionComponent } from './question/add-edit-question/add-edit-question.component';
import { ShowQuestionsComponent } from './question/show-questions/show-questions.component';
import { AnswerAddEditDeleteQuestionComponent } from './question/answer-add-edit-delete-question/answer-add-edit-delete-question.component';
import { LessonEvaluationMatchComponent } from './lesson-evaluation-match/lesson-evaluation-match.component';
import { ShowCheckMatchComponent } from './lesson-evaluation-match/show-check-match/show-check-match.component';
import { LessonUserMatchComponent } from './lesson-user-match/lesson-user-match.component';
import { UserShowCheckMatchLessonComponent } from './lesson-user-match/user-show-check-match-lesson/user-show-check-match-lesson.component';
import { EndOfLessonComponent } from './user-lesson/end-of-lesson/end-of-lesson.component';
import { GoEvaluationComponent } from './user-lesson/go-evaluation/go-evaluation.component';
import { StartLessonComponent } from './user-lesson/start-lesson/start-lesson.component';
import { UserPREComponent } from './user-p-r-e/user-p-r-e.component';
import { BottomNavbarComponent } from './bottom-navbar/bottom-navbar.component';

export function tokenGetter() {
  return localStorage.getItem('jwt');
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NotFoundComponent,
    MenuComponent,
    HomeComponent,
    AdminComponent,
    SystemUserComponent,
    ShowUserComponent,
    AddEditUserComponent,
    LessonComponent,
    AddEditLessonComponent,
    ShowLessonComponent,
    PdfAddDeleteDownloadLessonComponent,
    SoundAddDeleteDownloadLessonComponent,
    UserMainScreenComponent,
    UserLessonComponent,
    EvaluationComponent,
    AddEditEvaluationComponent,
    ShowEvaluationsComponent,
    QuestionComponent,
    AddEditQuestionComponent,
    ShowQuestionsComponent,
    AnswerAddEditDeleteQuestionComponent,
    LessonEvaluationMatchComponent,
    ShowCheckMatchComponent,
    LessonUserMatchComponent,
    UserShowCheckMatchLessonComponent,
    EndOfLessonComponent,
    GoEvaluationComponent,
    StartLessonComponent,
    UserPREComponent,
    BottomNavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    PdfViewerModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'admin', component: AdminComponent, canActivate: [AdminAuthGuard] },
      { path: 'users', component: SystemUserComponent, canActivate: [AdminAuthGuard] },
      { path: 'users/add', component: AddEditUserComponent, canActivate: [AdminAuthGuard] },
      { path: 'users/edit', component: AddEditUserComponent, canActivate: [AdminAuthGuard] },
      { path: 'lessons', component: LessonComponent, canActivate: [AdminAuthGuard] },
      { path: 'lessons/add', component: AddEditLessonComponent, canActivate: [AdminAuthGuard] },
      { path: 'lessons/edit', component: AddEditLessonComponent, canActivate: [AdminAuthGuard] },
      { path: 'lessons/:lessonid/evaluation/match', component: LessonEvaluationMatchComponent, canActivate: [AdminAuthGuard] },
      { path: 'lessons/:lessonid/user/match', component: LessonUserMatchComponent, canActivate: [AdminAuthGuard] },
      { path: 'my', component: UserMainScreenComponent, canActivate: [AuthGuard] },
      { path: 'mypre', component: UserPREComponent, canActivate: [AuthGuard] },
      { path: 'evaluations', component: EvaluationComponent, canActivate: [AdminAuthGuard] },
      { path: 'evaluations/add', component: AddEditEvaluationComponent, canActivate: [AdminAuthGuard] },
      { path: 'evaluations/edit/:id', component: AddEditEvaluationComponent, canActivate: [AdminAuthGuard] },
      { path: 'evaluations/:evaluationid/questions', component: QuestionComponent, canActivate: [AdminAuthGuard] },
      { path: 'evaluations/:evaluationid/questions/add', component: AddEditQuestionComponent, canActivate: [AdminAuthGuard] },
      { path: 'evaluations/:evaluationid/questions/edit/:id', component: AddEditQuestionComponent, canActivate: [AdminAuthGuard] },
      { path: 'lesson', component: UserLessonComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: '404', component : NotFoundComponent},
      { path: '', redirectTo: '/home', pathMatch: 'full' },
      { path: '**', redirectTo: '/404', pathMatch: 'full'}
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:5001'],
        disallowedRoutes: []
      }
    }),
    CalendarModule.forRoot(
      {
        provide: DateAdapter,
        useFactory: adapterFactory,
      },
      {
        dateFormatter: {
          provide: CalendarDateFormatter,
          useClass: CalendarMomentDateFormatter,
        },
      }
    ),
    SimpleNotificationsModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [AuthGuard, AdminAuthGuard, SharedService, { provide: MOMENT, useValue: dayjs },],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
