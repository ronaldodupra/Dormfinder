import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TenantService } from 'src/app/admin/tenants/services/tenant.service';
import { ITenant } from 'src/app/models/tenant.model';

@Component({
  selector: 'app-view-tenant',
  templateUrl: './view-tenant.component.html',
  styleUrls: ['./view-tenant.component.scss'],
})
export class ViewTenantComponent implements OnInit {
  private tenantId: number;

  tenant: ITenant;

  constructor(route: ActivatedRoute, private tenantService: TenantService) {
    this.tenantId = +route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
    this.loadTenant();
  }

  private loadTenant(): void {
    this.tenantService
      .getById(this.tenantId)
      .subscribe((tenant) => (this.tenant = tenant));
  }
}
