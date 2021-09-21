import { ViewBillingPeriodsComponent } from './billing-periods/view-billing-periods/view-billing-periods.component';
import { BillingPeriodsComponent } from './billing-periods/billing-periods/billing-periods.component';
import { EditContractComponent } from './leads/edit-contract/edit-contract.component';
import { NewContractComponent } from './leads/new-contract/new-contract.component';
import { ViewLeadComponent } from './leads/view-lead/view-lead.component';
import { ViewRoomComponent } from './rooms/view-room/view-room.component';
import { NewRoomComponent } from './rooms/new-room/new-room.component';
import { RoomsComponent } from './rooms/rooms/rooms.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BuildingsComponent } from 'src/app/admin/buildings/buildings/buildings.component';
import { EditBuildingComponent } from 'src/app/admin/buildings/edit-building/edit-building.component';
import { NewBuildingComponent } from 'src/app/admin/buildings/new-building/new-building.component';
import { ViewBuildingComponent } from 'src/app/admin/buildings/view-building/view-building.component';
import { DashboardComponent } from 'src/app/admin/dashboard/dashboard/dashboard.component';
import { MainComponent } from 'src/app/admin/layouts/main/main.component';
import { EditRoomComponent } from './rooms/edit-room/edit-room.component';
import { LeadsComponent } from './leads/leads/leads.component';
import { TenantsComponent } from 'src/app/admin/tenants/tenants/tenants.component';
import { ChargesComponent } from './charges/charges/charges.component';
import { EditChargeComponent } from './charges/edit-charge/edit-charge.component';
import { NewChargeComponent } from './charges/new-charge/new-charge.component';
import { MyAccountComponent } from './my-account/my-account/my-account.component';
import { EditMyAccountComponent } from './my-account/edit-my-account/edit-my-account.component';
import { ViewTenantComponent } from 'src/app/admin/tenants/view-tenant/view-tenant.component';
import { BillingsComponent } from './billing/billings/billings.component';
import { NewBillingPeriodComponent } from './billing-periods/new-billing-period/new-billing-period.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: '',
        component: DashboardComponent,
      },
      {
        path: 'buildings',
        component: BuildingsComponent,
      },
      {
        path: 'buildings/new',
        component: NewBuildingComponent,
      },
      {
        path: 'buildings/:id',
        component: ViewBuildingComponent,
      },
      {
        path: 'buildings/:id/edit',
        component: EditBuildingComponent,
      },
      {
        path: 'rooms',
        component: RoomsComponent,
      },
      {
        path: 'rooms/new',
        component: NewRoomComponent,
      },
      {
        path: 'rooms/:id/edit',
        component: EditRoomComponent,
      },
      {
        path: 'rooms/:id',
        component: ViewRoomComponent,
      },
      {
        path: 'leads/:leadId/newcontract',
        component: NewContractComponent,
      },
      {
        path: 'leads/:leadId/editcontract/:id',
        component: EditContractComponent,
      },
      {
        path: 'leads',
        component: LeadsComponent,
      },
      {
        path: 'leads/:id',
        component: ViewLeadComponent,
      },
      {
        path: 'tenants',
        component: TenantsComponent,
      },
      {
        path: 'tenants/:id',
        component: ViewTenantComponent,
      },
      {
        path: 'charges',
        component: ChargesComponent,
      },
      {
        path: 'charges/:id/edit',
        component: EditChargeComponent,
      },
      {
        path: 'charges/new',
        component: NewChargeComponent,
      },
      {
        path: 'my-account',
        component: MyAccountComponent,
      },
      {
        path: 'my-account/edit',
        component: EditMyAccountComponent,
      },
      {
        path: 'billing2',
        component: BillingsComponent,
      },
      {
        path: 'billing',
        component: BillingPeriodsComponent,
      },
      {
        path: 'billing/new',
        component: NewBillingPeriodComponent,
      },
      {
        path: 'billing/:id',
        component: ViewBillingPeriodsComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
