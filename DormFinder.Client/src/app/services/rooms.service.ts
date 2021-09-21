import { PaginatedList } from './../core/paging/PaginatedList';
import { ICreateRoom, IRoom } from './../models/rooms.model';
import { Observable } from 'rxjs';

import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { retry, catchError } from 'rxjs/operators';
import { ErrorHandler } from './error-handler.service';
import { PageOptions } from '../core/pageoptions/PageOptions';
@Injectable({
  providedIn: 'root',
})
export class RoomsService extends ErrorHandler {
  api: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    super();
    this.api = 'api/rooms/';
  }

  public getRooms(options: PageOptions): Observable<PaginatedList<IRoom>> {
    const params = options.toObject();

    return this.http
      .get<PaginatedList<IRoom>>(this.baseUrl + this.api + 'byBuildingFloor', {
        params,
      })
      .pipe(retry(3), catchError(this.handleError));
  }

  public getRoomList(): Observable<IRoom[]> {
    return this.http
      .get<IRoom[]>(this.baseUrl + this.api + 'rooms')
      .pipe(retry(3), catchError(this.handleError));
  }

  public getRoom(_roomId: number): Observable<IRoom> {
    return this.http
      .get<IRoom>(this.baseUrl + this.api + _roomId)
      .pipe(retry(3), catchError(this.handleError));
  }

  public addRoom(_buildingId: string, _floorId: string, _room: IRoom) {
    return this.http
      .post<any>(this.baseUrl + this.api + _buildingId + '/' + _floorId, _room)
      .pipe(retry(3), catchError(this.handleError));
  }

  public editRoom(_roomId: string, _room: IRoom) {
    return this.http
      .put<any>(this.baseUrl + this.api + _roomId, _room)
      .pipe(retry(3), catchError(this.handleError));
  }
  public insertRoom(roomData) {
    return this.http.post<any>(this.baseUrl + this.api, roomData);
  }
  public updateRoom(_roomId, roomDetails) {
    return this.http.put<any>(this.baseUrl + this.api + _roomId, roomDetails);
  }
  public addOccupant(_occupant) {
    return this.http.post<any>(
      this.baseUrl + this.api + `AddOccupant`,
      _occupant
    );
  }
  public updateOccupant(_occupant) {
    return this.http.put<any>(
      this.baseUrl + this.api + `UpdateOccupant`,
      _occupant
    );
  }
}
