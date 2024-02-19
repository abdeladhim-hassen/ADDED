/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PortableComponent } from './Portable.component';

describe('PortableComponent', () => {
  let component: PortableComponent;
  let fixture: ComponentFixture<PortableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PortableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PortableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
