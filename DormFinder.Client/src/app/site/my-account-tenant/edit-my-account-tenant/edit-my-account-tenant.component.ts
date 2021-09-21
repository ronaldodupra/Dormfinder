import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { IUser } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';
import { MyAccountTenantFormComponent } from '../my-account-tenant-form/my-account-tenant-form.component';

@Component({
  selector: 'app-edit-my-account-tenant',
  templateUrl: './edit-my-account-tenant.component.html',
  styleUrls: ['./edit-my-account-tenant.component.scss'],
})
export class EditMyAccountTenantComponent implements OnInit {
  @ViewChild(MyAccountTenantFormComponent)
  form: MyAccountTenantFormComponent;

  user: IUser;

  constructor(
    private userService: UserService,
    private snackbar: MatSnackBar,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getCurrentUser();
  }

  getCurrentUser() {
    this.userService.getCurrentUser().subscribe({
      next: (data) => {
        this.user = data;
      },
    });
  }

  save() {
    if (this.form.valid) {
      this.userService.updateUser(this.form.value).subscribe();

      if (this.form.image) {
        this.userService.updateUserImage(this.form.image).subscribe({
          next: (data) => {
            if (data) this.showSuccess();
          },
        });
      } else {
        this.showSuccess();
      }
    } else if (this.form.value.gender == null) {
      this.form.genderInvalid = true;
    }
  }

  showSuccess() {
    this.snackbar.open('Changes has been saved');
    this.router.navigate(['my-account']);
  }

  cancel() {
    this.router.navigate(['my-account']);
  }
}
