import { RoomPicService } from './../../../services/room-pic.service';
import { IBuilding } from 'src/app/models/buildings.model';
import { EditBedspaceDialogComponent } from './../edit-bedspace-dialog/edit-bedspace-dialog.component';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { RoomInclusionService } from './../../../services/room-inclusion.service';
import { InclusionService } from './../../../services/inclusion.service';
import {
  IRoom,
  ICreateRoom,
  IRoomInclusion,
} from './../../../models/rooms.model';
import { RoomsService } from './../../../services/rooms.service';
import { BedspaceService } from './../../../services/bedspace.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { IFile } from 'src/app/models/File.model';

@Component({
  selector: 'app-view-room',
  templateUrl: './view-room.component.html',
  styleUrls: ['./view-room.component.scss'],
})
export class ViewRoomComponent implements OnInit {
  bedSpace: string[];
  roomDetails: IRoom;
  roomInclusion: IRoomInclusion[];
  displayedColumns = ['description', 'isOccupied', 'isActive', 'actions'];
  roomId = Number(this.route.snapshot.paramMap.get('id'));
  loading: boolean = false;
  buildingname: string;
  dialogRef: MatDialogRef<EditBedspaceDialogComponent>;
  roomPics: IFile;
  date = new Date();
  dialogRefOccupant: any;
  constructor(
    private route: ActivatedRoute,
    private roomService: RoomsService,
    private bedSpaceService: BedspaceService,
    private roomInclusionService: RoomInclusionService,
    private roompicService: RoomPicService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.viewDetails(this.roomId);
    this.loadBed(this.roomId);
    // this.loadInclusion(this.roomId);
  }
  public loadBed(roomId) {
    this.bedSpaceService.getBedspaces(roomId).subscribe((result) => {
      this.bedSpace = result;
    });
  }
  public viewDetails(roomId) {
    this.roomService.getRoom(roomId).subscribe((result) => {
      this.roomDetails = result;
      this.roomInclusion = result.roomInclusion;
      this.buildingname = result.building.name;
      this.roomPics = result.roomPics;
    });
  }
  public loadInclusion(roomId) {
    this.roomInclusionService.getRoomInclusion(roomId).subscribe((result) => {
      this.roomInclusion = result;
    });
  }
  public editRoom(room) {
    console.log(room);
  }
  updateBedStatus(id, status) {
    this.loading = true;
    const body = {
      isActive: status,
    };
    this.bedSpaceService.updateBedStatus(id, body).subscribe((result) => {
      this.loadBed(this.roomId);
      this.loading = false;
    });
  }
  public editBedspace(Id, description) {
    this.dialogRef = this.dialog.open(EditBedspaceDialogComponent, {
      data: {
        Id,
        description,
      },
      width: '40%',
    });

    this.dialogRef.afterClosed().subscribe((result) => {
      this.loadBed(this.roomId);
    });
  }
  public setThumbnail(id) {
    this.roompicService.setupthumbNail(this.roomId, id).subscribe((result) => {
      this.viewDetails(this.roomId);
    });
  }
  public delete(id) {
    this.roompicService.removeImage(id).subscribe((result) => {
      this.viewDetails(this.roomId);
    });
  }
}
