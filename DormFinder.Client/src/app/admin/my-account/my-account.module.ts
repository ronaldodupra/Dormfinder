import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { MyAccountComponent } from './my-account/my-account.component';
import { EditMyAccountComponent } from './edit-my-account/edit-my-account.component';
import { MyAccountFormComponent } from './my-account-form/my-account-form.component';

@NgModule({
  declarations: [
    MyAccountComponent,
    EditMyAccountComponent,
    MyAccountFormComponent,
  ],
  imports: [SharedModule],
})
export class MyAccountModule {}
