import { DateAgoPipe } from './../core/pipes/date-ago.pipe';
import { OrdinalPipe } from './../core/pipes/ordinal.pipe';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/shared/material.module';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { FileUploaderComponent } from 'src/app/shared/components/file-uploader/file-uploader.component';
import { FileUploadComponent } from 'src/app/shared/components/file-upload/file-upload.component';
import { IfZeroPipe } from 'src/app/core/pipes/if-zero.pipe';
import { AmountPipe } from 'src/app/core/pipes/amount.pipe';
import { CoalescePipe } from 'src/app/core/pipes/coalesce.pipe';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
  declarations: [
    FileUploaderComponent,
    FileUploadComponent,
    OrdinalPipe,
    DateAgoPipe,
    IfZeroPipe,
    AmountPipe,
    CoalescePipe,
  ],
  imports: [CommonModule, MaterialModule, FlexLayoutModule],
  exports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    RouterModule,
    ReactiveFormsModule,
    FileUploaderComponent,
    FileUploadComponent,
    OrdinalPipe,
    DateAgoPipe,
    IfZeroPipe,
    AmountPipe,
    CoalescePipe,
  ],
})
export class SharedModule {}
