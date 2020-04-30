import { ProgrammingCategory } from './programming-category';

export interface ProgrammingLanguage {
    id: number;
    programmingLanguageName: string;
    programmingCategoryId: number;
    NumberOfHits?: number;
    ProgrammingCategory: ProgrammingCategory;
  }


