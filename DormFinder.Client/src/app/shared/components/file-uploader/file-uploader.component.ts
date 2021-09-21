import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-file-uploader',
  templateUrl: './file-uploader.component.html',
  styleUrls: ['./file-uploader.component.scss'],
  host: {
    class: 'block',
  },
})
export class FileUploaderComponent {
  @Output()
  upload: EventEmitter<File> = new EventEmitter();

  onSelect(files: FileList): void {
    Array.from(files).forEach((file) => this.upload.emit(file));
  }
}
