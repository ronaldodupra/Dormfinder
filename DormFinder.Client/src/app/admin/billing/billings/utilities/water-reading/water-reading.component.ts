import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Subject } from 'rxjs';
import { IReading } from 'src/app/models/reading.model';
import { BillingService } from 'src/app/services/billing.services';

@Component({
  selector: 'app-water-reading',
  templateUrl: './water-reading.component.html',
  styleUrls: ['./water-reading.component.scss'],
})
export class WaterReadingComponent implements OnInit {
  displayedColumns: string[] = ['meterNo', 'previousReading', 'currentReading'];

  dataSource: MatTableDataSource<IReading>;

  pagination: Subject<void> = new Subject();

  constructor(
    private billingService: BillingService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.loadReadings();
  }

  loadReadings() {
    this.billingService.getUtilitiesReadingWater().subscribe((data) => {
      console.log(data);

      this.dataSource = new MatTableDataSource(data.items);
    });
  }

  saveChanges() {
    this.billingService
      .saveChangesUtilities(this.dataSource.data)
      .subscribe(() => {});
  }

  change(value: number, reading: IReading) {
    reading.currentReading = Number(value);
  }
}
