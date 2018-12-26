import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComplaintsComponent } from './complaints.component';

describe('ComplaintsComponent', () => {
  let component: ComplaintsComponent;
  let fixture: ComponentFixture<ComplaintsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComplaintsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComplaintsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
