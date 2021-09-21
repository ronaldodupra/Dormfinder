import { BillingPeriodsModule } from './billing-periods/billing-periods.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { RoomsModule } from './rooms/rooms.module';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminRoutingModule } from './admin-routing.module';
import { BuildingsModule } from 'src/app/admin/buildings/buildings.module';
import { LayoutsModule } from 'src/app/admin/layouts/layouts.module';
import { LeadModule } from './leads/leads.module';
import { TenantsModule } from 'src/app/admin/tenants/tenants.module';
import { ChargesModule } from './charges/charges.module';
import { MyAccountModule } from './my-account/my-account.module';
import { BillingsModule } from './billing//billings.module';

@NgModule({
  imports: [
    AdminRoutingModule,
    LayoutsModule,
    BuildingsModule,
    FormsModule,
    ReactiveFormsModule,
    RoomsModule,
    TenantsModule,
    LeadModule,
    DashboardModule,
    ChargesModule,
    MyAccountModule,
    BillingsModule,
    BillingPeriodsModule,
  ],
})
export class AdminModule {}
