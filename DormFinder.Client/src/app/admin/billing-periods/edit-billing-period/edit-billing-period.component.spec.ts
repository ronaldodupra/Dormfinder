import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditBillingPeriodComponent } from './edit-billing-period.component';

describe('EditBillingPeriodComponent', () => {
  let component: EditBillingPeriodComponent;
  let fixture: ComponentFixture<EditBillingPeriodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditBillingPeriodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditBillingPeriodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
