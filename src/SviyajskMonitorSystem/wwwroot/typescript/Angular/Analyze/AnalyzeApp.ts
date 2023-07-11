import { NgModule } from '@angular/core';
import { BaseComponent } from "./BaseComponent";
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { PlaceComponent } from "./PlaceComponent";
import { HttpModule, Http } from "@angular/http";
import { DataService } from "./DataService";
import { AnalyzeComponent } from "./AnalyzeComponent";
import { ScanResultsComponent } from "./ScanElMicro";
import { SignalRModule } from "ng2-signalr";
import { SignalRConfiguration } from "ng2-signalr";
import { ConnectionService } from "./ConnectionService";
import { PagingComponent } from "./Paging";
import { OldSampleComponent } from "./OldSampleComponent";
import { OldPlaceComponent } from "./OldPlaceComponent";
import { ImagesComponent } from "./ImgComp";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { MdAutocompleteModule,
    MdButtonModule,
    MdButtonToggleModule,
    MdCardModule,
    MdCheckboxModule,
    MdChipsModule,
    MdDatepickerModule,
    MdDialogModule,
    MdExpansionModule,
    MdGridListModule,
    MdIconModule,
    MdInputModule,
    MdListModule,
    MdMenuModule,
    MdNativeDateModule,
    MdPaginatorModule,
    MdProgressBarModule,
    MdProgressSpinnerModule,
    MdRadioModule,
    MdRippleModule,
    MdSelectModule,
    MdSidenavModule,
    MdSliderModule,
    MdSlideToggleModule,
    MdSnackBarModule,
    MdSortModule,
    MdTableModule,
    MdTabsModule,
    MdToolbarModule,
    MdTooltipModule,
    MdStepperModule,} from '@angular/material';
import {CdkTableModule} from '@angular/cdk/table';

export function createConfig(): SignalRConfiguration {
    const c = new SignalRConfiguration();
    c.hubName = 'AnalyzeHub';
    c.url = "/signalr";
    // c.qs = { user: 'donald' };
   // c.url = 'http://ng2-signalr-backend.azurewebsites.net/';
    c.logging = true;
    return c;
}


@NgModule({
    imports: [BrowserModule,
        FormsModule,
        HttpModule,
        MdAutocompleteModule,
        MdButtonModule,
        MdButtonToggleModule,
        MdCardModule,
        MdCheckboxModule,
        MdChipsModule,
        MdDatepickerModule,
        MdDialogModule,
        MdExpansionModule,
        MdGridListModule,
        MdIconModule,
        MdInputModule,
        MdListModule,
        MdMenuModule,
        MdNativeDateModule,
        MdPaginatorModule,
        MdProgressBarModule,
        MdProgressSpinnerModule,
        MdRadioModule,
        MdRippleModule,
        MdSelectModule,
        MdSidenavModule,
        MdSliderModule,
        MdSlideToggleModule,
        MdSnackBarModule,
        MdSortModule,
        MdTableModule,
        MdTabsModule,
        MdToolbarModule,
        MdTooltipModule,
        MdStepperModule,
        BrowserAnimationsModule,
        ReactiveFormsModule,
        CdkTableModule,
        SignalRModule.forRoot(createConfig)],
    providers: [
        ConnectionService
    ],
    declarations: [BaseComponent,
        PlaceComponent,
        AnalyzeComponent,
        ScanResultsComponent,
        PagingComponent,
        OldSampleComponent,
        OldPlaceComponent,
        ImagesComponent],
    bootstrap: [BaseComponent]
   
})


export class AnalyzeAppModule {

}

