import { Injectable } from '@angular/core';
import { Question } from './question.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class QuestionService {
  private questionApiUrl = environment.apiUrl + 'question';

  constructor(private http: HttpClient) { }

  getAll() :Observable<Question[]> {
    return this.http.get<Question[]>(this.questionApiUrl);
  }
}