import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListOpdComponent } from './list-opd.component';

describe('ListOpdComponent', () => {
  let component: ListOpdComponent;
  let fixture: ComponentFixture<ListOpdComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListOpdComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListOpdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
