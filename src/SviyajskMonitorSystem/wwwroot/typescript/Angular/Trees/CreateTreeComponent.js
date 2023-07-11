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
const ng2_signalr_1 = require("ng2-signalr");
const ConnectionService_1 = require("./ConnectionService");
const forms_1 = require("@angular/forms");
const Dictionary_1 = require("./Dictionary");
const http_1 = require("@angular/http");
const ImgComp_1 = require("./ImgComp");
let CreateTreeComponent = class CreateTreeComponent {
    constructor(_signalR, http) {
        this._signalR = _signalR;
        this.http = http;
        this.tree = '#treelements';
        this.hasimage = false;
        this.haselement = false;
        this.loaded = false;
        this.treetype = new TreeType();
        this.ElementForm = new forms_1.FormGroup({
            identifier: new forms_1.FormControl()
        });
    }
    ngOnInit() {
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            this.entityValues = new Dictionary_1.Dictionary();
            let SetTreeType$ = new ng2_signalr_1.BroadcastEventListener("SetTreeType");
            this.connection.listen(SetTreeType$);
            SetTreeType$.subscribe((tt) => {
                this.treetype = tt.treeType;
                for (let key of this.treetype.keys) {
                    this.ElementForm.addControl(key.name, new forms_1.FormControl());
                    if (key.type == AttributeTypes.Choosable) {
                        this.GetEntityValues(key.entitytype.id, key.name);
                    }
                    if (key.type == AttributeTypes.photo) {
                        // alert('photo');
                        this.hasimage = true;
                        this.imageControlName = key.name;
                    }
                    if (key.type == AttributeTypes.elements) {
                        //  alert('elements');
                        this.haselement = true;
                        this.elementsControlName = key.name;
                    }
                }
                this.mobjid = tt.elid;
                this.GetTreeEelemnts(tt.elid, tt.treeType.id);
                this.loaded = true;
            });
            this.connection.invoke("InitTreeRedactor", this.elementid, this.typeid);
        });
    }
    GetEntityValues(typeid, keyname) {
        this.http.get("/EntityValues/GetValues?typeid=" + typeid.toString()).subscribe((resp) => {
            // console.log(resp.json());
            this.entityValues.SetElement(keyname, resp.json());
            this.ElementForm.controls[keyname].setValue(this.entityValues.GetElement(keyname)[0]);
            //console.log(this.entityValues);
        });
    }
    UpdateTreeElements(elid, typeid) {
        this.connection.invoke("GetTreeEls", elid, typeid).then((data) => {
            this.treeElements = data;
            $(this.tree).jstree().refresh(false, true);
        });
    }
    GetTreeEelemnts(elid, typeid) {
        this.connection.invoke("GetTreeEls", elid, typeid).then((data) => {
            this.treeElements = data;
            this.tree = $('#treelements').jstree({
                core: {
                    data: this.treeElements,
                    check_callback: true
                }
            });
        });
    }
    CreateTreeElement() {
        let selected = $(this.tree).jstree().get_selected();
        let parent = "#";
        if (selected.length > 0) {
            parent = selected[0];
        }
        if (parent != "#") {
            if (this.hasimage) {
                this.imgComp.UploadPhotos();
            }
            else {
                this.SendData();
            }
        }
        else {
            alert('Выберите элемент');
        }
    }
    SendData() {
        let identifier = this.ElementForm.controls["identifier"].value;
        let values = [];
        for (let key of this.treetype.keys) {
            let value = new AttributeValue();
            value.keyid = key.id;
            value.type = key.type;
            value.value = this.ElementForm.controls[key.name].value;
            values.push(value);
        }
        this.connection.invoke("CreateEl", parent, identifier, values).then((elid) => {
            let id = $(this.tree).jstree('create_node', [parent], { 'id': elid.toString(), 'text': identifier });
        });
    }
    RemoveTreeEleemnt() {
        let selected = $(this.tree).jstree().get_selected();
        if (selected.length > 0) {
            let element = selected[0];
            this.connection.invoke("RemoveElement", element).then(() => {
                let deleted = $(this.tree).jstree('delete_node', [element]);
            });
        }
    }
    CleanArray(id) {
        let tel = this.treeElements.find(t => t.id == id);
    }
    SetEleemnts(elementsString) {
        this.ElementForm.controls[this.elementsControlName].setValue(elementsString);
    }
    setImages(imagesStrring) {
        this.ElementForm.controls[this.imageControlName].setValue(imagesStrring);
        this.SendData();
    }
};
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], CreateTreeComponent.prototype, "typeid", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], CreateTreeComponent.prototype, "elementid", void 0);
__decorate([
    core_1.ViewChild(ImgComp_1.ImagesComponent),
    __metadata("design:type", ImgComp_1.ImagesComponent)
], CreateTreeComponent.prototype, "imgComp", void 0);
CreateTreeComponent = __decorate([
    core_1.Component({
        selector: 'tree',
        templateUrl: 'TreesElements/GetRedactor'
    }),
    __metadata("design:paramtypes", [ConnectionService_1.ConnectionService, http_1.Http])
], CreateTreeComponent);
exports.CreateTreeComponent = CreateTreeComponent;
class TreeParams {
}
exports.TreeParams = TreeParams;
class AttributeValue {
}
exports.AttributeValue = AttributeValue;
class TreeType {
}
exports.TreeType = TreeType;
class AttributeKey {
}
exports.AttributeKey = AttributeKey;
class EntityType {
}
exports.EntityType = EntityType;
class EntityValue {
}
exports.EntityValue = EntityValue;
class TreeElement {
}
exports.TreeElement = TreeElement;
var AttributeTypes;
(function (AttributeTypes) {
    AttributeTypes[AttributeTypes["intval"] = 0] = "intval";
    AttributeTypes[AttributeTypes["floatval"] = 1] = "floatval";
    AttributeTypes[AttributeTypes["stringval"] = 2] = "stringval";
    AttributeTypes[AttributeTypes["Choosable"] = 3] = "Choosable";
    AttributeTypes[AttributeTypes["photo"] = 4] = "photo";
    AttributeTypes[AttributeTypes["elements"] = 5] = "elements";
})(AttributeTypes || (AttributeTypes = {}));
//# sourceMappingURL=CreateTreeComponent.js.map