import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Question } from '../question/shared/question';
import { QuestionService } from '../question/shared/question.service';
import { QuestionCategory, QuestionCategoryRoute } from '../question/shared/question-category.enum';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers:  [ QuestionService ]
})

export class HomeComponent implements OnInit {
  public pageTitle = "Home";  
  public questions: Question[];
  public questionCategoryId: number;
  showAddQuestionForm = false;
  questionTextInput: string = '';
  
  constructor(private route: ActivatedRoute, private questionService: QuestionService) { }

  ngOnInit() {
   
    this.route.params.subscribe(params  => {
      switch(params['category']) {
        case QuestionCategoryRoute.Training: {       
            this.pageTitle = 'Training';
            this.questionCategoryId = QuestionCategory.Training;
          break;
        }
        case QuestionCategoryRoute.InjuryRecovery: { 
            this.pageTitle = 'Injury and Recovery';
            this.questionCategoryId = QuestionCategory.InjuryRecovery;
          break;
        }
        case QuestionCategoryRoute.RunningGears: {
            this.pageTitle = 'Running Gears';
            this.questionCategoryId = QuestionCategory.RunningGears;
          break;
        }
        case QuestionCategoryRoute.Nutrition: {
            this.pageTitle = 'Nutrition';
            this.questionCategoryId = QuestionCategory.Nutrition;
          break;
        }   
      } 
      
      this.questionService.getAll(this.questionCategoryId).subscribe(result => {
        this.questions = result['questions'];
      }, error => console.error(error));
    });
  }

  toggleAddQuestionForm() {
    this.showAddQuestionForm = !this.showAddQuestionForm;
  }

  createQuestion() {
    this.questionService.create(this.questionTextInput, this.questionCategoryId).subscribe(result => {
      let newQuestion = {id: result, text: this.questionTextInput, askedBy: 'Ynel Basa', answerCount: 0};
      this.questions.unshift(newQuestion);
      
      // Close question form and reset input fields
      this.questionTextInput = '';
      this.showAddQuestionForm = false;
    }, error => console.error(error));
  }

  deleteQuestion(question) {
    let index: number = this.questions.indexOf(question);
    if (index !== -1) {
        this.questions.splice(index, 1);
    }        
  }
}