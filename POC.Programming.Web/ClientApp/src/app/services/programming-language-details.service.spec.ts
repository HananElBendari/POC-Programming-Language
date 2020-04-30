import { TestBed } from '@angular/core/testing';
import { ProgrammingLanguageDetailsService } from './programming-language-details.service';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { ProgrammingLanguageDetails } from '../models/programming-language-details';

describe('ProgrammingLanguageDetailsService', () => {
  let service: ProgrammingLanguageDetailsService;
  const httpSpy = jasmine.createSpyObj('HttpClient', ['get']);
  const programmingLangDetails = of({id: 1} as ProgrammingLanguageDetails);
  httpSpy.get.and.returnValue(programmingLangDetails);

  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      {provide: HttpClient, useValue: httpSpy},
      { provide: 'BASE_URL', useValue: {}}
    ]
  }));

  beforeEach(() => {
    service = TestBed.get(ProgrammingLanguageDetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('getProgrammingLanguageDetails should call get method and return ProgrammingLanguageDetails', () => {
    const result = service.getProgrammingLanguageDetails(1);
    expect(httpSpy.get).toHaveBeenCalled();
    expect(result).toEqual(programmingLangDetails);
  });
});
