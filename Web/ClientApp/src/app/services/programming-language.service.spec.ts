import { TestBed } from '@angular/core/testing';

import { ProgrammingLanguageService } from './programming-language.service';

describe('ProgrammingLanguageService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProgrammingLanguageService = TestBed.get(ProgrammingLanguageService);
    expect(service).toBeTruthy();
  });
});
