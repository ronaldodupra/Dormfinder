import { PaginatedList } from 'src/app/core/paging/PaginatedList';
import { PageOptions } from 'src/app/core/pageoptions/PageOptions';
import { Observable } from 'rxjs';
import {
  ICreateBillingPeriod,
  IBillingPeriod,
} from './../models/billing-periods.model';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ErrorHandler } from './error-handler.service';

@Injectable({
  providedIn: 'root',
})
export class BillingPeriodService extends ErrorHandler {
  readonly api: string = 'api/billing-periods';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    super();
  }

  create(billingPeriod: ICreateBillingPeriod): Observable<IBillingPeriod> {
    return this.http.post<IBillingPeriod>(this.api, billingPeriod);
  }

  getById(_id: number) {
    return this.http.get<IBillingPeriod>(this.api + _id);
  }

  getBillingPeriods(
    options: PageOptions
  ): Observable<PaginatedList<IBillingPeriod>> {
    const params = options.toObject();
    return this.http.get<PaginatedList<IBillingPeriod>>(this.api, { params });
  }

  update(
    billingPeriod: ICreateBillingPeriod,
    billingId: number
  ): Observable<IBillingPeriod> {
    return this.http.put<IBillingPeriod>(
      `${this.api}/{billingId}`,
      billingPeriod
    );
  }
}
