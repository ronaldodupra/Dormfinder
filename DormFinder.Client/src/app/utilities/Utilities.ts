import { MatSnackBar } from '@angular/material/snack-bar';
import * as moment from 'moment';

export class Utilities {
  constructor(private snackBar: MatSnackBar) {}

  public openSnackBar(message: string): void {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }

  public removeDuplicates(arr) {
    let unique_array = arr.filter(function (elem, index, self) {
      return index == self.indexOf(elem);
    });
    return unique_array;
  }

  public getDistinctValues(arr, arr2) {
    let distinctArray = arr.filter((ref) =>
      arr2.indexOf(ref) > -1 ? false : ref
    );
    return distinctArray;
  }

  public addDays(date: Date, days: number): Date {
    date.setDate(date.getDate() + days);
    return date;
  }

  public formatDateToString(date: any): string {
    return moment(date).format('MM/DD/YYYY');
  }
}
