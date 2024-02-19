/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ListTourneeComponent } from './ListTournee.component';

describe('ListTourneeComponent', () => {
  let component: ListTourneeComponent;
  let fixture: ComponentFixture<ListTourneeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListTourneeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListTourneeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
