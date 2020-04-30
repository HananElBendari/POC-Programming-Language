import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorsLogService {

    private baseUrl: string;
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.baseUrl = baseUrl;
    }

    public logError(error: Error): Observable<boolean> {
      const url = `${this.baseUrl}api/LogErrors/Log`;
       return this.http.post<boolean>(url, error);
    }

  }
