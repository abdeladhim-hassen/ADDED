/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AnalyseService } from './analyse.service';

describe('Service: Analyse', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AnalyseService]
    });
  });

  it('should ...', inject([AnalyseService], (service: AnalyseService) => {
    expect(service).toBeTruthy();
  }));
});
