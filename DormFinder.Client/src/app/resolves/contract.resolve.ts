import { Injectable, Inject } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { ContractService } from "../services/contract.service";

@Injectable({
    providedIn: 'root'
})
export class ContractListResolver implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private contractService: ContractService) {

    }
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        return this.contractService.getContracts("1");
    }
}

@Injectable({
    providedIn: 'root'
})
export class ContractResolver implements Resolve<any> {
    constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private contractService: ContractService) {

    }
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        const id = route.paramMap.get("id");
        return this.contractService.getContract(id);
    }
}