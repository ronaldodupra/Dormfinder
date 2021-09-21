import { NgModule } from '@angular/core';
import { BuildingsComponent } from './buildings/buildings.component';
import { NewBuildingComponent } from './new-building/new-building.component';
import { ViewBuildingComponent } from './view-building/view-building.component';
import { EditBuildingComponent } from './edit-building/edit-building.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { BuildingFormComponent } from './building-form/building-form.component';
import { GoogleMapsModule } from '@angular/google-maps';

@NgModule({
  declarations: [
    BuildingsComponent,
    NewBuildingComponent,
    ViewBuildingComponent,
    EditBuildingComponent,
    BuildingFormComponent,
  ],
  imports: [SharedModule, GoogleMapsModule],
})
export class BuildingsModule {}
