import { NgModule } from '@angular/core';
import { TenantsComponent } from './tenants/tenants.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ViewTenantComponent } from './view-tenant/view-tenant.component';

@NgModule({
  declarations: [TenantsComponent, ViewTenantComponent],
  imports: [SharedModule],
})
export class TenantsModule {}
