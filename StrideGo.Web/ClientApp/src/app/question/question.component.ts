import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Question } from './shared/question'
import { QuestionService } from './shared/question.service'
import { Answer } from '../answer/shared/answer'
import { AnswerService } from '../answer/shared/answer.service'

@Component({
  selector: 'question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {
  @Input() question: Question;  
  @Output() deleteQuestionEvent = new EventEmitter<Question>();
  
  private answers: Answer[];
  private isEditing: boolean = false;
  private showAnswer: boolean = false;
  constructor(private questionService: QuestionService, private answerService: AnswerService) { 
  }

  ngOnInit() {
  }

  updateQuestion() {
    this.questionService.update(this.question).subscribe(() => {
      this.isEditing = false;    
    }, error => console.error(error));
  }

  deleteQuestion() {
    this.questionService.delete(this.question.id).subscribe(() => {
      this.deleteQuestionEvent.emit(this.question);
    }, error => console.error(error));
  }

  showAnswers() {
    this.showAnswer = !this.showAnswer;
    if(!this.answers) {      
      this.answerService.getAll(this.question.id).subscribe(result => {
        this.answers = result['answers'];
      }, error => console.error(error));
    }
  }
}
