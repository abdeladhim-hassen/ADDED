import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListCompteurComponent } from './list-compteur.component';

describe('ListCompteurComponent', () => {
  let component: ListCompteurComponent;
  let fixture: ComponentFixture<ListCompteurComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListCompteurComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListCompteurComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
