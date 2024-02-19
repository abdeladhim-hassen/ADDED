/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PortableListComponent } from './PortableList.component';

describe('PortableListComponent', () => {
  let component: PortableListComponent;
  let fixture: ComponentFixture<PortableListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PortableListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PortableListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
