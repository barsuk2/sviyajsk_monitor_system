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
const ConnectionService_1 = require("./ConnectionService");
let MainComponent = class MainComponent {
    constructor(_signalR) {
        this._signalR = _signalR;
        this.redactor = false;
    }
    ngOnInit() {
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
        });
    }
    OnTreeCreator(tp) {
        //this.connection.invoke("InitTreeRedactor", tp.matobj, tp.type).then(() => this.redactor = true);
        this.tp = tp;
        this.redactor = true;
    }
};
MainComponent = __decorate([
    core_1.Component({
        selector: 'Main',
        templateUrl: 'TreesElements/GetMain'
    }),
    __metadata("design:paramtypes", [ConnectionService_1.ConnectionService])
], MainComponent);
exports.MainComponent = MainComponent;
//# sourceMappingURL=MainComponent.js.map