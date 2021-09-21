import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FileProgress } from 'src/app/core/files/file-progress';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss'],
  host: {
    class: 'block',
  },
})
export class FileUploadComponent implements OnInit {
  @Input()
  progress: Observable<FileProgress<any>>;

  @Input()
  file: File;

  currentState: FileProgress<any>;

  src: string | ArrayBuffer;

  ngOnInit(): void {
    this.readImagePreview();
    this.progress.subscribe((state) => (this.currentState = state));
  }

  private readImagePreview(): void {
    const reader = new FileReader();
    reader.onload = (e) => {
      this.src = e.target.result;
    };
    reader.readAsDataURL(this.file);
  }
}
