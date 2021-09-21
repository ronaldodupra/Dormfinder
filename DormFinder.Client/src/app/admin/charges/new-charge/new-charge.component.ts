import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ChargeService } from 'src/app/services/charge.service';
import { ChargeFormComponent } from '../charge-form/charge-form.component';

@Component({
  selector: 'app-new-charge',
  templateUrl: './new-charge.component.html',
  styleUrls: ['./new-charge.component.scss'],
})
export class NewChargeComponent implements OnInit {
  @ViewChild(ChargeFormComponent)
  form: ChargeFormComponent;

  constructor(
    private chargeService: ChargeService,
    private snackbar: MatSnackBar,
    private router: Router
  ) {}

  ngOnInit(): void {}

  save(): void {
    if (!this.form.valid) {
      return;
    }

    this.chargeService.addCharge(this.form.value).subscribe({
      next: () => {
        this.snackbar.open('Success');
        this.router.navigate(['admin', 'charges']);
      },
      error: () => {
        this.snackbar.open('Error');
      },
    });
  }

  cancel(): void {
    this.router.navigate(['admin', 'charges']);
  }
}
