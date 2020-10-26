import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

enum QuestionCategory {
  Training = 'training',
  InjuryRecovery = 'injury_recovery',
  RunningGears = 'running_gears',
  Nutrition = 'nutrition'
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {
  public pageTitle = "Home";
  
  constructor(private route: ActivatedRoute) { }

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
}
