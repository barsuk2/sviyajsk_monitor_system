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
const forms_1 = require("@angular/forms");
const DataService_1 = require("./DataService");
const ConnectionService_1 = require("./ConnectionService");
let ScanResultsComponent = class ScanResultsComponent {
    constructor(dataService, _connService) {
        this.dataService = dataService;
        this._connService = _connService;
        this.regions = [];
        this.colors = [];
        this.chelements = [];
        this.currcolor = 0;
        this.currmd = [];
        this.mdForm = new forms_1.FormGroup({
            "color": new forms_1.FormControl(),
            "massdole": new forms_1.FormArray([])
        });
    }
    ngOnInit() {
        this._connService.GetConnectionPromise().then((conn) => { this.connection = conn; });
        this.dataService.getColors().subscribe((data) => {
            this.colors = data;
            this.mdForm.controls["color"].setValue(this.colors[0].id);
        });
        this.dataService.getChemistryElement().subscribe((data) => {
            this.chelements = data;
            for (let chel of this.chelements) {
                //    this.currmd.push(0);
                this.mdForm.controls["massdole"].push(new forms_1.FormControl(0));
            }
        });
        //let mdarray: FormArray = new FormArray([]);
        // this.mdForm.addControl("massdole")
    }
    ChangeCurrentRegion(n) {
        this.currentregion = n;
    }
    GetColorById(id) {
        let col = this.colors.find(c => c.id == id);
        return col;
    }
    AddNewRegion() {
        let r = new Region();
        r.sectors = [];
        this.regions.push(r);
        this.currentregion = this.regions.length - 1;
    }
    AddSector() {
        let s = new Sector();
        s.color = this.GetColorById(this.mdForm.controls["color"].value);
        s.Massdoles = [];
        // this.currcolor = 0;
        let k = 0;
        for (let chel of this.chelements) {
            let md = new MassDole();
            md.Chelement = chel;
            // alert(md.Chelement.fullname);
            // alert(this.currmd[k]);
            md.value = this.mdForm.controls["massdole"].controls[k].value;
            this.mdForm.controls["massdole"].controls[k].setValue(0);
            s.Massdoles.push(md);
            // this.currmd[k]=0;                    
            k++;
        }
        this.regions[this.currentregion].sectors.push(s);
    }
    SendData() {
        this.connection.invoke("CreateElEmScanAnalyze", this.regions).then(() => {
            this.regions = [];
        });
    }
};
ScanResultsComponent = __decorate([
    core_1.Component({
        selector: 'ElScanRes',
        templateUrl: '/Analyze/ElEmScanRes',
        providers: [DataService_1.DataService]
    }),
    __metadata("design:paramtypes", [DataService_1.DataService, ConnectionService_1.ConnectionService])
], ScanResultsComponent);
exports.ScanResultsComponent = ScanResultsComponent;
class ChemistryElement {
}
exports.ChemistryElement = ChemistryElement;
class MassDole {
}
exports.MassDole = MassDole;
class Color {
}
exports.Color = Color;
class Region {
}
exports.Region = Region;
class Sector {
}
exports.Sector = Sector;
//# sourceMappingURL=ScanElMicro.js.map