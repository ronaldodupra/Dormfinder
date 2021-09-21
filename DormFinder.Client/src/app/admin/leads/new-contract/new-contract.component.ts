import { LeadService } from 'src/app/services/lead.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import * as moment from 'moment';
import { IAddContract } from 'src/app/models/contract.model';
import { TimeParser } from 'src/app/shared/services/time-parser';
import { IUpdateContract } from 'src/app/models/contract.model';
import { IAddlead, Ilead } from 'src/app/models/lead.model';
import { ContractService } from 'src/app/services/contract.service';
import { RoomsService } from 'src/app/services/rooms.service';
import { ContractFormComponent } from '../contract-form/contract-form.component';

@Component({
  selector: 'app-new-contract',
  templateUrl: './new-contract.component.html',
  styleUrls: ['./new-contract.component.scss'],
})
export class NewContractComponent implements OnInit {
  @ViewChild(ContractFormComponent)
  form: ContractFormComponent;
  lead: Ilead;
  leadId: number;
  constructor(
    private fb: FormBuilder,
    private contractService: ContractService,
    private snackbar: MatSnackBar,
    private router: Router,
    private timeParser: TimeParser,
    private route: ActivatedRoute,
    private leadService: LeadService
  ) {
    this.leadId = Number(this.route.snapshot.paramMap.get('leadId'));
  }

  ngOnInit(): void {
    // if (history.state.id) {
    //   this.lead = history.state;
    // }
    this.getLeadById(this.leadId);
  }
  getLeadById(Id): void {
    this.leadService.getLeadById(Id).subscribe((result) => {
      this.lead = result;
      console.log(result);
    });
  }

  newContract() {
    if (!this.form.valid) {
      return;
    }
    var contract = this.form.value;

    this.getDates(contract);

    this.contractService.addContract(contract).subscribe({
      next: () => {
        this.snackbar.open('Success');
        this.router.navigate(['admin', 'leads']);
      },
      error: () => {
        this.snackbar.open('Error');
      },
    });
  }

  cancel(): void {
    this.router.navigate(['admin', 'leads']);
  }

  private getDates(contract: IAddContract) {
    contract.moveInDate = this.timeParser.parse(moment(contract.moveInDate));

    contract.moveOutDate = this.timeParser.parse(moment(contract.moveOutDate));

    contract.rentalEffectivityDate = this.timeParser.parse(
      moment(contract.rentalEffectivityDate)
    );

    contract.rentalEndDate = this.timeParser.parse(
      moment(contract.rentalEndDate)
    );

    contract.reservationStartDate = this.timeParser.parse(
      moment(contract.reservationStartDate)
    );

    contract.reservationExpirationDate = this.timeParser.parse(
      moment(contract.reservationExpirationDate)
    );
  }
}
