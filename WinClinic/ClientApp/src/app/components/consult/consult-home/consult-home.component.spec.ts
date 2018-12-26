import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultHomeComponent } from './consult-home.component';

describe('ConsultHomeComponent', () => {
  let component: ConsultHomeComponent;
  let fixture: ComponentFixture<ConsultHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsultHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
