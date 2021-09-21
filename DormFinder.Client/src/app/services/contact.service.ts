import { Injectable, Inject } from '@angular/core';
import { ErrorHandler } from './error-handler.service';
import { IContact } from '../models/contact.model';
import { HttpClient } from '@angular/common/http';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ContactService extends ErrorHandler {
  api: string = 'api/contacts';
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    super();
  }

  public getContacts(potentialTenantsOnly?: boolean) {
    let query = this.api;
    if (potentialTenantsOnly) query = this.api + '?potentialTenantsOnly=true';
    return this.http
      .get<any>(this.baseUrl + query)
      .pipe(retry(3), catchError(this.handleError));
  }

  public getContact(_id: string) {
    return this.http
      .get<any>(this.baseUrl + this.api + '/' + _id)
      .pipe(retry(3), catchError(this.handleError));
  }

  public addContact(_contact: any) {
    return this.http
      .post<any>(this.baseUrl + this.api, _contact)
      .pipe(retry(3), catchError(this.handleError));
  }

  public updateContact(_id: string, _contact: any) {
    return this.http
      .put<IContact>(this.baseUrl + this.api + '/' + _id, _contact)
      .pipe(retry(3), catchError(this.handleError));
  }
}
