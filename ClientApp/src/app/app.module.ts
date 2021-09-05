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
    PdfAddDeleteDownloadLessonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'admin', component: AdminComponent, canActivate: [AdminAuthGuard] },
      { path: 'users', component: SystemUserComponent, canActivate: [AdminAuthGuard] },
      { path: 'users/add', component: AddEditUserComponent, canActivate: [AdminAuthGuard] },
      { path: 'users/edit', component: AddEditUserComponent, canActivate: [AdminAuthGuard] },
      { path: 'lessons', component: LessonComponent, canActivate: [AdminAuthGuard] },
      { path: 'lessons/add', component: AddEditLessonComponent, canActivate: [AdminAuthGuard] },
      { path: 'lessons/edit', component: AddEditLessonComponent, canActivate: [AdminAuthGuard] },
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
    })
  ],
  providers: [AuthGuard, AdminAuthGuard, SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
