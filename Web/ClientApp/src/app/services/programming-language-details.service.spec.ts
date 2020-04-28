import { TestBed } from '@angular/core/testing';

import { ProgrammingLanguageDetailsService } from './programming-language-details.service';

describe('ProgrammingLanguageDetailsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProgrammingLanguageDetailsService = TestBed.get(ProgrammingLanguageDetailsService);
    expect(service).toBeTruthy();
  });
});
