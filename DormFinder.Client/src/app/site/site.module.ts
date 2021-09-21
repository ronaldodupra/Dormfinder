import { LeadDialogComponent } from './rent/view-property/lead-dialog/lead-dialog.component';
import { RentComponent } from 'src/app/site/rent/rent/rent.component';
import { HomeComponent } from 'src/app/site/home/home/home.component';
import { GoogleMapsModule } from '@angular/google-maps';

import { NgModule } from '@angular/core';
import { MainComponent } from './layout/main/main.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MaterialModule } from 'src/app/shared/material.module';
import { ViewPropertyComponent } from './rent/view-property/view-property.component';
import {
  DxSelectBoxModule,
  DxListModule,
  DxTemplateModule,
} from 'devextreme-angular';
import { SearchFormComponent } from './property/search-form/search-form.component';
import { MyAccountTenantComponent } from './my-account-tenant/my-account-tenant/my-account-tenant.component';
import { MyAccountTenantFormComponent } from './my-account-tenant/my-account-tenant-form/my-account-tenant-form.component';
import { EditMyAccountTenantComponent } from './my-account-tenant/edit-my-account-tenant/edit-my-account-tenant.component';
import { FlexLayoutModule } from '@angular/flex-layout';

import { LeadsTenantComponent } from './leads-tenant/leads-tenant/leads-tenant.component';
import { ViewLeadTenantComponent } from './leads-tenant/view-lead-tenant/view-lead-tenant.component';
@NgModule({
  declarations: [
    MainComponent,
    HomeComponent,
    RentComponent,
    ViewPropertyComponent,
    LeadDialogComponent,
    SearchFormComponent,
    MyAccountTenantComponent,
    EditMyAccountTenantComponent,
    MyAccountTenantFormComponent,
    LeadsTenantComponent,
    ViewLeadTenantComponent,
  ],
  imports: [
    SharedModule,
    FlexLayoutModule,
    MaterialModule,
    GoogleMapsModule,
    DxSelectBoxModule,
    DxListModule,
    DxTemplateModule,
  ],
})
export class SiteModule {}
