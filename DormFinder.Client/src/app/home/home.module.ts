import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { HomepageComponent } from './homepage/homepage.component';

@NgModule({
  declarations: [HomeComponent, HomepageComponent],
  imports: [SharedModule],
})
export class HomeModule {}
