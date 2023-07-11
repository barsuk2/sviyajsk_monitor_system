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
let OldSampleComponent = class OldSampleComponent {
    constructor(_signalR) {
        this._signalR = _signalR;
        this.OnSampleSetted = new core_1.EventEmitter();
    }
    ngOnInit() {
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            this.elperpage = 10;
            this.connection.invoke("GetSamples").then((os) => {
                this.AllElements = os;
                this.pc.SetOptions(this.AllElements.length, this.elperpage);
                this.onChangePage(1);
            });
        });
    }
    ChangePage(first) {
        this.currentelements = [];
        let lastnumber = first + this.elperpage;
        if (lastnumber >= this.AllElements.length) {
            lastnumber = this.AllElements.length;
        }
        for (let i = first; i < lastnumber; i++) {
            this.currentelements.push(this.AllElements[i]);
        }
    }
    onChangePage(n) {
        //  this.pc.currentpage = n;
        this.ChangePage(this.pc.firstitemnumber());
    }
    ChooseSample(id) {
        this.OnSampleSetted.emit(id);
    }
};
__decorate([
    core_1.ViewChild(Paging_1.PagingComponent),
    __metadata("design:type", Paging_1.PagingComponent)
], OldSampleComponent.prototype, "pc", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], OldSampleComponent.prototype, "OnSampleSetted", void 0);
OldSampleComponent = __decorate([
    core_1.Component({
        selector: 'olds',
        templateUrl: 'Analyze/OldSample'
    }),
    __metadata("design:paramtypes", [ConnectionService_1.ConnectionService])
], OldSampleComponent);
exports.OldSampleComponent = OldSampleComponent;
//# sourceMappingURL=OldSampleComponent.js.map