import { LeadsComponent } from './leads/leads.component';
import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { ViewLeadComponent } from './view-lead/view-lead.component';
import { ContractFormComponent } from './contract-form/contract-form.component';
import { NewContractComponent } from './new-contract/new-contract.component';
import { EditContractComponent } from './edit-contract/edit-contract.component';
@NgModule({
  declarations: [
    LeadsComponent,
    ViewLeadComponent,
    ContractFormComponent,
    NewContractComponent,
    EditContractComponent,
  ],
  imports: [SharedModule],
})
export class LeadModule {}
