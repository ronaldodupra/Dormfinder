import { Injectable, Inject } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AlertCountService {
  private dataSource = new BehaviorSubject<any>({
    reservationExpirationCount: 0,
    rentalEffectivityEndCount: 0,
  });
  currentData$ = this.dataSource.asObservable();
  readonly api = 'api/alerts';
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {}

  setData(data: any) {
    this.dataSource.next(data);
  }

  getInitialAlertData() {
    this.http
      .get<any>(this.baseUrl + this.api)
      .pipe(retry(3))
      .subscribe((result) => {
        this.setData(result);
      });
  }
}
