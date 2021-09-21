import { filter } from 'rxjs/operators';
import { dashboardService } from './../../../services/dashboard.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  constructor(private dashboardService: dashboardService) {}
  chart: any;
  isSample: boolean = true;
  color: string;
  GroupByFloor: [];
  ngOnInit(): void {
    this.RoomChart();
  }
  public RoomChart() {
    this.dashboardService.getRoomChart().subscribe((result) => {
      this.chart = result;
    });
  }
  public filter(search) {
    if (search.length > 2 || search.length == 0) {
      this.dashboardService.getRoomChartFilter(search).subscribe((result) => {
        this.chart = result;
      });
    }
  }
}
