import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CalendarEvent, 
  CalendarView,
  DAYS_OF_WEEK,
  CalendarMonthViewBeforeRenderEvent,
  CalendarDateFormatter,
  MOMENT
} from 'angular-calendar';
import dayjs from 'dayjs';
import tr from 'dayjs/locale/tr';
import { AdminAuthGuard } from '../guards/admin-auth.guard';
import { SharedService } from '../shared.service';

dayjs.locale({
  ...tr,
  weekStart: DAYS_OF_WEEK.MONDAY,
});

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  
  private userId: any;
  private preData: any[];

  view: CalendarView = CalendarView.Month;
  viewDate: Date = new Date();

  constructor(
    private shared: SharedService,
    private router: Router,
    private authAdminGuard: AdminAuthGuard,
    private jwtHelper: JwtHelperService
  ) {
    const token = localStorage.getItem('jwt');

    if(token && !this.jwtHelper.isTokenExpired(token) && this.jwtHelper.decodeToken(token)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === "Admin"){
      this.router.navigate(["/admin"]);
    } 
    
    dayjs.locale(tr);
    this.userId = localStorage.getItem("userId");
  }

  ngOnInit(): void {
    this.shared.getUserLessonLogsGeneralPre(this.userId).subscribe(data => {
      this.preData = data;
    });
  }

  events: CalendarEvent[] = [];

  beforeMonthViewRender(renderEvent: CalendarMonthViewBeforeRenderEvent): void {
    renderEvent.body.forEach((day) => {
      var _this = this;
      var interval = setInterval(function(){
          _this.daySigner(day, interval);
      },1000);
    });
  }

  daySigner(day: any, interval: any){
    if(this.preData){
      const date = new Date(day.date);
      this.preData.forEach(q => {
        var dateByData = new Date(Date.parse(q.operationTime));
        
        if(dateByData.getMonth() == date.getMonth()
          && dateByData.getFullYear() == date.getFullYear()
          && dateByData.getDate() == date.getDate()){
            day.backgroundColor = '#28a745'
        }else {
          if(day.backgroundColor != '#28a745')
          day.backgroundColor = '#ffc107'
        }
      });
      clearInterval(interval);
    }
  }
}
