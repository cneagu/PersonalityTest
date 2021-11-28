import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatRadioChange } from '@angular/material/radio';
import { MatDialog} from '@angular/material/dialog';
import { DialogComponent } from './dialog/dialog.component';

import { TestService } from './test.service';
import { Question, Option, TestRequest, TestResponse } from './test.model';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  questionsData: Question[] = [];
  form = this.fb.group({
    name: ['', Validators.required/*, Validators.minLength(4),Validators.maxLength(24)*/],
    questions: this.fb.array([])
  });

  testModel: TestRequest = {
    id: this.generateGuid(),
    name: '',
    questions: this.questionsData,
    isValid: false
  };

  isTestComplete: boolean = false;

  constructor(
    private fb: FormBuilder,
    private snackbar: MatSnackBar,
    private testService: TestService,
    public dialog: MatDialog  ) { }

  ngOnInit(): void {

    this.testService.getQuestions().subscribe(
      (data: Question[]) => {
        if (data === null || data === undefined) {
          const message = 'No information was receive';
          this.snackbar.open(message);
          return;
        }

        data.forEach((value: Question) => {
          this.questionsData.push(value);
        });
        this.loadQuiz();
      },
      error => {
        const message = 'Something went wrong';
        this.snackbar.open(message);
      });

  }

  get questions() {
    return this.form.get('questions') as FormArray;
  }

  options(question: AbstractControl) {
    return question.get('options') as FormArray;
  }
  loadQuiz() {

    this.addMultipleQuestions(this.questionsData);

    this.questionsData.forEach((q: { options: Option[]; }, i: number) =>
      this.addMultipleOptions(i, q.options)
    );
  }

  addMultipleQuestions(questions: Question[]) {
    questions.forEach((q: Question) => this.addQuestion(q));
  }

  addQuestion(q: Question) {
    const control = <FormArray>this.form.controls['questions'];
    control.push(this.initQuestion(q));
  }

  initQuestion(q?: Question) {
    return this.fb.group({
      id: [q?.id],
      text: [q?.text],
      options: this.fb.array([]),
    });
  }

  addMultipleOptions(qIndex: number, options: Option[]) {
    options.forEach((o: Option) => this.addOption(qIndex, o));
  }

  addOption(qIndex: number, option: Option) {
    const control = (<FormArray>this.form.controls['questions'])
      .at(qIndex)
      .get('options') as FormArray;
    control.push(this.initOption(option));
  }

  initOption(o : Option) {
    return this.fb.group({
      text: [o.text],
      value: [o.value, [Validators.required]],
    });
  }

  send() {
    
    if (this.testModel.isValid) {
      this.testService.sendTest(this.testModel).subscribe(
        (response: TestResponse) => {
          this.isTestComplete = true;
          this.dialog.open(DialogComponent, {
            width: '450px',
            data: { name: response.name, personality: response.personality },
          });
        },
        error => {
          const message = 'Error while sending the test. Please try again';
          this.snackbar.open(message);
        }
      )
    }
    else {
      const message = 'Invalid Test. Please check all the answers.';
      this.snackbar.open(message);
    }
  }

  radioChange(event: MatRadioChange, id: string) {
    let question = this.testModel.questions.find(x => x.id === id);
    if (question)
      question.value = event.value;

    this.validateTestQuestions();
  }

  refresh(): void {
    window.location.reload();
  }

  private validateTestQuestions() {
    for (let question of this.testModel.questions) {
      if (question.value === 0) {
        this.testModel.isValid = false;
        return;
      }
    }
    this.testModel.isValid = true;
  }

  //not my code
  private generateGuid(): string {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      var r = Math.random() * 16 | 0,
        v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }
}
