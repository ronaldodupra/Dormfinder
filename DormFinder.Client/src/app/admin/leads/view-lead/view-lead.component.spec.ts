import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewLeadComponent } from './view-lead.component';

describe('ViewLeadComponent', () => {
  let component: ViewLeadComponent;
  let fixture: ComponentFixture<ViewLeadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
<<<<<<< HEAD
<<<<<<<< HEAD:DormFinder.Client/src/app/admin/leads/view-lead/view-lead.component.spec.ts
      declarations: [ ViewLeadComponent ]
    })
    .compileComponents();
========
      declarations: [MainComponent],
    }).compileComponents();
>>>>>>>> 14cd84a6f1b695128e3a672382dd625ed0834a4a:DormFinder.Client/src/app/site/layout/main/main.component.spec.ts
=======
      declarations: [ ViewLeadComponent ]
    })
    .compileComponents();
>>>>>>> 14cd84a6f1b695128e3a672382dd625ed0834a4a
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewLeadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
