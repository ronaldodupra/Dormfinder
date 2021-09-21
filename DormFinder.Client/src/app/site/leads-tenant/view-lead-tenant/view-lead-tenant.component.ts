import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { IAddlead } from 'src/app/models/lead.model';
import { ContractService } from 'src/app/services/contract.service';
import { LeadService } from 'src/app/services/lead.service';

@Component({
  selector: 'app-view-lead-tenant',
  templateUrl: './view-lead-tenant.component.html',
  styleUrls: ['./view-lead-tenant.component.scss'],
})
export class ViewLeadTenantComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private leadService: LeadService,
    private contractService: ContractService,
    private snackbar: MatSnackBar
  ) {
    this.leadId = this.route.snapshot.paramMap.get('id');
  }

  leadId: string;

  lead: IAddlead;

  ngOnInit(): void {
    this.leadById(this.leadId);
  }
  public leadById(Id) {
    this.leadService.getLeadById(Id).subscribe((result) => {
      this.lead = result;
      console.log(result);
    });
  }

  private approve() {
    this.contractService.approveContract(this.lead.contract.id).subscribe({
      next: () => {
        this.snackbar.open('Success');
        this.leadById(this.leadId);
      },
      error: () => {
        this.snackbar.open('Error');
      },
    });
  }
}
