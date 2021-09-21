import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subject } from 'rxjs';
import { auditTime, distinctUntilChanged } from 'rxjs/operators';
import { PageOptions } from 'src/app/core/pageoptions/PageOptions';
import { IAddlead } from 'src/app/models/lead.model';
import { LeadService } from 'src/app/services/lead.service';

@Component({
  selector: 'app-leads',
  templateUrl: './leads.component.html',
  styleUrls: ['./leads.component.scss'],
})
export class LeadsComponent implements OnInit {
  displayedColumns: string[] = [
    'from',
    'received',
    'property',
    'number',
    'status',
    'action',
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

  dataSource: MatTableDataSource<IAddlead>;

  leadId: string;

  date = new Date();

  constructor(private leadService: LeadService) {}

  ngOnInit(): void {
    this.loadleads();

    this.pagination.pipe(auditTime(500)).subscribe(() => {
      this.loadleads();
    });
  }

  page(pageEvent: PageEvent): void {
    this.pageIndex = pageEvent.pageIndex;
    this.pagination.next();
  }

  sortdata(sort: Sort): void {
    this.sort = sort;
    this.loadleads();
  }

  private loadleads(): void {
    const options = new PageOptions(
      this.pageIndex,
      this.pageSize,
      this.sort.active,
      this.sort.direction
    );

    this.leadService.getLead(options).subscribe((data) => {
      console.log(data.items);
      this.dataSource = new MatTableDataSource(data.items);
      this.totalCount = data.totalCount;
    });
  }
}
