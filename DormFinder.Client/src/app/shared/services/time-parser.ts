import * as moment from 'moment';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TimeParser {
  /**
   * @date Date This should be a moment object in UTC. The method accepts it as Date but it is actually a moment object from mat-datepicker.
   * @returns returns the Date object of the @date in UTC.
   */
parse(date: moment.Moment): Date {
    if (!date) return null;
    
    return new Date(date.format('L') + ' ' + '00:00' + ':00Z');
  }
}
