import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LeadService } from 'src/app/services/lead.service';
import Swal from 'sweetalert2';
import { ViewPropertyComponent } from '../view-property.component';

@Component({
  selector: 'app-lead-dialog',
  templateUrl: './lead-dialog.component.html',
  styleUrls: ['./lead-dialog.component.scss'],
})
export class LeadDialogComponent implements OnInit {
  private roomId: number;

  constructor(
    private fb: FormBuilder,
    private leadService: LeadService,
    private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<ViewPropertyComponent>
  ) {
    this.roomId = data.roomId;
    this.form.patchValue({
      roomId: this.roomId,
    });
  }

  form: FormGroup = this.fb.group({
    firstname: [null, Validators.required],
    lastName: [null, Validators.required],
    email: [null, [Validators.required, Validators.email]],
    number: [null, Validators.required],
    message: [],
    roomId: [],
  });

  ngOnInit(): void {}

  newlead(): void {
    if (!this.form.valid) {
      return;
    }
    this.leadService.addlead(this.form.value).subscribe({
      next: () => {
        this.showSuccessDialog();
        this.closeDialog();
      },
    });
  }

  cancel(): void {
    this.closeDialog();
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

  private showSuccessDialog(): void {
    Swal.fire({
      title: 'Message',
      text: 'Message Successfully Sent',
      icon: 'success',
      backdrop: '#01579b',
      showConfirmButton: true,
    });
  }
}
