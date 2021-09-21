import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { ICity, IProvince } from 'src/app/models/options.model';
import { IUser } from 'src/app/models/user.model';

@Component({
  selector: 'app-my-account-form',
  templateUrl: './my-account-form.component.html',
  styleUrls: ['./my-account-form.component.scss'],
})
export class MyAccountFormComponent implements OnInit {
  @Input()
  user: IUser;

  genderInvalid: boolean = false;

  imageUrl: any;

  newImage: File;

  filteredCities: Observable<ICity[]>;

  filteredProvinces: Observable<IProvince[]>;

  form: FormGroup = this.fb.group({
    firstName: [null, Validators.required],
    lastName: [null, Validators.required],
    gender: [null, Validators.required],
    address: this.fb.group({
      province: [],
      city: [],
      addressLine1: [],
      addressLine2: [],
    }),
  });

  constructor(private fb: FormBuilder, private sanitizer: DomSanitizer) {}

  get valid(): boolean {
    this.form.markAllAsTouched();
    return this.form.valid;
  }

  get value(): IUser {
    const value = this.form.value;

    return value;
  }

  get image(): File {
    return this.newImage;
  }

  ngOnInit(): void {
    this.imageUrl = 'api/files/' + this.user.originalImageId;

    if (this.user) {
      this.form.patchValue(this.user);
    }
  }

  onSelect(files: FileList): void {
    this.newImage = files.item(0);

    this.readFile();
  }

  selectionChange(event: any) {
    if (event.value) {
      this.genderInvalid = false;
    }
  }

  private readFile(): void {
    const reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = this.sanitizer.bypassSecurityTrustResourceUrl(
        event.target.result
      );
    };

    reader.readAsDataURL(this.newImage);
  }
}
