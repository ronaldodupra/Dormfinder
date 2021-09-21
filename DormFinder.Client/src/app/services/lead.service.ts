import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ErrorHandler } from './error-handler.service';
import { retry, catchError } from 'rxjs/operators';

import { Observable } from 'rxjs';
import { IAddlead, Ilead } from '../models/lead.model';
import { PaginatedList } from '../core/paging/PaginatedList';
import { PageOptions } from '../core/pageoptions/PageOptions';

@Injectable({
  providedIn: 'root',
})
export class LeadService extends ErrorHandler {
  api = 'api/leads/';
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    super();
  }

  public addlead(lead: IAddlead) {
    return this.http.post<IAddlead>(this.baseUrl + this.api, lead);
  }

  getLead(options: PageOptions): Observable<PaginatedList<IAddlead>> {
    const params = options.toObject();
    return this.http.get<PaginatedList<IAddlead>>(`${this.api}`, {
      params,
    });
  }

  getLeadByUser(options: PageOptions): Observable<PaginatedList<IAddlead>> {
    const params = options.toObject();
    return this.http.get<PaginatedList<IAddlead>>(`${this.api}` + `/by-user`, {
      params,
    });
  }

  getLeadById(_id): Observable<Ilead> {
    return this.http.get<Ilead>(`${this.api}${_id}`);
  }
}
