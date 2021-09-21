import { ITenant, ICreateTenant } from 'src/app/models/tenant.model';
import { IContract } from 'src/app/models/contract.model';
import { IContact } from './../../../models/contact.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PageOptions } from 'src/app/core/pageoptions/PageOptions';
import { PaginatedList } from 'src/app/core/paging/PaginatedList';
@Injectable({
  providedIn: 'root',
})
export class TenantService {
  private baseUrl: string = 'api/tenants';

  constructor(private httpClient: HttpClient) {}

  getById(id: number): Observable<ITenant> {
    return this.httpClient.get<ITenant>(`${this.baseUrl}/${id}`);
  }

  create(createTenant: ICreateTenant): Observable<ITenant> {
    return this.httpClient.post<ITenant>(`${this.baseUrl}`, createTenant);
  }

  list(options: PageOptions): Observable<PaginatedList<ITenant>> {
    const params = options.toObject();
    return this.httpClient.get<PaginatedList<ITenant>>(`${this.baseUrl}`, {
      params,
    });
  }
  public getByRoomId(_roomId) {
    return this.httpClient.get<ITenant[]>(
      this.baseUrl + `/${_roomId}` + '/getTenantsByRoom'
    );
  }
}
