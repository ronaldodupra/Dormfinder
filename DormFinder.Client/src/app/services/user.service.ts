import { Injectable, Inject } from '@angular/core';
import {
  HttpClient,
  HttpEvent,
  HttpEventType,
  HttpRequest,
  HttpResponse,
} from '@angular/common/http';
import { retry, catchError, map, share } from 'rxjs/operators';
import { ErrorHandler } from './error-handler.service';
import { Observable } from 'rxjs';
import { IUser } from '../models/user.model';
import { FileProgress } from '../core/files/file-progress';

@Injectable({
  providedIn: 'root',
})
export class UserService extends ErrorHandler {
  api: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    super();
    this.api = 'api/users/';
  }

  getCurrentUser(): Observable<IUser> {
    return this.http
      .get<IUser>(`${this.api}`)
      .pipe(retry(3), catchError(this.handleError));
  }

  updateUser(user: IUser): Observable<IUser> {
    return this.http.put<IUser>(this.api, user);
  }

  updateUserImage(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);

    return this.http.post<any>(this.api + 'update-image', formData);
  }
}
