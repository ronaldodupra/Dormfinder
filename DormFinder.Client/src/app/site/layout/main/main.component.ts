import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
})
export class MainComponent implements OnInit {
  isAuthenticated: boolean;

  isTenant: boolean;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.isAuthenticated = this.authService.isAuthenticated();
    this.isTenant = this.authService.getClaims().userType == 'Tenant';
  }

  logout(): void {
    this.authService.logout();
    this.router.navigateByUrl('/login');
  }

  myAccount(): void {
    this.router.navigate(['my-account']);
  }
}
