import { OptionsService } from './../../../services/options.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HomeService } from './../../../services/home.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatAutocompleteTrigger } from '@angular/material/autocomplete';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { map, startWith } from 'rxjs/operators';
import { BuildingService } from 'src/app/services/building.service';
@Component({
  selector: 'app-search-form',
  templateUrl: './search-form.component.html',
  styleUrls: ['./search-form.component.scss'],
})
export class SearchFormComponent implements OnInit {
  autoCompleteValue = [];
  filteredOptions: Observable<string[]>;

  constructor(
    private buildingService: BuildingService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  @ViewChild('autoTrigger', { read: MatAutocompleteTrigger })
  autoTrigger: MatAutocompleteTrigger;
  form: FormGroup = this.fb.group({
    search: [null],
  });
  ngOnInit(): void {
    this.loadAddress();
    this.filteredOptions = this.form.controls['search'].valueChanges.pipe(
      startWith(''),
      map((value) => this._filter(value))
    );
  }
  private _filter(value: string): string[] {
    if (value.length > 2) {
      const filterValue = value.toLowerCase();
      return this.autoCompleteValue.filter((option) =>
        option.toLowerCase().includes(filterValue)
      );
    }
  }

  public loadAddress() {
    this.buildingService.getAddress().subscribe((result) => {
      result.forEach((x) => {
        this.autoCompleteValue.push(x.addressName);
      });
    });
  }
  public search() {
    if (this.form.value.search == null || this.form.value.search == undefined) {
      this.router.navigate(['rent']);
    }
    this.router.navigate([this.form.value.search, 'rent']);
  }
}
