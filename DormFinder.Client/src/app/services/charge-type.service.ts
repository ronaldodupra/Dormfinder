import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { ErrorHandler } from './error-handler.service';
import { ICharge, ICreateCharge } from '../models/charge.model';
import { Observable } from 'rxjs';
import { PageOptions } from '../core/pageoptions/PageOptions';
import { PaginatedList } from '../core/paging/PaginatedList';
import { IChargeType } from '../models/chargetype.model';

@Injectable({
  providedIn: 'root',
})
export class ChargeTypeService extends ErrorHandler {
  api: string = 'api/chargeTypes';
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    super();
  }

  public getChargeTypes(): Observable<PaginatedList<IChargeType>> {
    return this.http
      .get<PaginatedList<IChargeType>>(this.baseUrl + this.api, {})
      .pipe(retry(3), catchError(this.handleError));
  }
}
