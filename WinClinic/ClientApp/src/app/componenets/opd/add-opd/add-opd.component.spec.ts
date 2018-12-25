import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOpdComponent } from './add-opd.component';

describe('AddOpdComponent', () => {
  let component: AddOpdComponent;
  let fixture: ComponentFixture<AddOpdComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddOpdComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOpdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
