import { TestBed } from '@angular/core/testing';
import { ProgrammingCategoryService } from './programming-category.service';
import { HttpClient } from '@angular/common/http';
import { ProgrammingCategory } from '../models/programming-category';
import { of } from 'rxjs';

describe('ProgrammingCategoryService', () => {
  let service: ProgrammingCategoryService;
  const httpSpy = jasmine.createSpyObj('HttpClient', ['get']);

  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      {provide: HttpClient, useValue: httpSpy},
      { provide: 'BASE_URL', useValue: {}}
    ]
  }));

  beforeEach(() => {
    service = TestBed.get(ProgrammingCategoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('logError should call http.get method and return programmingCategories', () => {
    const programmingCategories = of([
      {id: 1} as ProgrammingCategory
    ]);
    httpSpy.get.and.returnValue(programmingCategories);
    const result = service.getAll();
    expect(httpSpy.get).toHaveBeenCalled();
    expect(result).toEqual(programmingCategories);
  });

  it('logError should call http.get method and return numberOfAvaliableCategories', () => {
    const numberOfAvaliableCat = of(1);
    httpSpy.get.and.returnValue(numberOfAvaliableCat);
    const result = service.numberOfAvaliableCategories();
    expect(httpSpy.get).toHaveBeenCalled();
    expect(result).toEqual(numberOfAvaliableCat);
  });
});
