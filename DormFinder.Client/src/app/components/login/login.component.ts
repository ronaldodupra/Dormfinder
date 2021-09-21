import { AuthGuard } from './../../auth/auth.guard';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loggingIn: BehaviorSubject<boolean> = new BehaviorSubject(null);

  loginError: string;

  form: FormGroup = this.fb.group({
    email: [null],
    password: [null],
  });

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private guard: AuthGuard
  ) {}

  ngOnInit(): void {
    this.checkIfAuthenticated();
    // this.fbLibrary();
  }

  fbLibrary() {
    (window as any).fbAsyncInit = function () {
      window['FB'].init({
        appId: '260642268721208',
        cookie: true,
        xfbml: true,
        version: 'v8.0',
      });
      window['FB'].AppEvents.logPageView();
    };

    (function (d, s, id) {
      var js,
        fjs = d.getElementsByTagName(s)[0];
      if (d.getElementById(id)) {
        return;
      }
      js = d.createElement(s);
      js.id = id;
      js.src = 'https://connect.facebook.net/en_US/sdk.js';
      fjs.parentNode.insertBefore(js, fjs);
    })(document, 'script', 'facebook-jssdk');
  }

  fblogin() {
    window.location.href = 'https://localhost:5001/ExternalLogin';
  }

  forgotPassword(): void {
    this.router.navigate(['account', 'forgot-password']);
  }

  login(): void {
    console.log(this.form.value);
    if (!this.form.valid) {
      return;
    }

    const { email, password } = this.form.value;

    this.loginError = null;
    this.loggingIn.next(true);

    this.authService.login(email, password).subscribe(
      () => {
        if (this.authService.redirectUrl != null) {
          const attemptedUrl = this.authService.redirectUrl;
          this.authService.redirectUrl = null;
          this.router.navigateByUrl(attemptedUrl);
        } else {
          if (this.authService.getClaims().userType == 'Landlord')
            this.router.navigate(['admin']);
          else this.router.navigate(['']);
        }
      },
      (error) => {
        this.loginError = error;
        console.log(error);
        this.loggingIn.next(false);
      }
    );
  }

  signup() {
    this.router.navigate(['signup']);
  }
  public checkIfAuthenticated() {
    if (!this.authService.isTokenValid()) {
      this.authService.logout();
      this.router.navigate(['login']);
    }
  }
}
