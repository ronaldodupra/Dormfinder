import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ChargeService } from 'src/app/services/charge.service';
import { ChargeFormComponent } from '../charge-form/charge-form.component';

@Component({
  selector: 'app-edit-charge',
  templateUrl: './edit-charge.component.html',
  styleUrls: ['./edit-charge.component.scss'],
})
export class EditChargeComponent implements OnInit {
  @ViewChild(ChargeFormComponent)
  form: ChargeFormComponent;

  charge: any;

  private chargeId: number;

  constructor(
    private chargeService: ChargeService,
    private snackbar: MatSnackBar,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.chargeId = +this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
    this.loadCharge();
  }

  private save(): void {
    if (!this.form.valid) {
      return;
    }

    this.chargeService.updateCharge(this.chargeId, this.form.value).subscribe({
      next: () => {
        this.snackbar.open('Changes has been saved');
        this.router.navigate(['admin', 'charges']);
      },
    });
  }

  cancel(): void {
    this.router.navigate(['admin', 'charges']);
  }

  private loadCharge(): void {
    this.chargeService
      .getById(this.chargeId)
      .subscribe((building) => (this.charge = building));
  }
}
