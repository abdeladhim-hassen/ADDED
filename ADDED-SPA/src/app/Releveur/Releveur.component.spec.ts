/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ReleveurComponent } from './Releveur.component';

describe('ReleveurComponent', () => {
  let component: ReleveurComponent;
  let fixture: ComponentFixture<ReleveurComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReleveurComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReleveurComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
