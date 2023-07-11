


import { Component, OnInit } from "@angular/core";
import { SignalRConnection } from "ng2-signalr";
import { ConnectionService } from "./ConnectionService";
import { TreeParams } from "./TreeTypeComponent";

@Component({
    selector: 'Main',
    templateUrl:'TreesElements/GetMain'
})

export class MainComponent implements OnInit {
    ngOnInit(): void {
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
        })
    }
    constructor(private _signalR: ConnectionService) { }
    connection: SignalRConnection;
    redactor: boolean = false;

    tp: TreeParams;


    OnTreeCreator(tp: TreeParams) {
        //this.connection.invoke("InitTreeRedactor", tp.matobj, tp.type).then(() => this.redactor = true);
        this.tp = tp;
        this.redactor = true;
    }

}