import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeadsTenantComponent } from './leads-tenant.component';

describe('LeadsTenantComponent', () => {
  let component: LeadsTenantComponent;
  let fixture: ComponentFixture<LeadsTenantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeadsTenantComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeadsTenantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
