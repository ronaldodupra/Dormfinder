import { Injectable, Inject } from '@angular/core';
import { IBuilding, ICreateBuilding } from '../models/buildings.model';
import { HttpClient } from '@angular/common/http';
import { retry, catchError } from 'rxjs/operators';
import { ErrorHandler } from './error-handler.service';
import { Observable } from 'rxjs';
import { PaginatedList } from 'src/app/core/paging/PaginatedList';
import { IBuildingType } from '../models/buildingtypes.model';
import { PageOptions } from '../core/pageoptions/PageOptions';

@Injectable({
  providedIn: 'root',
})
export class BuildingService extends ErrorHandler {
  api: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    super();
    this.api = 'api/buildings/';
  }

  create(createModel: ICreateBuilding): Observable<IBuilding> {
    return this.http.post<IBuilding>(`${this.api}`, createModel);
  }

  update(
    buildingId: number,
    updateModel: ICreateBuilding
  ): Observable<IBuilding> {
    return this.http.put<IBuilding>(`${this.api}/${buildingId}`, updateModel);
  }

  getById(buildingId: number): Observable<IBuilding> {
    return this.http
      .get<IBuilding>(`${this.api}/${buildingId}`)
      .pipe(retry(3), catchError(this.handleError));
  }

  list(options: PageOptions): Observable<PaginatedList<IBuilding>> {
    const params = options.toObject();

    return this.http.get<PaginatedList<IBuilding>>(`${this.api}`, {
      params,
    });
  }

  public getBuildings() {
    return this.http.get<any>(this.baseUrl + this.api);
  }

  public addBuilding(_building: IBuilding) {
    return this.http
      .post<any>(this.baseUrl + this.api, _building)
      .pipe(retry(3), catchError(this.handleError));
  }

  public editBuilding(_buildingId: string, _building: IBuilding) {
    return this.http
      .put<any>(this.baseUrl + this.api + _buildingId, _building)
      .pipe(retry(3), catchError(this.handleError));
  }

  public addAmenities(_buildingId: string, _amenities: string[]) {
    return this.http
      .post<any>(
        this.baseUrl + this.api + _buildingId + '/addAmenities',
        _amenities
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  public addInclusions(_buildingId: string, _inclusions: string[]) {
    return this.http
      .post<any>(
        this.baseUrl + this.api + _buildingId + '/addInclusions',
        _inclusions
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  public addNearBySchools(_buildingId: string, _nearBySchools: string[]) {
    return this.http
      .post<any>(
        this.baseUrl + this.api + _buildingId + '/addNearbySchools',
        _nearBySchools
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  public addFloor(_buildingId: string, _floor: any) {
    //change this to floor
    return this.http
      .put<any>(this.baseUrl + this.api + _buildingId + '/addFloor', _floor)
      .pipe(retry(3), catchError(this.handleError));
  }

  getbuildingtype(): Observable<IBuildingType[]> {
    return this.http.get<IBuildingType[]>(`${this.api}/buildingType`);
  }
  public getAddress() {
    return this.http.get<any[]>(this.baseUrl + this.api + `address`);
  }
}
