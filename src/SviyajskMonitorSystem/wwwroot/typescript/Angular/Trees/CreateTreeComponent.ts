

import { Component, OnInit, Input, ViewChild } from "@angular/core";
import { SignalRConnection, BroadcastEventListener } from "ng2-signalr";
import { ConnectionService } from "./ConnectionService";
import { FormGroup, FormControl } from "@angular/forms";
import { Dictionary } from "./Dictionary";
import { Http, Response } from "@angular/http";
import { ImagesComponent } from "./ImgComp";

@Component({
    selector: 'tree',
    templateUrl: 'TreesElements/GetRedactor'
})

export class CreateTreeComponent implements OnInit {
    ngOnInit(): void {
        this._signalR.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            this.entityValues = new Dictionary<string, EntityValue[]>();
            let SetTreeType$ = new BroadcastEventListener<TreeParams>("SetTreeType");
            this.connection.listen(SetTreeType$);
            SetTreeType$.subscribe((tt: TreeParams) => {

                this.treetype = tt.treeType;

                for (let key of this.treetype.keys) {

                    this.ElementForm.addControl(key.name, new FormControl())
                    if (key.type == AttributeTypes.Choosable) {
                        this.GetEntityValues(key.entitytype.id, key.name);
                    }
                    if (key.type == AttributeTypes.photo) {
                       // alert('photo');
                        this.hasimage = true;
                        this.imageControlName = key.name;
                    }
                    if (key.type == AttributeTypes.elements) {
                      //  alert('elements');
                        this.haselement = true;
                        this.elementsControlName = key.name;
                    }
                }
                this.mobjid = tt.elid;
                this.GetTreeEelemnts(tt.elid, tt.treeType.id);
                this.loaded = true;
            });
            this.connection.invoke("InitTreeRedactor", this.elementid, this.typeid);
        });
    }
    connection: SignalRConnection;
    constructor(private _signalR: ConnectionService, private http:Http) { }

    entityValues: Dictionary<string, EntityValue[]>;
    tree: string ='#treelements';
    treeElements: TreeElement[];
    hasimage: boolean = false;
    imageControlName: string;
    haselement: boolean = false;
    elementsControlName: string;
    loaded: boolean = false;
    mobjid: number;
    treetype: TreeType = new TreeType();
    ElementForm: FormGroup = new FormGroup({
        identifier: new FormControl()
    });





    @Input()
    typeid: string;
    @Input()
    elementid: number;

    @ViewChild(ImagesComponent)
    private imgComp: ImagesComponent


    GetEntityValues(typeid: number, keyname: string) {
        this.http.get("/EntityValues/GetValues?typeid=" + typeid.toString()).subscribe((resp: Response) => {
           // console.log(resp.json());
            this.entityValues.SetElement(keyname, resp.json());
            this.ElementForm.controls[keyname].setValue( this.entityValues.GetElement(keyname)[0]);
            //console.log(this.entityValues);
        })
    }


    UpdateTreeElements(elid: number, typeid: number) {
        this.connection.invoke("GetTreeEls", elid, typeid).then((data: TreeElement[]) => {
            this.treeElements = data;
            $(this.tree).jstree().refresh(false, true);
        })
    }

    GetTreeEelemnts(elid: number, typeid: number) {
        this.connection.invoke("GetTreeEls", elid, typeid).then((data: TreeElement[]) => {
            this.treeElements = data;
            this.tree = $('#treelements').jstree({
                core:{
                    data: this.treeElements,
                    check_callback :true
                }
               
            });
        })
    }

    CreateTreeElement() {
        let selected: string[] = <string[]>$(this.tree).jstree().get_selected();
        let parent: string = "#";
        if (selected.length > 0) {
            parent = selected[0];
        }
        if (parent != "#") {
            if (this.hasimage) {
           
            
               this.imgComp.UploadPhotos();
            } else {
               this.SendData();
            }
        } else {
            alert('Выберите элемент');
        }
    }


    SendData() {
        let identifier = this.ElementForm.controls["identifier"].value;
        let values: AttributeValue[] = [];
        for (let key of this.treetype.keys) {
            let value = new AttributeValue();
            value.keyid = key.id;
            value.type = key.type;
            value.value = this.ElementForm.controls[key.name].value;
            values.push(value);
        }
        this.connection.invoke("CreateEl", parent, identifier, values).then((elid: number) => {
            let id: string = $(this.tree).jstree('create_node', [parent], { 'id': elid.toString(), 'text': identifier });
        })
    }


    RemoveTreeEleemnt() {
        let selected: string[] = <string[]>$(this.tree).jstree().get_selected();
        if (selected.length > 0) {
            let element = selected[0];
            this.connection.invoke("RemoveElement", element).then(() => {
                let deleted = $(this.tree).jstree('delete_node', [element]);
            });
        }
    }

    CleanArray(id: string) {
        let tel: TreeElement = this.treeElements.find(t => t.id == id);

    }



    SetEleemnts(elementsString: string) {
        this.ElementForm.controls[this.elementsControlName].setValue(elementsString);
    }


    setImages(imagesStrring: string) {
        this.ElementForm.controls[this.imageControlName].setValue(imagesStrring);
        this.SendData();
    }

}

export class TreeParams {
    elid: number;
    elname: string;
    treeType:TreeType;
}

export class AttributeValue {
    keyid: number;
    type: AttributeTypes;
    value: string;
}

export class TreeType {
    id: number;
    name: string;
    keys: AttributeKey[];
}

export class AttributeKey {
    id: number;
    name: string;
    type: AttributeTypes;
    entitytype: EntityType;
}

export class EntityType {
    id: number;
    name: string;
}

export class EntityValue {
    id: number;
    value: string;
}

export class TreeElement {
    id: string;
    parent: string;
    text: string;
}



 enum AttributeTypes {
    intval,
    floatval,
    stringval,
    Choosable,
    photo,
    elements
}