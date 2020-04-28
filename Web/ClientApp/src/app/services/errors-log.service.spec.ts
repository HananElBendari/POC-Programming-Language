import { TestBed } from '@angular/core/testing';

import { ErrorsLogService } from './errors-log.service';

describe('ErrorsLogService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ErrorsLogService = TestBed.get(ErrorsLogService);
    expect(service).toBeTruthy();
  });
});
