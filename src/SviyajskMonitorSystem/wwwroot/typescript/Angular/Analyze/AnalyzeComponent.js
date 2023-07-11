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
const DataService_1 = require("./DataService");
const ng2_signalr_1 = require("ng2-signalr");
const ConnectionService_1 = require("./ConnectionService");
//import { Person } from "./PlaceComponent";
let AnalyzeComponent = class AnalyzeComponent {
    constructor(dataService, _connService) {
        this.dataService = dataService;
        this._connService = _connService;
        this.persons = [];
    }
    ngOnInit() {
        this._connService.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            let AnCreatorLoaded$ = new ng2_signalr_1.BroadcastEventListener('AN_CREATOR_LOADED');
            this.connection.listen(AnCreatorLoaded$);
            AnCreatorLoaded$.subscribe((physical) => { this.setphysical(physical); });
        });
        this.dataService.getPEoples().subscribe((data) => {
            this.persons = data;
            this.analyze.personid = this.persons[0].id;
        });
        this.analyze = new Analyze();
    }
    setphysical(physical) {
        if (physical) {
            this.analyze.type = 0;
        }
        else {
            this.analyze.type = 1;
        }
        this.physical = physical;
    }
    SendAnalyze() {
        this.connection.invoke("SetAnalyze", this.analyze).then(() => {
            this.analyze = new Analyze();
        });
    }
};
AnalyzeComponent = __decorate([
    core_1.Component({
        selector: 'analyze',
        templateUrl: "/Analyze/AnalyzeComponent",
        providers: [DataService_1.DataService]
    }),
    __metadata("design:paramtypes", [DataService_1.DataService, ConnectionService_1.ConnectionService])
], AnalyzeComponent);
exports.AnalyzeComponent = AnalyzeComponent;
class Person {
}
exports.Person = Person;
class Analyze {
}
exports.Analyze = Analyze;
//# sourceMappingURL=AnalyzeComponent.js.map