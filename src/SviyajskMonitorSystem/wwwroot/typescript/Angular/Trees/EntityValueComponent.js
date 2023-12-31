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
let EntityValueComponent = class EntityValueComponent {
    constructor() {
        this.OnValueChanged = new core_1.EventEmitter();
    }
    ChangeValue(id) {
        this.currentvalue = this.values.find(v => v.id == id);
        this.OnValueChanged.emit(this.currentvalue);
    }
};
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], EntityValueComponent.prototype, "key", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", EnVal)
], EntityValueComponent.prototype, "currentvalue", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], EntityValueComponent.prototype, "values", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], EntityValueComponent.prototype, "OnValueChanged", void 0);
EntityValueComponent = __decorate([
    core_1.Component({
        selector: 'entityvalue',
        templateUrl: ''
    })
], EntityValueComponent);
exports.EntityValueComponent = EntityValueComponent;
class EnVal {
}
exports.EnVal = EnVal;
//# sourceMappingURL=EntityValueComponent.js.map