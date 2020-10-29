import { Component, OnInit } from '@angular/core';
import { QuestionCategoryRoute } from '../question/shared/question-category.enum';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})

export class SideNavComponent implements OnInit {
  public questionCategoryRoute = QuestionCategoryRoute;
  constructor() { }

  ngOnInit() { }
}
