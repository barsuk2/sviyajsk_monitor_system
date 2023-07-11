import { Component, OnInit } from "@angular/core";
import { DataService } from "./DataService";
import { Http } from "@angular/http";
import { SignalRConnection, BroadcastEventListener } from "ng2-signalr";
import { ConnectionService } from "./ConnectionService";
//import { Person } from "./PlaceComponent";
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

@Component({
    selector: 'analyze',
    templateUrl: "/Analyze/AnalyzeComponent",
    providers: [DataService],
    imports: [
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
    ]
})

export class AnalyzeComponent implements OnInit {

    ngOnInit(): void {
        this._connService.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            let AnCreatorLoaded$ = new BroadcastEventListener<boolean>('AN_CREATOR_LOADED');
            this.connection.listen(AnCreatorLoaded$);
            AnCreatorLoaded$.subscribe((physical:boolean) => { this.setphysical(physical); })
        });
        this.dataService.getPEoples().subscribe((data) => {
            this.persons = data;
            this.analyze.personid = this.persons[0].id;
        });
        this.analyze = new Analyze();
    }
    connection: SignalRConnection;
    constructor(private dataService: DataService, private _connService:ConnectionService) { }
    persons: Person[] = [];
    analyze: Analyze;
    physical: boolean;

    setphysical(physical:boolean): void {
        if (physical) {
            this.analyze.type = 0;
        } else {
            this.analyze.type = 1;
        }
        this.physical = physical;
    }



    SendAnalyze(): void {
        this.connection.invoke("SetAnalyze", this.analyze).then(() => {
            this.analyze = new Analyze();
        })
    }


}

export class Person {
    id: number;
    name: string;
    surname: string;
}


export class Analyze {
    shifr: string;
    date: string;
    personid: number;
    type: number;
}