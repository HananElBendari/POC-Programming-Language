import { Component, OnInit, OnDestroy } from '@angular/core';
import { Observable, Subject, of } from 'rxjs';
import { ProgrammingCategory } from '../../models/programming-category';
import { ProgrammingCategoryService } from '../../services/programming-category.service';
import { ProgrammingLanguageService } from '../../services/programming-language.service';
import { ProgrammingLanguageDetailsService } from '../../services/programming-language-details.service';
import { ProgrammingLanguage } from '../../models/Programming-language';
import { ProgrammingLanguageDetails } from '../../models/programming-language-details';
import { takeUntil } from 'rxjs/operators';



@Component({
  selector: 'app-programming-language',
  templateUrl: './programming-language.component.html',
  styleUrls: ['./programming-language.component.css']
})
export class ProgrammingLanguageComponent implements OnInit, OnDestroy {

  destroy$ = new Subject<boolean>();
  programmingCategoryList$: Observable<Array<ProgrammingCategory>>;
  programmingLanguageList: {[id: number]: Array<ProgrammingLanguage>} = {};
  progLanguageDetails: {[id: number]: ProgrammingLanguageDetails} = {};
  showMoreCategory: {[id: number]: boolean} = {};
  showMoreProgrammingLanguage: {[id: number]: boolean} = {};
  numberOfAvaliableCategories: number;

  constructor(
    private programmingCategoryService: ProgrammingCategoryService,
    private programmingLanguageService: ProgrammingLanguageService,
    private programmingLanguageDetailsService: ProgrammingLanguageDetailsService
  ) { }

  ngOnInit() {
    this.programmingCategoryService.getNumberOfAvaliableCategories().pipe(takeUntil(this.destroy$)).subscribe( avaliableCategories => {
      this.numberOfAvaliableCategories = avaliableCategories;
    });
    this.programmingCategoryList$ = this.programmingCategoryService.getAll();
  }

  ngOnDestroy() {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }

  public getByCategoryId(id: number) {
    this.showMoreCategory[id] = true;
    if (!this.programmingLanguageList[id]) {
      this.programmingLanguageService.getByCategoryId(id).pipe(takeUntil(this.destroy$)).subscribe(
        progLanguage => this.programmingLanguageList[id] = progLanguage
      );
    }
  }

  public getProgrammingLanguageDetailsById(id: number) {
    this.showMoreProgrammingLanguage[id] = true;
    if (!this.progLanguageDetails[id]) {
      this.programmingLanguageDetailsService.getProgrammingLanguageDetails(id).pipe(takeUntil(this.destroy$)).subscribe(
        progLangDetails => this.progLanguageDetails[id] = progLangDetails
      );
    }
  }

  public showLessCategory(id: number) {
    this.showMoreCategory[id] = false;
  }

  public showLessProgrammingLanguage(id: number) {
    this.showMoreProgrammingLanguage[id] = false;
  }

}
