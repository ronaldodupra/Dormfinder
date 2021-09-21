import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
@Injectable({
  providedIn: 'root',
})
export class RoomInclusionService {
  api: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    this.api = 'api/roomInclusion/';
  }
  public getRoomInclusion(id) {
    return this.http.get<any>(this.baseUrl + this.api + id + `/getInclusion`);
  }
}
