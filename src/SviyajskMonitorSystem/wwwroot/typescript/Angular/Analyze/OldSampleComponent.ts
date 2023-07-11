import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { IPagable } from "./IPaging";
import {  OldSample } from "./PlaceComponent";
import { SignalRConnection } from "ng2-signalr";
import { ConnectionService } from "./ConnectionService";
import { PagingComponent } from "./Paging";

@Component({
    selector: 'olds',
    templateUrl:'Analyze/OldSample'
})

export class OldSampleComponent implements OnInit {
    ngOnInit(): void {
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            this.elperpage = 10;
            
            this.connection.invoke("GetSamples").then((os: OldSample[]) => {
                this.AllElements = os;
                this.pc.SetOptions(this.AllElements.length, this.elperpage);
                this.onChangePage(1);
            })
        });
    }

    @ViewChild(PagingComponent)
    pc: PagingComponent;



    @Output() OnSampleSetted =  new EventEmitter<number>();


    constructor(private _signalR: ConnectionService) {

    }

    connection: SignalRConnection;
    currentelements: OldSample[];
    AllElements: OldSample[];
    elperpage: number;
    ChangePage(first: number): void {
        this.currentelements = [];
        let lastnumber = first + this.elperpage;
        if (lastnumber >= this.AllElements.length) {
            lastnumber = this.AllElements.length ;
        }
        for (let i = first; i < lastnumber; i++) {
            this.currentelements.push(this.AllElements[i]);
        }
    }
    onChangePage(n: number): void {
      //  this.pc.currentpage = n;
        this.ChangePage(this.pc.firstitemnumber());
    }

    ChooseSample(id: number): void {
        this.OnSampleSetted.emit(id);
    }


}


