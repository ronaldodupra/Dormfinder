import { Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from "@angular/router";
import { Inject, Injectable, inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class AmenityRefResolver implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {}
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        return this.http.get<any>(this.baseUrl +'api/references?type=amenities');
        }
} 

@Injectable({
    providedIn: 'root'
})
export class InclusionRefResolver implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {}
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        return this.http.get<any>(this.baseUrl + 'api/references?type=inclusions');
        }
}

@Injectable({
    providedIn: 'root'
})
export class NearbySchoolRefResolver implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        return this.http.get<any>(this.baseUrl + 'api/references?type=nearbySchools');
    }
}

@Injectable({
    providedIn: 'root'
})
export class ChargesRefResolver implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        return this.http.get<any>(this.baseUrl + 'api/references?type=charges');
    }
}


@Injectable({
    providedIn: 'root'
})
export class HobbiesRefResolver implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        return this.http.get<any>(this.baseUrl + 'api/references?type=hobbies');
    }
}

@Injectable({
    providedIn: 'root'
})
export class ContactTypeRefResolver implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        return this.http.get<any>(this.baseUrl + 'api/references?type=contactType');
    }
}

@Injectable({
    providedIn: 'root'
})
export class RoomTypeRefResolver implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        return this.http.get<any>(this.baseUrl + 'api/references?type=roomTypes');
    }
}

@Injectable({
    providedIn: 'root'
})
export class BedTypeRefResolver implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        return this.http.get<any>(this.baseUrl + 'api/references?type=bedTypes');
    }
}



