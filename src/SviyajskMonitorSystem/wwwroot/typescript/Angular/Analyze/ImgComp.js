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
const http_1 = require("@angular/http");
let ImagesComponent = class ImagesComponent {
    constructor(http) {
        this.http = http;
        this.ImagesUrls = [];
        this.OnImagesSetted = new core_1.EventEmitter();
    }
    OnImageAdded(event) {
        console.log(event);
        var self = this;
        let files = event.target.files;
        for (let i = 0; i < files.length; i++) {
            let fr = new FileReader();
            fr.onload = function (e) {
                self.ImagesUrls.push(e.target.result);
            };
            fr.readAsDataURL(files[i]);
        }
    }
    ClickFile() {
        $('#fileinput').click();
    }
    DeleteImage(index) {
        this.ImagesUrls.splice(index, 1);
    }
    UploadPhotos() {
        this.http.post("Images/UploadImage", this.ImagesUrls).subscribe((data) => {
            this.ImagesUrls = [];
            this.OnImagesSetted.emit(data.json());
        });
    }
    GenerateId(id) {
        let sid = id.toString + "img";
        return sid;
    }
};
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], ImagesComponent.prototype, "OnImagesSetted", void 0);
ImagesComponent = __decorate([
    core_1.Component({
        selector: 'image',
        templateUrl: 'Images/ImgTemplate'
        // providers: [Http]
    }),
    __metadata("design:paramtypes", [http_1.Http])
], ImagesComponent);
exports.ImagesComponent = ImagesComponent;
//# sourceMappingURL=ImgComp.js.map