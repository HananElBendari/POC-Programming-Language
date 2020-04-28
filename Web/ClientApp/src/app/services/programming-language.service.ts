import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProgrammingLanguage } from '../models/Programming-language';

@Injectable({
  providedIn: 'root'
})
export class ProgrammingLanguageService {
  private baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public getByCategoryId(id: number): Observable<Array<ProgrammingLanguage>> {
    const url = `${this.baseUrl}api/ProgrammingLanguage/GetProgrammingLanguageByCategory/${id}`;
    return this.http.get<Array<ProgrammingLanguage>>(url);
  }

  public getNumberOfHitsByProgrammingLanguageId(id: number): Observable<number> {
    const url = `${this.baseUrl}api/ProgrammingLanguage/GetNumberOfHitsByProgrammingLanguageId/${id}`;
    return this.http.get<number>(url);
  }

}
