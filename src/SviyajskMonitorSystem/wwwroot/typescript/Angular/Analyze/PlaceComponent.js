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
const ConnectionService_1 = require("./ConnectionService");
const OldPlaceComponent_1 = require("./OldPlaceComponent");
const OldSampleComponent_1 = require("./OldSampleComponent");
const ImgComp_1 = require("./ImgComp");
let PlaceComponent = class PlaceComponent {
    constructor(dataService, _connService) {
        this.dataService = dataService;
        this._connService = _connService;
        this.method = Method.NewPlace;
        this.persons = [];
        this.storages = [];
        this.organizations = [];
    }
    ngOnInit() {
        // let els: string;
        // alert("init");
        this.sample = new Sample();
        this._connService.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            this.CreateTree(this.connection);
            this.GetOrgs(this.connection);
        });
        this.place = new Place();
        this.place.geocords = new vector3(0, 0, 0);
        this.place.pos = new vector3(0, 0, 0);
        this.place.dir = new vector3(0, 0, 0);
        this.place.sample = new Sample();
        // this.dataService.getElements().subscribe((data)=>els=data);
        // alert('jgfjh');
        this.dataService.getPEoples().subscribe((data) => {
            this.persons = data;
            this.place.sample.personid = this.persons[0].id;
            this.sample.personid = this.persons[0].id;
        });
        //this.dataService.getOrganizations().subscribe((data) => {
        //    alert(data[0].Storages);
        //    this.organizations = data;
        //    this.currentorgid = data[0].id;
        //    this.storages = data[0].Storages;
        //    this.place.sample.storageid = data[0].Storages[0].id;
        //})
        // alert(this.persons[0].name);
        // this.dataService.getStorages().subscribe((data) => { this.storages = data; this.place.sample.storageid = this.storages[0].id; });
    }
    //newplaceMethods
    ChangeOrg() {
        this.storages = this.organizations.find(org => org.id == this.currentorgid).Storages;
        this.place.sample.storageid = this.storages[0].id;
        this.sample.storageid = this.storages[0].id;
    }
    ChangeMethod(m) {
        this.method = m;
        this.place.sample.personid = this.persons[0].id;
        this.sample.personid = this.persons[0].id;
        this.place.sample.storageid = this.storages[0].id;
        this.sample.storageid = this.storages[0].id;
    }
    SetSelectedElement() {
        let selected = $('#jstree').jstree().get_selected();
        if (selected.length) {
            this.place.elementid = parseInt(selected[0]);
        }
        else {
            alert("Выберите материальный объект");
        }
        // alert(selected);                              
    }
    SendPlace() {
        //  alert("invoke");
        this.SetSelectedElement();
        if (this.place.sample == undefined) {
            alert("bad");
        }
        this.imc.UploadPhotos();
    }
    OnImageSended(ids) {
        this.place.photoids = ids;
        this.connection.invoke("SetNewPlace", this.place);
        this.CleanData();
    }
    CleanData() {
        this.place.geocords = new vector3(0, 0, 0);
        this.place.pos = new vector3(0, 0, 0);
        this.place.dir = new vector3(0, 0, 0);
        this.place.sample = new Sample();
    }
    CreateTree(connection) {
        //  alert("tree");
        this.connection.invoke('GetElements').then((elements) => {
            this.tree = $('#jstree').jstree({
                core: {
                    data: elements
                }
            });
        });
    }
    GetOrgs(connection) {
        connection.invoke("GetOrgs").then((data) => {
            this.organizations = data;
            this.currentorgid = this.organizations[0].id;
            this.storages = this.organizations[0].Storages;
            for (let org of this.organizations) {
                connection.invoke("GetStorageByOrg", org.id).then((st) => {
                    org.Storages = st;
                    this.ChangeOrg();
                });
            }
        });
    }
    //OldPlaceMethods
    OnPlaceSetted(id) {
        this.sample.pointid = id;
    }
    SetOldPlace() {
        // if (this.sample == undefined) { alert('Wrong'); }
        alert(this.sample.physical);
        this.connection.invoke('SetExistingPlace', this.sample);
    }
    // oldplaces: OldPlace[] = [];
    //OldSampleMethods
    OnSampleSetted(id) {
        alert("Setted");
        this.connection.invoke('SetExistingSample', id);
    }
};
__decorate([
    core_1.ViewChild(OldPlaceComponent_1.OldPlaceComponent),
    __metadata("design:type", OldPlaceComponent_1.OldPlaceComponent)
], PlaceComponent.prototype, "opc", void 0);
__decorate([
    core_1.ViewChild(OldSampleComponent_1.OldSampleComponent),
    __metadata("design:type", OldSampleComponent_1.OldSampleComponent)
], PlaceComponent.prototype, "osc", void 0);
__decorate([
    core_1.ViewChild(ImgComp_1.ImagesComponent),
    __metadata("design:type", ImgComp_1.ImagesComponent)
], PlaceComponent.prototype, "imc", void 0);
PlaceComponent = __decorate([
    core_1.Component({
        selector: 'Place',
        templateUrl: '/Analyze/CreatePlace',
        providers: [DataService_1.DataService]
    }),
    __metadata("design:paramtypes", [DataService_1.DataService, ConnectionService_1.ConnectionService])
], PlaceComponent);
exports.PlaceComponent = PlaceComponent;
class Person {
}
exports.Person = Person;
class Organization {
}
exports.Organization = Organization;
class Storage {
}
exports.Storage = Storage;
class vector3 {
    constructor(x, y, z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
exports.vector3 = vector3;
class TreeElement {
}
exports.TreeElement = TreeElement;
class Place {
}
exports.Place = Place;
class Sample {
}
exports.Sample = Sample;
class OldPlace {
}
exports.OldPlace = OldPlace;
class OldSample {
}
exports.OldSample = OldSample;
var Method;
(function (Method) {
    Method[Method["NewPlace"] = 0] = "NewPlace";
    Method[Method["ExistingPlace"] = 1] = "ExistingPlace";
    Method[Method["ExistingSample"] = 2] = "ExistingSample";
})(Method || (Method = {}));
//# sourceMappingURL=PlaceComponent.js.map