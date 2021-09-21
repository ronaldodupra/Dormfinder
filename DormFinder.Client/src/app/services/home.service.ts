import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class HomeService {
  api: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    this.api = 'api/home/';
  }
}
