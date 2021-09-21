import { Component, Input, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ICharge } from 'src/app/models/charge.model';
import { IChargeType } from 'src/app/models/chargetype.model';
import { ChargeTypeService } from 'src/app/services/charge-type.service';

@Component({
  selector: 'app-charge-form',
  templateUrl: './charge-form.component.html',
  styleUrls: ['./charge-form.component.scss'],
})
export class ChargeFormComponent implements OnInit {
  @Input()
  charge: ICharge;

  chargeTypes: IChargeType[];

  form: FormGroup = this.fb.group({
    comments: [''],
    defaultCharge: [null, Validators.required],
    billingStatementOrder: [null, Validators.required],
    isVat: [null, Validators.required],
    chargeTypeId: [],
  });

  constructor(
    private fb: FormBuilder,
    private chargeTypeService: ChargeTypeService
  ) {}

  get valid(): boolean {
    this.form.markAllAsTouched();
    return this.form.valid;
  }

  get value(): ICharge {
    const value = this.form.value;

    return value;
  }

  ngOnInit(): void {
    if (this.charge) {
      this.form.patchValue(this.charge);
    }

    this.chargeTypeService.getChargeTypes().subscribe((data) => {
      this.chargeTypes = data.items;
    });
  }
}
