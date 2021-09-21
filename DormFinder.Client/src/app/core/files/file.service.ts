import {
  HttpClient,
  HttpEvent,
  HttpEventType,
  HttpRequest,
  HttpResponse,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, share } from 'rxjs/operators';
import {
  FileProgress,
  FileProgressState,
} from 'src/app/core/files/file-progress';

@Injectable({
  providedIn: 'root',
})
export class FileService {
  constructor(private httpClient: HttpClient) {}

  upload<T>(
    url: string,
    file: File,
    data: object = {}
  ): Observable<FileProgress<T>> {
    // Add file to form
    const formData = new FormData();
    formData.append('file', file);

    // Add custom metadata to form
    Object.entries(data).forEach(([key, value]) => {
      formData.append(key, value);
    });

    const request = new HttpRequest('POST', url, formData, {
      reportProgress: true,
    });

    return this.httpClient
      .request(request)
      .pipe(catchError(this.handleError))
      .pipe<FileProgress<T>>(
        map<HttpEvent<any> | HttpResponse<any>, FileProgress<T>>(
          this.handleProgress
        )
      )
      .pipe(share());
  }

  private handleProgress<T>(event: any): FileProgress<T> {
    switch (event.type) {
      case HttpEventType.Sent:
        return new FileProgress(FileProgressState.Sending, 0);
      case HttpEventType.UploadProgress:
        return new FileProgress(
          FileProgressState.InProgress,
          Math.round((100 * event.loaded) / event.total)
        );
      case HttpEventType.ResponseHeader:
        return new FileProgress(FileProgressState.Receiving, 100);
      case HttpEventType.DownloadProgress:
        return new FileProgress(FileProgressState.Receiving, 100);
      case HttpEventType.Response:
        const response = event as HttpResponse<T>;
        return new FileProgress(FileProgressState.Success, 100, response.body);
      default:
        return new FileProgress(FileProgressState.Failed, 100);
    }
  }

  private handleError<T>(err: any): Observable<FileProgress<T>> {
    return throwError(new FileProgress(FileProgressState.Failed, 0, err));
  }
}
