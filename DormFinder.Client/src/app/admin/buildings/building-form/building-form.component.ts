import { Component, Input, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { EMPTY, Observable } from 'rxjs';
import { filter, map, startWith } from 'rxjs/operators';
import { IFileEntry } from 'src/app/core/files/file-entry';
import { FileProgress } from 'src/app/core/files/file-progress';
import { FileService } from 'src/app/core/files/file.service';
import { IBuilding, ICreateBuilding } from 'src/app/models/buildings.model';
import { IBuildingType } from 'src/app/models/buildingtypes.model';
import { ICity, IProvince } from 'src/app/models/options.model';
import { BuildingService } from 'src/app/services/building.service';
import { OptionsService } from 'src/app/services/options.service';

@Component({
  selector: 'app-building-form',
  templateUrl: './building-form.component.html',
  styleUrls: ['./building-form.component.scss'],
})
export class BuildingFormComponent implements OnInit {
  @Input()
  building: IBuilding;

  buildingTypes: IBuildingType[];

  provinces: IProvince[];

  cities: ICity[];

  fileEntries: IFileEntry[] = [];

  FloorEntries: number[] = [];

  filteredCities: Observable<ICity[]>;

  filteredProvinces: Observable<IProvince[]>;

  addAmenityControl: FormControl = this.fb.control(null);

  addNearbyPlaceControl: FormControl = this.fb.control(null);

  marker = null;

  center: google.maps.LatLngLiteral = {
    lat: 14.599512,
    lng: 121.0223,
  };

  nearByPlace = [];

  form: FormGroup = this.fb.group({
    name: [, [Validators.required]],
    description: [],
    buildingType: [],
    floorNumber: [],
    address: this.fb.group({
      province: [],
      city: [],
      addressLine1: [],
      addressLine2: [],
      latitude: [],
      longitude: [],
    }),
    amenities: this.fb.array([]),
    nearByEntries: this.fb.array([]),
    files: this.fb.array([]),
  });

  uploads: {
    file: File;
    progress: Observable<FileProgress<IFileEntry>>;
  }[] = [];

  constructor(
    private optionsService: OptionsService,
    private fb: FormBuilder,
    private buildingservice: BuildingService,
    private fileService: FileService
  ) {}

  get amenities(): FormArray {
    return this.form.get('amenities') as FormArray;
  }
  get nearByEntries(): FormArray {
    return this.form.get('nearByEntries') as FormArray;
  }

  get valid(): boolean {
    this.form.markAllAsTouched();
    return this.form.valid;
  }

  get value(): ICreateBuilding {
    const value = this.form.value;
    value.fileEntries = this.fileEntries;
    value.floorEntries = this.FloorEntries;

    return value;
  }

  ngOnInit(): void {
    if (this.building != null) {
      this.form.patchValue(this.building);
      if (this.building?.address.latitude != null) {
        this.marker = {
          position: {
            lat: this.building.address.latitude,
            lng: this.building.address.longitude,
          },
        };
      }
      this.building.buildingNearbyPlaces.forEach((x) => {
        this.nearByEntries.push(this.fb.control(x.place));
      });
    }
    this.loadbuildingtype();
    this.loadCities();
    this.loadProvinces();
  }

  addAmenity(): void {
    const value = this.addAmenityControl.value as string;
    this.addAmenityControl.setValue(null);

    this.amenities.push(this.fb.control(value));
  }
  testing() {
    this.FloorEntries = Array.from(
      { length: this.form.value.floorNumber },
      (v, k) => k + 1
    );
  }

  upload(file: File): void {
    const upload = this.fileService.upload<IFileEntry>('api/files', file);

    // Wait for the final entry and it to the list of file entries
    upload.pipe(filter((t) => t.isSuccess())).subscribe((t) => {
      console.log(t, t.body);
      this.fileEntries.push(t.body);
    });

    this.uploads.push({
      file,
      progress: upload,
    });
  }

  private loadProvinces(): void {
    this.optionsService.getProvinces().subscribe((provinces) => {
      this.provinces = provinces;
      this.filteredProvinces = this.form
        .get('address.province')
        .valueChanges.pipe(
          startWith(''),
          map((value) => this._filterProvinces(value))
        );
    });
  }

  private loadCities(): void {
    this.optionsService.getCities().subscribe((municipalities) => {
      this.cities = municipalities;
      this.filteredCities = this.form.get('address.city').valueChanges.pipe(
        startWith(''),
        map((value) => this._filter(value))
      );
    });
  }

  private _filterProvinces(value: string): IProvince[] {
    const filterValue = value.toLowerCase();

    return this.provinces
      .filter((option) =>
        option.description.toLowerCase().includes(filterValue)
      )
      .slice(0, 50);
  }

  private _filter(value: string): ICity[] {
    const filterValue = value.toLowerCase();

    return this.cities
      .filter((option) =>
        option.description.toLowerCase().includes(filterValue)
      )
      .slice(0, 50);
  }

  private loadbuildingtype(): void {
    this.buildingservice.getbuildingtype().subscribe((buildingtype) => {
      this.buildingTypes = buildingtype;
    });
  }

  addMarker(event: google.maps.MouseEvent): void {
    this.marker = {
      position: {
        lat: event.latLng.lat(),
        lng: event.latLng.lng(),
      },
    };

    this.form.get('address').patchValue({
      latitude: this.marker?.position.lat,
      longitude: this.marker?.position.lng,
    });
  }

  removeMarker(): void {
    this.marker = null;
  }

  addNearbyPlace(): void {
    const value = this.addNearbyPlaceControl.value as string;
    if (value == null || value == '') {
    } else {
      this.addNearbyPlaceControl.setValue(null);

      this.nearByEntries.push(this.fb.control(value));
    }
  }
  removeNearByPlace(value) {
    this.nearByEntries.removeAt(value);
  }
}
