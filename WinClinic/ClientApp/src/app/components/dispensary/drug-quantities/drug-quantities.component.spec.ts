import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DrugQuantitiesComponent } from './drug-quantities.component';

describe('DrugQuantitiesComponent', () => {
  let component: DrugQuantitiesComponent;
  let fixture: ComponentFixture<DrugQuantitiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DrugQuantitiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DrugQuantitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
