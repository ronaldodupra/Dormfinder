import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { DataSource } from '@angular/cdk/table';
@Injectable({
  providedIn: 'root',
})
export class RoomTypeDataService {
  api: string;
  private dataSource = new BehaviorSubject<any>(1);
  currentData$ = this.dataSource.asObservable();

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    this.api = 'api/roomtype/';
  }

  setData(data: any) {
    this.dataSource.next(data);
  }
  public getRoomType() {
    return this.http.get<any>(this.baseUrl + this.api);
  }
}
