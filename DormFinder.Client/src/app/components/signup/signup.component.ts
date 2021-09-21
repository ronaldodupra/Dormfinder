import { Component, OnInit, NgModule } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { RegistrationService } from 'src/app/services/registration.service';
import { RegistrationClaims } from './shared/registration-claims';
import Swal from 'sweetalert2';

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
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignUpComponent implements OnInit {
  registered: BehaviorSubject<boolean> = new BehaviorSubject(null);

  loadingState: LoadingState = new LoadingState(LoadingState.LOADING);

  hide = true;

  token: string;
  usertype: string;

  claim: RegistrationClaims;

  usernameAvailable = false;

  error: string;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private registrationService: RegistrationService,
    private router: Router
  ) {}

  form: FormGroup = this.fb.group({
    usertype: [null, Validators.required],
    email: [null, [Validators.required, Validators.email]],
    password: [null, [Validators.required, Validators.minLength(8)]],
    firstname: [null, Validators.required],
    lastName: [null, Validators.required],
    city: [],
  });

  types: string[] = ['Landlord', 'Tenant'];

  ngOnInit(): void {}

  checkUsernameAvailability() {
    const { userName } = this.form.value;

    this.registrationService.getUser(userName).subscribe(
      () => (this.usernameAvailable = true),
      () => (this.usernameAvailable = false)
    );
  }

  private showError(text: string) {
    this.loadingState.changeState(LoadingState.ERROR);

    this.error = text;
  }

  register() {
    if (!this.form.valid) {
      return;
    }

    const value = this.form.value;
    value.token = this.token;

    this.registered.next(true);

    this.registrationService.create(value).subscribe(() => {
      this.showSuccessDialog();
      this.router.navigate(['login']);
    });
  }

  private showSuccessDialog() {
    Swal.fire({
      title: 'Registered',
      text: 'Successfully registered!',
      icon: 'success',
      backdrop: '#01579b',
      showConfirmButton: true,
    });
  }
}
