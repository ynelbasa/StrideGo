import { Component, Input, OnInit } from '@angular/core';
import { Answer } from './shared/answer';

@Component({
  selector: 'answer',
  templateUrl: './answer.component.html',
  styleUrls: ['./answer.component.css']
})
export class AnswerComponent implements OnInit {
  @Input() answer: Answer;  

  constructor() { }

  ngOnInit() {
  }

}
