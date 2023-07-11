"use strict";
exports.__esModule = true;
var Dictionary = (function () {
    function Dictionary() {
        this.elements = [];
    }
    Dictionary.prototype.SetElement = function (k, v) {
        var el = new DictionaryElement(k, v);
        this.elements.push(el);
    };
    Dictionary.prototype.GetElement = function (key) {
        var el = this.elements.find(function (el) { return el.key == key; });
        return el.value;
    };
    Dictionary.prototype.HasElement = function (key) {
        var el = this.elements.filter(function (el) { return el.key == key; });
        if (el.length > 0) {
            return true;
        }
        else {
            return false;
        }
    };
    Dictionary.prototype.RemoveEleemnt = function (key) {
        var el = this.elements.findIndex(function (el) { return el.key == key; });
        this.elements.splice(el);
    };
    return Dictionary;
}());
exports.Dictionary = Dictionary;
var DictionaryElement = (function () {
    function DictionaryElement(key, value) {
        this.key = key;
        this.value = value;
    }
    return DictionaryElement;
}());
