import { BillingPeriodsComponent } from './billing-periods/billing-periods.component';
import { SharedModule } from '../../shared/shared.module';
import { NgModule } from '@angular/core';
import { NewBillingPeriodComponent } from './new-billing-period/new-billing-period.component';
import { BillingPeriodFormComponent } from './billing-period-form/billing-period-form.component';
import { ViewBillingPeriodsComponent } from './view-billing-periods/view-billing-periods.component';
import { EditBillingPeriodComponent } from './edit-billing-period/edit-billing-period.component';
@NgModule({
  declarations: [
    BillingPeriodsComponent,
    NewBillingPeriodComponent,
    BillingPeriodFormComponent,
    ViewBillingPeriodsComponent,
    EditBillingPeriodComponent,
  ],
  imports: [SharedModule],
})
export class BillingPeriodsModule {}
