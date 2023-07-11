import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
    selector: 'paging',
    templateUrl:'/Analyze/Paging'
})

export class PagingComponent  {

    @Output() onChangePage = new EventEmitter<number>();
    itemscount:number
    itemsperpage: number;
    pagescount: number;
    //itemscount: number;
    currentpage: number = 1;

    buttons: number[] = [];


    SetOptions(itemscount: number, itemsonpage: number): void {
        this.buttons = [];
        this.itemscount = itemscount;
        this.itemsperpage = itemsonpage;
        let buttonscount = Math.round(itemscount / itemsonpage);
       // alert(buttonscount);
        this.pagescount = buttonscount;
        for (let i = 0; i < buttonscount; i++) {
            this.buttons.push(i + 1);
        }
    }


    lastitemnumber(): number {
        return this.currentpage * this.itemsperpage-1;
    }

    firstitemnumber(): number {
        return (this.currentpage-1) * this.itemsperpage;
    }


    Next(): void {
        if (this.currentpage > 1) {
            this.ChangePage(this.currentpage - 1);
        }
    }


    Back(): void {
        if (this.currentpage < this.pagescount) {
            this.ChangePage(this.currentpage + 1);
        }
    }


    ChangePage(n: number) {
        this.currentpage = n;
        if (n <= this.buttons.length && n >= 0) {
            this.onChangePage.emit(n);
        }
    }

}