/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PortableService } from './Portable.service';

describe('Service: Portable', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PortableService]
    });
  });

  it('should ...', inject([PortableService], (service: PortableService) => {
    expect(service).toBeTruthy();
  }));
});
