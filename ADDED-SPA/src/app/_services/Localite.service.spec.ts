/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LocaliteService } from './Localite.service';

describe('Service: Localite', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LocaliteService]
    });
  });

  it('should ...', inject([LocaliteService], (service: LocaliteService) => {
    expect(service).toBeTruthy();
  }));
});
