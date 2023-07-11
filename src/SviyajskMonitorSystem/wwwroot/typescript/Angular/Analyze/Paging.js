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
var core_1 = require("@angular/core");
var PagingComponent = (function () {
    function PagingComponent() {
        this.onChangePage = new core_1.EventEmitter();
        //itemscount: number;
        this.currentpage = 1;
        this.buttons = [];
    }
    PagingComponent.prototype.SetOptions = function (itemscount, itemsonpage) {
        this.buttons = [];
        this.itemscount = itemscount;
        this.itemsperpage = itemsonpage;
        var buttonscount = Math.round(itemscount / itemsonpage);
        // alert(buttonscount);
        this.pagescount = buttonscount;
        for (var i = 0; i < buttonscount; i++) {
            this.buttons.push(i + 1);
        }
    };
    PagingComponent.prototype.lastitemnumber = function () {
        return this.currentpage * this.itemsperpage - 1;
    };
    PagingComponent.prototype.firstitemnumber = function () {
        return (this.currentpage - 1) * this.itemsperpage;
    };
    PagingComponent.prototype.Next = function () {
        if (this.currentpage > 1) {
            this.ChangePage(this.currentpage - 1);
        }
    };
    PagingComponent.prototype.Back = function () {
        if (this.currentpage < this.pagescount) {
            this.ChangePage(this.currentpage + 1);
        }
    };
    PagingComponent.prototype.ChangePage = function (n) {
        this.currentpage = n;
        if (n <= this.buttons.length && n >= 0) {
            this.onChangePage.emit(n);
        }
    };
    __decorate([
        core_1.Output(),
        __metadata("design:type", Object)
    ], PagingComponent.prototype, "onChangePage", void 0);
    PagingComponent = __decorate([
        core_1.Component({
            selector: 'paging',
            templateUrl: '/Analyze/Paging'
        })
    ], PagingComponent);
    return PagingComponent;
}());
exports.PagingComponent = PagingComponent;
//# sourceMappingURL=Paging.js.map