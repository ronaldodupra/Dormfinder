import { ActivatedRoute } from '@angular/router';
import { Component, Input, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { IAddContract, IContract } from 'src/app/models/contract.model';
import { IAddlead, Ilead } from 'src/app/models/lead.model';
import { IRoom } from 'src/app/models/rooms.model';
import { OptionsService } from 'src/app/services/options.service';
import { RoomsService } from 'src/app/services/rooms.service';
import { ICharge } from 'src/app/models/charge.model';
import { ChargeService } from 'src/app/services/charge.service';
import { PageOptions } from 'src/app/core/pageoptions/PageOptions';
import { IChargeType } from 'src/app/models/chargetype.model';

@Component({
  selector: 'app-contract-form',
  templateUrl: './contract-form.component.html',
  styleUrls: ['./contract-form.component.scss'],
})
export class ContractFormComponent implements OnInit {
  @Input()
  contract: IContract;

  @Input()
  lead: Ilead;

  charges: ICharge[];

  rooms: IRoom[];

  leadId: number;

  addChargeControl: FormControl = this.fb.control(null);

  form: FormGroup = this.fb.group({
    rentalEffectivityDate: [null, Validators.required],
    moveInDate: [null],
    moveOutDate: [null],
    rentalEndDate: [null],
    reservationStartDate: [null],
    reservationExpirationDate: [null],
    allowableReservationDays: [null],
    earlyTerminationFee: [null],
    tenantName: [null, Validators.required],
    roomId: [null, Validators.required],
    unitNumber: [null, Validators.required],
    bedSpaceNumber: [null, Validators.required],
    securityDeposit: [null, Validators.required],
    rfidDeposit: [null, Validators.required],
    utilitiesElectricity: [null, Validators.required],
    utilitiesWater: [null, Validators.required],
    basicRent: [null, Validators.required],
    status: [null, Validators.required],
    leadId: [null],
    contractCharge: this.fb.array([]),
  });

  constructor(
    private optionsService: OptionsService,
    private fb: FormBuilder,
    private roomService: RoomsService,
    private route: ActivatedRoute,
    private chargeService: ChargeService
  ) {
    this.leadId = Number(this.route.snapshot.paramMap.get('leadId'));
  }

  get contractCharge(): FormArray {
    return this.form.get('contractCharge') as FormArray;
  }

  get valid(): boolean {
    this.form.markAllAsTouched();
    return this.form.valid;
  }
  get value(): IAddContract {
    const value = this.form.value;
    value.leadId = this.leadId;
    value.userId = this.getUserId();

    value.contractCharge = [];
    this.contractCharge.value.forEach((element) => {
      value.contractCharge.push(element.id);
    });

    return value;
  }

  ngOnInit(): void {
    if (this.lead != undefined) {
      this.form.patchValue({
        tenantName: this.lead.firstName + ' ' + this.lead.lastName,
        unitNumber: this.lead.room.roomNumber,
        basicRent: this.lead.room.basicRent,
        roomId: this.lead.roomId,
      });
    }
    if (this.contract != null) {
      this.form.patchValue(this.contract);

      this.contract.contractCharge.forEach((x) => {
        this.contractCharge.push(this.fb.control(x.charge));
      });
    }

    this.loadCharges();
    this.loadRooms();
  }

  private getUserId(): number {
    if (this.lead != undefined) return this.lead.userId;
    else return this.contract.userId;
  }

  loadCharges() {
    this.chargeService.getCharges(new PageOptions()).subscribe((data) => {
      this.charges = data.items;
    });
  }

  loadRooms() {
    this.roomService.getRoomList().subscribe({
      next: (data) => {
        this.rooms = data;
      },
    });
  }

  addCharge(): void {
    const value: ICharge = this.addChargeControl.value;
    if (value == null) {
    } else {
      this.addChargeControl.setValue(null);

      this.contractCharge.push(this.fb.control(value));

      console.log(this.form.value);
    }
  }
  removeCharge(value) {
    this.contractCharge.removeAt(value);
  }
}
