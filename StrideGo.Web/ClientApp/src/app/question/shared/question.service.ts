import { Injectable } from '@angular/core';
import { Question } from './question';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class QuestionService {
  private questionApiUrl = environment.apiUrl + 'question';
  // TODO: Setup UserService and get the authenticated user
  private userId = 'A7F7F628-B1BE-4884-AFBB-537B75F17CAB';
  // TODO: Implement filtering by question category, default to first category for now
  private questionCategoryId = 1;
  
  constructor(private http: HttpClient) { }

  getAll():Observable<Question[]> {
    return this.http.get<Question[]>(this.questionApiUrl);
  }

  create(questionText):Observable<number> {
    let question = {
      userId: this.userId,
      questionCategoryId: this.questionCategoryId,
      text: questionText
    };
    
    return this.http.post<number>(this.questionApiUrl, question);
  }

  update(questionData:Question) {
    let question = { id: questionData.id, text: questionData.text };
    return this.http.put(this.questionApiUrl, question);
  }

  delete(questionId) {
    return this.http.delete(this.questionApiUrl + '/' + questionId);
  }
}