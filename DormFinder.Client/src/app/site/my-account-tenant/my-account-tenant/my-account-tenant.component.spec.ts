import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyAccountTenantComponent } from './my-account-tenant.component';

describe('MyAccountTenantComponent', () => {
  let component: MyAccountTenantComponent;
  let fixture: ComponentFixture<MyAccountTenantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyAccountTenantComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyAccountTenantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
