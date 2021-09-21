import { IBillingPeriod } from './../../../models/billing-periods.model';
import { BillingPeriodService } from './../../../services/billing-period.service';
import { ActivatedRoute } from '@angular/router';
import { PageOptions } from 'src/app/core/pageoptions/PageOptions';
import { Subject } from 'rxjs';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { IContract, IAddContract } from 'src/app/models/contract.model';
import { MatTableDataSource } from '@angular/material/table';
import { ContractService } from 'src/app/services/contract.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-billing-periods',
  templateUrl: './view-billing-periods.component.html',
  styleUrls: ['./view-billing-periods.component.scss'],
})
export class ViewBillingPeriodsComponent implements OnInit {
  billingPeriodId: number;
  constructor(
    private contractService: ContractService,
    private route: ActivatedRoute,
    private billingPeriodService: BillingPeriodService
  ) {
    this.billingPeriodId = +this.route.snapshot.paramMap.get('id');
  }
  billingPeriod: IBillingPeriod;

  displayedColumns: string[] = [
    'tenantName',
    'lease',
    'allowableReservationDays',
    'status',
    'actions',
  ];

  totalPages: number;

  dataSource: MatTableDataSource<IAddContract>;

  totalCount: number;

  sort: Sort = {
    active: '',
    direction: '',
  };
  pageIndex = 0;

  pageSize = 5;

  pagination: Subject<void> = new Subject();

  ngOnInit(): void {
    this.getBillingId(this.billingPeriodId);
  }
  public getBillingId(Id) {
    this.billingPeriodService.getById(Id).subscribe((data) => {
      this.billingPeriod = data;
      this.getContracts();
    });
  }
  public getContracts() {
    const options = new PageOptions(
      this.pageIndex,
      this.pageSize,
      this.sort.active,
      this.sort.direction
    );
    this.contractService
      .getContract(options, this.billingPeriodId)
      .subscribe((data) => {
        this.dataSource = new MatTableDataSource(data.items);
        this.totalCount = data.totalCount;
      });
  }
  sortdata(sort: Sort): void {
    this.sort = sort;
    this.getContracts();
  }
  page(pageEvent: PageEvent): void {
    this.pageIndex = pageEvent.pageIndex;
    this.pagination.next();
  }
}
