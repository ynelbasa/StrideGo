import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { Answer } from '../shared/answer'

@Injectable({
  providedIn: 'root'
})

export class AnswerService {
  private answerApiUrl = environment.apiUrl + 'answer';
  // TODO: Setup UserService and get the authenticated user
  private userId = 'A7F7F628-B1BE-4884-AFBB-537B75F17CAB';
  
  constructor(private http: HttpClient) { }

  getAll(questionId:number):Observable<Answer[]> {
      return this.http.get<Answer[]>(this.answerApiUrl + '?questionId=' + questionId);   
  }

   create(answerText:string, questionId:number):Observable<number> {
    let answer = {
      questionId: questionId,
      userId: this.userId,
      text: answerText
    };
    
    return this.http.post<number>(this.answerApiUrl, answer);
  }

  update(answerData:Answer) {
    let answer = { id: answerData.id, text: answerData.text };
    return this.http.put(this.answerApiUrl, answer);
  }

  delete(answerId:number) {
    return this.http.delete(this.answerApiUrl + '/' + answerId);
  }

}
