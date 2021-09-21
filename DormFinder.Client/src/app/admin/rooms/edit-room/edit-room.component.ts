import { MatSnackBar } from '@angular/material/snack-bar';
import { IRoom, ICreateRoom } from './../../../models/rooms.model';
import { RoomsService } from './../../../services/rooms.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';
import { RoomFormComponent } from '../room-form/room-form.component';
import { timeInterval } from 'rxjs/operators';

@Component({
  selector: 'app-edit-room',
  templateUrl: './edit-room.component.html',
  styleUrls: ['./edit-room.component.scss'],
})
export class EditRoomComponent implements OnInit {
  @ViewChild(RoomFormComponent)
  form: RoomFormComponent;
  private roomId: number;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private roomService: RoomsService,
    private snackBar: MatSnackBar
  ) {
    this.roomId = +this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
    this.LoadRoomId();
  }
  updateRoom() {
    if (!this.form.valid) {
      return;
    }
    this.roomService.updateRoom(this.roomId, this.form.value).subscribe({
      next: () => {
        this.snackBar.open('Success');
        this.router.navigate(['admin', 'rooms', this.roomId]);
      },
      error: () => {
        this.snackBar.open('Error');
      },
    });
  }
  cancel(): void {
    this.router.navigate(['admin', 'rooms']);
  }
  private LoadRoomId() {
    this.roomService.getRoom(this.roomId).subscribe((room) => {
      this.form.formGroup.patchValue(room);

      this.patchInclusion(room);
    });
  }
  public patchInclusion(room) {
    var InclusionId = [];
    room.roomInclusion.forEach((x) => {
      InclusionId.push(x.inclusion.id);
    });

    this.form.formGroup.patchValue({
      roomInclusions: InclusionId,
      type: room.roomType.id,
      buildingId: room.building.id,
    });
    setTimeout(() => {
      this.form.floor(room.building.id);
    }, 350);
  }
}
