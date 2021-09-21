import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subject } from 'rxjs';
import { auditTime, distinctUntilChanged } from 'rxjs/operators';
import { PageOptions } from 'src/app/core/pageoptions/PageOptions';
import { ICharge } from 'src/app/models/charge.model';
import { ChargeService } from 'src/app/services/charge.service';

@Component({
  selector: 'app-charges',
  templateUrl: './charges.component.html',
  styleUrls: ['./charges.component.scss'],
})
export class ChargesComponent implements OnInit {
  displayedColumns: string[] = [
    'billingStatementOrder',
    'comments',
    'defaultCharge',
    'isVat',
    'actions',
  ];

  totalPages: number;

  totalCount: number;

  pageIndex = 0;

  pageSize = 5;

  sort: Sort = {
    active: '',
    direction: '',
  };

  pagination: Subject<void> = new Subject();

  dataSource: MatTableDataSource<ICharge>;

  constructor(private chargeService: ChargeService) {}

  ngOnInit(): void {
    this.loadCharges();

    this.pagination.pipe(auditTime(500)).subscribe(() => {
      this.loadCharges();
    });
  }

  page(pageEvent: PageEvent): void {
    this.pageIndex = pageEvent.pageIndex;
    this.pagination.next();
  }

  sortdata(sort: Sort): void {
    this.sort = sort;
    this.loadCharges();
  }

  private loadCharges(): void {
    const options = new PageOptions(
      this.pageIndex,
      this.pageSize,
      this.sort.active,
      this.sort.direction
    );

    this.chargeService.getCharges(options).subscribe((data) => {
      this.dataSource = new MatTableDataSource(data.items);
      this.totalCount = data.totalCount;
    });
  }
}
