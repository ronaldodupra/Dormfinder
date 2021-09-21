import { Injectable, Inject } from '@angular/core';
import {
  Resolve,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BuildingService } from '../services/building.service';

@Injectable({
  providedIn: 'root',
})
export class BuildingResolver implements Resolve<any> {
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
    private buildingService: BuildingService
  ) {}
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any> | Promise<any> | any {
    const id = route.paramMap.get('id');
    return this.buildingService.getById(id);
  }
}

@Injectable({
  providedIn: 'root',
})
export class BuildingListResolver implements Resolve<any> {
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
    private buildingService: BuildingService
  ) {}
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any> | Promise<any> | any {
    return this.buildingService.getBuildings();
  }
}
