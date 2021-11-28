import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { HttpService } from '../core/http.service';

import { Question, TestRequest, TestResponse } from './test.model';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  constructor(private httpService: HttpService) { }

  sendTest(test: TestRequest): Observable<TestResponse> {

    return this.httpService.Post<TestResponse>('test/sendTest', test);
  }

  getQuestions(): Observable<Question[]> {
    return this.httpService.Get<Question[]>('test/getQuestions');
  }
}
