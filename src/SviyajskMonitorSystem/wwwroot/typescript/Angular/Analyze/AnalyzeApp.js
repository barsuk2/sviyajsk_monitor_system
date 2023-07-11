"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const BaseComponent_1 = require("./BaseComponent");
const platform_browser_1 = require("@angular/platform-browser");
const forms_1 = require("@angular/forms");
const material = require("@angular/material");
const animation = require("@angular/platform-browser/animations");
const PlaceComponent_1 = require("./PlaceComponent");
const http_1 = require("@angular/http");
const AnalyzeComponent_1 = require("./AnalyzeComponent");
const ScanElMicro_1 = require("./ScanElMicro");
const ng2_signalr_1 = require("ng2-signalr");
const ng2_signalr_2 = require("ng2-signalr");
const ConnectionService_1 = require("./ConnectionService");
const Paging_1 = require("./Paging");
const OldSampleComponent_1 = require("./OldSampleComponent");
const OldPlaceComponent_1 = require("./OldPlaceComponent");
const ImgComp_1 = require("./ImgComp");
function createConfig() {
    const c = new ng2_signalr_2.SignalRConfiguration();
    c.hubName = 'AnalyzeHub';
    c.url = "/signalr";
    // c.qs = { user: 'donald' };
    // c.url = 'http://ng2-signalr-backend.azurewebsites.net/';
    c.logging = true;
    return c;
}
exports.createConfig = createConfig;
let AnalyzeAppModule = class AnalyzeAppModule {
};
AnalyzeAppModule = __decorate([
    core_1.NgModule({
        imports: [
            animation.BrowserAnimationsModule,
            material.MdCheckboxModule,
            material.MdAutocompleteModule,
            material.MatButtonModule,
            material.MatButtonToggleModule,
            material.MdCardModule,
            material.MdChipsModule,
            material.MdDatepickerModule,
            material.MdDialogModule,
            material.MdExpansionModule,
            material.MdGridListModule,
            material.MdIconModule,
            material.MdInputModule,
            material.MdListModule,
            material.MdMenuModule,
            material.MdNativeDateModule,
            material.MdPaginatorModule,
            material.MdProgressBarModule,
            material.MdProgressSpinnerModule,
            material.MdRadioModule,
            material.MdRippleModule,
            material.MdSelectModule,
            material.MdSidenavModule,
            material.MdSliderModule,
            material.MdSlideToggleModule,
            material.MdSnackBarModule,
            material.MdSortModule,
            material.MdTableModule,
            material.MdTabsModule,
            material.MdToolbarModule,
            material.MdTooltipModule,
            material.MdStepperModule,
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            http_1.HttpModule,
            forms_1.ReactiveFormsModule,
            ng2_signalr_1.SignalRModule.forRoot(createConfig)],
        providers: [ConnectionService_1.ConnectionService],
        declarations: [BaseComponent_1.BaseComponent, PlaceComponent_1.PlaceComponent, AnalyzeComponent_1.AnalyzeComponent, ScanElMicro_1.ScanResultsComponent, Paging_1.PagingComponent, OldSampleComponent_1.OldSampleComponent, OldPlaceComponent_1.OldPlaceComponent, ImgComp_1.ImagesComponent],
        bootstrap: [BaseComponent_1.BaseComponent]
    })
], AnalyzeAppModule);
exports.AnalyzeAppModule = AnalyzeAppModule;
//# sourceMappingURL=AnalyzeApp.js.map
