import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { CalendarEvent, CalendarView } from 'angular-calendar';
import dayjs from 'dayjs';
import tr from 'dayjs/locale/tr';

dayjs.locale(tr);

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})


export class HomeComponent implements OnInit {
  
  viewDate: Date = new Date();

  constructor() {
  }

  ngOnInit(): void {
    
  }

}
