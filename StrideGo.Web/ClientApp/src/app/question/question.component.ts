import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Question } from './shared/question'
import { QuestionService } from './shared/question.service'

@Component({
  selector: 'question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {
  @Input() question: Question;  
  @Output() deleteQuestionEvent = new EventEmitter<Question>();
  
  constructor(private questionService: QuestionService) { 
  }

  ngOnInit() {
    this.question.isEditing = false;
  }

  toggleEditing() {
    this.question.isEditing = !this.question.isEditing;
  }

  updateQuestion() {
    this.questionService.update(this.question).subscribe(() => {
      this.question.isEditing = false;    
    }, error => console.error(error));
  }

  deleteQuestion() {
    this.questionService.delete(this.question.id).subscribe(() => {
      this.deleteQuestionEvent.emit(this.question);
    }, error => console.error(error));
  }
}
