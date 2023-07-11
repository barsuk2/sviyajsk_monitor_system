export interface IPagable<T> {
    currentelements: T;
    AllElements: T;
    elperpage: number;
    ChangePage(first: number): void;//this method change page data 
    onChangePage(n:number):void   //event from component
}