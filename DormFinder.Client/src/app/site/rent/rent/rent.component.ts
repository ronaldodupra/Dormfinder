import { OptionsService } from './../../../services/options.service';
import { MatTableDataSource } from '@angular/material/table';
import { DataSource } from '@angular/cdk/table';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HomeService } from './../../../services/home.service';
import { IRent, IRentBuildingAddress } from './../../../models/rent.model';
import { RentService } from './../../../services/rent.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { img } from './test';
import { MatAutocompleteTrigger } from '@angular/material/autocomplete';
import { MatSelect } from '@angular/material/select';
import { map, startWith } from 'rxjs/operators';
import { MatPaginator } from '@angular/material/paginator';
import { BuildingService } from 'src/app/services/building.service';
@Component({
  selector: 'app-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.scss'],
})
export class RentComponent implements OnInit {
  autoCompleteValue = [];
  filteredOptions: Observable<string[]>;
  @ViewChild('autoTrigger', { read: MatAutocompleteTrigger })
  autoTrigger: MatAutocompleteTrigger;
  rents: IRent[];
  loading: boolean = false;
  isSearching: boolean = false;
  resultCount: number;
  searchString: string;
  pagination: number;
  constructor(
    private rentService: RentService,
    private buildingService: BuildingService,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {
    this.searchString = this.route.snapshot.paramMap.get('searchString');
    this.form.patchValue({
      search: this.searchString,
    });
  }
  form: FormGroup = this.fb.group({
    search: [[null], null, null],
    minPrice: [null],
    maxPrice: [null],
  });
  ngOnInit(): void {
    this.searchString == null ? this.getRooms() : this.searchRoom();

    this.loadAddress();
    this.filteredOptions = this.form.controls['search'].valueChanges.pipe(
      startWith(''),
      map((value) => this._filter(value))
    );
  }
  private _filter(value: string): string[] {
    if (value != null) {
      if (value.length > 2) {
        const filterValue = value;
        return this.autoCompleteValue.filter((option) =>
          option.toLowerCase().includes(filterValue)
        );
      }
    }
  }
  public getRooms() {
    this.rentService.getRooms().subscribe((data) => {
      this.rents = data;
    });
  }
  public searchRoom() {
    this.loading = true;
    if (this.form.value.search == '') {
      this.form.patchValue({
        search: null,
      });
    }
    this.rentService.getSearchRooms(this.form.value).subscribe((data) => {
      setTimeout(() => {
        this.rents = data;
        this.loading = false;
        this.resultCount = data.length;
        this.isSearching = true;
        this.pagination = 1;
      });
    });
  }
  public loadAddress() {
    this.buildingService.getAddress().subscribe((result) => {
      result.forEach((x) => {
        this.autoCompleteValue.push(x.addressName);
      });
    });
  }
  public cancelSearch() {
    this.form.reset();
    this.isSearching = false;
    this.getRooms();
  }
}
