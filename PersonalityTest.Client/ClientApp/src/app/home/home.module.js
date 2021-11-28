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
var home_component_1 = require("./home.component");
var router_1 = require("@angular/router");
var card_1 = require("@angular/material/card");
var button_1 = require("@angular/material/button");
var routes = [
    {
        path: "",
        component: home_component_1.HomeComponent
    }
];
var HomeModule = /** @class */ (function () {
    function HomeModule() {
    }
    HomeModule = __decorate([
        core_1.NgModule({
            declarations: [
                home_component_1.HomeComponent
            ],
            imports: [
                common_1.CommonModule,
                router_1.RouterModule.forChild(routes),
                card_1.MatCardModule,
                button_1.MatButtonModule
            ]
        })
    ], HomeModule);
    return HomeModule;
}());
exports.HomeModule = HomeModule;
