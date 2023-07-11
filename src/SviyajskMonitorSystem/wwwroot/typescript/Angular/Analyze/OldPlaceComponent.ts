import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { IPagable } from "./IPaging";
import { OldPlace } from "./PlaceComponent";
import { ConnectionService } from "./ConnectionService";
import { SignalRConnection } from "ng2-signalr";
import { PagingComponent } from "./Paging";


@Component({
    selector: 'oldp',
    templateUrl:'/Analyze/OldPlace'
})

export class OldPlaceComponent implements  OnInit{
    ngOnInit(): void {
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            conn.invoke("GetPlaces").then((op: OldPlace[]) => {
                this.AllElements = op;
                this.elperpage = 10;
                this.pc.SetOptions(this.AllElements.length, this.elperpage);
                this.onChangePage(1);
            })
        });
    }


    @Output() OnPlaceSetted =  new EventEmitter<number>();


    constructor(private _signalR: ConnectionService) {

    }
    @ViewChild(PagingComponent)
    pc: PagingComponent;
    connection: SignalRConnection;
    currentelements: OldPlace[];
    AllElements: OldPlace[];
    elperpage: number;
    currentplace: number=0;
    ChangePage(first: number): void {
        this.currentelements = [];
      //  alert(first);
        let lastnumber = first + this.elperpage;
        if (lastnumber >= this.AllElements.length) {
            lastnumber = this.AllElements.length ;
        }
        for (let i = first; i < lastnumber; i++) {
          
            this.currentelements.push(this.AllElements[i]);
        }
        
    }
    onChangePage(n: number): void {
        this.pc.currentpage = n;
      //  alert(n);
        this.ChangePage(this.pc.firstitemnumber());
    }


    GenerateButtonId(id: number) {
        return "op" + id.toString();
    }

    ChoosePlace(id: number): void {
        let old = this.currentplace;
        this.currentplace = id;
        if (old != 0) {
            $('#' + this.GenerateButtonId(old)).removeClass('btn-success');
            $('#' + this.GenerateButtonId(old)).addClass('btn-default');
        }
        $('#' + this.GenerateButtonId(id)).removeClass('btn-default');
        $('#' + this.GenerateButtonId(id)).addClass('btn-success');
        this.OnPlaceSetted.emit(id);
    }


}