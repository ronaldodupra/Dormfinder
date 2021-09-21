import { Injectable, Inject } from '@angular/core';
import { IBuilding, ICreateBuilding } from '../models/buildings.model';
import { HttpClient } from '@angular/common/http';
import { retry, catchError } from 'rxjs/operators';
import { ErrorHandler } from './error-handler.service';
import { Observable } from 'rxjs';
import { PaginatedList } from 'src/app/core/paging/PaginatedList';
import { IBuildingType } from '../models/buildingtypes.model';
import { PageOptions } from '../core/pageoptions/PageOptions';
import { IReading } from '../models/reading.model';

@Injectable({
  providedIn: 'root',
})
export class BillingService extends ErrorHandler {
  api: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    super();
    this.api = 'api/billings/';
  }

  getUtilitiesReadingWater(): Observable<PaginatedList<IReading>> {
    return this.http.get<PaginatedList<IReading>>(
      this.baseUrl + this.api + '/water'
    );
  }

  getUtilitiesReadingElectricity(): Observable<PaginatedList<IReading>> {
    return this.http.get<PaginatedList<IReading>>(
      this.baseUrl + this.api + '/electricity'
    );
  }

  saveChangesUtilities(readings: IReading[]) {
    console.log(readings);
    return this.http.put(this.baseUrl + this.api, readings);
  }
}
