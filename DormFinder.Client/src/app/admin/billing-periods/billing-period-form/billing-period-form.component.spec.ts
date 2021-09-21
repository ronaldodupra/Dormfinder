import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BillingPeriodFormComponent } from './billing-period-form.component';

describe('BillingPeriodFormComponent', () => {
  let component: BillingPeriodFormComponent;
  let fixture: ComponentFixture<BillingPeriodFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BillingPeriodFormComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BillingPeriodFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
