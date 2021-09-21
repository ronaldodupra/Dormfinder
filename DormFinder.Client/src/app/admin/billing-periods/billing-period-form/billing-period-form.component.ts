import { TimeParser } from 'src/app/shared/services/time-parser';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import {
  ICreateBillingPeriod,
  IBillingPeriod,
} from './../../../models/billing-periods.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, Inject } from '@angular/core';

@Component({
  selector: 'app-billing-period-form',
  templateUrl: './billing-period-form.component.html',
  styleUrls: ['./billing-period-form.component.scss'],
})
export class BillingPeriodFormComponent implements OnInit {
  date = new Date();

  yearPattern = /^[0-9]{4,4}$/;

  id: number;
  months = [
    { id: 1, name: 'January' },
    { id: 2, name: 'February' },
    { id: 3, name: 'March' },
    { id: 4, name: 'April' },
    { id: 5, name: 'May' },
    { id: 6, name: 'June' },
    { id: 7, name: 'July' },
    { id: 8, name: 'August' },
    { id: 9, name: 'September' },
    { id: 10, name: 'October' },
    { id: 11, name: 'November' },
    { id: 12, name: 'December' },
  ];
  get value(): ICreateBillingPeriod {
    const value = this.formGroup.value;
    return value;
  }

  get valid(): boolean {
    this.formGroup.markAllAsTouched();
    return this.formGroup.valid;
  }
  get billingId(): number {
    return this.id;
  }
  constructor(
    private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    if (data.billing) {
      this.id = data.billing.id;
      this.formGroup.patchValue({
        beginDate: data.billing.beginDate,
        endDate: data.billing.endDate,
        month: new Date(data.billing.billingMonth).getMonth() + 1,
        year: new Date(data.billing.billingMonth).getFullYear(),
      });
      this.trigger();
    }
  }
  formGroup: FormGroup = this.fb.group({
    month: [null, [Validators.required]],
    year: [null, [Validators.required, Validators.pattern(this.yearPattern)]],
    beginDate: [null, [Validators.required]],
    endDate: [null, [Validators.required]],
    billingMonth: [null],
  });
  ngOnInit(): void {}
  trigger() {
    this.date.setMonth(this.formGroup.value.month - 1);
    this.date.setFullYear(this.formGroup.value.year);
    this.date.setDate(1);

    this.formGroup.patchValue({
      billingMonth: this.date,
    });
  }
}
