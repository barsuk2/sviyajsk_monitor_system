import { Component, OnInit } from '@angular/core'
import { FormGroup, FormControl, Validators, FormArray } from "@angular/forms";
import { DataService } from "./DataService";
import { SignalRConnection } from "ng2-signalr";
import { ConnectionService } from "./ConnectionService";


@Component({
    selector: 'ElScanRes',
    templateUrl: '/Analyze/ElEmScanRes',
    providers: [DataService]
})

export class ScanResultsComponent implements OnInit {
    ngOnInit(): void {
        this._connService.GetConnectionPromise().then((conn) => { this.connection = conn; });
        this.dataService.getColors().subscribe((data) => {
            this.colors = data;
            this.mdForm.controls["color"].setValue( this.colors[0].id);
        })
        this.dataService.getChemistryElement().subscribe((data) => {
            this.chelements = data;
            for (let chel of this.chelements) {
            //    this.currmd.push(0);
                (<FormArray>this.mdForm.controls["massdole"]).push(new FormControl(0));
            }
        });
        //let mdarray: FormArray = new FormArray([]);
       // this.mdForm.addControl("massdole")
       
        
    }
    constructor(private dataService: DataService, private _connService: ConnectionService) { }
    currentregion: number;

    regions: Region[]=[];
    colors: Color[]=[];
    chelements: ChemistryElement[] = [];
    currcolor: number = 0;
    currmd: number[] = [];
    connection: SignalRConnection;
    mdForm: FormGroup = new FormGroup({
        "color": new FormControl(),
       "massdole": new FormArray([])
    })



    ChangeCurrentRegion(n: number): void {
        this.currentregion = n;
    }


    GetColorById(id: number): Color {
        let col:Color= this.colors.find(c => c.id == id);
        return col;
    }

    AddNewRegion(): void {
        let r = new Region();
        r.sectors = [];
        this.regions.push(r);
        this.currentregion = this.regions.length - 1;
    }


    AddSector(): void {
        let s: Sector = new Sector();
        s.color = this.GetColorById( this.mdForm.controls["color"].value);
        s.Massdoles = [];
       // this.currcolor = 0;
        let k = 0;
        for (let chel of this.chelements) {
            let md: MassDole = new MassDole();
            md.Chelement = chel;
           // alert(md.Chelement.fullname);
            // alert(this.currmd[k]);
            md.value = (<FormArray>this.mdForm.controls["massdole"]).controls[k].value;
            (<FormArray>this.mdForm.controls["massdole"]).controls[k].setValue(0);
            s.Massdoles.push(md);
           // this.currmd[k]=0;                    
            k++;
        }
        this.regions[this.currentregion].sectors.push(s);
    }

    SendData() {
        this.connection.invoke("CreateElEmScanAnalyze", this.regions).then(() => {
            this.regions = [];
        })
    }


}

export class ChemistryElement {
    id: number;
    fullname: string;
    shortname: string;
}

export class MassDole {
    Chelement: ChemistryElement;
    value: number;
}
export class Color {
    id: number;
    name: string;
}
export class Region {
    sectors: Sector[];
}
export class Sector {
    Massdoles: MassDole[];
      color:Color
}