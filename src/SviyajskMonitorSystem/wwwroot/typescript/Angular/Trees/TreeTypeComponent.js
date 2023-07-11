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
let TreeTypeComponent = class TreeTypeComponent {
    constructor(_signalR) {
        this._signalR = _signalR;
        this.tree = '#jstree';
        this.types = [];
        this.OnTreeCreator = new core_1.EventEmitter();
    }
    ngOnInit() {
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            conn.invoke("GetElements").then((elements) => {
                $(this.tree).jstree({
                    core: {
                        data: elements
                    }
                });
            });
            conn.invoke("GetTypeNames").then((types) => {
                this.types = types;
                this.currenttype = this.types[0];
            });
        });
    }
    ChangeType(i) {
        this.currenttype = this.types[i];
    }
    InitRedactor() {
        //    alert(this.tree);
        let selected = $(this.tree).jstree().get_selected();
        if (selected.length) {
            this.currentel = parseInt(selected[0]);
            this.OnTreeCreator.emit(new TreeParams(this.currenttype, this.currentel));
        }
        else {
            alert("Выберите материальный объект");
        }
    }
};
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], TreeTypeComponent.prototype, "OnTreeCreator", void 0);
TreeTypeComponent = __decorate([
    core_1.Component({
        selector: 'createtree',
        templateUrl: 'TreesElements/GetTType'
    }),
    __metadata("design:paramtypes", [ConnectionService_1.ConnectionService])
], TreeTypeComponent);
exports.TreeTypeComponent = TreeTypeComponent;
class TreeParams {
    constructor(typename, elid) {
        this.type = typename;
        this.matobj = elid;
    }
}
exports.TreeParams = TreeParams;
//# sourceMappingURL=TreeTypeComponent.js.map