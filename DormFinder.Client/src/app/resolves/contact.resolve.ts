import { Injectable, Inject } from "@angular/core";
import { ErrorHandler } from "../services/error-handler.service";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { ContactService } from "../services/contact.service";


@Injectable({
    providedIn: 'root'
})
export class ContactResolver implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private contactService: ContactService) {
    }
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        const id = route.paramMap.get("id");
        return this.contactService.getContact(id);
    }
}

@Injectable({
    providedIn: 'root'
})
export class ContactListResolver implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private contactService: ContactService) {
    }
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        return this.contactService.getContacts();
    }
}