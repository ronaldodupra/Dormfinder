import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { ErrorHandler } from './error-handler.service';
import { ICharge, ICreateCharge } from '../models/charge.model';
import { Observable } from 'rxjs';
import { PageOptions } from '../core/pageoptions/PageOptions';
import { PaginatedList } from '../core/paging/PaginatedList';

@Injectable({
  providedIn: 'root',
})
export class ChargeService extends ErrorHandler {
  api: string = 'api/charges';
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    super();
  }

  public getCharges(options: PageOptions): Observable<PaginatedList<ICharge>> {
    const params = options.toObject();
    return this.http
      .get<PaginatedList<ICharge>>(this.baseUrl + this.api, {
        params,
      })
      .pipe(retry(3), catchError(this.handleError));
  }

  public getChargesByCompany(_companyId: string) {
    return this.http
      .get<any>(this.baseUrl + this.api + '/byCompany/' + _companyId)
      .pipe(retry(3), catchError(this.handleError));
  }

  public addCharge(charge: ICreateCharge): Observable<ICharge> {
    return this.http
      .post<ICharge>(this.baseUrl + this.api, charge)
      .pipe(retry(3), catchError(this.handleError));
  }

  public updateCharge(
    chargeId: number,
    charge: ICreateCharge
  ): Observable<ICharge> {
    return this.http
      .put<ICharge>(this.baseUrl + this.api + '/' + chargeId, charge)
      .pipe(retry(3), catchError(this.handleError));
  }

  public changeOrder(_chargeOrders: any[]) {
    return this.http
      .post<any>(this.baseUrl + this.api + '/changeOrder', _chargeOrders)
      .pipe(retry(3), catchError(this.handleError));
  }

  public getById(chargeId: number): Observable<ICharge> {
    return this.http
      .get<ICharge>(`${this.api}/${chargeId}`)
      .pipe(retry(3), catchError(this.handleError));
  }
}
