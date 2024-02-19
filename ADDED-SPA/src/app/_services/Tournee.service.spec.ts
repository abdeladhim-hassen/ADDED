/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TourneeService } from './Tournee.service';

describe('Service: Tournee', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TourneeService]
    });
  });

  it('should ...', inject([TourneeService], (service: TourneeService) => {
    expect(service).toBeTruthy();
  }));
});
