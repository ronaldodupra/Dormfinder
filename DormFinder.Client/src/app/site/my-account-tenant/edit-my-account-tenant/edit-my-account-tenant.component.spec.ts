import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMyAccountTenantComponent } from './edit-my-account-tenant.component';

describe('EditMyAccountTenantComponent', () => {
  let component: EditMyAccountTenantComponent;
  let fixture: ComponentFixture<EditMyAccountTenantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditMyAccountTenantComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditMyAccountTenantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
