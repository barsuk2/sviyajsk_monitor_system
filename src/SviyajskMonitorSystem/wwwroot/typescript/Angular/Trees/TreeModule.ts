import { NgModule } from '@angular/core';
import { SignalRConfiguration, SignalRModule } from "ng2-signalr";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { ConnectionService } from "./ConnectionService";
import { MainComponent } from "./MainComponent";
import { CreateTreeComponent } from "./CreateTreeComponent";
import { TreeTypeComponent } from "./TreeTypeComponent";
import { ElementsComponent } from "./ElementsComponent";
import { ImagesComponent } from "./ImgComp";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {MdAutocompleteModule,
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
    MdStepperModule} from "@angular/material";


export function createConfig(): SignalRConfiguration {
    const c = new SignalRConfiguration();
    c.hubName = 'TreeElementHub';
    c.url = "/signalr";
    // c.qs = { user: 'donald' };
    // c.url = 'http://ng2-signalr-backend.azurewebsites.net/';
    c.logging = true;
    return c;
}


@NgModule({
    imports: [
        BrowserAnimationsModule,
        BrowserModule,
        FormsModule,
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
        HttpModule,
        ReactiveFormsModule,
        SignalRModule.forRoot(createConfig)],
    providers: [ConnectionService],
    declarations: [MainComponent,
        CreateTreeComponent,
        TreeTypeComponent,
        ImagesComponent,
        ElementsComponent],
    bootstrap: [MainComponent]
}) 

export class TreesApp {

}