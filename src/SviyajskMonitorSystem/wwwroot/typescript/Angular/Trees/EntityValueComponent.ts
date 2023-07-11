

import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector: 'entityvalue',
    templateUrl:''
})

export class EntityValueComponent {
    @Input() key: string;
    @Input() currentvalue: EnVal;
    @Input() values: EnVal[];

    @Output() OnValueChanged = new EventEmitter<EnVal>();

    ChangeValue(id: number) {
        this.currentvalue = this.values.find(v => v.id == id);
        this.OnValueChanged.emit(this.currentvalue);
    }

}

export class EnVal {
    id: number;
    value: string;
}