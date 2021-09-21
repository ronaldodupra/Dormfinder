import { IRoom } from './../../../models/rooms.model';
import { MatTableDataSource } from '@angular/material/table';
import { RoomsService } from './../../../services/rooms.service';
import { Router } from '@angular/router';

import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { auditTime } from 'rxjs/operators';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { PageOptions } from 'src/app/core/pageoptions/PageOptions';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.scss'],
})
export class RoomsComponent implements OnInit {
  constructor(private roomService: RoomsService, private router: Router) {}
  newRoomRoute: string = 'new';

  isDisabled: boolean = true;

  dataSource: MatTableDataSource<IRoom>;

  totalPages: number;

  totalCount: number;

  pageIndex = 0;

  pageSize = 5;

  sort: Sort = {
    active: '',
    direction: '',
  };

  pagination: Subject<void> = new Subject();

  displayedColumns = [
    'name',
    'description',
    'price',
    'inclusion',
    'roomType',
    'actions',
  ];

  ngOnInit(): void {
    this.loadRooms();

    this.pagination.pipe(auditTime(500)).subscribe(() => {
      this.loadRooms();
    });
  }
  public loadRooms() {
    const options = new PageOptions(
      this.pageIndex,
      this.pageSize,
      this.sort.active,
      this.sort.direction
    );

    this.roomService.getRooms(options).subscribe((data) => {
      this.dataSource = new MatTableDataSource(data.items);
      this.totalCount = data.totalCount;
    });
  }

  page(pageEvent: PageEvent): void {
    this.pageIndex = pageEvent.pageIndex;
    this.pagination.next();
  }

  sortdata(sort: Sort): void {
    this.sort = sort;
    this.loadRooms();
  }

  public roomDetails(roomId) {
    const snapShotUrl = this.router.routerState.snapshot.url;
    this.router.navigate([snapShotUrl, roomId]);
  }
}
