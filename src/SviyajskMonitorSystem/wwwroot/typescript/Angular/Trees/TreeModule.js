"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const ng2_signalr_1 = require("ng2-signalr");
const platform_browser_1 = require("@angular/platform-browser");
const forms_1 = require("@angular/forms");
const http_1 = require("@angular/http");
const ConnectionService_1 = require("./ConnectionService");
const MainComponent_1 = require("./MainComponent");
const CreateTreeComponent_1 = require("./CreateTreeComponent");
const TreeTypeComponent_1 = require("./TreeTypeComponent");
const ElementsComponent_1 = require("./ElementsComponent");
const ImgComp_1 = require("./ImgComp");
const animations_1 = require("@angular/platform-browser/animations");
const material_1 = require("@angular/material");
function createConfig() {
    const c = new ng2_signalr_1.SignalRConfiguration();
    c.hubName = 'TreeElementHub';
    c.url = "/signalr";
    // c.qs = { user: 'donald' };
    // c.url = 'http://ng2-signalr-backend.azurewebsites.net/';
    c.logging = true;
    return c;
}
exports.createConfig = createConfig;
let TreesApp = class TreesApp {
};
TreesApp = __decorate([
    core_1.NgModule({
        imports: [
            animations_1.BrowserAnimationsModule,
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            material_1.MdAutocompleteModule,
            material_1.MdButtonModule,
            material_1.MdButtonToggleModule,
            material_1.MdCardModule,
            material_1.MdCheckboxModule,
            material_1.MdChipsModule,
            material_1.MdDatepickerModule,
            material_1.MdDialogModule,
            material_1.MdExpansionModule,
            material_1.MdGridListModule,
            material_1.MdIconModule,
            material_1.MdInputModule,
            material_1.MdListModule,
            material_1.MdMenuModule,
            material_1.MdNativeDateModule,
            material_1.MdPaginatorModule,
            material_1.MdProgressBarModule,
            material_1.MdProgressSpinnerModule,
            material_1.MdRadioModule,
            material_1.MdRippleModule,
            material_1.MdSelectModule,
            material_1.MdSidenavModule,
            material_1.MdSliderModule,
            material_1.MdSlideToggleModule,
            material_1.MdSnackBarModule,
            material_1.MdSortModule,
            material_1.MdTableModule,
            material_1.MdTabsModule,
            material_1.MdToolbarModule,
            material_1.MdTooltipModule,
            material_1.MdStepperModule,
            http_1.HttpModule,
            forms_1.ReactiveFormsModule,
            ng2_signalr_1.SignalRModule.forRoot(createConfig)
        ],
        providers: [ConnectionService_1.ConnectionService],
        declarations: [MainComponent_1.MainComponent,
            CreateTreeComponent_1.CreateTreeComponent,
            TreeTypeComponent_1.TreeTypeComponent,
            ImgComp_1.ImagesComponent,
            ElementsComponent_1.ElementsComponent],
        bootstrap: [MainComponent_1.MainComponent]
    })
], TreesApp);
exports.TreesApp = TreesApp;
//# sourceMappingURL=TreeModule.js.map