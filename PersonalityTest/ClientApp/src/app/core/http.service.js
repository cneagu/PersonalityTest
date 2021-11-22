"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const http_1 = require("@angular/common/http");
const core_1 = require("@angular/core");
let HttpService = class HttpService {
    constructor(http) {
        this.http = http;
        this.baseApiUrl = 'api/';
    }
    Get(url) {
        return this.http.get(`${this.baseApiUrl}${url}`, {
            headers: this.getHeaders()
        });
    }
    Post(url, body) {
        return this.http.post(`${this.baseApiUrl}${url}`, body, {
            headers: this.getHeaders()
        });
    }
    getHeaders() {
        return new http_1.HttpHeaders({
            'X-Requested-With': 'XMLHttpRequest'
        });
    }
};
HttpService = __decorate([
    core_1.Injectable({
        providedIn: 'root'
    })
], HttpService);
exports.HttpService = HttpService;
