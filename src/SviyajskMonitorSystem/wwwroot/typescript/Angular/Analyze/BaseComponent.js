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
const PlaceComponent_1 = require("./PlaceComponent");
const ng2_signalr_1 = require("ng2-signalr");
const AnalyzeComponent_1 = require("./AnalyzeComponent");
const ScanElMicro_1 = require("./ScanElMicro");
const ConnectionService_1 = require("./ConnectionService");
let BaseComponent = class BaseComponent {
    constructor(_signalR) {
        this._signalR = _signalR;
        this.status = 0;
    }
    ngOnInit() {
        // alert("in");
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            let OnPointSended$ = new ng2_signalr_1.BroadcastEventListener('ON_POINT_SENDED');
            this.connection.listen(OnPointSended$);
            OnPointSended$.subscribe(() => {
                this.changestatus(OpStatus.Analyze);
            });
            let OnAnalyseSended$ = new ng2_signalr_1.BroadcastEventListener('ANALYZE_SENDED');
            this.connection.listen(OnAnalyseSended$);
            OnAnalyseSended$.subscribe((st) => {
                this.changestatus(st);
            });
            let OnDataSended$ = new ng2_signalr_1.BroadcastEventListener('DATA_SENDED');
            this.connection.listen(OnDataSended$);
            OnDataSended$.subscribe((st) => {
                this.changestatus(st);
            });
        });
    }
    changestatus(st) {
        this.status = st;
    }
};
__decorate([
    core_1.ViewChild(PlaceComponent_1.PlaceComponent),
    __metadata("design:type", PlaceComponent_1.PlaceComponent)
], BaseComponent.prototype, "placecomp", void 0);
__decorate([
    core_1.ViewChild(AnalyzeComponent_1.AnalyzeComponent),
    __metadata("design:type", AnalyzeComponent_1.AnalyzeComponent)
], BaseComponent.prototype, "ancomp", void 0);
__decorate([
    core_1.ViewChild(ScanElMicro_1.ScanResultsComponent),
    __metadata("design:type", ScanElMicro_1.ScanResultsComponent)
], BaseComponent.prototype, "SRComp", void 0);
BaseComponent = __decorate([
    core_1.Component({
        selector: 'BaseComp',
        templateUrl: "/Analyze/BaseComponent"
    }),
    __metadata("design:paramtypes", [ConnectionService_1.ConnectionService])
], BaseComponent);
exports.BaseComponent = BaseComponent;
var OpStatus;
(function (OpStatus) {
    OpStatus[OpStatus["Place"] = 0] = "Place";
    OpStatus[OpStatus["Analyze"] = 1] = "Analyze";
    OpStatus[OpStatus["ElEmScanRes"] = 2] = "ElEmScanRes";
    OpStatus[OpStatus["RfAnRes"] = 3] = "RfAnRes";
    OpStatus[OpStatus["MbAnRes"] = 4] = "MbAnRes";
    OpStatus[OpStatus["DendrAnRes"] = 5] = "DendrAnRes";
})(OpStatus || (OpStatus = {}));
//# sourceMappingURL=BaseComponent.js.map