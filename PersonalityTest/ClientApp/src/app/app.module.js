"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const platform_browser_1 = require("@angular/platform-browser");
const core_1 = require("@angular/core");
const http_1 = require("@angular/common/http");
const toolbar_1 = require("@angular/material/toolbar");
const icon_1 = require("@angular/material/icon");
const app_component_1 = require("./app.component");
const app_routing_module_1 = require("./app-routing.module");
const animations_1 = require("@angular/platform-browser/animations");
let AppModule = class AppModule {
};
AppModule = __decorate([
    core_1.NgModule({
        declarations: [
            app_component_1.AppComponent,
        ],
        imports: [
            platform_browser_1.BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
            http_1.HttpClientModule,
            app_routing_module_1.AppRoutingModule,
            animations_1.BrowserAnimationsModule,
            toolbar_1.MatToolbarModule,
            icon_1.MatIconModule,
        ],
        providers: [],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
