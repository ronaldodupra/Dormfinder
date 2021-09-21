import { MatSnackBar } from '@angular/material/snack-bar';
import { RoomFormComponent } from './../room-form/room-form.component';
import { RoomsService } from './../../../services/rooms.service';
import { Router } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-new-room',
  templateUrl: './new-room.component.html',
  styleUrls: ['./new-room.component.scss'],
})
export class NewRoomComponent implements OnInit {
  @ViewChild(RoomFormComponent)
  form: RoomFormComponent;
  constructor(
    private router: Router,
    private roomService: RoomsService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {}

  saveRoom() {
    if (!this.form.valid) {
      return;
    }
    this.roomService.insertRoom(this.form.value).subscribe({
      next: (result) => {
        this.snackBar.open('Success');
        this.router.navigate(['admin', 'rooms', result.id]);
      },
      error: () => {
        this.snackBar.open('Error');
      },
    });
  }
  cancel(): void {
    this.router.navigate(['admin', 'rooms']);
  }
}
