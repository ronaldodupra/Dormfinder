import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class dashboardService {
  api: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    this.api = 'api/dashboard/';
  }
  public getRoomChart() {
    return this.http.get<any[]>(this.api);
  }
  public getRoomChartFilter(search) {
    return this.http.get<any[]>(this.api + search);
  }
}
