import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { RegistrationService } from 'src/app/services/registration.service';
import { RegistrationClaims } from '../signup/shared/registration-claims';
import { CommonModule } from '@angular/common';

class LoadingState {
  static LOADING: string = 'Loading';

  static ERROR: string = 'Error';

  static SUCCESS: string = 'Success';

  state: string;

  constructor(state: string) {
    this.state = state;
  }

  get isLoading(): boolean {
    return this.state === LoadingState.LOADING;
  }

  get isSuccess(): boolean {
    return this.state === LoadingState.SUCCESS;
  }

  get isError(): boolean {
    return this.state === LoadingState.ERROR;
  }

  changeState(state: string): void {
    this.state = state;
  }
}


@Component({
  selector: 'app-verify',
  templateUrl: './verify.component.html',
  styleUrls: ['./verify.component.scss']
})
export class VerifyComponent implements OnInit {

  registered: BehaviorSubject<boolean> = new BehaviorSubject(null);
  
  loadingState: LoadingState = new LoadingState(LoadingState.LOADING);

  claim: RegistrationClaims;

  usernameAvailable = false;

  token: string;

  error: string;

  verified: boolean;

  constructor(private registrationService: RegistrationService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    try {
      this.readToken();
      this.readClaims();
      this.checkExpiration();

      this.validateToServer().subscribe(
        () => this.verified = true,
        () => this.verified = false
      );
    } catch (error) {
      if (error instanceof Error) {
        this.showError(error.message);
      } else {
        this.showError('Unexpected error');
      }
    }

    // this.loadingState.changeState(LoadingState.SUCCESS);
  }

  private login(){
    this.router.navigate(['login']);
  }

  private readToken() {
    this.token = this.route.snapshot.queryParams['token'];

    if (this.token == null) {
      throw new Error('Registration token is missing');
    }
  }

  private readClaims() {
    try {
      this.claim = this.registrationService.mapTokenToClaims(this.token);
    } catch (error) {
      throw new Error('Registration link is invalid');
    }
  }

  private checkExpiration() {
    if (this.registrationService.isExpired(this.claim)) {
      throw new Error('Registration link has expired');
    }
  }

  private validateToServer(): Observable<any> {
    return this.registrationService.verify(this.token);
  }

  private showError(text: string) {
    this.loadingState.changeState(LoadingState.ERROR);

    this.error = text;
  }

}
