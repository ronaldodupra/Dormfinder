import { IRent } from './../models/rent.model';
import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class RentService {
  api: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    this.api = 'api/rent/';
  }
  public getRooms() {
    return this.http.get<IRent[]>(this.baseUrl + this.api);
  }
  public getSearchRooms(_form) {
    return this.http.get<IRent[]>(
      this.baseUrl +
        this.api +
        `location=${_form.search}&minprice=${Number(
          _form.minPrice
        )}&maxprice=${Number(_form.maxPrice)}`
    );
  }
}
