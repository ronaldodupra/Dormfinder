import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewLeadTenantComponent } from './view-lead-tenant.component';

describe('ViewLeadTenantComponent', () => {
  let component: ViewLeadTenantComponent;
  let fixture: ComponentFixture<ViewLeadTenantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewLeadTenantComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewLeadTenantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
