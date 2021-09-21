import { MatDialogRef } from '@angular/material/dialog';
import { TimeParser } from 'src/app/shared/services/time-parser';
import { ICreateBillingPeriod } from './../../../models/billing-periods.model';
import { Router } from '@angular/router';
import { BillingPeriodService } from './../../../services/billing-period.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { BillingPeriodFormComponent } from '../billing-period-form/billing-period-form.component';
import * as moment from 'moment';

@Component({
  selector: 'app-edit-billing-period',
  templateUrl: './edit-billing-period.component.html',
  styleUrls: ['./edit-billing-period.component.scss'],
})
export class EditBillingPeriodComponent implements OnInit {
  @ViewChild(BillingPeriodFormComponent)
  form: BillingPeriodFormComponent;
  constructor(
    private billingPeriodService: BillingPeriodService,
    private router: Router,
    private timeParser: TimeParser,
    private dialogRef: MatDialogRef<EditBillingPeriodComponent>
  ) {}

  ngOnInit(): void {}
  save() {
    if (!this.form.valid) {
      return;
    }
    var billingPeriod = this.form.value;
    this.getDates(billingPeriod);
    this.billingPeriodService
      .update(this.form.value, this.form.billingId)
      .subscribe((result) => {
        this.cancel();
        this.router.navigate(['admin', 'billing', result.id]);
      });
  }
  public cancel() {
    this.dialogRef.close();
  }
  private getDates(contract: ICreateBillingPeriod) {
    contract.endDate = this.timeParser.parse(moment(contract.endDate));

    contract.beginDate = this.timeParser.parse(moment(contract.beginDate));
  }
}
