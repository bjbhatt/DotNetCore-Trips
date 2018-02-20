import { TestBed, inject } from '@angular/core/testing';

import { CanAllocationService } from './can-allocation.service';

describe('CanAllocationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CanAllocationService]
    });
  });

  it('should be created', inject([CanAllocationService], (service: CanAllocationService) => {
    expect(service).toBeTruthy();
  }));
});
