import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { BuildingFormComponent } from 'src/app/admin/buildings/building-form/building-form.component';
import { BuildingService } from 'src/app/services/building.service';

@Component({
  selector: 'app-edit-building',
  templateUrl: './edit-building.component.html',
  styleUrls: ['./edit-building.component.scss'],
})
export class EditBuildingComponent implements OnInit {
  @ViewChild(BuildingFormComponent)
  form: BuildingFormComponent;

  building: any;

  private buildingId: number;

  constructor(
    private buildingService: BuildingService,
    private snackbar: MatSnackBar,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.buildingId = +this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
    this.loadBuilding();
  }

  save(): void {
    if (!this.form.valid) {
      return;
    }

    this.buildingService.update(this.buildingId, this.form.value).subscribe({
      next: () => {
        this.snackbar.open('Changes has been saved');
        this.router.navigate(['admin', 'buildings', this.buildingId]);
      },
    });
  }

  cancel(): void {
    this.router.navigate(['admin', 'buildings']);
  }

  private loadBuilding(): void {
    this.buildingService
      .getById(this.buildingId)
      .subscribe((building) => (this.building = building));
  }
}
