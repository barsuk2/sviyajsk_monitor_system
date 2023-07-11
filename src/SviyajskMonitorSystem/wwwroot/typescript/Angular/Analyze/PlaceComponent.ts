import { Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from './DataService';
import { Http } from "@angular/http";

import { SignalRConnection, SignalR } from "ng2-signalr";
import { ConnectionService } from "./ConnectionService";
import {  OldPlaceComponent } from "./OldPlaceComponent";
import { OldSampleComponent } from "./OldSampleComponent";
import { ImagesComponent } from "./ImgComp";
@Component({
    selector: 'Place',
    templateUrl: '/Analyze/CreatePlace',
    providers: [DataService]
    
})

export class PlaceComponent implements OnInit {


    connection: SignalRConnection;
    tree: JSTree
    constructor(private dataService: DataService, private _connService:ConnectionService) { }
              
    ngOnInit(): void {
        // let els: string;
        // alert("init");
        this.sample = new Sample();
        this._connService.GetConnectionPromise().then((conn) => {
            this.connection = conn;
            this.CreateTree(this.connection);
            this.GetOrgs(this.connection);
        });
        this.place = new Place();
        this.place.geocords = new vector3(0, 0, 0);
        this.place.pos = new vector3(0, 0, 0);
        this.place.dir = new vector3(0, 0, 0);
        this.place.sample = new Sample();
        
       
       // this.dataService.getElements().subscribe((data)=>els=data);
       // alert('jgfjh');

        this.dataService.getPEoples().subscribe((data) => {
            this.persons = data;
            this.place.sample.personid = this.persons[0].id;
            this.sample.personid = this.persons[0].id;
        });
        //this.dataService.getOrganizations().subscribe((data) => {
        //    alert(data[0].Storages);
        //    this.organizations = data;
           
        //    this.currentorgid = data[0].id;
        //    this.storages = data[0].Storages;
        //    this.place.sample.storageid = data[0].Storages[0].id;
           
        //})
        // alert(this.persons[0].name);
       // this.dataService.getStorages().subscribe((data) => { this.storages = data; this.place.sample.storageid = this.storages[0].id; });
    }



    @ViewChild(OldPlaceComponent)
    opc: OldPlaceComponent;

    @ViewChild(OldSampleComponent)
    osc: OldSampleComponent;

    @ViewChild(ImagesComponent)
    imc: ImagesComponent;






    method: Method = Method.NewPlace;


    
    persons: Person[]=[];
    storages: Storage[] = [];
    organizations: Organization[] = [];
    currentorgid: number;

    //NewPlaceVariables
    place: Place;



    //OldPlaceVariables

         placeid:number


    //OldSampleVariables

        sampleid:number



    //newplaceMethods
    ChangeOrg(): void {
        this.storages = this.organizations.find(org => org.id == this.currentorgid).Storages;
        this.place.sample.storageid = this.storages[0].id;
        this.sample.storageid = this.storages[0].id;
    }
    

    ChangeMethod(m: Method): void {
        this.method = m;
        this.place.sample.personid = this.persons[0].id;
        this.sample.personid = this.persons[0].id;
        this.place.sample.storageid = this.storages[0].id;
        this.sample.storageid = this.storages[0].id;
    }


   

    SetSelectedElement(): void {
        let selected: string[] = <string[]>$('#jstree').jstree().get_selected();
        if (selected.length) {
            this.place.elementid = parseInt( selected[0]);
        } else {
            alert("Выберите материальный объект");
        }
       // alert(selected);                              
    }

    SendPlace(): void {
      //  alert("invoke");
        this.SetSelectedElement();
        if (this.place.sample == undefined) { alert("bad"); }
        this.imc.UploadPhotos();
        
   
    }

    OnImageSended(ids: string[]) {
        this.place.photoids = ids;
        this.connection.invoke("SetNewPlace", this.place);
        this.CleanData();
    }

    CleanData(): void {
        this.place.geocords = new vector3(0, 0, 0);
        this.place.pos = new vector3(0, 0, 0);
        this.place.dir = new vector3(0, 0, 0);
        this.place.sample = new Sample();
    }


    CreateTree(connection: SignalRConnection): void{
      //  alert("tree");
       this.connection.invoke('GetElements').then((elements: TreeElement[]) => {
           this.tree = $('#jstree').jstree({
               core: {
                   data: elements
               }
           });
       });
    }


    GetOrgs(connection: SignalRConnection): void {
        connection.invoke("GetOrgs").then((data: Organization[]) => {
            this.organizations = data;
            this.currentorgid = this.organizations[0].id;
            this.storages = this.organizations[0].Storages;
            for (let org of this.organizations) {
                connection.invoke("GetStorageByOrg", org.id).then((st: Storage[]) => {
                    org.Storages = st;
                    this.ChangeOrg();
                })
            }
           
            
        })
    }





    //OldPlaceMethods

    OnPlaceSetted(id: number): void {
        this.sample.pointid = id;
    }

    sample: Sample;




    SetOldPlace(): void {

        // if (this.sample == undefined) { alert('Wrong'); }
        alert(this.sample.physical);
        this.connection.invoke('SetExistingPlace', this.sample);
    }

   // oldplaces: OldPlace[] = [];
   



    //OldSampleMethods

    OnSampleSetted(id: number): void {
        alert("Setted");
        this.connection.invoke('SetExistingSample', id);
    }


}

export class Person {
    id: number;
    name: string;
    surname: string;
}

export class Organization {
    id: number;
    Name: string;
    Storages: Storage[];
}

export class Storage {
    id: number;
    place: string;
}

export class vector3 {
    constructor(x: number, y: number, z: number) {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    x: number;
    y: number;
    z: number;
}
export class TreeElement {
    id: string;
    parent: string;
    text: string;
}

export class Place {
    haspoint: boolean;
    hasgeocords: boolean;
    pos: vector3;
    dir: vector3;
    modelid: number;
    geocords: vector3;
    elementid: number;
    placedescription: string;
    photoids: string[];
    sample: Sample;
}

export class Sample {
    pointid: number;
    physical: boolean;
    date: string;
    shifr: string;
    personid: number;
    storageid: number;
}




export class OldPlace {
    pointid: number;
    elementpath: string;
    pos: vector3;
    dir: vector3;
    samplecodes:string

}



export class OldSample {
    sampleid: number;
    place: OldPlace;
    date: string;
    shifr: string;
    researcher: Person;
    researchCodes: string;
}


enum Method{NewPlace,ExistingPlace,ExistingSample}