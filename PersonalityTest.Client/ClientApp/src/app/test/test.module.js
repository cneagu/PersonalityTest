"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var router_1 = require("@angular/router");
var forms_2 = require("@angular/forms");
var button_1 = require("@angular/material/button");
var radio_1 = require("@angular/material/radio");
var form_field_1 = require("@angular/material/form-field");
var input_1 = require("@angular/material/input");
var snack_bar_1 = require("@angular/material/snack-bar");
var dialog_1 = require("@angular/material/dialog");
var test_component_1 = require("./test.component");
var dialog_component_1 = require("./dialog/dialog.component");
var routes = [
    {
        path: "",
        component: test_component_1.TestComponent
    }
];
var TestModule = /** @class */ (function () {
    function TestModule() {
    }
    TestModule = __decorate([
        core_1.NgModule({
            declarations: [
                test_component_1.TestComponent,
                dialog_component_1.DialogComponent
            ],
            imports: [
                common_1.CommonModule,
                router_1.RouterModule.forChild(routes),
                forms_2.FormsModule,
                radio_1.MatRadioModule,
                form_field_1.MatFormFieldModule,
                input_1.MatInputModule,
                button_1.MatButtonModule,
                forms_1.ReactiveFormsModule,
                snack_bar_1.MatSnackBarModule,
                dialog_1.MatDialogModule
            ]
        })
    ], TestModule);
    return TestModule;
}());
exports.TestModule = TestModule;
