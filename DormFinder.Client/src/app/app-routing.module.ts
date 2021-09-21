import { AuthGuard } from './auth/auth.guard';
import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { HomeComponent } from './site/home/home/home.component';
import { MainComponent } from './site/layout/main/main.component';
import { RentComponent } from './site/rent/rent/rent.component';
import { ViewPropertyComponent } from './site/rent/view-property/view-property.component';
import { LoginComponent } from './components/login/login.component';
import { SignUpComponent } from './components/signup/signup.component';
import { VerifyComponent } from './components/verify/verify.component';
import { AuthGuardLogin } from './auth/auth.guard.login';
import { MyAccountTenantComponent } from './site/my-account-tenant/my-account-tenant/my-account-tenant.component';
import { EditMyAccountTenantComponent } from './site/my-account-tenant/edit-my-account-tenant/edit-my-account-tenant.component';
import { LeadsTenantComponent } from './site/leads-tenant/leads-tenant/leads-tenant.component';
import { ViewLeadTenantComponent } from './site/leads-tenant/view-lead-tenant/view-lead-tenant.component';

const routes: Route[] = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: '',
        component: HomeComponent,
      },
      {
        path: 'rent',
        component: RentComponent,
      },
      {
        path: ':searchString/rent',
        component: RentComponent,
      },
      {
        path: 'rent/:id',
        component: ViewPropertyComponent,
      },
      {
        path: 'my-account',
        component: MyAccountTenantComponent,
      },
      {
        path: 'my-account/edit',
        component: EditMyAccountTenantComponent,
      },
      {
        path: 'leads',
        component: LeadsTenantComponent,
      },
      {
        path: 'leads/:id',
        component: ViewLeadTenantComponent,
      },
    ],
  },
  {
    path: 'admin',
    loadChildren: () =>
      import('./admin/admin.module').then((m) => m.AdminModule),
    canActivate: [AuthGuard],
  },
  {
    path: 'signup',
    component: SignUpComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [AuthGuardLogin],
  },
  {
    path: 'verify',
    component: VerifyComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
