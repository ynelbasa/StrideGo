import { Component, Input, OnInit } from '@angular/core';
import { Answer } from './shared/answer';
import { AnswerService } from './shared/answer.service';

@Component({
  selector: 'answer',
  templateUrl: './answer.component.html',
  styleUrls: ['./answer.component.css']
})
export class AnswerComponent implements OnInit {
  @Input() answer: Answer;  

  isEditing: boolean = false;
  constructor(private answerService: AnswerService) { }

  ngOnInit() {
  }

  updateAnswer() {    
    this.answerService.update(this.answer).subscribe(() => {
      this.isEditing = false;    
    }, error => console.error(error));
  }
}
