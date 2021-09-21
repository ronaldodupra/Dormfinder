import {
  IRoomProperty,
  IRoomPic,
  IRoomInclusion,
  IBuildingPics,
  IBuildingAmenity,
} from './../../../models/room-property';
import { IAddress } from './../../../models/address.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { img } from './../rent/test';
import { PropertyService } from './../../../services/property.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LeadDialogComponent } from './lead-dialog/lead-dialog.component';

@Component({
  selector: 'app-view-property',
  templateUrl: './view-property.component.html',
  styleUrls: ['./view-property.component.scss'],
})
export class ViewPropertyComponent implements OnInit {
  Id: number;
  img = img;
  propertyDetails: IRoomProperty;
  address: IAddress;
  roomInclusions: IRoomInclusion[];
  roomImages: IRoomPic[];
  buildingImages: IBuildingPics[];
  buildingAmentiy: IBuildingAmenity[];
  formGroup: FormGroup = this.fb.group({
    name: [],
    email: [],
    website: [],
    comment: [],
  });
  properties: string;
  center: any;
  marker = null;
  constructor(
    private route: ActivatedRoute,
    private propertyService: PropertyService,
    private fb: FormBuilder,
    private dialog: MatDialog
  ) {
    this.Id = +this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
    this.getProperty(this.Id);
    this.similarProperty();
  }
  public event(event: google.maps.MouseEvent): void {
    this.marker = {
      position: {
        lat: event.latLng.lat(),
        lng: event.latLng.lng(),
      },
    };
  }
  public getProperty(id) {
    this.propertyService.getProperty(id).subscribe((result) => {
      this.propertyDetails = result;
      this.roomInclusions = result.roomInclusion;
      this.address = result.building.address;
      this.roomImages = result.roomPics;
      this.buildingImages = result.building.buildingPics;
      this.buildingAmentiy = result.building.buildingAmenities;
      this.center = {
        lat: Number(result.building.address.latitude),
        lng: Number(result.building.address.longitude),
      };
      this.marker = {
        position: {
          lat: Number(result.building.address.latitude),
          lng: Number(result.building.address.longitude),
        },
      };
    });
  }
  openDialogbox(): void {
    this.dialog.open(LeadDialogComponent, {
      width: '40%',
      height: '30',
      data: {
        roomId: this.Id,
      },
    });
  }
  public similarProperty() {
    this.propertyService.getSimilarProperty(this.Id).subscribe((result) => {
      this.properties = result;
    });
  }
}
