export class Dictionary<K, T>{
    elements: DictionaryElement<K, T>[] = [];

    SetElement(k: K, v: T) {
        let el = new DictionaryElement<K, T>(k, v);
        this.elements.push(el);

    }

    GetElement(key: K): T {
        let el: DictionaryElement<K, T> = this.elements.find(el => el.key == key);
        return el.value;
    }

    HasElement(key: K): boolean {
        let el: DictionaryElement<K, T>[] = this.elements.filter(el => el.key == key);
        if (el.length>0) {
            return true;
        } else {
            return false;
        }
    }

    RemoveEleemnt(key: K) {
        let el = this.elements.findIndex(el => el.key == key);
        this.elements.splice(el);
    }

}

class DictionaryElement<K, T>{
    key: K;
    value: T;
    constructor(key: K, value: T) {
        this.key = key;
        this.value = value;
    }
}