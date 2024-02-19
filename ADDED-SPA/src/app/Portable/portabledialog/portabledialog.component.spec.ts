/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PortabledialogComponent } from './portabledialog.component';

describe('PortabledialogComponent', () => {
  let component: PortabledialogComponent;
  let fixture: ComponentFixture<PortabledialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PortabledialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PortabledialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
