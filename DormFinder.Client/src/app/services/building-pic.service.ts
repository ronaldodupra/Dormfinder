import { Injectable, Inject } from '@angular/core';
import { IBuildingPic } from '../models/building-pics.model';
import { HttpClient } from '@angular/common/http';
import { retry, catchError } from 'rxjs/operators';
import { ErrorHandler } from './error-handler.service';

@Injectable({
  providedIn: 'root',
})
export class BuildingPicService extends ErrorHandler {
  api: string;
  uploadedPics: IBuildingPic[];
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    super();
    this.api = 'api/buildingPics/';
  }

  public getPhotos(_buildingId: string) {
    //try buffering this
    console.log('Got photos');
    return this.http
      .get<any>(this.baseUrl + this.api + _buildingId)
      .pipe(retry(3), catchError(this.handleError));
  }

  public uploadPhotos(_buildingId: string, _files: string[]) {
    console.table(_files);
    return this.http
      .post<any>(this.baseUrl + this.api + _buildingId, _files)
      .pipe(retry(3), catchError(this.handleError));
  }

  public updatePhoto(_id: string, _pic: any) {
    console.table(_pic);

    return this.http
      .put<any>(this.baseUrl + this.api + _id, _pic)
      .pipe(retry(3), catchError(this.handleError));
  }

  public deletePhoto(_id: string) {
    return this.http
      .delete<any>(this.baseUrl + this.api + _id)
      .pipe(retry(3), catchError(this.handleError));
  }
}
