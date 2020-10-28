import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment'

enum QuestionCategory {
  Training = 'training',
  InjuryRecovery = 'injury_recovery',
  RunningGears = 'running_gears',
  Nutrition = 'nutrition'
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  public pageTitle = "Home";  
  public questions: Question[];
  showAddQuestionForm = false;
  
  constructor(http: HttpClient, private route: ActivatedRoute) {
     http.get<Question[]>(environment.apiUrl + 'question').subscribe(result => {
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

interface Question {
  id: number;
  text: string;
  askedBy: string;
}
