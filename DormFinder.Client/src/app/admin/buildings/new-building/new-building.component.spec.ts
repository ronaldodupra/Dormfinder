import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewBuildingComponent } from './new-building.component';

describe('NewBuildingComponent', () => {
  let component: NewBuildingComponent;
  let fixture: ComponentFixture<NewBuildingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewBuildingComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewBuildingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
