import { IFloors } from './../../../models/buildings.model';
import { IBuilding } from 'src/app/models/buildings.model';
import { FileProgress } from './../../../core/files/file-progress';
import { filter } from 'rxjs/operators';
import { IFileEntry } from './../../../core/files/file-entry';
import { FileService } from './../../../core/files/file.service';
import { ICreateRoom, IRoom } from './../../../models/rooms.model';
import { InclusionService } from './../../../services/inclusion.service';
import { BuildingService } from './../../../services/building.service';
import { RoomTypeDataService } from './../../../services/room-type-data.service';
import { RoomsService } from './../../../services/rooms.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html',
  styleUrls: ['./room-form.component.scss'],
})
export class RoomFormComponent implements OnInit {
  @Input()
  room: ICreateRoom;

  constructor(
    private fb: FormBuilder,
    private roomTypeService: RoomTypeDataService,
    private buildingService: BuildingService,
    private inclusionService: InclusionService,
    public fileService: FileService
  ) {}

  ngOnInit(): void {
    this.loadBuildings();
    this.loadRoomType();
    this.loadInclusion();
  }

  roomTypeData: any[];
  inclusionData: string[];
  buildingData: IBuilding[];
  floors: IFloors[];
  fileEntries: IFileEntry[] = [];
  floorLength: number;
  uploads: {
    file: File;
    progress: Observable<FileProgress<IFileEntry>>;
  }[] = [];

  formGroup: FormGroup = this.fb.group({
    roomName: [, [Validators.required]],
    buildingId: [, [Validators.required]],
    type: [, [Validators.required]],
    area: [],
    roomNumber: [null],
    description: [null],
    floorId: [],
    basicRent: [],
    roomInclusions: [[]],
    securityDeposit: [],
    advanceRent: [],
    occupant: [],
  });

  public loadRoomType() {
    this.roomTypeService.getRoomType().subscribe((result) => {
      this.roomTypeData = result;
    });
  }

  get value(): ICreateRoom {
    const value = this.formGroup.value;
    value.fileEntries = this.fileEntries;
    return value;
  }

  get valid(): boolean {
    this.formGroup.markAllAsTouched();
    return this.formGroup.valid;
  }

  public loadInclusion() {
    this.inclusionService.getInclusions().subscribe((result) => {
      this.inclusionData = result;
    });
  }

  public loadBuildings() {
    this.buildingService.getBuildings().subscribe((result) => {
      this.buildingData = result.items;
    });
  }

  upload(file: File): void {
    const upload = this.fileService.upload<IFileEntry>('api/files', file);

    // Wait for the final entry and it to the list of file entries
    upload.pipe(filter((t) => t.isSuccess())).subscribe((t) => {
      console.log(t, t.body.filename);
      console.log(t);
      this.fileEntries.push(t.body);
    });

    this.uploads.push({
      file,
      progress: upload,
    });
  }

  floor(e) {
    const filter = this.buildingData.find((x) => x.id == e);
    this.floors = filter.floors;
    this.floorLength = this.floors.length;
  }
}
