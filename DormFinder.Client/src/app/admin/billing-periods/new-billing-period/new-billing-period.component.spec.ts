import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewBillingPeriodComponent } from './new-billing-period.component';

describe('NewBillingPeriodComponent', () => {
  let component: NewBillingPeriodComponent;
  let fixture: ComponentFixture<NewBillingPeriodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewBillingPeriodComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewBillingPeriodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
