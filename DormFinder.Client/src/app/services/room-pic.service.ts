import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root',
})
export class RoomPicService {
  api: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    this.api = 'api/roompic/';
  }
  public setupthumbNail(_roomId, _fileEntryId) {
    return this.http.put<any>(
      this.baseUrl + this.api + _roomId + `/Thumbnail`,
      _fileEntryId
    );
  }
  public removeImage(id) {
    return this.http.delete<any>(this.baseUrl + this.api + id);
  }
}
