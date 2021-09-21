import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { BillingsComponent } from './billings/billings.component';
import { WaterReadingComponent } from './billings//utilities/water-reading/water-reading.component';
import { ElectricityReadingComponent } from './billings/utilities/electricity-reading/electricity-reading.component';

@NgModule({
  declarations: [
    BillingsComponent,
    WaterReadingComponent,
    ElectricityReadingComponent,
  ],
  imports: [SharedModule],
})
export class BillingsModule {}
