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
const http_1 = require("@angular/http");
let ElementsComponent = class ElementsComponent {
    constructor(_signalR, http) {
        this._signalR = _signalR;
        this.http = http;
        this.tree = '#checkboxelements';
        this.OnElementsSetted = new core_1.EventEmitter();
    }
    ngOnInit() {
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            conn.invoke("GetElements").then((elements) => {
                $(this.tree).jstree({
                    core: {
                        data: elements
                    },
                    plugins: ['checkbox']
                });
                //console.log();
                let component = this;
                $(this.tree).on('check_node', function (e, data) {
                    component.EleementsSetted();
                });
                $(this.tree).on('uncheck_node', function (e, data) {
                    component.EleementsSetted();
                });
            });
        });
    }
    EleementsSetted() {
        let elementsid = '';
        let checkedElements = $(this.tree).jstree().get_checked(false);
        for (let el of checkedElements) {
            elementsid += el;
            elementsid += ";";
        }
        this.OnElementsSetted.emit(elementsid);
    }
};
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], ElementsComponent.prototype, "OnElementsSetted", void 0);
ElementsComponent = __decorate([
    core_1.Component({
        selector: 'elements',
        templateUrl: 'TreesElements/GetElementsTemp'
    }),
    __metadata("design:paramtypes", [ConnectionService_1.ConnectionService, http_1.Http])
], ElementsComponent);
exports.ElementsComponent = ElementsComponent;
//# sourceMappingURL=ElementsComponent.js.map