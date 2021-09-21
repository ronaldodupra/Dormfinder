import { IRoomProperty } from './../models/room-property';
import { Observable } from 'rxjs';
import { IProperty, IPropertyLocation } from './../models/property.model';

import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root',
})
export class PropertyService {
  api: string;
  constructor(
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    this.api = 'api/property/';
  }
  public getProperty(id): Observable<IRoomProperty> {
    return this.http.get<IRoomProperty>(this.baseUrl + this.api + id);
  }
  public getSimilarProperty(id) {
    return this.http.get<string>(this.baseUrl + this.api + id + `/properties`);
  }
  public filterLocation(filter): Observable<IPropertyLocation[]> {
    return this.http.get<IPropertyLocation[]>(
      this.baseUrl + this.api + `filter=${filter}`
    );
  }
}
