import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChargesComponent } from './charges/charges.component';
import { ChargeFormComponent } from './charge-form/charge-form.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { EditChargeComponent } from './edit-charge/edit-charge.component';
import { NewChargeComponent } from './new-charge/new-charge.component';

@NgModule({
  declarations: [
    ChargesComponent,
    ChargeFormComponent,
    EditChargeComponent,
    NewChargeComponent,
  ],
  imports: [SharedModule],
})
export class ChargesModule {}
