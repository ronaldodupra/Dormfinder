import { MatSnackBar } from '@angular/material/snack-bar';
import { BedspaceService } from './../../../services/bedspace.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Component, OnInit, Inject, Injectable } from '@angular/core';

@Component({
  selector: 'app-edit-bedspace-dialog',
  templateUrl: './edit-bedspace-dialog.component.html',
  styleUrls: ['./edit-bedspace-dialog.component.scss'],
})
export class EditBedspaceDialogComponent implements OnInit {
  bedspaceId: number;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<EditBedspaceDialogComponent>,
    private bedspaceService: BedspaceService,
    private snackBar: MatSnackBar
  ) {
    this.bedspaceId = data.Id;
    this.formGroup.patchValue({
      description: data.description,
    });
  }
  formGroup: FormGroup = this.fb.group({
    description: [, [Validators.required]],
  });
  ngOnInit(): void {}
  public cancel() {
    this.dialogRef.close();
  }
  public save() {
    if (!this.formGroup.valid) {
      return;
    }
    this.bedspaceService
      .editBedspace(this.bedspaceId, this.formGroup.value)
      .subscribe({
        next: () => {
          this.snackBar.open('Success');
          this.cancel();
        },
        error: () => {
          this.snackBar.open('Error');
        },
      });
  }
}
