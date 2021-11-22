import { Component, OnInit } from '@angular/core';
import { Question, TestModel } from './test.model';
import { FormArray, FormBuilder, Validators } from '@angular/forms';

let testMoq: TestModel = {
  name: '',
  questions: [
    {
      text: 'ce faci ?',
      options: [
        {
          text: 'optiunea 1',
          value: 1
        },
        {
          text: 'optiunea 2',
          value: 2
        }
      ],
      value: 0
    },
    {
      text: 'ba ce plm 2',
      options: [
        {
          text: 'optiunea 1',
          value: 3
        },
        {
          text: 'optiunea 2',
          value: 4
        }
      ],
      value: 0
    }
  ]
};

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  testForm = this.fb.group({
    name: ['', Validators.required],
    questionse: this.fb.array([''])
  });
  questions : Question | any;

  get questionse() {
    return this.testForm.get('questions') as FormArray;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.questions = testMoq.questions;
    for (let question of testMoq.questions) {
      this.questionse.push(this.fb.group({
        options: [question.options.values]
        }));
      console.log(testMoq);
    }
  }

  send() {
    
    console.log(this.testForm.value);
  }

}
