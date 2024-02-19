import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListAnomalieComponent } from './list-anomalie.component';

describe('ListAnomalieComponent', () => {
  let component: ListAnomalieComponent;
  let fixture: ComponentFixture<ListAnomalieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListAnomalieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListAnomalieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
