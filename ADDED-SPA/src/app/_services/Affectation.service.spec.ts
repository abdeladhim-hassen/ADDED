/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AffectationService } from './Affectation.service';

describe('Service: Affectation', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AffectationService]
    });
  });

  it('should ...', inject([AffectationService], (service: AffectationService) => {
    expect(service).toBeTruthy();
  }));
});
