import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Person } from './PlaceComponent';
import { Storage, Organization } from './PlaceComponent';
import { Color } from './ScanElMicro';
import { ChemistryElement } from './ScanElMicro';
@Injectable()
export class DataService {
    constructor(private http: Http) { }

    getPEoples(): Observable<Person[]> {
        return this.http.get('/People/GetPErsonsJson').map(
            (resp: Response) => {
                return resp.json();
            });
    }


    getColors(): Observable<Color[]> {
        return this.http.get('/Colors/GetColorsJson').map(
            (resp: Response) => {
                return resp.json();
            });
    }

    getChemistryElement(): Observable<ChemistryElement[]> {
        return this.http.get('/ChemistryElements/GetChelJson').map(
            (resp: Response) => {
                return resp.json();
            });
    }

    getElements():Observable<string> {
       // let text: string;
        let i = this.http.get('/Elements/GetAllElements').map((data: Response) => { return data.text()});
        return i;
       // return text;
    }


    getOrganizations(): Observable<Organization[]> {
        return this.http.get('/Organizations/GetOrganizationsJson').map((resp: Response) => {
            return resp.json();
        })
    }

    getStorages():Observable<Storage[]> {
        return this.http.get('/Storages/GetStoragesJson').map(
            (resp: Response) => {
               return resp.json();
            });
    }

}