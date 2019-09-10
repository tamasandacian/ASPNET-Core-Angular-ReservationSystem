import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservationDetailComponent } from './reservation-detail.component';

describe('ReservationDetailComponent', () => {
  let component: ReservationDetailComponent;
  let fixture: ComponentFixture<ReservationDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReservationDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservationDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
