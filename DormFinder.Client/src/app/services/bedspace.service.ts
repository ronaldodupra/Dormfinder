import { Injectable, Inject } from '@angular/core';
import { IBedspace } from '../models/bedspace.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { retry, catchError } from 'rxjs/operators';
import { ErrorHandler } from './error-handler.service';

@Injectable({
  providedIn: 'root',
})
export class BedspaceService extends ErrorHandler {
  api: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    super();
    this.api = 'api/bedspaces/';
  }

  public getBedspaces(_roomId: number, availableOnly?: boolean) {
    // if (availableOnly) {
    //   _roomId = _roomId + "?availableOnly=true"
    // }
    return this.http
      .get<any>(this.baseUrl + this.api + _roomId + '/roomBed')
      .pipe(retry(3), catchError(this.handleError));
  }

  public getBedspacesForUpdate(_roomId: string, _bedspaceId: string) {
    return this.http
      .get<any>(
        this.baseUrl +
          this.api +
          'byRoom/' +
          _roomId +
          '/forUpdate/' +
          _bedspaceId
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  public getBedspace(_bedspaceId: string) {
    return this.http
      .get<IBedspace>(this.baseUrl + this.api + _bedspaceId)
      .pipe(retry(3), catchError(this.handleError));
  }

  public addBedspace(_roomId: string, _bedspace: any) {
    return this.http
      .post<any>(this.baseUrl + this.api + _roomId, _bedspace)
      .pipe(retry(3), catchError(this.handleError));
  }

  public editBedspace(_bedspaceId: number, _editbedspace: any) {
    return this.http
      .put<any>(this.baseUrl + this.api + _bedspaceId, _editbedspace)
      .pipe(retry(3), catchError(this.handleError));
  }
  public updateBedStatus(_bedId, _status) {
    return this.http.put<any>(
      this.baseUrl + this.api + _bedId + `/bedstatus`,
      _status
    );
  }
}
