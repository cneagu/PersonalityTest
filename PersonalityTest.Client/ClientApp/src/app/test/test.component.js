"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var dialog_component_1 = require("./dialog/dialog.component");
var TestComponent = /** @class */ (function () {
    function TestComponent(fb, snackbar, testService, dialog) {
        this.fb = fb;
        this.snackbar = snackbar;
        this.testService = testService;
        this.dialog = dialog;
        this.questionsData = [];
        this.form = this.fb.group({
            name: ['', forms_1.Validators.required /*, Validators.minLength(4),Validators.maxLength(24)*/],
            questions: this.fb.array([])
        });
        this.testModel = {
            id: this.generateGuid(),
            name: '',
            questions: this.questionsData,
            isValid: false
        };
        this.isTestComplete = false;
    }
    TestComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.testService.getQuestions().subscribe(function (data) {
            if (data === null || data === undefined) {
                var message = 'No information was receive';
                _this.snackbar.open(message);
                return;
            }
            data.forEach(function (value) {
                _this.questionsData.push(value);
            });
            _this.loadQuiz();
        }, function (error) {
            var message = 'Something went wrong';
            _this.snackbar.open(message);
        });
    };
    Object.defineProperty(TestComponent.prototype, "questions", {
        get: function () {
            return this.form.get('questions');
        },
        enumerable: true,
        configurable: true
    });
    TestComponent.prototype.options = function (question) {
        return question.get('options');
    };
    TestComponent.prototype.loadQuiz = function () {
        var _this = this;
        this.addMultipleQuestions(this.questionsData);
        this.questionsData.forEach(function (q, i) {
            return _this.addMultipleOptions(i, q.options);
        });
    };
    TestComponent.prototype.addMultipleQuestions = function (questions) {
        var _this = this;
        questions.forEach(function (q) { return _this.addQuestion(q); });
    };
    TestComponent.prototype.addQuestion = function (q) {
        var control = this.form.controls['questions'];
        control.push(this.initQuestion(q));
    };
    TestComponent.prototype.initQuestion = function (q) {
        return this.fb.group({
            id: [q ? .id : ],
            text: [q ? .text : ],
            options: this.fb.array([])
        });
    };
    TestComponent.prototype.addMultipleOptions = function (qIndex, options) {
        var _this = this;
        options.forEach(function (o) { return _this.addOption(qIndex, o); });
    };
    TestComponent.prototype.addOption = function (qIndex, option) {
        var control = this.form.controls['questions']
            .at(qIndex)
            .get('options');
        control.push(this.initOption(option));
    };
    TestComponent.prototype.initOption = function (o) {
        return this.fb.group({
            text: [o.text],
            value: [o.value, [forms_1.Validators.required]]
        });
    };
    TestComponent.prototype.send = function () {
        var _this = this;
        if (this.testModel.isValid) {
            this.testService.sendTest(this.testModel).subscribe(function (response) {
                _this.isTestComplete = true;
                _this.dialog.open(dialog_component_1.DialogComponent, {
                    width: '450px',
                    data: { name: response.name, personality: response.personality }
                });
            }, function (error) {
                var message = 'Error while sending the test. Please try again';
                _this.snackbar.open(message);
            });
        }
        else {
            var message = 'Invalid Test. Please check all the answers.';
            this.snackbar.open(message);
        }
    };
    TestComponent.prototype.radioChange = function (event, id) {
        var question = this.testModel.questions.find(function (x) { return x.id === id; });
        if (question)
            question.value = event.value;
        this.validateTestQuestions();
    };
    TestComponent.prototype.refresh = function () {
        window.location.reload();
    };
    TestComponent.prototype.validateTestQuestions = function () {
        for (var _i = 0, _a = this.testModel.questions; _i < _a.length; _i++) {
            var question = _a[_i];
            if (question.value === 0) {
                this.testModel.isValid = false;
                return;
            }
        }
        this.testModel.isValid = true;
    };
    //not my code
    TestComponent.prototype.generateGuid = function () {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    };
    TestComponent = __decorate([
        core_1.Component({
            selector: 'app-test',
            templateUrl: './test.component.html',
            styleUrls: ['./test.component.css']
        })
    ], TestComponent);
    return TestComponent;
}());
exports.TestComponent = TestComponent;
