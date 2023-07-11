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
const Paging_1 = require("./Paging");
let OldPlaceComponent = class OldPlaceComponent {
    constructor(_signalR) {
        this._signalR = _signalR;
        this.OnPlaceSetted = new core_1.EventEmitter();
        this.currentplace = 0;
    }
    ngOnInit() {
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            conn.invoke("GetPlaces").then((op) => {
                this.AllElements = op;
                this.elperpage = 10;
                this.pc.SetOptions(this.AllElements.length, this.elperpage);
                this.onChangePage(1);
            });
        });
    }
    ChangePage(first) {
        this.currentelements = [];
        //  alert(first);
        let lastnumber = first + this.elperpage;
        if (lastnumber >= this.AllElements.length) {
            lastnumber = this.AllElements.length;
        }
        for (let i = first; i < lastnumber; i++) {
            this.currentelements.push(this.AllElements[i]);
        }
    }
    onChangePage(n) {
        this.pc.currentpage = n;
        //  alert(n);
        this.ChangePage(this.pc.firstitemnumber());
    }
    GenerateButtonId(id) {
        return "op" + id.toString();
    }
    ChoosePlace(id) {
        let old = this.currentplace;
        this.currentplace = id;
        if (old != 0) {
            $('#' + this.GenerateButtonId(old)).removeClass('btn-success');
            $('#' + this.GenerateButtonId(old)).addClass('btn-default');
        }
        $('#' + this.GenerateButtonId(id)).removeClass('btn-default');
        $('#' + this.GenerateButtonId(id)).addClass('btn-success');
        this.OnPlaceSetted.emit(id);
    }
};
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], OldPlaceComponent.prototype, "OnPlaceSetted", void 0);
__decorate([
    core_1.ViewChild(Paging_1.PagingComponent),
    __metadata("design:type", Paging_1.PagingComponent)
], OldPlaceComponent.prototype, "pc", void 0);
OldPlaceComponent = __decorate([
    core_1.Component({
        selector: 'oldp',
        templateUrl: '/Analyze/OldPlace'
    }),
    __metadata("design:paramtypes", [ConnectionService_1.ConnectionService])
], OldPlaceComponent);
exports.OldPlaceComponent = OldPlaceComponent;
//# sourceMappingURL=OldPlaceComponent.js.map