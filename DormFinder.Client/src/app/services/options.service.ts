import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICity, IProvince } from 'src/app/models/options.model';
import { IBuildingType } from '../models/buildingtypes.model';

@Injectable({
  providedIn: 'root',
})
export class OptionsService {
  private readonly baseUrl: string = 'api/options';

  constructor(private httpClient: HttpClient) {}

  getProvinces(): Observable<IProvince[]> {
    return this.httpClient.get<IProvince[]>(`${this.baseUrl}/provinces`);
  }

  getCities(): Observable<ICity[]> {
    return this.httpClient.get<ICity[]>(`${this.baseUrl}/cities`);
  }

  public getAddress(){
    return this.httpClient.get<any[]>(this.baseUrl+`/address`); 
  }
}
