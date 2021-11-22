"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const common_1 = require("@angular/common");
const forms_1 = require("@angular/forms");
const router_1 = require("@angular/router");
const forms_2 = require("@angular/forms");
const button_1 = require("@angular/material/button");
const radio_1 = require("@angular/material/radio");
const form_field_1 = require("@angular/material/form-field");
const input_1 = require("@angular/material/input");
const test_component_1 = require("./test.component");
const routes = [
    {
        path: "",
        component: test_component_1.TestComponent,
    }
];
let TestModule = class TestModule {
};
TestModule = __decorate([
    core_1.NgModule({
        declarations: [
            test_component_1.TestComponent
        ],
        imports: [
            common_1.CommonModule,
            router_1.RouterModule.forChild(routes),
            forms_2.FormsModule,
            radio_1.MatRadioModule,
            form_field_1.MatFormFieldModule,
            input_1.MatInputModule,
            button_1.MatButtonModule,
            forms_1.ReactiveFormsModule
        ]
    })
], TestModule);
exports.TestModule = TestModule;
