import { EditBillingPeriodComponent } from './../edit-billing-period/edit-billing-period.component';
import { NewBillingPeriodComponent } from './../new-billing-period/new-billing-period.component';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { auditTime } from 'rxjs/operators';
import { PageEvent } from '@angular/material/paginator';
import { PageOptions } from 'src/app/core/pageoptions/PageOptions';
import { Subject } from 'rxjs';
import { Sort } from '@angular/material/sort';
import { IBillingPeriod } from './../../../models/billing-periods.model';
import { BillingPeriodService } from './../../../services/billing-period.service';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-billing-periods',
  templateUrl: './billing-periods.component.html',
  styleUrls: ['./billing-periods.component.scss'],
})
export class BillingPeriodsComponent implements OnInit {
  constructor(
    private billingPeriodService: BillingPeriodService,
    private dialog: MatDialog
  ) {}

  displayedColumns: string[] = [
    'billingMonth',
    'beginDate',
    'endDate',
    'actions',
  ];

  dataSource: MatTableDataSource<IBillingPeriod>;

  totalPages: number;

  totalCount: number;

  pageIndex = 0;

  pageSize = 5;

  sort: Sort = {
    active: '',
    direction: '',
  };

  pagination: Subject<void> = new Subject();

  dialogRef: MatDialogRef<any>;

  ngOnInit(): void {
    this.loadBillingPeriods();
    this.pagination.pipe(auditTime(500)).subscribe(() => {
      this.loadBillingPeriods();
    });
  }
  public loadBillingPeriods() {
    const options = new PageOptions(
      this.pageIndex,
      this.pageSize,
      this.sort.active,
      this.sort.direction
    );
    this.billingPeriodService.getBillingPeriods(options).subscribe((data) => {
      this.dataSource = new MatTableDataSource(data.items);
      this.totalCount = data.totalCount;
    });
  }
  page(pageEvent: PageEvent): void {
    this.pageIndex = pageEvent.pageIndex;
    this.pagination.next();
  }

  sortdata(sort: Sort): void {
    this.sort = sort;
    this.loadBillingPeriods();
  }
  public newBillingPeriod() {
    this.dialogRef = this.dialog.open(NewBillingPeriodComponent, {
      data: {},
      width: '40%',
    });
  }
  public editBillingPeriod(billing) {
    this.dialogRef = this.dialog.open(EditBillingPeriodComponent, {
      data: { billing },
      width: '40%',
    });
  }
}
