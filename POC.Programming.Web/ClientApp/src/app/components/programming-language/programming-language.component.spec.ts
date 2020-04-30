import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ProgrammingLanguageComponent } from './programming-language.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { ProgrammingCategoryService } from '../../services/programming-category.service';
import { ProgrammingLanguageService } from '../../services/programming-language.service';
import { ProgrammingLanguageDetailsService } from '../../services/programming-language-details.service';
import { of } from 'rxjs';
import { ProgrammingLanguage } from '../../models/Programming-language';
import { ProgrammingLanguageDetails } from '../../models/programming-language-details';

describe('ProgrammingLanguageComponent', () => {
  let component: ProgrammingLanguageComponent;
  let fixture: ComponentFixture<ProgrammingLanguageComponent>;

  const programmingLanguage: Array<ProgrammingLanguage> = [{
    id: 1,
    programmingCategoryId: 1,
    programmingLanguageName: 'Lang 1',
    ProgrammingCategory: null
  }];

  const programmingLanguageDetails: ProgrammingLanguageDetails = {
    id: 1,
    userIp: null,
    like: true,
    ProgrammingLanguageId: 1
  };

  const programmingCategoryServiceSpy = jasmine.createSpyObj('ProgrammingCategoryService', ['getAll', 'numberOfAvaliableCategories']);
  programmingCategoryServiceSpy.numberOfAvaliableCategories.and.returnValue(of(1));

  const programmingLanguageServiceSpy = jasmine.createSpyObj('ProgrammingLanguageService', ['getByCategoryId']);
  programmingLanguageServiceSpy.getByCategoryId.and.returnValue(of(programmingLanguage));

  const programmingLanguageDetailsServiceSpy = jasmine.createSpyObj('ProgrammingLanguageDetailsService', ['getProgrammingLanguageDetails']);
  programmingLanguageDetailsServiceSpy.getProgrammingLanguageDetails.and.returnValue(of(programmingLanguageDetails));

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      declarations: [ ProgrammingLanguageComponent ],
      providers: [
        {provide: ProgrammingCategoryService, useValue: programmingCategoryServiceSpy},
        {provide: ProgrammingLanguageService, useValue: programmingLanguageServiceSpy},
        {provide: ProgrammingLanguageDetailsService, useValue: programmingLanguageDetailsServiceSpy}
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProgrammingLanguageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('getByCategoryId should not call ProgrammingLanguageService.getByCategoryId', () => {
    const id = 1;
    component.programmingLanguageList[id] = programmingLanguage;
    fixture.detectChanges();
    component.getByCategoryId(id);
    expect(programmingLanguageServiceSpy.getByCategoryId).toHaveBeenCalledTimes(0);
  });

  it('getByCategoryId should call ProgrammingLanguageService and set programmingLanguageList value & showMoreCategory[id] to true', () => {
    const id = 1;
    component.getByCategoryId(id);
    expect(programmingLanguageServiceSpy.getByCategoryId).toHaveBeenCalledWith(id);
    expect(component.showMoreCategory[id]).toBeTruthy();
    expect(component.programmingLanguageList[id]).toEqual(programmingLanguage);
    programmingLanguageServiceSpy.getByCategoryId.calls.reset();
  });

  it('getProgrammingLanguageDetailsById should not call ProgrammingLanguageDetailsService.getProgrammingLanguageDetailsById', () => {
    const id = 1;
    component.progLanguageDetails[id] = programmingLanguageDetails;
    fixture.detectChanges();
    component.getProgrammingLanguageDetailsById(id);
    expect(programmingLanguageDetailsServiceSpy.getProgrammingLanguageDetails).toHaveBeenCalledTimes(0);
  });

  it(`getProgrammingLanguageDetailsById should call getProgrammingLanguageDetails and
  set progLanguageDetails[id] value & showMoreProgrammingLanguage to true`, () => {
    const id = 1;
    component.getProgrammingLanguageDetailsById(id);
    expect(programmingLanguageDetailsServiceSpy.getProgrammingLanguageDetails).toHaveBeenCalledWith(id);
    expect(component.showMoreProgrammingLanguage[id]).toBeTruthy();
    expect(component.progLanguageDetails[id]).toEqual(programmingLanguageDetails);
    programmingLanguageDetailsServiceSpy.getProgrammingLanguageDetails.calls.reset();
  });

  it('showLessCategory should set showMoreCategory[id] value to false', () => {
    const id = 1;
    component.showLessCategory(id);
    expect(component.showMoreCategory[id]).toBeFalsy();
  });

  it('showLessProgrammingLanguage should set showMoreProgrammingLanguage[id] value to false', () => {
    const id = 1;
    component.showLessProgrammingLanguage(id);
    expect(component.showMoreProgrammingLanguage[id]).toBeFalsy();
  });

  it('should unsubscribe on destroy', () => {
    const nextSpy = spyOn(component.destroy$, 'next');
    const unsubscribeSpy = spyOn(component.destroy$, 'unsubscribe');
    component.ngOnDestroy();
    expect(nextSpy).toHaveBeenCalled();
    expect(unsubscribeSpy).toHaveBeenCalled();
  });
});
