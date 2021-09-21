import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { matTabsAnimations } from '@angular/material/tabs';
import { Subject } from 'rxjs';
import { auditTime } from 'rxjs/operators';
import { PageOptions } from 'src/app/core/pageoptions/PageOptions';
import { IBuilding } from 'src/app/models/buildings.model';
import { BuildingService } from 'src/app/services/building.service';

@Component({
  selector: 'app-buildings',
  templateUrl: './buildings.component.html',
  styleUrls: ['./buildings.component.scss'],
})
export class BuildingsComponent implements OnInit {
  displayedColumns: string[] = ['name', 'address', 'actions'];

  dataSource: MatTableDataSource<IBuilding>;

  totalPages: number;

  totalCount: number;

  pageIndex = 0;

  pageSize = 5;

  sort: Sort = {
    active: '',
    direction: '',
  };

  pagination: Subject<void> = new Subject();

  constructor(private buildingService: BuildingService) {}

  ngOnInit(): void {
    this.loadBuildings();

    this.pagination.pipe(auditTime(500)).subscribe(() => {
      this.loadBuildings();
    });
  }

  page(pageEvent: PageEvent): void {
    this.pageIndex = pageEvent.pageIndex;
    this.pagination.next();
  }

  sortdata(sort: Sort): void {
    this.sort = sort;
    this.loadBuildings();
  }

  loadBuildings() {
    const options = new PageOptions(
      this.pageIndex,
      this.pageSize,
      this.sort.active,
      this.sort.direction
    );

    this.buildingService.list(options).subscribe((data) => {
      this.dataSource = new MatTableDataSource(data.items);
      this.totalCount = data.totalCount;
    });
  }
}
