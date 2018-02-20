import { TestBed, inject } from '@angular/core/testing';

import { CanService } from './can.service';

describe('CanService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CanService]
    });
  });

  it('should be created', inject([CanService], (service: CanService) => {
    expect(service).toBeTruthy();
  }));
});
