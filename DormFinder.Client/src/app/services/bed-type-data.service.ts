import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BedTypeDataService {
  private dataSource = new BehaviorSubject<any>(1);
  currentData$ = this.dataSource.asObservable();

  constructor() {}

  setData(data: any) {
    this.dataSource.next(data);
  }
}
