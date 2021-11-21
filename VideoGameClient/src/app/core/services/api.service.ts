import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  get<T>(url: string): Observable<T>{
    return this.http.get<T>(url);
  }

  put<T>(url: string, body: any | null): Observable<T>{
    return this.http.put<T>(url, body);
  }
}