import { Component, ViewChild, OnInit} from "@angular/core";
import { NgSwitch } from '@angular/common';
import { DataService } from "./DataService";
import { Http } from "@angular/http";
import { PlaceComponent } from "./PlaceComponent";
import { SignalRConnection, SignalR, BroadcastEventListener } from "ng2-signalr";
import { AnalyzeComponent } from "./AnalyzeComponent";
import { ScanResultsComponent } from "./ScanElMicro";
import { ConnectionService } from "./ConnectionService";
@Component({
    selector: 'BaseComp',
    templateUrl: "/Analyze/BaseComponent"
   
})
export class BaseComponent implements OnInit {
    ngOnInit(): void {
      
        // alert("in");
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            let OnPointSended$ = new BroadcastEventListener('ON_POINT_SENDED');
            this.connection.listen(OnPointSended$);
            OnPointSended$.subscribe(() => {
                this.changestatus(OpStatus.Analyze);
            });
            let OnAnalyseSended$ = new BroadcastEventListener<OpStatus>('ANALYZE_SENDED');
            this.connection.listen(OnAnalyseSended$);
            OnAnalyseSended$.subscribe((st: OpStatus) => {
                this.changestatus(st);
            });
            let OnDataSended$ = new BroadcastEventListener<OpStatus>('DATA_SENDED');
            this.connection.listen(OnDataSended$);
            OnDataSended$.subscribe((st: OpStatus) => {
                this.changestatus(st);
            });
        });
       
            
       
    }
    connection: SignalRConnection;
    constructor(private _signalR: ConnectionService) { }
    status: OpStatus = 0;

    @ViewChild(PlaceComponent)
    private placecomp: PlaceComponent;

    @ViewChild(AnalyzeComponent)
    private ancomp: AnalyzeComponent;

    @ViewChild(ScanResultsComponent)
    private SRComp: ScanResultsComponent;

    changestatus(st: OpStatus): void {
        this.status = st;
    }
}
enum OpStatus{Place,Analyze,ElEmScanRes,RfAnRes,MbAnRes,DendrAnRes}