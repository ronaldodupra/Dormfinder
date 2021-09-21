import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlertCountService } from './services/alert-count.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'app';
  currentActiveNav = 'home';
  alert: any;

  constructor(
    private activatedRoute: ActivatedRoute,
    private alertCountService: AlertCountService
  ) {}

  ngOnInit(): void {
    // this.alertCountService.getInitialAlertData();
    // this.alertCountService.currentData$.subscribe(
    //   (data) => (this.alert = data)
    // );
  }

  changeActiveNav(nav: string): void {
    // this.currentActiveNav = nav;
  }
}
