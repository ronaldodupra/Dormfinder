import { Injectable, Inject } from "@angular/core";
import { ErrorHandler } from "../services/error-handler.service";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { retry, catchError } from "rxjs/operators";
import { ContactService } from "../services/contact.service";

@Injectable({
    providedIn: 'root'
})
export class TenantResolver extends ErrorHandler implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private tenantService: ContactService) {
        super();
    }
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        const id = route.paramMap.get("id");
        return this.tenantService.getContact(id).pipe(
            retry(3),
            catchError(this.handleError)
        )
    }
}
