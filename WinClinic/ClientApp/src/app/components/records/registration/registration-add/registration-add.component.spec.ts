import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrationAddComponent } from './registration-add.component';

describe('RegistrationAddComponent', () => {
  let component: RegistrationAddComponent;
  let fixture: ComponentFixture<RegistrationAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistrationAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrationAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
