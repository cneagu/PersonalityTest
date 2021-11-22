"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const forms_1 = require("@angular/forms");
let testMoq = {
    name: '',
    questions: [
        {
            text: 'ba ce plm',
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
let TestComponent = class TestComponent {
    constructor(fb) {
        this.fb = fb;
        this.testForm = this.fb.group({
            name: ['', forms_1.Validators.required],
            questionse: this.fb.array([''])
        });
    }
    get questionse() {
        return this.testForm.get('questions');
    }
    ngOnInit() {
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
};
TestComponent = __decorate([
    core_1.Component({
        selector: 'app-test',
        templateUrl: './test.component.html',
        styleUrls: ['./test.component.css']
    })
], TestComponent);
exports.TestComponent = TestComponent;
