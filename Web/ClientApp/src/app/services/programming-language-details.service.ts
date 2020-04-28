import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProgrammingLanguage } from '../models/Programming-language';
import { ProgrammingLanguageDetails } from '../models/programming-language-details';

@Injectable({
  providedIn: 'root'
})
export class ProgrammingLanguageDetailsService {
  
  private baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public getprogrammingLanguageDetails(id: number): Observable<ProgrammingLanguageDetails> {
    const url = `${this.baseUrl}api/ProgrammingLanguageDetails/GetProgrammingLanguageDetails/${id}`;
    return this.http.get<ProgrammingLanguageDetails>(url);
  }
}
