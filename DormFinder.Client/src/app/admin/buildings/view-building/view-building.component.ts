import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBuilding } from 'src/app/models/buildings.model';
import { BuildingService } from 'src/app/services/building.service';

@Component({
  selector: 'app-view-building',
  templateUrl: './view-building.component.html',
  styleUrls: ['./view-building.component.scss'],
})
export class ViewBuildingComponent implements OnInit {
  private roomId: number = +this.route.snapshot.paramMap.get('id');

  buildingDetails: IBuilding;

  constructor(
    private route: ActivatedRoute,
    private buildingService: BuildingService
  ) {}

  ngOnInit(): void {
    this.getBuildingDetails();
  }

  getBuildingDetails() {
    this.buildingService.getById(this.roomId).subscribe((data) => {
      this.buildingDetails = data;
      console.log(data);
    });
  }
}
