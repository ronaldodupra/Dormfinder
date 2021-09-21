import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyAccountTenantFormComponent } from './my-account-tenant-form.component';

describe('MyAccountTenantFormComponent', () => {
  let component: MyAccountTenantFormComponent;
  let fixture: ComponentFixture<MyAccountTenantFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyAccountTenantFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyAccountTenantFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
