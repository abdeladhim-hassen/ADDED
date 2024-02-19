/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ListReleveurComponent } from './ListReleveur.component';

describe('ListReleveurComponent', () => {
  let component: ListReleveurComponent;
  let fixture: ComponentFixture<ListReleveurComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListReleveurComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListReleveurComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
