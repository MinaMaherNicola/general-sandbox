function Logger(constructor: Function) {
	console.log('Logging...');
	console.log(constructor);
}

function DecoratorFactory(logString: string) {
	console.log(logString);
	return function (constructor: Function) {
		console.log('Logging...');
		console.log(constructor);
	};
}

@DecoratorFactory('Logging Person!')
class Person {
	name: string = 'Max';

	constructor() {
		console.log('Creating person object....');
	}
}

const pers = new Person();

console.log(pers);

function Log(target: any, propertyName: string | symbol) {
	console.log('Property Decorator!');
	console.log(target, propertyName);
}

function Log2(target: any, name: string, descriptor: PropertyDescriptor) {
	console.log('Accessor decorator!');
	console.log(target);
	console.log(name);
	console.log(descriptor);
}

function Log3(target: any, name: string | symbol, descriptor: PropertyDescriptor) {
	console.log('Method decorator!');
	console.log(target);
	console.log(name);
	console.log(descriptor);
}

function Log4(target: any, name: string | symbol, position: number) {
	console.log('Parameter decorator!');
	console.log(target);
	console.log(name);
	console.log(position);
}

class Product {
	@Log
	title: string;
	private _price: number;

	@Log2
	set setPrice(value: number) {
		this._price = value;
	}

	constructor(t: string, p: number) {
		this.title = t;
		this._price = p;
	}

	@Log3
	getPriceWithTax(tax: number): number {
		return this._price + tax;
	}
}
