import { Injectable, Inject } from '@angular/core';
import { ProgrammingCategory } from '../models/programming-category';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProgrammingCategoryService {
  private baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public getAll(): Observable<Array<ProgrammingCategory>> {
    const url = `${this.baseUrl}api/ProgrammingCategory/GetAll`;
    return this.http.get<Array<ProgrammingCategory>>(url);
  }
}
