import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { IAddContract } from 'src/app/models/contract.model';
import { ContractService } from 'src/app/services/contract.service';
import { TimeParser } from 'src/app/shared/services/time-parser';
import { ContractFormComponent } from '../contract-form/contract-form.component';

@Component({
  selector: 'app-edit-contract',
  templateUrl: './edit-contract.component.html',
  styleUrls: ['./edit-contract.component.scss'],
})
export class EditContractComponent implements OnInit {
  @ViewChild(ContractFormComponent)
  form: ContractFormComponent;
  Id: number;
  leadId: number;
  contract: any;
  constructor(
    private contractService: ContractService,
    private snackbar: MatSnackBar,
    private route: ActivatedRoute,
    private router: Router,
    private timeParser: TimeParser
  ) {
    this.Id = +this.route.snapshot.paramMap.get('id');
    this.leadId = +this.route.snapshot.paramMap.get('leadId');
  }

  ngOnInit(): void {
    this.loadContract();
  }

  editcontract(): void {
    if (!this.form.valid) {
      return;
    }
    var contract = this.form.value;

    this.getDates(contract);

    this.contractService.updateContract(this.Id, contract).subscribe({
      next: () => {
        this.snackbar.open('Changes has been saved');
        // this.router.navigate(['admin', 'contracts', this.Id]);
        this.router.navigate(['admin', 'leads']);
      },
    });
  }

  cancel(): void {
    this.router.navigate(['admin', 'leads']);
  }

  private loadContract(): void {
    this.contractService.GetById(this.Id).subscribe((contract) => {
      this.contract = contract;
    });
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
