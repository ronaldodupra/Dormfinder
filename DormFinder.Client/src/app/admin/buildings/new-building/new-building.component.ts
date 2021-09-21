import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { BuildingFormComponent } from 'src/app/admin/buildings/building-form/building-form.component';
import { BuildingService } from 'src/app/services/building.service';

@Component({
  selector: 'app-new-building',
  templateUrl: './new-building.component.html',
  styleUrls: ['./new-building.component.scss'],
})
export class NewBuildingComponent implements OnInit {
  @ViewChild(BuildingFormComponent)
  form: BuildingFormComponent;

  constructor(
    private buildingService: BuildingService,
    private snackbar: MatSnackBar,
    private router: Router
  ) {}

  ngOnInit(): void {}

  save(): void {
    if (!this.form.valid) {
      return;
    }

    this.buildingService.create(this.form.value).subscribe({
      next: () => {
        this.snackbar.open('Success');
        this.router.navigate(['admin', 'buildings']);
      },
      error: () => {
        this.snackbar.open('Error');
      },
    });
  }

  cancel(): void {
    this.router.navigate(['admin', 'buildings']);
  }
}
