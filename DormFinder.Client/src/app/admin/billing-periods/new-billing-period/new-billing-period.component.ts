import { MatDialogRef } from '@angular/material/dialog';
import { TimeParser } from 'src/app/shared/services/time-parser';
import { ICreateBillingPeriod } from './../../../models/billing-periods.model';
import { BillingPeriodService } from './../../../services/billing-period.service';
import { Router } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';
import { BillingPeriodFormComponent } from '../billing-period-form/billing-period-form.component';
import * as moment from 'moment';

@Component({
  selector: 'app-new-billing-period',
  templateUrl: './new-billing-period.component.html',
  styleUrls: ['./new-billing-period.component.scss'],
})
export class NewBillingPeriodComponent implements OnInit {
  @ViewChild(BillingPeriodFormComponent)
  form: BillingPeriodFormComponent;

  constructor(
    private router: Router,
    private billingPeriodService: BillingPeriodService,
    private timeParser: TimeParser,
    private dialogRef: MatDialogRef<NewBillingPeriodComponent>
  ) {}

  ngOnInit(): void {}
  save() {
    if (!this.form.valid) {
      return;
    }
    var billingPeriod = this.form.value;
    this.getDates(billingPeriod);
    this.billingPeriodService.create(this.form.value).subscribe((result) => {
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
