
import { Injectable } from '@angular/core';
//import { Resolve } from '@angular/router';
import { SignalRConnection, SignalR } from "ng2-signalr";
import { Observable } from "rxjs/Observable";

@Injectable()
export class ConnectionService  {
   
    private connection: Promise<SignalRConnection>;

    constructor(private _signalR: SignalR) {

    }

    GetConnectionPromise(): Promise<SignalRConnection> {
        if (this.connection == undefined) {
           // alert("in");
            this.connection =<Promise<SignalRConnection>> this._signalR.connect(); 
        }
        if (this.connection == undefined) { alert("bad");}
        return this.connection;
    }
}
