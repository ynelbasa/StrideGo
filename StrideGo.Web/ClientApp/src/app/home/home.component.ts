import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Question } from '../question/shared/question'
import { QuestionService } from '../question/shared/question.service';
import { QuestionCategory } from '../question/shared/question-category.enum'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers:  [ QuestionService ]
})

export class HomeComponent implements OnInit {
  public pageTitle = "Home";  
  public questions: Question[];
  showAddQuestionForm = false;
  
  constructor(private route: ActivatedRoute, private questionService: QuestionService) {
   this.questionService.getAll().subscribe(result => {
      this.questions = result['questions'];
    }, error => console.error(error));
  }

  ngOnInit() {
    this.route.params.subscribe(params  => {
      switch(params['category']) {
        case QuestionCategory.Training:{       
        this.pageTitle = 'Training';
          break;
        }
        case QuestionCategory.InjuryRecovery:{ 
        this.pageTitle = 'Injury and Recovery';
          break;
        }
        case QuestionCategory.RunningGears: {
        this.pageTitle = 'Running Gears';
          break;
        }
        case QuestionCategory.Nutrition: {
        this.pageTitle = 'Nutrition';
          break;
        }   
      }
    });
  }

  toggleAddQuestionForm() {
    this.showAddQuestionForm = !this.showAddQuestionForm;
  }
}