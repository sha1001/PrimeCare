import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FacilityresourcesComponent } from './facilityresources.component';

describe('FacilityresourcesComponent', () => {
  let component: FacilityresourcesComponent;
  let fixture: ComponentFixture<FacilityresourcesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FacilityresourcesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FacilityresourcesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
