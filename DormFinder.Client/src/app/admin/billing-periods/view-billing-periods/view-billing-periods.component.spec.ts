import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewBillingPeriodsComponent } from './view-billing-periods.component';

describe('ViewBillingPeriodsComponent', () => {
  let component: ViewBillingPeriodsComponent;
  let fixture: ComponentFixture<ViewBillingPeriodsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewBillingPeriodsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewBillingPeriodsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
