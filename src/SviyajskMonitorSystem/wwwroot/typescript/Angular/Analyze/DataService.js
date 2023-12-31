"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const http_1 = require("@angular/http");
require("rxjs/add/operator/map");
let DataService = class DataService {
    constructor(http) {
        this.http = http;
    }
    getPEoples() {
        return this.http.get('/People/GetPErsonsJson').map((resp) => {
            return resp.json();
        });
    }
    getColors() {
        return this.http.get('/Colors/GetColorsJson').map((resp) => {
            return resp.json();
        });
    }
    getChemistryElement() {
        return this.http.get('/ChemistryElements/GetChelJson').map((resp) => {
            return resp.json();
        });
    }
    getElements() {
        // let text: string;
        let i = this.http.get('/Elements/GetAllElements').map((data) => { return data.text(); });
        return i;
        // return text;
    }
    getOrganizations() {
        return this.http.get('/Organizations/GetOrganizationsJson').map((resp) => {
            return resp.json();
        });
    }
    getStorages() {
        return this.http.get('/Storages/GetStoragesJson').map((resp) => {
            return resp.json();
        });
    }
};
DataService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], DataService);
exports.DataService = DataService;
//# sourceMappingURL=DataService.js.map