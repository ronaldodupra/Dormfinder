import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.scss'],
})
export class MyAccountComponent implements OnInit {
  user: IUser;

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.getCurrentUser();
  }

  private getCurrentUser() {
    this.userService.getCurrentUser().subscribe({
      next: (data) => {
        this.user = data;
      },
    });
  }
}
