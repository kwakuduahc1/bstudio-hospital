import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServeServiceComponent } from './serve-service.component';

describe('ServeServiceComponent', () => {
  let component: ServeServiceComponent;
  let fixture: ComponentFixture<ServeServiceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServeServiceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServeServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
