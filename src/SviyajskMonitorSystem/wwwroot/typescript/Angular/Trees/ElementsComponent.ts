

import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { SignalRConnection } from "ng2-signalr";
import { ConnectionService } from "./ConnectionService";
import { Http } from "@angular/http";
import { TreeElement } from "./CreateTreeComponent";

@Component({
    selector: 'elements',
    templateUrl:'TreesElements/GetElementsTemp'
})

export class ElementsComponent implements OnInit {
    ngOnInit(): void {
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            conn.invoke("GetElements").then((elements: TreeElement[]) => {
                $(this.tree).jstree({
                    core: {
                        data: elements
                    },
                    plugins:['checkbox']
                    
                });
                //console.log();
                let component = this;
                $(this.tree).on('check_node', function (e, data) {
                    component.EleementsSetted();
                });
                $(this.tree).on('uncheck_node', function (e, data) {
                    component.EleementsSetted();
                });
            });
        })
    }






    tree: string = '#checkboxelements';
    connection: SignalRConnection;
    constructor(private _signalR: ConnectionService, private http: Http) { }


    @Output()
    OnElementsSetted = new EventEmitter<string>();

    EleementsSetted() {
        let elementsid: string = '';
        let checkedElements: string[] = $(this.tree).jstree().get_checked(false);
        for (let el of checkedElements) {
            elementsid += el;
            elementsid += ";";
        }
        this.OnElementsSetted.emit(elementsid);
    }


}