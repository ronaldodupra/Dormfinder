import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditBedspaceDialogComponent } from './edit-bedspace-dialog.component';

describe('EditBedspaceDialogComponent', () => {
  let component: EditBedspaceDialogComponent;
  let fixture: ComponentFixture<EditBedspaceDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditBedspaceDialogComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditBedspaceDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
