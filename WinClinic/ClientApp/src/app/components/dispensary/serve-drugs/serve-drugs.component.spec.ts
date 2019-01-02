import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServeDrugsComponent } from './serve-drugs.component';

describe('ServeDrugsComponent', () => {
  let component: ServeDrugsComponent;
  let fixture: ComponentFixture<ServeDrugsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServeDrugsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServeDrugsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
