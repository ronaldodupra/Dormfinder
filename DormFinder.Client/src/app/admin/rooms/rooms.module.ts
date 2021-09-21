import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { NewRoomComponent } from './new-room/new-room.component';
import { RoomsComponent } from './rooms/rooms.component';
import { ViewRoomComponent } from './view-room/view-room.component';
import { RoomFormComponent } from './room-form/room-form.component';
import { EditRoomComponent } from './edit-room/edit-room.component';
import { EditBedspaceDialogComponent } from './edit-bedspace-dialog/edit-bedspace-dialog.component';

@NgModule({
  declarations: [
    RoomsComponent,
    NewRoomComponent,
    ViewRoomComponent,
    EditRoomComponent,
    RoomFormComponent,
    EditBedspaceDialogComponent,
  ],
  imports: [SharedModule],
})
export class RoomsModule {}
