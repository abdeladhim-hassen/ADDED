/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ReleveurService } from './Releveur.service';

describe('Service: Releveur', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ReleveurService]
    });
  });

  it('should ...', inject([ReleveurService], (service: ReleveurService) => {
    expect(service).toBeTruthy();
  }));
});
