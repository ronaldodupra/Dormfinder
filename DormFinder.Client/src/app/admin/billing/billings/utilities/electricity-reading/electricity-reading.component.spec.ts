import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ElectricityReadingComponent } from './electricity-reading.component';

describe('ElectricityReadingComponent', () => {
  let component: ElectricityReadingComponent;
  let fixture: ComponentFixture<ElectricityReadingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ElectricityReadingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ElectricityReadingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
