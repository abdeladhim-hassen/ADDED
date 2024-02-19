/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DistrictService } from './District.service';

describe('Service: District', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DistrictService]
    });
  });

  it('should ...', inject([DistrictService], (service: DistrictService) => {
    expect(service).toBeTruthy();
  }));
});
