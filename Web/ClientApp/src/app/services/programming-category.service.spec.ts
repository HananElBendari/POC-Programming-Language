import { TestBed } from '@angular/core/testing';

import { ProgrammingCategoryService } from './programming-category.service';

describe('ProgrammingCategoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProgrammingCategoryService = TestBed.get(ProgrammingCategoryService);
    expect(service).toBeTruthy();
  });
});
