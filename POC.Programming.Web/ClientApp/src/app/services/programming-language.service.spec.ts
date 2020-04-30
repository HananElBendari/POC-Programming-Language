import { TestBed } from '@angular/core/testing';
import { ProgrammingLanguageService } from './programming-language.service';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { ProgrammingLanguage } from '../models/Programming-language';

describe('ProgrammingLanguageService', () => {
  let service: ProgrammingLanguageService;
  const httpSpy = jasmine.createSpyObj('HttpClient', ['get']);

  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      {provide: HttpClient, useValue: httpSpy},
      { provide: 'BASE_URL', useValue: {}}
    ]
  }));

  beforeEach(() => {
    service = TestBed.get(ProgrammingLanguageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('getByCategoryId should call get method and return ProgrammingLanguage', () => {
    const programmingLang = of([{id: 1} as ProgrammingLanguage]);
    httpSpy.get.and.returnValue(programmingLang);

    const result = service.getByCategoryId(1);
    expect(httpSpy.get).toHaveBeenCalled();
    expect(result).toEqual(programmingLang);
  });

  it('getNumberOfHitsByProgrammingLanguageId should call get method and return number', () => {
    const value = of(1);
    httpSpy.get.and.returnValue(value);
    const result = service.getNumberOfHitsByProgrammingLanguageId(1);
    expect(httpSpy.get).toHaveBeenCalled();
    expect(result).toEqual(value);

  });

});
