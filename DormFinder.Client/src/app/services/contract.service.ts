import { PageOptions } from 'src/app/core/pageoptions/PageOptions';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ErrorHandler } from './error-handler.service';
import { retry, catchError } from 'rxjs/operators';
import {
  IAddContract,
  IContract,
  IContractChecklist,
  IContractDeposit,
  IUpdateContract,
} from '../models/contract.model';
import { Observable } from 'rxjs';
import { PaginatedList } from '../core/paging/PaginatedList';

@Injectable({
  providedIn: 'root',
})
export class ContractService extends ErrorHandler {
  api = 'api/contracts/';
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    super();
  }

  public getContracts(companyId: string) {
    return this.http
      .get<any>(this.baseUrl + this.api + 'byCompany/' + companyId)
      .pipe(retry(3), catchError(this.handleError));
  }

  // public getContract(contractId: string) {
  //   return this.http
  //     .get<any>(this.baseUrl + this.api + contractId)
  //     .pipe(retry(3), catchError(this.handleError));
  // }

  getContract(
    options: PageOptions,
    _id: number
  ): Observable<PaginatedList<IAddContract>> {
    const params = options.toObject();
    return this.http.get<PaginatedList<IAddContract>>(
      `${this.api}byBillingPeriodId/${_id}`,
      {
        params,
      }
    );
  }

  GetById(Id: number): Observable<IContract> {
    return this.http
      .get<IContract>(`${this.api}/${Id}`)
      .pipe(retry(3), catchError(this.handleError));
  }
  // public addContract(value): Observable<IAddContract> {
  //   return this.http.post<IAddContract>(this.baseUrl + this.api, value);
  // }

  public addContract(contracts: IAddContract) {
    return this.http.post<IAddContract>(this.baseUrl + this.api, contracts);
  }

  public updateContract(contractId: number, contract: IAddContract) {
    return this.http
      .put<any>(this.baseUrl + this.api + contractId, contract)
      .pipe(retry(3), catchError(this.handleError));
  }

  public updateChecklist(contractId: string, checkList: IContractChecklist) {
    return this.http
      .post<any>(
        this.baseUrl + this.api + contractId + '/updateChecklist',
        checkList
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  public updateDeposit(contractId: string, deposit: IContractDeposit) {
    return this.http
      .post<any>(
        this.baseUrl + this.api + contractId + '/updateDeposit',
        deposit
      )
      .pipe(retry(3), catchError(this.handleError));
  }
  public getByRoomId(_roomId) {
    return this.http.get<IContract[]>(
      this.baseUrl + this.api + `${_roomId}` + '/getContractsByRoom'
    );
  }
  approveContract(contractId) {
    return this.http
      .post<any>(this.baseUrl + this.api + contractId + '/approve', null)
      .pipe(retry(3), catchError(this.handleError));
  }
}
