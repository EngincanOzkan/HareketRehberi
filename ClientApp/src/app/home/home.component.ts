import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { CalendarView, DAYS_OF_WEEK  } from 'angular-calendar';
import dayjs from 'dayjs';
import tr from 'dayjs/locale/tr';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})


export class HomeComponent implements OnInit {
  
  view: CalendarView = CalendarView.Month;

  viewDate: Date = new Date();

  constructor() {
    dayjs.locale(tr);
  }

  ngOnInit(): void {
    
  }
}
