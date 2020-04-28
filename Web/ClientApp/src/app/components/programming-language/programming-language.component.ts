import { Component, OnInit, OnDestroy } from '@angular/core';
import { Observable, Subject } from 'rxjs';
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
  programmingLanguageList$: Observable<Array<ProgrammingLanguage>>;
  progLanguageDetails: ProgrammingLanguageDetails;
  activeIndexes = [];

  constructor(
    private programmingCategoryService: ProgrammingCategoryService,
    private programmingLanguageService: ProgrammingLanguageService,
    private programmingLanguageDetailsService: ProgrammingLanguageDetailsService
  ) { }

  ngOnInit() {
    this.programmingCategoryList$ = this.programmingCategoryService.getAll();
  }

  ngOnDestroy() {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }

  public getByCategoryId(id: number) {
    this.programmingLanguageList$ = this.programmingLanguageService.getByCategoryId(id);
  }

  public getProgrammingLanguageDetails(id: number) {
    this.programmingLanguageDetailsService.getprogrammingLanguageDetails(id).pipe(takeUntil(this.destroy$)).subscribe(
      details => {this.progLanguageDetails = details;
        if (this.activeIndexes.findIndex(a => a.id === id) < 0 ) { this.activeIndexes.push(id); }}
    );
  }
}
