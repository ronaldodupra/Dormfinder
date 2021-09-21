import { ITenant } from 'src/app/models/tenant.model';
import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TenantService } from 'src/app/admin/tenants/services/tenant.service';
import { PageOptions } from 'src/app/core/pageoptions/PageOptions';

@Component({
  selector: 'app-tenants',
  templateUrl: './tenants.component.html',
  styleUrls: ['./tenants.component.scss'],
})
export class TenantsComponent implements OnInit {
  readonly displayedColumns: string[] = [
    'id',
    'fullname',
    'property',
    'actions',
  ];

  dataSource: MatTableDataSource<ITenant>;

  pageIndex: number = 0;

  pageSize: number = 25;

  totalCount: number = 0;

  constructor(private tenantService: TenantService) {}

  ngOnInit(): void {
    this.loadTenants();
  }

  page(pageEvent: PageEvent): void {
    this.pageIndex = pageEvent.pageIndex;
    this.pageSize = pageEvent.pageSize;
  }

  private loadTenants(): void {
    const options = new PageOptions(this.pageIndex, this.pageSize);

    this.tenantService.list(options).subscribe((data) => {
      this.dataSource = new MatTableDataSource(data.items);
      this.totalCount = data.totalCount;
    });
  }
}
