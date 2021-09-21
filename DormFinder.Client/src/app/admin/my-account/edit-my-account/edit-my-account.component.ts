import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { IUser } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';
import { MyAccountFormComponent } from '../my-account-form/my-account-form.component';

@Component({
  selector: 'app-edit-my-account',
  templateUrl: './edit-my-account.component.html',
  styleUrls: ['./edit-my-account.component.scss'],
})
export class EditMyAccountComponent implements OnInit {
  @ViewChild(MyAccountFormComponent)
  form: MyAccountFormComponent;

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
    this.router.navigate(['admin', 'my-account']);
  }

  cancel() {
    this.router.navigate(['admin', 'my-account']);
  }
}
