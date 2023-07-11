

import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { ConnectionService } from "./ConnectionService";
import { SignalRConnection } from "ng2-signalr";
import { TreeElement } from "./CreateTreeComponent";


@Component({
    selector: 'createtree',
    templateUrl:'TreesElements/GetTType'
})
export class TreeTypeComponent implements OnInit {
   
    connection: SignalRConnection;
    tree: string ='#jstree';
    types: string[] = [];
    currenttype: string;
    currentel: number;
    constructor(private _signalR: ConnectionService) { }

    @Output()
    OnTreeCreator = new EventEmitter<TreeParams>();

     
    ngOnInit(): void {
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            conn.invoke("GetElements").then((elements: TreeElement[]) => {
                $(this.tree).jstree({
                    core: {
                        data: elements
                    }
                });
            });
            conn.invoke("GetTypeNames").then((types: string[]) => {
                this.types = types;
                this.currenttype = this.types[0];
            });

        });
    }


    ChangeType(i: number) {
        this.currenttype = this.types[i];
    }

    InitRedactor() {
    //    alert(this.tree);
        let selected: string[] = <string[]>$(this.tree).jstree().get_selected();
        if (selected.length) {
            this.currentel = parseInt(selected[0]);
            this.OnTreeCreator.emit(new TreeParams(this.currenttype, this.currentel));
        } else {
            alert("Выберите материальный объект");
        }
       
    }


}

export class TreeParams {
    constructor(typename: string, elid: number) {
        this.type = typename;
        this.matobj = elid;
    }
     type: string;
     matobj: number;
}