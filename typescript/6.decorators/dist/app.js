"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
function Logger(constructor) {
    console.log('Logging...');
    console.log(constructor);
}
function DecoratorFactory(logString) {
    console.log(logString);
    return function (constructor) {
        console.log('Logging...');
        console.log(constructor);
    };
}
let Person = class Person {
    constructor() {
        this.name = 'Max';
        console.log('Creating person object....');
    }
};
Person = __decorate([
    DecoratorFactory('Logging Person!')
], Person);
const pers = new Person();
console.log(pers);
function Log(target, propertyName) {
    console.log('Property Decorator!');
    console.log(target, propertyName);
}
function Log2(target, name, descriptor) {
    console.log('Accessor decorator!');
    console.log(target);
    console.log(name);
    console.log(descriptor);
}
function Log3(target, name, descriptor) {
    console.log('Method decorator!');
    console.log(target);
    console.log(name);
    console.log(descriptor);
}
function Log4(target, name, position) {
    console.log('Parameter decorator!');
    console.log(target);
    console.log(name);
    console.log(position);
}
class Product {
    set setPrice(value) {
        this._price = value;
    }
    constructor(t, p) {
        this.title = t;
        this._price = p;
    }
    getPriceWithTax(tax) {
        return this._price + tax;
    }
}
__decorate([
    Log
], Product.prototype, "title", void 0);
__decorate([
    Log2
], Product.prototype, "setPrice", null);
__decorate([
    Log3
], Product.prototype, "getPriceWithTax", null);
