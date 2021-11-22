import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  private baseApiUrl: string;

  constructor(private http: HttpClient) {
    this.baseApiUrl = 'api/';
  }

  Get<T>(url: string): Observable<T> {
    return this.http.get<T>(`${this.baseApiUrl}${url}`, {
      headers: this.getHeaders()
    });
  }

  Post<T>(url: string, body: any): Observable<T> {
    return this.http.post<T>(`${this.baseApiUrl}${url}`, body, {
      headers: this.getHeaders()
    });
  }

  private getHeaders() {
    return new HttpHeaders({
      'X-Requested-With': 'XMLHttpRequest'
    });
  }
}
