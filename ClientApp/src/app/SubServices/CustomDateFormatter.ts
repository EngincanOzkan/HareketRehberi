/*import { CalendarMomentDateFormatter, DateFormatterParams } from 'angular-calendar';
import { formatDate } from '@angular/common';
import { Injectable } from '@angular/core';


@Injectable()
export class CustomDateFormatter extends CalendarMomentDateFormatter {
 
    public monthViewColumnHeader({ date, locale }: DateFormatterParams): string {
        console.log(locale)
        return formatDate(date, 'EEE', locale || 'en-US');
    }

    public monthViewTitle({ date, locale }: DateFormatterParams): string {
        return formatDate(date, 'MMM y', locale || 'en-US');
    }
}*/